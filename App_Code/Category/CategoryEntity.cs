using System;

namespace BIC.Entity
{
	/// <summary>
    /// Business entity for Category
    /// </summary>
	public class CategoryEntity
	{
		#region Attributes
			public const string  FIELD_CATEGORYID = "CategoryID";
			public const string  FIELD_NAME = "Name";
			public const string  FIELD_VALUE = "Value";
			public const string  FIELD_NOTE = "Note";
			public const string  FIELD_TYPEOFCATEGORY = "TypeOfCategory";
			public const string  FIELD_PRIORITY = "Priority";
			public const string  FIELD_ISACTIVE = "IsActive";
		#endregion

		#region Contructors
		public CategoryEntity() { }
		
		public CategoryEntity(int _CategoryID, string _Name, string _Value, string _Note, int _TypeOfCategory, int _Priority, bool _IsActive)
		{
			CategoryID = _CategoryID;
			Name = _Name;
			Value = _Value;
			Note = _Note;
			TypeOfCategory = _TypeOfCategory;
			Priority = _Priority;
			IsActive = _IsActive;
		}
		#endregion
		
		#region CategoryID
		private int _CategoryID = 0;
		/// <summary>
		/// Gets or sets CategoryID
		/// </summary>
		public int CategoryID
		{
			get
			{
				return _CategoryID;
			}
			set
			{
				_CategoryID = value;
			}
		}
		#endregion

		#region Name
		private string _Name = String.Empty;
		/// <summary>
		/// Gets or sets Name
		/// </summary>
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}
		#endregion

		#region Value
		private string _Value = String.Empty;
		/// <summary>
		/// Gets or sets Value
		/// </summary>
		public string Value
		{
			get
			{
				return _Value;
			}
			set
			{
				_Value = value;
			}
		}
		#endregion

		#region Note
		private string _Note = String.Empty;
		/// <summary>
		/// Gets or sets Note
		/// </summary>
		public string Note
		{
			get
			{
				return _Note;
			}
			set
			{
				_Note = value;
			}
		}
		#endregion

		#region TypeOfCategory
		private int _TypeOfCategory = 0;
		/// <summary>
		/// Gets or sets TypeOfCategory
		/// </summary>
		public int TypeOfCategory
		{
			get
			{
				return _TypeOfCategory;
			}
			set
			{
				_TypeOfCategory = value;
			}
		}
		#endregion

		#region Priority
		private int _Priority = 0;
		/// <summary>
		/// Gets or sets Priority
		/// </summary>
		public int Priority
		{
			get
			{
				return _Priority;
			}
			set
			{
				_Priority = value;
			}
		}
		#endregion

		#region IsActive
		private bool _IsActive = false;
		/// <summary>
		/// Gets or sets IsActive
		/// </summary>
		public bool IsActive
		{
			get
			{
				return _IsActive;
			}
			set
			{
				_IsActive = value;
			}
		}
		#endregion

	}
}

