namespace BIC.DAO
{
    using BIC.Entity;
    using BIC.Handler;
    using BIC.Utils;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class SearchDAO : SearchProvider
    {
        private const string DELETE_SEARCH = "[dbo].SearchDelete";
        private const string INSERT_SEARCH = "[dbo].SearchInsert";
        private const string SEARCHBYKEYWORD = "[dbo].SearchByKeyWord";
        private const string SEARCHBYKEYWORDLANG = "[dbo].SearchByKeyWordLang";
        private const string SEARCHTOPBYKEYWORD = "[dbo].SearchTopByKeyword";
        private const string SEARCHTOPBYKEYWORDLANG = "[dbo].SearchTopByKeywordLang";
        private const string SELECT_ALL_SEARCH = "[dbo].SearchesGetAll";
        private const string SELECT_SEARCH_BYID = "[dbo].SearchGetByID";
        private const string UPDATE_SEARCH = "[dbo].SearchUpdate";

        public override bool DeleteSearch(int _SearchID)
        {
            bool flag;
            try
            {
                using (SqlConnection connection = new SqlConnection(BicWebConfig.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].SearchDelete", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SearchID", SqlDbType.Int).Value = _SearchID;
                    connection.Open();
                    int num = DataAccess.ExecuteNonQuery(cmd);
                    connection.Close();
                    flag = num == 1;
                }
            }
            catch (Exception exception)
            {
                LogEvent.LogToFile(exception.ToString());
                flag = false;
            }
            return flag;
        }

        public override List<SearchEntity> GetAllSearchs()
        {
            List<SearchEntity> searchCollectionFromReader = null;
            using (SqlConnection connection = new SqlConnection(BicWebConfig.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("[dbo].SearchesGetAll", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                searchCollectionFromReader = this.GetSearchCollectionFromReader(DataAccess.ExecuteReader(cmd));
                connection.Close();
            }
            return searchCollectionFromReader;
        }

        public override SearchEntity GetSearchByID(int _SearchID)
        {
            SearchEntity searchFromReader = null;
            using (SqlConnection connection = new SqlConnection(BicWebConfig.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("[dbo].SearchGetByID", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SearchID", SqlDbType.Int).Value = _SearchID;
                connection.Open();
                IDataReader reader = DataAccess.ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    searchFromReader = this.GetSearchFromReader(reader);
                }
                connection.Close();
            }
            return searchFromReader;
        }

        private List<SearchEntity> GetSearchCollectionFromReader(IDataReader reader)
        {
            List<SearchEntity> list = new List<SearchEntity>();
            while (reader.Read())
            {
                list.Add(this.GetSearchFromReader(reader));
            }
            return list;
        }

        private SearchEntity GetSearchFromReader(IDataReader reader)
        {
            return new SearchEntity(BicConvert.ToInt32(reader["SearchID"]), reader["LanguageKey"].ToString().Trim(), reader["Description"].ToString().Trim(), reader["Keyword"].ToString().Trim(), BicConvert.ToInt32(reader["ImageID"]), reader["Link"].ToString().Trim(), BicConvert.ToInt32(reader["Priority"]), BicConvert.ToBoolean(reader["IsActive"]), reader["DienThoai"].ToString().Trim());
        }

        public override bool InsertSearch(SearchEntity entity)
        {
            bool flag;
            try
            {
                using (SqlConnection connection = new SqlConnection(BicWebConfig.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].SearchInsert", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = entity.Description;
                    cmd.Parameters.Add("@DienThoai", SqlDbType.NVarChar).Value = entity.DienThoai;
                    cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = entity.Keyword;
                    cmd.Parameters.Add("@LanguageKey", SqlDbType.NVarChar).Value = entity.LanguageKey;
                    cmd.Parameters.Add("@ImageID", SqlDbType.Int).Value = entity.ImageID;
                    cmd.Parameters.Add("@Link", SqlDbType.NVarChar).Value = entity.Link;
                    cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = entity.Priority;
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                    cmd.Parameters.Add("@SearchID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    connection.Open();
                    int num = DataAccess.ExecuteNonQuery(cmd);
                    entity.SearchID = (int) cmd.Parameters["@SearchID"].Value;
                    connection.Close();
                    flag = num == 1;
                }
            }
            catch (Exception exception)
            {
                LogEvent.LogToFile(exception.ToString());
                flag = false;
            }
            return flag;
        }

        public override List<SearchEntity> SearchByKeyWord(object keyword)
        {
            List<SearchEntity> searchCollectionFromReader = null;
            using (SqlConnection connection = new SqlConnection(BicWebConfig.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("[dbo].SearchByKeyWord", connection);
                cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = keyword;
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                searchCollectionFromReader = this.GetSearchCollectionFromReader(DataAccess.ExecuteReader(cmd));
                connection.Close();
            }
            return searchCollectionFromReader;
        }

        public override List<SearchEntity> SearchByKeyWord(object keyword, object N)
        {
            List<SearchEntity> searchCollectionFromReader = null;
            using (SqlConnection connection = new SqlConnection(BicWebConfig.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("[dbo].SearchTopByKeyword", connection);
                cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = keyword;
                cmd.Parameters.Add("@N", SqlDbType.NVarChar).Value = N;
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                searchCollectionFromReader = this.GetSearchCollectionFromReader(DataAccess.ExecuteReader(cmd));
                connection.Close();
            }
            return searchCollectionFromReader;
        }

        public override List<SearchEntity> SearchByKeyWord(object keyword, object N, object LanguageKey)
        {
            List<SearchEntity> searchCollectionFromReader = null;
            using (SqlConnection connection = new SqlConnection(BicWebConfig.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("[dbo].SearchTopByKeywordLang", connection);
                cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = keyword;
                cmd.Parameters.Add("@N", SqlDbType.NVarChar).Value = N;
                cmd.Parameters.Add("@LanguageKey", SqlDbType.NVarChar).Value = LanguageKey;
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                searchCollectionFromReader = this.GetSearchCollectionFromReader(DataAccess.ExecuteReader(cmd));
                connection.Close();
            }
            return searchCollectionFromReader;
        }

        public override bool UpdateSearch(SearchEntity entity)
        {
            bool flag;
            try
            {
                using (SqlConnection connection = new SqlConnection(BicWebConfig.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].SearchUpdate", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SearchID", SqlDbType.Int).Value = entity.SearchID;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = entity.Description;
                    cmd.Parameters.Add("@LanguageKey", SqlDbType.NVarChar).Value = entity.LanguageKey;
                    cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = entity.Keyword;
                    cmd.Parameters.Add("@ImageID", SqlDbType.Int).Value = entity.ImageID;
                    cmd.Parameters.Add("@Link", SqlDbType.NVarChar).Value = entity.Link;
                    cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = entity.Priority;
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                    cmd.Parameters.Add("@DienThoai", SqlDbType.NVarChar).Value = entity.DienThoai;
                    connection.Open();
                    int num = DataAccess.ExecuteNonQuery(cmd);
                    connection.Close();
                    flag = num == 1;
                }
            }
            catch (Exception exception)
            {
                LogEvent.LogToFile(exception.ToString());
                flag = false;
            }
            return flag;
        }
    }
}

