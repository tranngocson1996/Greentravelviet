using System;

namespace BIC.Entity
{
    /// <summary>
    /// Business entity for Category
    /// </summary>
    public class CommentEntity
    {
        #region Attributes

        public const string FIELD_COMMENTID = "CommentID";
        public const string FIELD_TITLE = "Title";
        public const string FIELD_ID = "ID";
        public const string FIELD_TYPEOFCOMMENT = "TypeOfComment";
        public const string FIELD_CREATEDATE = "CreateDate";
        public const string FIELD_ADDRESS = "Address";
        public const string FIELD_FULLNAME = "FullName";
        public const string FIELD_EMAIL = "Email";
        public const string FIELD_DESCRIPTION = "Description";
        public const string FIELD_PRIORITY = "Priority";
        public const string FIELD_ISACTIVE = "IsActive";
        public const string FIELD_MODIFIEDDATE = "ModifiedDate";
        public const string FIELD_DONGY = "DongY";
        public const string FIELD_KHONGDONGY = "KhongDongY";
        public const string FIELD_PARENT = "Parent";
        public const string FIELD_GIOITINH = "GioiTinh";
        public const string FIELD_ISHOT = "IsHot";
        public const string FIELD_TEMPPASS = "TempPass";
        public const string FIELD_LANGUAGEKEY = "LanguageKey";

        #endregion Attributes

        #region Contructors

        public CommentEntity()
        {
        }

        public CommentEntity(int _CommentID, string _Title, int _ID, string _TypeOfComment, DateTime _CreateDate, string _Address, string _FullName, string _Email, string _Description, int _Priority, bool _IsActive, DateTime _ModifiedDate, int _DongY, int _KhongDongY, int _Parent, bool _GioiTinh, bool _isHot, string _tempPass, string _languageKey)
        {
            CommentID = _CommentID;
            Title = _Title;
            Id = _ID;
            TypeOfComment = _TypeOfComment;
            CreateDate = _CreateDate;
            Address = _Address;
            FullName = _FullName;
            Email = _Email;
            Description = _Description;
            Priority = _Priority;
            IsActive = _IsActive;
            ModifiedDate = _ModifiedDate;
            DongY = _DongY;
            KhongDongY = _KhongDongY;
            Parent = _Parent;
            GioiTinh = _GioiTinh;
            IsHot = _isHot;
            TempPass = _tempPass;
            LanguageKey = _languageKey;
        }

        #endregion Contructors

        #region CommentID

        /// <summary>
        /// Gets or sets CommentID
        /// </summary>
        public int CommentID { get; set; }

        #endregion CommentID

        #region Title

        private string _Title = String.Empty;

        /// <summary>
        /// Gets or sets Title
        /// </summary>
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        #endregion Title

        #region Id

        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }

        #endregion Id

        #region TypeOfComment

        private string _TypeOfComment = String.Empty;

        /// <summary>
        /// Gets or sets TypeOfComment
        /// </summary>
        public string TypeOfComment
        {
            get { return _TypeOfComment; }
            set { _TypeOfComment = value; }
        }

        #endregion TypeOfComment

        #region CreateDate

        private DateTime _CreateDate = DateTime.MinValue;

        /// <summary>
        /// Gets or sets CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }

        #endregion CreateDate

        #region Address

        private string _Address = String.Empty;

        /// <summary>
        /// Gets or sets Address
        /// </summary>
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        #endregion Address

        #region FullName

        private string _FullName = String.Empty;

        /// <summary>
        /// Gets or sets FullName
        /// </summary>
        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }

        #endregion FullName

        #region Email

        private string _Email = String.Empty;

        /// <summary>
        /// Gets or sets Email
        /// </summary>
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        #endregion Email

        #region Description

        private string _Description = String.Empty;

        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        #endregion Description

        #region Priority

        /// <summary>
        /// Gets or sets Priority
        /// </summary>
        public int Priority { get; set; }

        #endregion Priority

        #region DongY

        /// <summary>
        /// Gets or sets DongY
        /// </summary>
        public int DongY { get; set; }

        #endregion DongY

        #region KhongDongY

        /// <summary>
        /// Gets or sets KhongDongY
        /// </summary>
        public int KhongDongY { get; set; }

        #endregion KhongDongY

        #region Parent

        /// <summary>
        /// Gets or sets Parent
        /// </summary>
        public int Parent { get; set; }

        #endregion Parent

        #region IsActive

        /// <summary>
        /// Gets or sets IsActive
        /// </summary>
        public bool IsActive { get; set; }

        #endregion IsActive

        #region GioiTinh

        /// <summary>
        /// Gets or sets GioiTinh
        /// </summary>
        public bool GioiTinh { get; set; }

        #endregion GioiTinh

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

        #endregion ModifiedDate

        #region IsHot

        public bool IsHot { get; set; }

        #endregion

        #region TempPass

        private string _TempPass = string.Empty;

        public string TempPass
        {
            get { return _TempPass; }
            set { _TempPass = value; }
        }

        #endregion

        #region LanguageKey

        private string _language = string.Empty;

        public string LanguageKey
        {
            get { return _language; }
            set { _language = value; }
        }

        #endregion

    }
}