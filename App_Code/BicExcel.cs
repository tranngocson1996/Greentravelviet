using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace BIC.Utils.BicExcel
{
    public class ExcelBase : Component, IDisposable
    {
        #region Constructors

        public ExcelBase()
        {
            UseFinalizer = false;
        }

        public ExcelBase(string workBook)
            : this()
        {
            this.WorkBook = workBook;
        }

        #endregion Constructors

        #region Workbook/range settings

        /// <summary>
        /// The Range which to query. This can be any Excel range (eg "A1:B5") or
        /// just a worksheet name.
        /// If this value is null, the first sheet of the <see cref="WorkBook"/> is used
        /// </summary>
        private string _range;

        private string _workbook;
        private int _worksheetindex;

        /// <summary>
        /// The workbook (file) name to query
        /// </summary>
        [DefaultValue(null)]
        public string WorkBook
        {
            get { return _workbook; }
            set
            {
                CloseConnection();
                _workbook = value;
                _determinedrange = null;
            }
        }

        [DefaultValue(null)]
        public string Range
        {
            get { return _range; }
            set
            {
                _range = value;
                _determinedrange = null;
            }
        }

        /// <summary>
        /// The 0 based INDEX of the worksheet to query.
        /// If you want to set the name of the worksheet, use <see cref="Range"/> instead.
        /// NB: if <see cref="Range"/> is set, this property is ignored
        /// </summary>
        [DefaultValue(0)]
        public int WorkSheetIndex
        {
            get { return _worksheetindex; }
            set
            {
                _worksheetindex = value;
                _determinedrange = null;
            }
        }

        /// <summary>
        /// Checks if the <see cref="WorkBook"/> exists
        /// </summary>
        public bool WorkBookExists
        {
            get { return File.Exists(WorkBook); }
        }

        #region Range formatting

        /// <summary>
        /// If a range was determined in a previous step, keep it buffered here
        /// </summary>
        private string _determinedrange;

        /// <summary>
        /// Gets the properly formatted sheet name
        /// if no worksheet was provided, read out sheet information and select everything
        /// from the first sheet
        /// </summary>
        public string GetRange()
        {
            if (_determinedrange == null)
            {
                string range = Range;
                switch (range)
                {
                    case null:
                        range = DetermineRange();
                        break;
                }
                if (range.IndexOf(':') == -1 && !range.EndsWith("$"))
                    range += "$"; //sheetname has to be appended with a $
                _determinedrange = "[" + range + "]";
            }
            return _determinedrange;
        }

        /// <summary>
        /// See <see cref="AutoDetermineRange"/> property for more info
        /// </summary>
        /// <returns></returns>
        private string DetermineRange()
        {
            string sheet = GetSheetName(_worksheetindex);
            if (!_autodeterminerange) return sheet;
            return new RangeFinder(this, sheet).ToString();
        }

        #region RangeFinder

        private class RangeFinder
        {
            /// <summary>
            /// minimum percentage that needs to be filled to count as a datarow
            /// </summary>
            private const double MINFILLED = .75;

            /// <summary>
            /// The amount of subsequent (or preceding) rows that need to be filled a <see cref="MINFILLED"/> percentage
            /// for it to count as a datarow
            /// </summary>
            private const int CHECK_ROWS = 3;

            private readonly int _cols;

            private readonly DataTable _dtSchema;
            private readonly Import _eb;

            /// <summary>
            /// minimum amount of columns that need to be filled
            /// <seealso cref="MINFILLED"/>
            /// </summary>
            private readonly int _min;

            private bool _forward = true;
            private OleDbDataAdapter _da;
            private OleDbDataReader _indexReader;
            private DataTable _indexTable = new DataTable();
            private string _indexquery;
            private ExcelDataRange _rng;

            public RangeFinder(ExcelBase owner, string sheet)
            {
                _eb = new Import(owner.WorkBook) { Range = sheet, UseHeaders = false, InterMixedAsText = true };
                //DataTable dt = eb.Query();
                try
                {
                    _eb.OpenConnection();
                    //get the number of rows and columns
                    _da = new OleDbDataAdapter(
                        "select * from [" + sheet + "]", _eb.Connection);
                    _dtSchema = new DataTable();
                    _da.FillSchema(_dtSchema, SchemaType.Source);
                    _cols = _dtSchema.Columns.Count;
                    var rows = (int)ExecuteScalar("select count(*) from [" + sheet + "]");
                    //fill the range object
                    _rng.From.Row = _rng.From.Column = 1;
                    _rng.To.Row = rows;
                    _rng.To.Column = _cols;

                    _min = (int)(_cols * MINFILLED);
                    //now rng contains the complete square range of data containing cells
                    //try to narrow it by getting as much hits as possible
                    DecreaseRange();
                }
                finally
                {
                    _indexReader.Close();
                    _eb.CloseConnection();
                }
            }

            private object ExecuteScalar(string sql)
            {
                return new OleDbCommand(sql, _da.SelectCommand.Connection).ExecuteScalar();
            }

            private string GetIndexQuery()
            {
                if (_indexquery == null)
                {
                    var sql = new StringBuilder("select 0");

                    foreach (DataRow dr in _dtSchema.Rows)
                    {
                        string colname = "[" + dr["column_name"] + "]";
                        sql.Append("+iif(").Append(colname).Append(" is null,0,1)");
                    }
                    sql.Append(" as ind from ");
                    _indexquery = sql.ToString();
                }
                return _indexquery;
            }

            //ExcelDataRange indexRange;

            private int GetIndex()
            {
                if (!_forward)
                {
                    _indexReader.Close();
                    _indexReader = null;
                    _da.SelectCommand.CommandText = string.Format(" select * from {0}:{0}"
                                                                 , _rng.To.Row);
                }
                if (_indexReader == null)
                    _indexReader = _da.SelectCommand.ExecuteReader();
                int cnt = 0;
                if (!_indexReader.Read()) return -1;
                for (int i = 0; i < _indexReader.FieldCount; i++)
                {
                    if (!_indexReader.IsDBNull(i)) cnt++;
                }
                return cnt;
                _da.TableMappings.Clear();

                _da = new OleDbDataAdapter(_da.SelectCommand.CommandText, _eb._conn);
                _indexTable = new DataTable();
                //da.FillSchema(indexTable, SchemaType.Source);
                _da.Fill(_indexTable);
                return _indexTable.Columns.Count;
            }

            /// <summary>
            /// Decrease the range step by step
            /// The problem is that when obtaining all, a lot more nulls are returned
            /// than you would visibly see. That makes most algorithms to get the
            /// block useless.
            /// this is also why just obtaining the datatable complete and removing the
            /// rows will not suffice: the proper field data types will not have been set
            /// Best way I could figure without using interop was to increase the start
            /// range to see if the avarage filled values increase.
            /// </summary>
            private void DecreaseRange()
            {
                for (; ; )
                {
                    if (GetIndex() >= _min)
                    {
                        int i = 0;
                        for (; i < CHECK_ROWS; i++)
                        {
                            AlterRange(1);
                            if (GetIndex() < _min)
                            {
                                break;
                            }
                        }
                        if (i == CHECK_ROWS)
                        {
                            AlterRange(-i);
                            if (_forward)
                                _forward = false;
                            else
                                break;
                        }
                    }
                    if (_rng.From.Row > _rng.To.Row)
                        throw new Exception("Could not determine data range");
                    AlterRange(1);
                }
            }

            private void AlterRange(int i)
            {
                if (_forward)
                    _rng.From.Row += i;
                else
                    _rng.To.Row -= i;
            }

            public override string ToString()
            {
                return _rng.ToString();
            }

            #region Nested type: ExcelDataRange

            private struct ExcelDataRange
            {
                public ExcelRange
                    From, To;

                public override string ToString()
                {
                    return GetRange(From, To);
                }

                private static string GetRange(ExcelRange from, ExcelRange to)
                {
                    return from + ":" + to;
                }

                public string TopRow()
                {
                    return GetRange(From, new ExcelRange(To.Column, From.Row));
                }

                public string BottomRow()
                {
                    return GetRange(new ExcelRange(From.Column, To.Row), To);
                }
            }

            #endregion Nested type: ExcelDataRange

            #region Nested type: ExcelRange

            private struct ExcelRange
            {
                public int Column;
                public int Row;

                public ExcelRange(int col, int row)
                {
                    Column = col;
                    this.Row = row;
                }

                public override string ToString()
                {
                    //return string.Format("R{0}C{1}", Row, Column);
                    string res = Row.ToString();
                    int col = Column;
                    while (col > 0)
                    {
                        int cc = col % 26;
                        var c = (char)('A' + cc - 1);
                        res = c + res;
                        col /= 26;
                    }
                    return res;
                }
            }

            #endregion Nested type: ExcelRange
        }

        #endregion RangeFinder

        #endregion Range formatting

        /// <summary>
        /// Checks if the workbook exists and throws an exception if it doesn't
        /// <seealso cref="WorkBookExists"/>
        /// </summary>
        protected void CheckWorkbook()
        {
            if (!WorkBookExists) throw new FileNotFoundException("Workbook not found", WorkBook);
        }

        #endregion Workbook/range settings

        #region Connection

        private bool _autodeterminerange;
        private OleDbConnection _conn;
        private bool _imex;
        private int _opencount;
        private bool _useheaders = true;
        private bool _wasopenbeforerememberstate;

        /// <summary>
        /// Determines if the first row in the specified <see cref="Range"/> contains the headers
        /// </summary>
        [DefaultValue(true)]
        public bool UseHeaders
        {
            get { return _useheaders; }
            set
            {
                if (_useheaders != value)
                {
                    CloseConnection();
                    _useheaders = value;
                }
            }
        }

        /// <summary>
        /// if this value is <c>true</c>, 'intermixed' data columns are handled as text (otherwise Excel tries to make a calcuated guess on what the datatype should be)
        /// </summary>
        [DefaultValue(false)]
        public bool InterMixedAsText
        {
            get { return _imex; }
            set
            {
                if (_imex != value)
                {
                    CloseConnection();
                    _imex = value;
                }
            }
        }

        /// <summary>
        /// Tries to obtain the range automatically by looking for a large chunk of data. Use this value if there's a lot of
        /// static around the actual data.
        /// Beware though: this takes some additional steps and can cause performance loss
        /// when querying larger files.
        /// automatically determening the range is not fullproof. Be sure to check the results
        /// on first time use.
        /// NB: if the <see cref="Range"/> is set, this property is ignored.
        /// </summary>
        [DefaultValue(false)]
        public bool AutoDetermineRange
        {
            get { return _autodeterminerange; }
            set
            {
                if (_autodeterminerange != value)
                {
                    _autodeterminerange = value;
                    _determinedrange = null;
                }
            }
        }

        /// <summary>
        /// Gets a connection to the current <see cref="WorkBook"/>
        /// When called for the first time (or after changing the workbook)
        /// a new connection is created.
        /// To close the connection, preferred is the use of <see cref="CloseConnection"/>
        /// </summary>
        public OleDbConnection Connection
        {
            get
            {
                if (_conn == null)
                {
                    _conn = CreateConnection();
                    UseFinalizer = true;
                }
                return _conn;
            }
        }

        public bool ConnectionIsOpen
        {
            get { return _conn != null && _conn.State != ConnectionState.Closed; }
        }

        /// <summary>
        /// Creates &nbspa NEW connection. If this method is called directly, this
        /// class will not check if it is closed.
        /// To get a handled connection, use the <see cref="Connection"/> property.
        /// </summary>
        /// <returns></returns>
        public OleDbConnection CreateConnection()
        {
            CheckWorkbook();
            return new OleDbConnection(
                string.Format("Provider=Microsoft.Jet.OLEDB.4.0;" +
                              "Data Source={0};Extended Properties='Excel 8.0;HDR={1};Imex={2}'",
                              WorkBook, _useheaders ? "Yes" : "No",
                              _imex ? "1" : "0")
                );
        }

        /// <summary>
        /// Closes the connection (if open)
        /// </summary>
        public void CloseConnection()
        {
            if (_conn != null && ConnectionIsOpen)
                _conn.Dispose();
            _conn = null;
            UseFinalizer = false;
        }

        protected void CloseConnection(bool OnlyIfNoneOpen)
        {
            if (OnlyIfNoneOpen)
            {
                if (--_opencount > 0 || _wasopenbeforerememberstate) return;
            }
            CloseConnection();
        }

        /// <summary>
        /// Opens the <see cref="Connection"/>
        /// </summary>
        public void OpenConnection()
        {
            OpenConnection(false);
        }

        protected void OpenConnection(bool rememberState)
        {
            if (rememberState && _opencount++ == 0) _wasopenbeforerememberstate = ConnectionIsOpen;
            if (!ConnectionIsOpen)
                Connection.Open();
        }

        #endregion Connection

        private bool _usefinalizer;

        private bool UseFinalizer
        {
            get { return _usefinalizer; }
            set
            {
                if (_usefinalizer == value) return;
                _usefinalizer = value;
                if (value)
                    GC.ReRegisterForFinalize(this);
                else
                    GC.SuppressFinalize(this);
            }
        }

        #region Helper functions

        /// <summary>
        /// queries the connection for the sheetnames and returns them
        /// </summary>
        /// <returns></returns>
        public string[] GetSheetNames()
        {
            OpenConnection(true);
            try
            {
                // Read out sheet information
                DataTable dt = Connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("Could not get sheet names");
                }

                var res = new string[dt.Rows.Count];
                for (int i = 0; i < res.Length; i++)
                {
                    string name = dt.Rows[i]["TABLE_NAME"].ToString();

                    if (name[0] == '\'')
                    {
                        //numeric sheetnames get single quotes around them in the schema.
                        //remove them here
                        if (Regex.IsMatch(
                            name, @"^'\d\w+\$'$"))
                            name = name.Substring(1, name.Length - 2);
                    }
                    res[i] = name;
                }
                return res;
            }
            finally
            {
                CloseConnection(true);
            }
        }

        /// <summary>
        /// Gets the name of the first sheet
        /// (this is also the default range used, when no <see cref="Range"/> is specified)
        /// </summary>
        /// <returns></returns>
        public string GetFirstSheet()
        {
            return GetSheetName(0);
        }

        public string GetSheetName(int index)
        {
            string[] sheets = GetSheetNames();
            if (index < 0 || index >= sheets.Length)
                throw new IndexOutOfRangeException("No worksheet exists at the specified index");
            return sheets[index];
        }

        #endregion Helper functions

        #region IDisposable Members

        public void Dispose()
        {
            CloseConnection();
        }

        #endregion IDisposable Members

        ~ExcelBase()
        {
            Dispose();
        }
    }

    public class Import : ExcelBase
    {
        #region Static query procedures

        /// <summary>
        /// Imports the first worksheet of the specified file
        /// </summary>
        /// <param name="file"></param>
        public static DataTable Query(string file)
        {
            return Query(file, null);
        }

        /// <summary>
        /// Imports the specified sheet in the specified file
        /// </summary>
        /// <param name="file"></param>
        /// <param name="range">The worksheet or excel range to query</param>
        /// <returns></returns>
        public static DataTable Query(string file, string range)
        {
            return new Import(file, range).Query();
        }

        public static DataTable Select(string file, string sql)
        {
            var i = new Import(file) { SQL = sql };
            return i.Query();
        }

        #endregion Static query procedures

        #region Constructors

        public Import()
        {
        }

        public Import(string workBook)
            : base(workBook)
        {
        }

        public Import(string workBook, string range)
            : this(workBook)
        {
            this.Range = range;
        }

        #endregion Constructors

        #region SQL Query

        public string SQL;

        private string _fields = "*";

        private string _where;

        /// <summary>
        /// The fields which should be returned (default all fields with data: "*")
        /// </summary>
        [DefaultValue("*")]
        public string Fields
        {
            get { return _fields; }
            set { _fields = value; }
        }

        /// <summary>
        /// An optional where clause. Works pretty much the same as 'normal' SQL. (Default=null)
        /// </summary>
        [DefaultValue(null)]
        public string Where
        {
            get { return _where; }
            set { _where = value; }
        }

        private void ResetFields()
        {
            _fields = "*";
        }

        protected string GetSelectSQL()
        {
            if (SQL != null) return SQL;
            // if no sql was provided, construct from worksheet and where
            string sql = string.Format("select {0} from {1}", _fields, GetRange());
            if (_where != null)
                sql += " WHERE " + _where;
            return sql;
        }

        /// <summary>
        /// Performs the query with the specifed settings
        /// </summary>
        /// <returns></returns>
        public DataTable Query()
        {
            return Query((DataTable)null);
        }

        /// <summary>
        /// Same as <see cref="Query()"/>, but an existing datatable is used and filled
        /// (it will be your own responsibility to format the datatable correctly)
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable Query(DataTable dt)
        {
            CheckWorkbook();
            try
            {
                OpenConnection(true);
                if (dt == null)
                    dt = new DataTable();
                new OleDbDataAdapter(GetSelectSQL(), Connection).Fill(dt);
                return dt;
            }
            finally
            {
                CloseConnection(true);
            }
        }

        /// <summary>
        /// Fills the datatable with the results of the query
        /// (wrapper around <see cref="Query(DataTable)"/>)
        /// </summary>
        /// <param name="dt"></param>
        public void Fill(DataTable dt)
        {
            Query(dt);
        }

        #endregion SQL Query
    }

    public class Export
    {
        #region Export proceducres

        /// <summary>
        ///  ExportToSpreadsheet(DataTable, FileName);
        /// </summary>
        public static void ExportToSpreadsheet(DataTable table, string name)
        {
            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            foreach (DataColumn column in table.Columns)
            {
                context.Response.Write(column.ColumnName + ";");
            }
            context.Response.Write(Environment.NewLine);
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    context.Response.Write(row[i].ToString().Replace(";", string.Empty) + ";");
                }
                context.Response.Write(Environment.NewLine);
            }
            context.Response.ContentType = "application/vnd.ms-excel";
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + name + ".xls");
            context.Response.End();
        }

        #endregion Export proceducres

        //'Choose one of these: as the contentType
        //'Excel 2003 : "application/vnd.ms-excel"-xls
        //'Excel 2007 : "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" -xlsx
    }
}