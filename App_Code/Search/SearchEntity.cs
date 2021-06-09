namespace BIC.Entity
{
    using System;

    public class SearchEntity
    {
        private string _Description;
        private string _DienThoai;
        private int _ImageID;
        private bool _IsActive;
        private string _Keyword;
        private string _LanguageKey;
        private string _Link;
        private int _Priority;
        private int _SearchID;
        public const string FIELD_DESCRIPTION = "Description";
        public const string FIELD_DIENTHOAI = "DienThoai";
        public const string FIELD_IMAGEID = "ImageID";
        public const string FIELD_ISACTIVE = "IsActive";
        public const string FIELD_KEYWORD = "Keyword";
        public const string FIELD_LINK = "Link";
        public const string FIELD_PRIORITY = "Priority";
        public const string FIELD_SEARCHID = "SearchID";

        public SearchEntity()
        {
            this._SearchID = 0;
            this._Description = string.Empty;
            this._DienThoai = string.Empty;
            this._Keyword = string.Empty;
            this._ImageID = 0;
            this._Link = string.Empty;
            this._LanguageKey = string.Empty;
            this._Priority = 0;
            this._IsActive = false;
        }

        public SearchEntity(int _SearchID, string _LanguageKey, string _Description, string _Keyword, int _ImageID, string _Link, int _Priority, bool _IsActive, string _DienThoai)
        {
            this._SearchID = 0;
            this._Description = string.Empty;
            this._DienThoai = string.Empty;
            this._Keyword = string.Empty;
            this._ImageID = 0;
            this._Link = string.Empty;
            this._LanguageKey = string.Empty;
            this._Priority = 0;
            this._IsActive = false;
            this.SearchID = _SearchID;
            this.Description = _Description;
            this.Keyword = _Keyword;
            this.ImageID = _ImageID;
            this.Link = _Link;
            this.Priority = _Priority;
            this.IsActive = _IsActive;
            this.LanguageKey = _LanguageKey;
            this.DienThoai = _DienThoai;
        }

        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }
        }

        public string DienThoai
        {
            get
            {
                return this._DienThoai;
            }
            set
            {
                this._DienThoai = value;
            }
        }

        public int ImageID
        {
            get
            {
                return this._ImageID;
            }
            set
            {
                this._ImageID = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return this._IsActive;
            }
            set
            {
                this._IsActive = value;
            }
        }

        public string Keyword
        {
            get
            {
                return this._Keyword;
            }
            set
            {
                this._Keyword = value;
            }
        }

        public string LanguageKey
        {
            get
            {
                return this._LanguageKey;
            }
            set
            {
                this._LanguageKey = value;
            }
        }

        public string Link
        {
            get
            {
                return this._Link;
            }
            set
            {
                this._Link = value;
            }
        }

        public int Priority
        {
            get
            {
                return this._Priority;
            }
            set
            {
                this._Priority = value;
            }
        }

        public int SearchID
        {
            get
            {
                return this._SearchID;
            }
            set
            {
                this._SearchID = value;
            }
        }
    }
}

