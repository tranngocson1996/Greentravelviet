using System;

namespace BIC.Entity
{
    /// <summary>
    /// Business entity for Category
    /// </summary>
    public class CityEntity
    {
        #region Attributes

        public const string FIELD_CITYID = "CityID";
        public const string FIELD_CITYNAME = "CityName";
        public const string FIELD_PRIORITY = "Priority";
        public const string FIELD_ISACTIVE = "IsActive";
        public const string FIELD_CHUYEN_NHANH = "ChuyenNhanh";
        public const string FIELD_CHUYEN_CHAM = "ChuyenCham";
        public const string FIELD_MIEN_PHI_NHANH = "MienPhiNhanh";
        public const string FIELD_MIEN_PHI_CHAM = "MienPhiCham";
        public const string FIELD_NEWCOLUMN1 = "NewColumn1";
        public const string FIELD_NEWCOLUMN2 = "NewColumn2";
        public const string FIELD_NEWCOLUMN3 = "NewCOlumn3";

        #endregion Attributes

        #region Contructors

        public CityEntity()
        {
        }

        public CityEntity(int _CityID, string _CityName, int _Priority, bool _IsActive, string _chuyenNhanh, string _chuyenCham, string _mienPhiNhanh, string _mienPhiCham, string _newColumn1, string _newColumn2, string _newColumn3)
        {
            CityID = _CityID;
            CityName = _CityName;
            Priority = _Priority;
            IsActive = _IsActive;
            ChuyenNhanh = _chuyenNhanh;
            ChuyenCham = _chuyenCham;
            MienPhiNhanh = _mienPhiNhanh;
            MienPhiCham = _mienPhiCham;
            NewColumn1 = _newColumn1;
            NewColumn2 = _newColumn2;
            NewColumn3 = _newColumn3;
        }

        #endregion Contructors

        #region CityID

        /// <summary>
        /// Gets or sets CityID
        /// </summary>
        public int CityID { get; set; }

        #endregion CityID

        #region CityName

        private string _CityName = String.Empty;

        /// <summary>
        /// Gets or sets CityName
        /// </summary>
        public string CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }

        #endregion CityName

        #region Priority

        /// <summary>
        /// Gets or sets Priority
        /// </summary>
        public int Priority { get; set; }

        #endregion Priority

        #region IsActive

        /// <summary>
        /// Gets or sets IsActive
        /// </summary>
        public bool IsActive { get; set; }

        #endregion IsActive

        #region ChuyenNhanh

        private string _chuyenNhanh = string.Empty;
        public string ChuyenNhanh
        {
            get { return _chuyenNhanh; }
            set { _chuyenNhanh = value; }
        }


        #endregion

        #region ChuyenCham

        private string _chuyenCham = string.Empty;
        public string ChuyenCham
        {
            get { return _chuyenCham; }
            set { _chuyenCham = value; }
        }

        #endregion

        #region MienPhiNhanh

        private string _mienPhiNhanh = string.Empty;
        public string MienPhiNhanh
        {
            get { return _mienPhiNhanh; }
            set { _mienPhiNhanh = value; }
        }

        #endregion

        #region MienPhiCham

        private string _mienPhiCham = string.Empty;
        public string MienPhiCham
        {
            get { return _mienPhiCham; }
            set { _mienPhiCham = value; }
        }

        #endregion

        #region NewColumn1

        private string _newColumn1 = string.Empty;

        public string NewColumn1
        {
            get { return _newColumn1; }
            set { _newColumn1 = value; }
        }

        #endregion

        #region NewColumn2
        private string _newColumn2 = string.Empty;
        public string NewColumn2
        {
            get { return _newColumn2; }
            set { _newColumn2 = value; }
        }

        #endregion

        #region NewCloumn3
        private string _newColumn3 = string.Empty;
        public string NewColumn3
        {
            get { return _newColumn3; }
            set { _newColumn3 = value; }
        }

        #endregion

    }
}