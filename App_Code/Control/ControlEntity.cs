using System;

namespace BIC.Entity
{
    /// <summary>
    /// Business entity for Category
    /// </summary>
    public class ControlEntity
    {
        #region Attributes

        public const string FIELD_CONTROLID = "ControlID";
        public const string FIELD_CONTROLNAME = "ControlName";
        public const string FIELD_FOLDERNAME = "FolderName";
        public const string FIELD_CONTROLURL = "ControlUrl";
        public const string FIELD_LOADURL = "LoadUrl";
        public const string FIELD_PRIORITY = "Priority";
        public const string FIELD_ISACTIVE = "IsActive";

        #endregion

        #region Contructors

        public ControlEntity()
        {
        }

        public ControlEntity(int _ControlID, string _ControlName, string _FolderName, string _ControlUrl, bool _LoadUrl,
                             int _Priority, bool _IsActive)
        {
            ControlID = _ControlID;
            ControlName = _ControlName;
            FolderName = _FolderName;
            ControlUrl = _ControlUrl;
            LoadUrl = _LoadUrl;
            Priority = _Priority;
            IsActive = _IsActive;
        }

        #endregion

        #region ControlID

        /// <summary>
        /// Gets or sets ControlID
        /// </summary>
        public int ControlID { get; set; }

        #endregion

        #region ControlName

        private string _ControlName = String.Empty;

        /// <summary>
        /// Gets or sets ControlName
        /// </summary>
        public string ControlName
        {
            get { return _ControlName; }
            set { _ControlName = value; }
        }

        #endregion

        #region FolderName

        private string _FolderName = String.Empty;

        /// <summary>
        /// Gets or sets FolderName
        /// </summary>
        public string FolderName
        {
            get { return _FolderName; }
            set { _FolderName = value; }
        }

        #endregion

        #region ControlUrl

        private string _ControlUrl = String.Empty;

        /// <summary>
        /// Gets or sets ControlUrl
        /// </summary>
        public string ControlUrl
        {
            get { return _ControlUrl; }
            set { _ControlUrl = value; }
        }

        #endregion

        #region LoadUrl

        /// <summary>
        /// Gets or sets LoadUrl
        /// </summary>
        public bool LoadUrl { get; set; }

        #endregion

        #region Priority

        /// <summary>
        /// Gets or sets Priority
        /// </summary>
        public int Priority { get; set; }

        #endregion

        #region IsActive

        /// <summary>
        /// Gets or sets IsActive
        /// </summary>
        public bool IsActive { get; set; }

        #endregion
    }
}