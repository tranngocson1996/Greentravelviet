using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BIC.Entity;
using BIC.Utils;
namespace BIC.DAO
{
    public class OrderMenuDAO : OrderMenuProvider
    {
        #region Stored Procedure names
        private const string INSERT_ORDERMENU = "[dbo].OrderMenuInsert";
        private const string UPDATE_ORDERMENU = "[dbo].OrderMenuUpdate";
        private const string DELETE_ORDERMENU = "[dbo].OrderMenuDelete";
        private const string SELECT_ORDERMENU_BYID = "[dbo].OrderMenuGetByID";
        private const string SELECT_ORDERMENU_BYCusID = "[dbo].OrderMenuGetByCusID";
        private const string SELECT_ALL_ORDERMENU = "[dbo].OrderMenusGetAll";

        #endregion

        /// <summary>
        /// Create a new OrderMenuEntity
        /// </summary>
        public override bool InsertOrderMenu(OrderMenuEntity entity)
        {

            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(INSERT_ORDERMENU, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@OrderCode", SqlDbType.NVarChar).Value = entity.OrderCode;
                cmd.Parameters.Add("@OrderStatus", SqlDbType.NVarChar).Value = entity.OrderStatus;
                cmd.Parameters.Add("@Customer", SqlDbType.NVarChar).Value = entity.Customer;
                cmd.Parameters.Add("@OrderSubTotal", SqlDbType.Float).Value = entity.OrderSubTotal;
                cmd.Parameters.Add("@OrderTax", SqlDbType.Float).Value = entity.OrderTax;
                cmd.Parameters.Add("@OrderDiscount2", SqlDbType.Float).Value = entity.OrderDiscount2;
                cmd.Parameters.Add("@OrderDiscount", SqlDbType.Float).Value = entity.OrderDiscount;
                cmd.Parameters.Add("@OrderShippingFee", SqlDbType.Float).Value = entity.OrderShippingFee;
                cmd.Parameters.Add("@CustomerIp", SqlDbType.NVarChar).Value = entity.CustomerIp;
                cmd.Parameters.Add("@PaymentMethod", SqlDbType.NVarChar).Value = entity.PaymentMethod;
                cmd.Parameters.Add("@PaymentStatus", SqlDbType.NVarChar).Value = entity.PaymentStatus;
                cmd.Parameters.Add("@DeliveryStaff", SqlDbType.NVarChar).Value = entity.DeliveryStaff;
                cmd.Parameters.Add("@ShippingMethod", SqlDbType.NVarChar).Value = entity.ShippingMethod;
                cmd.Parameters.Add("@ShippingStatus", SqlDbType.NVarChar).Value = entity.ShippingStatus;
                cmd.Parameters.Add("@ShippingFullName", SqlDbType.NVarChar).Value = entity.ShippingFullName;
                cmd.Parameters.Add("@ShippingEmail", SqlDbType.NVarChar).Value = entity.ShippingEmail;
                cmd.Parameters.Add("@ShippingPhone", SqlDbType.NVarChar).Value = entity.ShippingPhone;
                cmd.Parameters.Add("@ShippingFax", SqlDbType.NVarChar).Value = entity.ShippingFax;
                cmd.Parameters.Add("@ShippingCompany", SqlDbType.NVarChar).Value = entity.ShippingCompany;
                cmd.Parameters.Add("@ShippingAddress", SqlDbType.NVarChar).Value = entity.ShippingAddress;
                cmd.Parameters.Add("@ShippingDate", SqlDbType.DateTime).Value = entity.ShippingDate;
                cmd.Parameters.Add("@ShippingDeliveredDate", SqlDbType.DateTime).Value = entity.ShippingDeliveredDate;
                cmd.Parameters.Add("@ShippingCity", SqlDbType.NVarChar).Value = entity.ShippingCity;
                cmd.Parameters.Add("@ShippingState", SqlDbType.NVarChar).Value = entity.ShippingState;
                cmd.Parameters.Add("@ShippingCountry", SqlDbType.NVarChar).Value = entity.ShippingCountry;
                cmd.Parameters.Add("@BillingFullName", SqlDbType.NVarChar).Value = entity.BillingFullName;
                cmd.Parameters.Add("@BillingEmail", SqlDbType.NVarChar).Value = entity.BillingEmail;
                cmd.Parameters.Add("@BillingPhone", SqlDbType.NVarChar).Value = entity.BillingPhone;
                cmd.Parameters.Add("@BillingFax", SqlDbType.NVarChar).Value = entity.BillingFax;
                cmd.Parameters.Add("@BillingCompany", SqlDbType.NVarChar).Value = entity.BillingCompany;
                cmd.Parameters.Add("@BillingShippingAddress", SqlDbType.NVarChar).Value = entity.BillingShippingAddress;
                cmd.Parameters.Add("@BillingCity", SqlDbType.NVarChar).Value = entity.BillingCity;
                cmd.Parameters.Add("@BillingState", SqlDbType.NVarChar).Value = entity.BillingState;
                cmd.Parameters.Add("@BillingCountry", SqlDbType.NVarChar).Value = entity.BillingCountry;
                cmd.Parameters.Add("@InvoiceTaxCode", SqlDbType.NVarChar).Value = entity.InvoiceTaxCode;
                cmd.Parameters.Add("@InvoiceAddress", SqlDbType.NVarChar).Value = entity.InvoiceAddress;
                cmd.Parameters.Add("@OrderNote", SqlDbType.NVarChar).Value = entity.OrderNote;
                cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = entity.ModifiedBy;
                cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = entity.ModifiedDate;
                cmd.Parameters.Add("@Column4", SqlDbType.NVarChar).Value = entity.Column4;
                cmd.Parameters.Add("@Column3", SqlDbType.NVarChar).Value = entity.Column3;
                cmd.Parameters.Add("@Column2", SqlDbType.NVarChar).Value = entity.Column2;
                cmd.Parameters.Add("@Column1", SqlDbType.NVarChar).Value = entity.Column1;
                cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = entity.Priority;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                cmd.Parameters.Add("@SavePoint", SqlDbType.Float).Value = entity.SavePoint;
                cmd.Parameters.Add("@UsePoint", SqlDbType.Float).Value = entity.UsePoint;
                cmd.Parameters.Add("@OrderMenuID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                entity.OrderMenuID = (Int32)cmd.Parameters["@OrderMenuID"].Value;
                cn.Close();
                return (ret == 1);
            }

        }

        /// <summary>
        /// Update a OrderMenuEntity
        /// </summary>
        public override bool UpdateOrderMenu(OrderMenuEntity entity)
        {

            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(UPDATE_ORDERMENU, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@OrderMenuID", SqlDbType.Int).Value = entity.OrderMenuID;
                cmd.Parameters.Add("@OrderCode", SqlDbType.NVarChar).Value = entity.OrderCode;
                cmd.Parameters.Add("@OrderStatus", SqlDbType.NVarChar).Value = entity.OrderStatus;
                cmd.Parameters.Add("@Customer", SqlDbType.NVarChar).Value = entity.Customer;
                cmd.Parameters.Add("@OrderSubTotal", SqlDbType.Float).Value = entity.OrderSubTotal;
                cmd.Parameters.Add("@OrderTax", SqlDbType.Float).Value = entity.OrderTax;
                cmd.Parameters.Add("@OrderDiscount2", SqlDbType.Float).Value = entity.OrderDiscount2;
                cmd.Parameters.Add("@OrderDiscount", SqlDbType.Float).Value = entity.OrderDiscount;
                cmd.Parameters.Add("@OrderShippingFee", SqlDbType.Float).Value = entity.OrderShippingFee;
                cmd.Parameters.Add("@CustomerIp", SqlDbType.NVarChar).Value = entity.CustomerIp;
                cmd.Parameters.Add("@PaymentMethod", SqlDbType.NVarChar).Value = entity.PaymentMethod;
                cmd.Parameters.Add("@PaymentStatus", SqlDbType.NVarChar).Value = entity.PaymentStatus;
                cmd.Parameters.Add("@DeliveryStaff", SqlDbType.NVarChar).Value = entity.DeliveryStaff;
                cmd.Parameters.Add("@ShippingMethod", SqlDbType.NVarChar).Value = entity.ShippingMethod;
                cmd.Parameters.Add("@ShippingStatus", SqlDbType.NVarChar).Value = entity.ShippingStatus;
                cmd.Parameters.Add("@ShippingFullName", SqlDbType.NVarChar).Value = entity.ShippingFullName;
                cmd.Parameters.Add("@ShippingEmail", SqlDbType.NVarChar).Value = entity.ShippingEmail;
                cmd.Parameters.Add("@ShippingPhone", SqlDbType.NVarChar).Value = entity.ShippingPhone;
                cmd.Parameters.Add("@ShippingFax", SqlDbType.NVarChar).Value = entity.ShippingFax;
                cmd.Parameters.Add("@ShippingCompany", SqlDbType.NVarChar).Value = entity.ShippingCompany;
                cmd.Parameters.Add("@ShippingAddress", SqlDbType.NVarChar).Value = entity.ShippingAddress;
                cmd.Parameters.Add("@ShippingDate", SqlDbType.DateTime).Value = entity.ShippingDate;
                cmd.Parameters.Add("@ShippingDeliveredDate", SqlDbType.DateTime).Value = entity.ShippingDeliveredDate;
                cmd.Parameters.Add("@ShippingCity", SqlDbType.NVarChar).Value = entity.ShippingCity;
                cmd.Parameters.Add("@ShippingState", SqlDbType.NVarChar).Value = entity.ShippingState;
                cmd.Parameters.Add("@ShippingCountry", SqlDbType.NVarChar).Value = entity.ShippingCountry;
                cmd.Parameters.Add("@BillingFullName", SqlDbType.NVarChar).Value = entity.BillingFullName;
                cmd.Parameters.Add("@BillingEmail", SqlDbType.NVarChar).Value = entity.BillingEmail;
                cmd.Parameters.Add("@BillingPhone", SqlDbType.NVarChar).Value = entity.BillingPhone;
                cmd.Parameters.Add("@BillingFax", SqlDbType.NVarChar).Value = entity.BillingFax;
                cmd.Parameters.Add("@BillingCompany", SqlDbType.NVarChar).Value = entity.BillingCompany;
                cmd.Parameters.Add("@BillingShippingAddress", SqlDbType.NVarChar).Value = entity.BillingShippingAddress;
                cmd.Parameters.Add("@BillingCity", SqlDbType.NVarChar).Value = entity.BillingCity;
                cmd.Parameters.Add("@BillingState", SqlDbType.NVarChar).Value = entity.BillingState;
                cmd.Parameters.Add("@BillingCountry", SqlDbType.NVarChar).Value = entity.BillingCountry;
                cmd.Parameters.Add("@InvoiceTaxCode", SqlDbType.NVarChar).Value = entity.InvoiceTaxCode;
                cmd.Parameters.Add("@InvoiceAddress", SqlDbType.NVarChar).Value = entity.InvoiceAddress;
                cmd.Parameters.Add("@OrderNote", SqlDbType.NVarChar).Value = entity.OrderNote;
                cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = entity.ModifiedBy;
                cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = entity.ModifiedDate;
                cmd.Parameters.Add("@Column4", SqlDbType.NVarChar).Value = entity.Column4;
                cmd.Parameters.Add("@Column3", SqlDbType.NVarChar).Value = entity.Column3;
                cmd.Parameters.Add("@Column2", SqlDbType.NVarChar).Value = entity.Column2;
                cmd.Parameters.Add("@Column1", SqlDbType.NVarChar).Value = entity.Column1;
                cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = entity.Priority;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                cmd.Parameters.Add("@SavePoint", SqlDbType.Float).Value = entity.SavePoint;
                cmd.Parameters.Add("@UsePoint", SqlDbType.Float).Value = entity.UsePoint;
                //cmd.Parameters.Add("@OrderMenuID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                var ret = ExecuteNonQuery(cmd);
                cn.Close();
                return (ret == 1);
            }

        }

        /// <summary>
        /// Deletes a OrderMenuEntity
        /// </summary>
        public override bool DeleteOrderMenu(int _OrderMenuID)
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(DELETE_ORDERMENU, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@OrderMenuID", SqlDbType.Int).Value = _OrderMenuID;
                cn.Open();
                var ret = ExecuteNonQuery(cmd);
                cn.Close();
                return (ret == 1);
            }
        }

        /// <summary>
        /// Returns an existing OrderMenu with the specified ID
        /// </summary>
        public override OrderMenuEntity GetOrderMenuByID(int _OrderMenuID)
        {
            OrderMenuEntity _OrderMenuEntity = null;
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(SELECT_ORDERMENU_BYID, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@OrderMenuID", SqlDbType.Int).Value = _OrderMenuID;
                cn.Open();
                var reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    _OrderMenuEntity = GetOrderMenuFromReader(reader);
                }
                cn.Close();
            }
            return _OrderMenuEntity;
        }

        public List<OrderMenuEntity> GetOrderMenuByCusID(string _CusId)
        {
            List<OrderMenuEntity> _OrderMenuEntity;
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(SELECT_ORDERMENU_BYCusID, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@Customer", SqlDbType.VarChar).Value = _CusId;
                cn.Open();
                _OrderMenuEntity = GetOrderMenuCollectionFromReader(ExecuteReader(cmd));
                cn.Close();
            }
            return _OrderMenuEntity;
        }


        /// <summary>
        /// Returns a new OrderMenuEntity instance filled with the DataReader's current record data
        /// </summary>
        private OrderMenuEntity GetOrderMenuFromReader(IDataReader reader)
        {
            return new OrderMenuEntity(
                BicConvert.ToInt32(reader["OrderMenuID"]),
                reader["OrderCode"].ToString().Trim(),
                reader["OrderStatus"].ToString().Trim(),
                reader["Customer"].ToString().Trim(),
                BicConvert.ToDouble(reader["OrderSubTotal"]),
                BicConvert.ToDouble(reader["OrderTax"]),
                BicConvert.ToDouble(reader["OrderDiscount2"]),
                BicConvert.ToDouble(reader["OrderDiscount"]),
                BicConvert.ToDouble(reader["OrderShippingFee"]),
                reader["CustomerIp"].ToString().Trim(),
                reader["PaymentMethod"].ToString().Trim(),
                reader["PaymentStatus"].ToString().Trim(),
                reader["DeliveryStaff"].ToString().Trim(),
                reader["ShippingMethod"].ToString().Trim(),
                reader["ShippingStatus"].ToString().Trim(),
                reader["ShippingFullName"].ToString().Trim(),
                reader["ShippingEmail"].ToString().Trim(),
                reader["ShippingPhone"].ToString().Trim(),
                reader["ShippingFax"].ToString().Trim(),
                reader["ShippingCompany"].ToString().Trim(),
                reader["ShippingAddress"].ToString().Trim(),
                BicConvert.ToDateTime(reader["ShippingDate"]),
                BicConvert.ToDateTime(reader["ShippingDeliveredDate"]),
                reader["ShippingCity"].ToString().Trim(),
                reader["ShippingState"].ToString().Trim(),
                reader["ShippingCountry"].ToString().Trim(),
                reader["BillingFullName"].ToString().Trim(),
                reader["BillingEmail"].ToString().Trim(),
                reader["BillingPhone"].ToString().Trim(),
                reader["BillingFax"].ToString().Trim(),
                reader["BillingCompany"].ToString().Trim(),
                reader["BillingShippingAddress"].ToString().Trim(),
                reader["BillingCity"].ToString().Trim(),
                reader["BillingState"].ToString().Trim(),
                reader["BillingCountry"].ToString().Trim(),
                reader["InvoiceTaxCode"].ToString().Trim(),
                reader["InvoiceAddress"].ToString().Trim(),
                reader["OrderNote"].ToString().Trim(),
                reader["ModifiedBy"].ToString().Trim(),
                BicConvert.ToDateTime(reader["ModifiedDate"]),
                reader["Column4"].ToString().Trim(),
                reader["Column3"].ToString().Trim(),
                reader["Column2"].ToString().Trim(),
                reader["Column1"].ToString().Trim(),
                BicConvert.ToInt32(reader["Priority"]),
                BicConvert.ToBoolean(reader["IsActive"]),
                BicConvert.ToDouble(reader["SavePoint"]),
                BicConvert.ToDouble(reader["UsePoint"]));
        }

        /// <summary>
        /// Returns a collection with all the OrderMenus
        /// </summary>
        public override List<OrderMenuEntity> GetAllOrderMenus()
        {
            List<OrderMenuEntity> _OrderMenuEntity;
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(SELECT_ALL_ORDERMENU, cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                _OrderMenuEntity = GetOrderMenuCollectionFromReader(ExecuteReader(cmd));
                cn.Close();
            }
            return _OrderMenuEntity;
        }

        /// <summary>
        /// Returns a collection of OrderMenuEntity objects with the data read from the input DataReader
        /// </summary>
        private List<OrderMenuEntity> GetOrderMenuCollectionFromReader(IDataReader reader)
        {
            var ordermenuEntity = new List<OrderMenuEntity>();
            while (reader.Read())
                ordermenuEntity.Add(GetOrderMenuFromReader(reader));
            return ordermenuEntity;
        }
    }
}

