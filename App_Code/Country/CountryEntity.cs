using System;

namespace BIC.Entity
{
    /// <summary>
    /// Business entity for Category
    /// </summary>
    public class CountryEntity
    {
        #region Attributes

        public const string FIELD_COUNTRYID = "CountryId";
        public const string FIELD_COUNTRYNAME = "CountryName";
        public const string FIELD_PRIORITY = "Priority";
        public const string FIELD_ISACTIVE = "IsActive";

        #endregion Attributes

        #region Contructors

        public CountryEntity()
        {
        }

        public CountryEntity(int _CountryId, string _CountryName, int _Priority, bool _IsActive)
        {
            CountryId = _CountryId;
            CountryName = _CountryName;
            Priority = _Priority;
            IsActive = _IsActive;
        }

        #endregion Contructors

        #region CountryId

        /// <summary>
        /// Gets or sets CountryId
        /// </summary>
        public int CountryId { get; set; }

        #endregion CountryId

        #region CountryName

        private string _CountryName = String.Empty;

        /// <summary>
        /// Gets or sets CountryName
        /// </summary>
        public string CountryName
        {
            get { return _CountryName; }
            set { _CountryName = value; }
        }

        #endregion CountryName

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
    }
}