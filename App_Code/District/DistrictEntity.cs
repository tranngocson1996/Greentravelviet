using System;

namespace BIC.Entity
{
    /// <summary>
    /// Business entity for Category
    /// </summary>
    public class DistrictEntity
    {
        #region Attributes

        public const string FIELD_DISTRICTID = "DistrictID";
        public const string FIELD_CITYID = "CityID";
        public const string FIELD_DISTRICTNAME = "DistrictName";
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

        public DistrictEntity()
        {
        }

        public DistrictEntity(int _DistrictID, int _cityID, string _DistrictName, int _Priority, bool _IsActive, string _chuyenNhanh, string _chuyenCham, string _mienPhiNhanh, string _mienPhiCham, string _newColumn1, string _newColumn2, string _newColumn3)
        {
            DistrictID = _DistrictID;
            CityID = _cityID;
            DistrictName = _DistrictName;
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

        #region DistrictID

        /// <summary>
        /// Gets or sets DistrictID
        /// </summary>
        public int DistrictID { get; set; }

        #endregion DistrictID

        #region

        public int CityID { get; set; }

        #endregion

        #region DistrictName

        private string _DistrictName = String.Empty;

        /// <summary>
        /// Gets or sets DistrictName
        /// </summary>
        public string DistrictName
        {
            get { return _DistrictName; }
            set { _DistrictName = value; }
        }

        #endregion DistrictName

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