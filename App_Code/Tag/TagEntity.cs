using System;

namespace BIC.Entity
{
	/// <summary>
    /// Business entity for Category
    /// </summary>
	public class TagEntity
	{
		#region Attributes
			public const string  FIELD_TAGID = "TagID";
			public const string  FIELD_KEYWORD = "Keyword";
			public const string  FIELD_ID = "ID";
			public const string  FIELD_TYPEID = "TypeID";
			public const string  FIELD_PRIORITY = "Priority";
			public const string  FIELD_ISACTIVE = "IsActive";
		#endregion
		#region Contructors
		public TagEntity() { }
		
		public TagEntity(int _TagID, string _Keyword, string _ID, int _TypeID, int _Priority, bool _IsActive)
		{
			TagID = _TagID;
			Keyword = _Keyword;
			Id = _ID;
			TypeID = _TypeID;
			Priority = _Priority;
			IsActive = _IsActive;
		}
		#endregion
		
		#region TagID
		private int _TagID = 0;
		/// <summary>
		/// Gets or sets TagID
		/// </summary>
		public int TagID
		{
			get
			{
				return _TagID;
			}
			set
			{
				_TagID = value;
			}
		}
		#endregion

		#region Keyword
		private string _Keyword = String.Empty;
		/// <summary>
		/// Gets or sets Keyword
		/// </summary>
		public string Keyword
		{
			get
			{
				return _Keyword;
			}
			set
			{
				_Keyword = value;
			}
		}
		#endregion

		#region Id
		private string _Id = String.Empty;
		/// <summary>
		/// Gets or sets Id
		/// </summary>
		public string Id
		{
			get
			{
				return _Id;
			}
			set
			{
				_Id = value;
			}
		}
		#endregion

		#region TypeID
		private int _TypeID = 0;
		/// <summary>
		/// Gets or sets TypeID
		/// </summary>
		public int TypeID
		{
			get
			{
				return _TypeID;
			}
			set
			{
				_TypeID = value;
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

