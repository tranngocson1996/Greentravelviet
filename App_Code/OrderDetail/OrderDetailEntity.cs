using System;

namespace BIC.Entity
{
	/// <summary>
    /// Business entity for Category
    /// </summary>
	public class OrderDetailEntity
	{
		#region Attributes
			public const string  FIELD_ORDERDETAILID = "OrderDetailID";
			public const string  FIELD_ORDERMENUID = "OrderMenuID";
			public const string  FIELD_PRODUCTNAME = "ProductName";
			public const string  FIELD_PRODUCTID = "ProductID";
			public const string  FIELD_PRODUCTCODE = "ProductCode";
			public const string  FIELD_PRODUCTPRICE = "ProductPrice";
			public const string  FIELD_DISCOUNT = "Discount";
			public const string  FIELD_SUBTOTAL = "SubTotal";
			public const string  FIELD_TOTAL = "Total";
			public const string  FIELD_TAX = "Tax";
			public const string  FIELD_PRIORITY = "Priority";
			public const string  FIELD_ISACTIVE = "IsActive";
		#endregion
		#region Contructors
		public OrderDetailEntity() { }
		
		public OrderDetailEntity(int _OrderDetailID, int _OrderMenuID, string _ProductName, int _ProductID, string _ProductCode, double _ProductPrice, double _Discount, double _SubTotal, double _Total, double _Tax, int _Priority, bool _IsActive)
		{
			OrderDetailID = _OrderDetailID;
			OrderMenuID = _OrderMenuID;
			ProductName = _ProductName;
			ProductID = _ProductID;
			ProductCode = _ProductCode;
			ProductPrice = _ProductPrice;
			Discount = _Discount;
			SubTotal = _SubTotal;
			Total = _Total;
			Tax = _Tax;
			Priority = _Priority;
			IsActive = _IsActive;
		}
		#endregion
		
		#region OrderDetailID
		private int _OrderDetailID = 0;
		/// <summary>
		/// Gets or sets OrderDetailID
		/// </summary>
		public int OrderDetailID
		{
			get
			{
				return _OrderDetailID;
			}
			set
			{
				_OrderDetailID = value;
			}
		}
		#endregion

		#region OrderMenuID
		private int _OrderMenuID = 0;
		/// <summary>
		/// Gets or sets OrderMenuID
		/// </summary>
		public int OrderMenuID
		{
			get
			{
				return _OrderMenuID;
			}
			set
			{
				_OrderMenuID = value;
			}
		}
		#endregion

		#region ProductName
		private string _ProductName = String.Empty;
		/// <summary>
		/// Gets or sets ProductName
		/// </summary>
		public string ProductName
		{
			get
			{
				return _ProductName;
			}
			set
			{
				_ProductName = value;
			}
		}
		#endregion

		#region ProductID
		private int _ProductID = 0;
		/// <summary>
		/// Gets or sets ProductID
		/// </summary>
		public int ProductID
		{
			get
			{
				return _ProductID;
			}
			set
			{
				_ProductID = value;
			}
		}
		#endregion

		#region ProductCode
		private string _ProductCode = String.Empty;
		/// <summary>
		/// Gets or sets ProductCode
		/// </summary>
		public string ProductCode
		{
			get
			{
				return _ProductCode;
			}
			set
			{
				_ProductCode = value;
			}
		}
		#endregion

		#region ProductPrice
		private double _ProductPrice = 0.0;
		/// <summary>
		/// Gets or sets ProductPrice
		/// </summary>
		public double ProductPrice
		{
			get
			{
				return _ProductPrice;
			}
			set
			{
				_ProductPrice = value;
			}
		}
		#endregion

		#region Discount
		private double _Discount = 0.0;
		/// <summary>
		/// Gets or sets Discount
		/// </summary>
		public double Discount
		{
			get
			{
				return _Discount;
			}
			set
			{
				_Discount = value;
			}
		}
		#endregion

		#region SubTotal
		private double _SubTotal = 0.0;
		/// <summary>
		/// Gets or sets SubTotal
		/// </summary>
		public double SubTotal
		{
			get
			{
				return _SubTotal;
			}
			set
			{
				_SubTotal = value;
			}
		}
		#endregion

		#region Total
		private double _Total = 0.0;
		/// <summary>
		/// Gets or sets Total
		/// </summary>
		public double Total
		{
			get
			{
				return _Total;
			}
			set
			{
				_Total = value;
			}
		}
		#endregion

		#region Tax
		private double _Tax = 0.0;
		/// <summary>
		/// Gets or sets Tax
		/// </summary>
		public double Tax
		{
			get
			{
				return _Tax;
			}
			set
			{
				_Tax = value;
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

