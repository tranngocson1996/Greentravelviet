using System;

namespace BIC.Entity
{
    /// <summary>
    /// Business entity for Category
    /// </summary>
    public class DocumentEntity
    {
        #region Attributes

        public const string FIELD_DOCUMENTID = "DocumentID";
        public const string FIELD_BRIEFDESCRIPTION = "BriefDescription";
        public const string FIELD_DISPLAYNAME = "DisplayName";
        public const string FIELD_NAME = "Name";
        public const string FIELD_SIZE = "Size";
        public const string FIELD_EXT = "Ext";
        public const string FIELD_DOCUMENTTYPEID = "DocumentTypeID";
        public const string FIELD_CREATEDDATE = "CreatedDate";
        public const string FIELD_MODIFIEDDATE = "ModifiedDate";
        public const string FIELD_CREATEDBY = "CreatedBy";
        public const string FIELD_MODIFIEDBY = "ModifiedBy";
        public const string FIELD_VIEWNO = "ViewNo";
        public const string FIELD_ISNEW = "IsNew";
        public const string FIELD_PRIORITY = "Priority";
        public const string FIELD_ISACTIVE = "IsActive";
        public const string FIELD_DOCUMENTNO = "DocumentNo";
        public const string FIELD_USERNAMEVIEW = "UserNameView";
        public const string FIELD_USERNAMEEDIT = "UserNameEdit";

        #endregion

        #region Contructors

        public DocumentEntity()
        {
        }

        public DocumentEntity(int _DocumentID, string _BriefDescription, string _DisplayName, string _Name, int _Size,
                              string _Ext, int _DocumentTypeID, DateTime _CreatedDate, DateTime _ModifiedDate,
                              string _CreatedBy, string _ModifiedBy, int _ViewNo, bool _IsNew, int _Priority,
                              bool _IsActive, string _DocumentNo, string _UserNameView, string _UserNameEdit)
        {
            DocumentID = _DocumentID;
            BriefDescription = _BriefDescription;
            DisplayName = _DisplayName;
            Name = _Name;
            Size = _Size;
            Ext = _Ext;
            DocumentTypeID = _DocumentTypeID;
            CreatedDate = _CreatedDate;
            ModifiedDate = _ModifiedDate;
            CreatedBy = _CreatedBy;
            ModifiedBy = _ModifiedBy;
            ViewNo = _ViewNo;
            IsNew = _IsNew;
            Priority = _Priority;
            IsActive = _IsActive;
            DocumentNo = _DocumentNo;
            UserNameView = _UserNameView;
            UserNameEdit = _UserNameEdit;
        }

        #endregion

        #region DocumentID

        /// <summary>
        /// Gets or sets DocumentID
        /// </summary>
        public int DocumentID { get; set; }

        #endregion

        #region BriefDescription

        private string _BriefDescription = String.Empty;

        /// <summary>
        /// Gets or sets BriefDescription
        /// </summary>
        public string BriefDescription
        {
            get { return _BriefDescription; }
            set { _BriefDescription = value; }
        }

        #endregion

        #region DisplayName

        private string _DisplayName = String.Empty;

        /// <summary>
        /// Gets or sets DisplayName
        /// </summary>
        public string DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }

        #endregion

        #region Name

        private string _Name = String.Empty;

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        #endregion

        #region Size

        /// <summary>
        /// Gets or sets Size
        /// </summary>
        public int Size { get; set; }

        #endregion

        #region Ext

        private string _Ext = String.Empty;

        /// <summary>
        /// Gets or sets Ext
        /// </summary>
        public string Ext
        {
            get { return _Ext; }
            set { _Ext = value; }
        }

        #endregion

        #region DocumentTypeID

        /// <summary>
        /// Gets or sets DocumentTypeID
        /// </summary>
        public int DocumentTypeID { get; set; }

        #endregion

        #region CreatedDate

        private DateTime _CreatedDate = DateTime.MinValue;

        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }

        #endregion

        #region ModifiedDate

        private DateTime _ModifiedDate = DateTime.MinValue;

        /// <summary>
        /// Gets or sets ModifiedDate
        /// </summary>
        public DateTime ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }

        #endregion

        #region CreatedBy

        private string _CreatedBy = String.Empty;

        /// <summary>
        /// Gets or sets CreatedBy
        /// </summary>
        public string CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }

        #endregion

        #region ModifiedBy

        private string _ModifiedBy = String.Empty;

        /// <summary>
        /// Gets or sets ModifiedBy
        /// </summary>
        public string ModifiedBy
        {
            get { return _ModifiedBy; }
            set { _ModifiedBy = value; }
        }

        #endregion

        #region ViewNo

        /// <summary>
        /// Gets or sets ViewNo
        /// </summary>
        public int ViewNo { get; set; }

        #endregion

        #region IsNew

        /// <summary>
        /// Gets or sets IsNew
        /// </summary>
        public bool IsNew { get; set; }

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

        #region DocumentNo

        private string _DocumentNo = String.Empty;

        /// <summary>
        /// Gets or sets DocumentNo
        /// </summary>
        public string DocumentNo
        {
            get { return _DocumentNo; }
            set { _DocumentNo = value; }
        }

        #endregion

        #region UserNameView

        private string _UserNameView = String.Empty;

        /// <summary>
        /// Gets or sets UserNameView
        /// </summary>
        public string UserNameView
        {
            get { return _UserNameView; }
            set { _UserNameView = value; }
        }

        #endregion

        #region UserNameEdit

        private string _UserNameEdit = String.Empty;

        /// <summary>
        /// Gets or sets UserNameEdit
        /// </summary>
        public string UserNameEdit
        {
            get { return _UserNameEdit; }
            set { _UserNameEdit = value; }
        }

        #endregion
    }
}