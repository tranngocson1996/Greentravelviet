using System;

namespace BIC.Entity
{
    /// <summary>
    /// Business entity for Category
    /// </summary>
    public class OrderMenuEntity
    {
        #region Attributes
        public const string FIELD_ORDERMENUID = "OrderMenuID";
        public const string FIELD_ORDERCODE = "OrderCode";
        public const string FIELD_ORDERSTATUS = "OrderStatus";
        public const string FIELD_CUSTOMER = "Customer";
        public const string FIELD_ORDERSUBTOTAL = "OrderSubTotal";
        public const string FIELD_ORDERTAX = "OrderTax";
        public const string FIELD_ORDERDISCOUNT2 = "OrderDiscount2";
        public const string FIELD_ORDERDISCOUNT = "OrderDiscount";
        public const string FIELD_ORDERSHIPPINGFEE = "OrderShippingFee";
        public const string FIELD_CUSTOMERIP = "CustomerIp";
        public const string FIELD_PAYMENTMETHOD = "PaymentMethod";
        public const string FIELD_PAYMENTSTATUS = "PaymentStatus";
        public const string FIELD_DELIVERYSTAFF = "DeliveryStaff";
        public const string FIELD_SHIPPINGMETHOD = "ShippingMethod";
        public const string FIELD_SHIPPINGSTATUS = "ShippingStatus";
        public const string FIELD_SHIPPINGFULLNAME = "ShippingFullName";
        public const string FIELD_SHIPPINGEMAIL = "ShippingEmail";
        public const string FIELD_SHIPPINGPHONE = "ShippingPhone";
        public const string FIELD_SHIPPINGFAX = "ShippingFax";
        public const string FIELD_SHIPPINGCOMPANY = "ShippingCompany";
        public const string FIELD_SHIPPINGADDRESS = "ShippingAddress";
        public const string FIELD_SHIPPINGDATE = "ShippingDate";
        public const string FIELD_SHIPPINGDELIVEREDDATE = "ShippingDeliveredDate";
        public const string FIELD_SHIPPINGCITY = "ShippingCity";
        public const string FIELD_SHIPPINGSTATE = "ShippingState";
        public const string FIELD_SHIPPINGCOUNTRY = "ShippingCountry";
        public const string FIELD_BILLINGFULLNAME = "BillingFullName";
        public const string FIELD_BILLINGEMAIL = "BillingEmail";
        public const string FIELD_BILLINGPHONE = "BillingPhone";
        public const string FIELD_BILLINGFAX = "BillingFax";
        public const string FIELD_BILLINGCOMPANY = "BillingCompany";
        public const string FIELD_BILLINGSHIPPINGADDRESS = "BillingShippingAddress";
        public const string FIELD_BILLINGCITY = "BillingCity";
        public const string FIELD_BILLINGSTATE = "BillingState";
        public const string FIELD_BILLINGCOUNTRY = "BillingCountry";
        public const string FIELD_INVOICETAXCODE = "InvoiceTaxCode";
        public const string FIELD_INVOICEADDRESS = "InvoiceAddress";
        public const string FIELD_ORDERNOTE = "OrderNote";
        public const string FIELD_MODIFIEDBY = "ModifiedBy";
        public const string FIELD_MODIFIEDDATE = "ModifiedDate";
        public const string FIELD_COLUMN4 = "Column4";
        public const string FIELD_COLUMN3 = "Column3";
        public const string FIELD_COLUMN2 = "Column2";
        public const string FIELD_COLUMN1 = "Column1";
        public const string FIELD_PRIORITY = "Priority";
        public const string FIELD_ISACTIVE = "IsActive";
        public const string FIELD_SAVE_POINT = "SavePoint";
        public const string FIELD_USE_POINT = "UsePoint";
        #endregion

        #region Contructors
        public OrderMenuEntity()
        {
           
        }

        public OrderMenuEntity(int _OrderMenuID, string _OrderCode, string _OrderStatus, string _Customer, double _OrderSubTotal, double _OrderTax, double _OrderDiscount2, double _OrderDiscount, double _OrderShippingFee, string _CustomerIp, string _PaymentMethod, string _PaymentStatus, string _DeliveryStaff, string _ShippingMethod, string _ShippingStatus, string _ShippingFullName, string _ShippingEmail, string _ShippingPhone, string _ShippingFax, string _ShippingCompany, string _ShippingAddress, DateTime _ShippingDate, DateTime _ShippingDeliveredDate, string _ShippingCity, string _ShippingState, string _ShippingCountry, string _BillingFullName, string _BillingEmail, string _BillingPhone, string _BillingFax, string _BillingCompany, string _BillingShippingAddress, string _BillingCity, string _BillingState, string _BillingCountry, string _InvoiceTaxCode, string _InvoiceAddress, string _OrderNote, string _ModifiedBy, DateTime _ModifiedDate, string _Column4, string _Column3, string _Column2, string _Column1, int _Priority, bool _IsActive, double _savePoint, double _usePoint)
        {
            OrderMenuID = _OrderMenuID;
            OrderCode = _OrderCode;
            OrderStatus = _OrderStatus;
            Customer = _Customer;
            OrderSubTotal = _OrderSubTotal;
            OrderTax = _OrderTax;
            OrderDiscount2 = _OrderDiscount2;
            OrderDiscount = _OrderDiscount;
            OrderShippingFee = _OrderShippingFee;
            CustomerIp = _CustomerIp;
            PaymentMethod = _PaymentMethod;
            PaymentStatus = _PaymentStatus;
            DeliveryStaff = _DeliveryStaff;
            ShippingMethod = _ShippingMethod;
            ShippingStatus = _ShippingStatus;
            ShippingFullName = _ShippingFullName;
            ShippingEmail = _ShippingEmail;
            ShippingPhone = _ShippingPhone;
            ShippingFax = _ShippingFax;
            ShippingCompany = _ShippingCompany;
            ShippingAddress = _ShippingAddress;
            ShippingDate = _ShippingDate;
            ShippingDeliveredDate = _ShippingDeliveredDate;
            ShippingCity = _ShippingCity;
            ShippingState = _ShippingState;
            ShippingCountry = _ShippingCountry;
            BillingFullName = _BillingFullName;
            BillingEmail = _BillingEmail;
            BillingPhone = _BillingPhone;
            BillingFax = _BillingFax;
            BillingCompany = _BillingCompany;
            BillingShippingAddress = _BillingShippingAddress;
            BillingCity = _BillingCity;
            BillingState = _BillingState;
            BillingCountry = _BillingCountry;
            InvoiceTaxCode = _InvoiceTaxCode;
            InvoiceAddress = _InvoiceAddress;
            OrderNote = _OrderNote;
            ModifiedBy = _ModifiedBy;
            ModifiedDate = _ModifiedDate;
            Column4 = _Column4;
            Column3 = _Column3;
            Column2 = _Column2;
            Column1 = _Column1;
            Priority = _Priority;
            IsActive = _IsActive;
            SavePoint = _savePoint;
            UsePoint = _usePoint;
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

        #region OrderCode
        private string _OrderCode = String.Empty;
        /// <summary>
        /// Gets or sets OrderCode
        /// </summary>
        public string OrderCode
        {
            get
            {
                return _OrderCode;
            }
            set
            {
                _OrderCode = value;
            }
        }
        #endregion

        #region OrderStatus
        private string _OrderStatus = String.Empty;
        /// <summary>
        /// Gets or sets OrderStatus
        /// </summary>
        public string OrderStatus
        {
            get
            {
                return _OrderStatus;
            }
            set
            {
                _OrderStatus = value;
            }
        }
        #endregion

        #region Customer
        private string _Customer = String.Empty;
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public string Customer
        {
            get
            {
                return _Customer;
            }
            set
            {
                _Customer = value;
            }
        }
        #endregion

        #region OrderSubTotal
        private double _OrderSubTotal = 0.0;
        /// <summary>
        /// Gets or sets OrderSubTotal
        /// </summary>
        public double OrderSubTotal
        {
            get
            {
                return _OrderSubTotal;
            }
            set
            {
                _OrderSubTotal = value;
            }
        }
        #endregion

        #region OrderTax
        private double _OrderTax = 0.0;
        /// <summary>
        /// Gets or sets OrderTax
        /// </summary>
        public double OrderTax
        {
            get
            {
                return _OrderTax;
            }
            set
            {
                _OrderTax = value;
            }
        }
        #endregion

        #region OrderDiscount2
        private double _OrderDiscount2 = 0.0;
        /// <summary>
        /// Gets or sets OrderDiscount2
        /// </summary>
        public double OrderDiscount2
        {
            get
            {
                return _OrderDiscount2;
            }
            set
            {
                _OrderDiscount2 = value;
            }
        }
        #endregion

        #region OrderDiscount
        private double _OrderDiscount = 0.0;
        /// <summary>
        /// Gets or sets OrderDiscount
        /// </summary>
        public double OrderDiscount
        {
            get
            {
                return _OrderDiscount;
            }
            set
            {
                _OrderDiscount = value;
            }
        }
        #endregion

        #region OrderShippingFee
        private double _OrderShippingFee = 0.0;
        /// <summary>
        /// Gets or sets OrderShippingFee
        /// </summary>
        public double OrderShippingFee
        {
            get
            {
                return _OrderShippingFee;
            }
            set
            {
                _OrderShippingFee = value;
            }
        }
        #endregion

        #region CustomerIp
        private string _CustomerIp = String.Empty;
        /// <summary>
        /// Gets or sets CustomerIp
        /// </summary>
        public string CustomerIp
        {
            get
            {
                return _CustomerIp;
            }
            set
            {
                _CustomerIp = value;
            }
        }
        #endregion

        #region PaymentMethod
        private string _PaymentMethod = String.Empty;
        /// <summary>
        /// Gets or sets PaymentMethod
        /// </summary>
        public string PaymentMethod
        {
            get
            {
                return _PaymentMethod;
            }
            set
            {
                _PaymentMethod = value;
            }
        }
        #endregion

        #region PaymentStatus
        private string _PaymentStatus = String.Empty;
        /// <summary>
        /// Gets or sets PaymentStatus
        /// </summary>
        public string PaymentStatus
        {
            get
            {
                return _PaymentStatus;
            }
            set
            {
                _PaymentStatus = value;
            }
        }
        #endregion

        #region DeliveryStaff
        private string _DeliveryStaff = String.Empty;
        /// <summary>
        /// Gets or sets DeliveryStaff
        /// </summary>
        public string DeliveryStaff
        {
            get
            {
                return _DeliveryStaff;
            }
            set
            {
                _DeliveryStaff = value;
            }
        }
        #endregion

        #region ShippingMethod
        private string _ShippingMethod = String.Empty;
        /// <summary>
        /// Gets or sets ShippingMethod
        /// </summary>
        public string ShippingMethod
        {
            get
            {
                return _ShippingMethod;
            }
            set
            {
                _ShippingMethod = value;
            }
        }
        #endregion

        #region ShippingStatus
        private string _ShippingStatus = String.Empty;
        /// <summary>
        /// Gets or sets ShippingStatus
        /// </summary>
        public string ShippingStatus
        {
            get
            {
                return _ShippingStatus;
            }
            set
            {
                _ShippingStatus = value;
            }
        }
        #endregion

        #region ShippingFullName
        private string _ShippingFullName = String.Empty;
        /// <summary>
        /// Gets or sets ShippingFullName
        /// </summary>
        public string ShippingFullName
        {
            get
            {
                return _ShippingFullName;
            }
            set
            {
                _ShippingFullName = value;
            }
        }
        #endregion

        #region ShippingEmail
        private string _ShippingEmail = String.Empty;
        /// <summary>
        /// Gets or sets ShippingEmail
        /// </summary>
        public string ShippingEmail
        {
            get
            {
                return _ShippingEmail;
            }
            set
            {
                _ShippingEmail = value;
            }
        }
        #endregion

        #region ShippingPhone
        private string _ShippingPhone = String.Empty;
        /// <summary>
        /// Gets or sets ShippingPhone
        /// </summary>
        public string ShippingPhone
        {
            get
            {
                return _ShippingPhone;
            }
            set
            {
                _ShippingPhone = value;
            }
        }
        #endregion

        #region ShippingFax
        private string _ShippingFax = String.Empty;
        /// <summary>
        /// Gets or sets ShippingFax
        /// </summary>
        public string ShippingFax
        {
            get
            {
                return _ShippingFax;
            }
            set
            {
                _ShippingFax = value;
            }
        }
        #endregion

        #region ShippingCompany
        private string _ShippingCompany = String.Empty;
        /// <summary>
        /// Gets or sets ShippingCompany
        /// </summary>
        public string ShippingCompany
        {
            get
            {
                return _ShippingCompany;
            }
            set
            {
                _ShippingCompany = value;
            }
        }
        #endregion

        #region ShippingAddress
        private string _ShippingAddress = String.Empty;
        /// <summary>
        /// Gets or sets ShippingAddress
        /// </summary>
        public string ShippingAddress
        {
            get
            {
                return _ShippingAddress;
            }
            set
            {
                _ShippingAddress = value;
            }
        }
        #endregion

        #region ShippingDate
        private DateTime _ShippingDate = DateTime.MinValue;
        /// <summary>
        /// Gets or sets ShippingDate
        /// </summary>
        public DateTime ShippingDate
        {
            get
            {
                return _ShippingDate;
            }
            set
            {
                _ShippingDate = value;
            }
        }
        #endregion

        #region ShippingDeliveredDate
        private DateTime _ShippingDeliveredDate = DateTime.MinValue;
        /// <summary>
        /// Gets or sets ShippingDeliveredDate
        /// </summary>
        public DateTime ShippingDeliveredDate
        {
            get
            {
                return _ShippingDeliveredDate;
            }
            set
            {
                _ShippingDeliveredDate = value;
            }
        }
        #endregion

        #region ShippingCity
        private string _ShippingCity = String.Empty;
        /// <summary>
        /// Gets or sets ShippingCity
        /// </summary>
        public string ShippingCity
        {
            get
            {
                return _ShippingCity;
            }
            set
            {
                _ShippingCity = value;
            }
        }
        #endregion

        #region ShippingState
        private string _ShippingState = String.Empty;
        /// <summary>
        /// Gets or sets ShippingState
        /// </summary>
        public string ShippingState
        {
            get
            {
                return _ShippingState;
            }
            set
            {
                _ShippingState = value;
            }
        }
        #endregion

        #region ShippingCountry
        private string _ShippingCountry = String.Empty;
        /// <summary>
        /// Gets or sets ShippingCountry
        /// </summary>
        public string ShippingCountry
        {
            get
            {
                return _ShippingCountry;
            }
            set
            {
                _ShippingCountry = value;
            }
        }
        #endregion

        #region BillingFullName
        private string _BillingFullName = String.Empty;
        /// <summary>
        /// Gets or sets BillingFullName
        /// </summary>
        public string BillingFullName
        {
            get
            {
                return _BillingFullName;
            }
            set
            {
                _BillingFullName = value;
            }
        }
        #endregion

        #region BillingEmail
        private string _BillingEmail = String.Empty;
        /// <summary>
        /// Gets or sets BillingEmail
        /// </summary>
        public string BillingEmail
        {
            get
            {
                return _BillingEmail;
            }
            set
            {
                _BillingEmail = value;
            }
        }
        #endregion

        #region BillingPhone
        private string _BillingPhone = String.Empty;
        /// <summary>
        /// Gets or sets BillingPhone
        /// </summary>
        public string BillingPhone
        {
            get
            {
                return _BillingPhone;
            }
            set
            {
                _BillingPhone = value;
            }
        }
        #endregion

        #region BillingFax
        private string _BillingFax = String.Empty;
        /// <summary>
        /// Gets or sets BillingFax
        /// </summary>
        public string BillingFax
        {
            get
            {
                return _BillingFax;
            }
            set
            {
                _BillingFax = value;
            }
        }
        #endregion

        #region BillingCompany
        private string _BillingCompany = String.Empty;
        /// <summary>
        /// Gets or sets BillingCompany
        /// </summary>
        public string BillingCompany
        {
            get
            {
                return _BillingCompany;
            }
            set
            {
                _BillingCompany = value;
            }
        }
        #endregion

        #region BillingShippingAddress
        private string _BillingShippingAddress = String.Empty;
        /// <summary>
        /// Gets or sets BillingShippingAddress
        /// </summary>
        public string BillingShippingAddress
        {
            get
            {
                return _BillingShippingAddress;
            }
            set
            {
                _BillingShippingAddress = value;
            }
        }
        #endregion

        #region BillingCity
        private string _BillingCity = String.Empty;
        /// <summary>
        /// Gets or sets BillingCity
        /// </summary>
        public string BillingCity
        {
            get
            {
                return _BillingCity;
            }
            set
            {
                _BillingCity = value;
            }
        }
        #endregion

        #region BillingState
        private string _BillingState = String.Empty;
        /// <summary>
        /// Gets or sets BillingState
        /// </summary>
        public string BillingState
        {
            get
            {
                return _BillingState;
            }
            set
            {
                _BillingState = value;
            }
        }
        #endregion

        #region BillingCountry
        private string _BillingCountry = String.Empty;
        /// <summary>
        /// Gets or sets BillingCountry
        /// </summary>
        public string BillingCountry
        {
            get
            {
                return _BillingCountry;
            }
            set
            {
                _BillingCountry = value;
            }
        }
        #endregion

        #region InvoiceTaxCode
        private string _InvoiceTaxCode = String.Empty;
        /// <summary>
        /// Gets or sets InvoiceTaxCode
        /// </summary>
        public string InvoiceTaxCode
        {
            get
            {
                return _InvoiceTaxCode;
            }
            set
            {
                _InvoiceTaxCode = value;
            }
        }
        #endregion

        #region InvoiceAddress
        private string _InvoiceAddress = String.Empty;
        /// <summary>
        /// Gets or sets InvoiceAddress
        /// </summary>
        public string InvoiceAddress
        {
            get
            {
                return _InvoiceAddress;
            }
            set
            {
                _InvoiceAddress = value;
            }
        }
        #endregion

        #region OrderNote
        private string _OrderNote = String.Empty;
        /// <summary>
        /// Gets or sets OrderNote
        /// </summary>
        public string OrderNote
        {
            get
            {
                return _OrderNote;
            }
            set
            {
                _OrderNote = value;
            }
        }
        #endregion

        #region ModifiedBy
        private string _ModifiedBy = String.Empty;
        /// <summary>
        /// Gets or sets ModifiedBy
        /// </summary>
        public string ModifiedBy
        {
            get
            {
                return _ModifiedBy;
            }
            set
            {
                _ModifiedBy = value;
            }
        }
        #endregion

        #region ModifiedDate
        private DateTime _ModifiedDate = DateTime.MinValue;
        /// <summary>
        /// Gets or sets ModifiedDate
        /// </summary>
        public DateTime ModifiedDate
        {
            get
            {
                return _ModifiedDate;
            }
            set
            {
                _ModifiedDate = value;
            }
        }
        #endregion

        #region Column4
        private string _Column4 = String.Empty;
        /// <summary>
        /// Gets or sets Column4
        /// </summary>
        public string Column4
        {
            get
            {
                return _Column4;
            }
            set
            {
                _Column4 = value;
            }
        }
        #endregion

        #region Column3
        private string _Column3 = String.Empty;
        /// <summary>
        /// Gets or sets Column3
        /// </summary>
        public string Column3
        {
            get
            {
                return _Column3;
            }
            set
            {
                _Column3 = value;
            }
        }
        #endregion

        #region Column2
        private string _Column2 = String.Empty;
        /// <summary>
        /// Gets or sets Column2
        /// </summary>
        public string Column2
        {
            get
            {
                return _Column2;
            }
            set
            {
                _Column2 = value;
            }
        }
        #endregion

        #region Column1
        private string _Column1 = String.Empty;
        /// <summary>
        /// Gets or sets Column1
        /// </summary>
        public string Column1
        {
            get
            {
                return _Column1;
            }
            set
            {
                _Column1 = value;
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

        #region SavePoint

        private double _savePoint = 0;

        public double SavePoint
        {
            get { return _savePoint; }
            set { _savePoint = value; }
        }

        #endregion

        #region UsePoint

        private double _usePoint = 0;

        public double UsePoint
        {
            get { return _usePoint; }
            set { _usePoint = value; }
        }

        #endregion UserPoint

    }
}

