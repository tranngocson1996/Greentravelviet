using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BIC.Entity;
using BIC.Utils;
namespace BIC.DAO
{
    public class OrderDetailDAO : OrderDetailProvider
    {
        #region Stored Procedure names
        private const string INSERT_ORDERDETAIL = "[dbo].OrderDetailInsert";
        private const string UPDATE_ORDERDETAIL = "[dbo].OrderDetailUpdate";
        private const string DELETE_ORDERDETAIL = "[dbo].OrderDetailDelete";
        private const string SELECT_ORDERDETAIL_BYID = "[dbo].OrderDetailGetByID";
        private const string SELECT_ALL_ORDERDETAIL = "[dbo].OrderDetailsGetAll";
        private const string SELECT_ORDERDETAIL_BY_ORDERMENU_ID = "[dbo].OrderDetailGetByOrderMenuID";

        #endregion

        /// <summary>
        /// Create a new OrderDetailEntity
        /// </summary>
        public override bool InsertOrderDetail(OrderDetailEntity entity)
        {

            using (SqlConnection cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(INSERT_ORDERDETAIL, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderMenuID", SqlDbType.Int).Value = entity.OrderMenuID;
                cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = entity.ProductName;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = entity.ProductID;
                cmd.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = entity.ProductCode;
                cmd.Parameters.Add("@ProductPrice", SqlDbType.Float).Value = entity.ProductPrice;
                cmd.Parameters.Add("@Discount", SqlDbType.Float).Value = entity.Discount;
                cmd.Parameters.Add("@SubTotal", SqlDbType.Float).Value = entity.SubTotal;
                cmd.Parameters.Add("@Total", SqlDbType.Float).Value = entity.Total;
                cmd.Parameters.Add("@Tax", SqlDbType.Float).Value = entity.Tax;
                cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = entity.Priority;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                cmd.Parameters.Add("@OrderDetailID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                entity.OrderDetailID = (Int32)cmd.Parameters["@OrderDetailID"].Value;
                cn.Close();
                return (ret == 1);
            }

        }

        /// <summary>
        /// Update a OrderDetailEntity
        /// </summary>
        public override bool UpdateOrderDetail(OrderDetailEntity entity)
        {

            using (SqlConnection cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(UPDATE_ORDERDETAIL, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderDetailID", SqlDbType.Int).Value = entity.OrderDetailID;
                cmd.Parameters.Add("@OrderMenuID", SqlDbType.Int).Value = entity.OrderMenuID;
                cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = entity.ProductName;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = entity.ProductID;
                cmd.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = entity.ProductCode;
                cmd.Parameters.Add("@ProductPrice", SqlDbType.Float).Value = entity.ProductPrice;
                cmd.Parameters.Add("@Discount", SqlDbType.Float).Value = entity.Discount;
                cmd.Parameters.Add("@SubTotal", SqlDbType.Float).Value = entity.SubTotal;
                cmd.Parameters.Add("@Total", SqlDbType.Float).Value = entity.Total;
                cmd.Parameters.Add("@Tax", SqlDbType.Float).Value = entity.Tax;
                cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = entity.Priority;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                cn.Open();
                int ret = DataAccess.ExecuteNonQuery(cmd);
                cn.Close();
                return (ret == 1);
            }

        }

        /// <summary>
        /// Deletes a OrderDetailEntity
        /// </summary>
        public override bool DeleteOrderDetail(int _OrderDetailID)
        {

            using (SqlConnection cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(DELETE_ORDERDETAIL, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderDetailID", SqlDbType.Int).Value = _OrderDetailID;
                cn.Open();
                int ret = DataAccess.ExecuteNonQuery(cmd);
                cn.Close();
                return (ret == 1);
            }

        }

        /// <summary>
        /// Returns an existing OrderDetail with the specified ID
        /// </summary>
        public override OrderDetailEntity GetOrderDetailByID(int _OrderDetailID)
        {
            OrderDetailEntity _OrderDetailEntity = null;
            using (SqlConnection cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SELECT_ORDERDETAIL_BYID, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderDetailID", SqlDbType.Int).Value = _OrderDetailID;
                cn.Open();
                IDataReader reader = DataAccess.ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    _OrderDetailEntity = GetOrderDetailFromReader(reader);
                }
                cn.Close();
            }
            return _OrderDetailEntity;
        }


        /// <summary>
        /// Returns a new OrderDetailEntity instance filled with the DataReader's current record data
        /// </summary>
        private OrderDetailEntity GetOrderDetailFromReader(IDataReader reader)
        {
            return new OrderDetailEntity(
                BicConvert.ToInt32(reader["OrderDetailID"]),
                BicConvert.ToInt32(reader["OrderMenuID"]),
                reader["ProductName"].ToString().Trim(),
                BicConvert.ToInt32(reader["ProductID"]),
                reader["ProductCode"].ToString().Trim(),
                BicConvert.ToDouble(reader["ProductPrice"]),
                BicConvert.ToDouble(reader["Discount"]),
                BicConvert.ToDouble(reader["SubTotal"]),
                BicConvert.ToDouble(reader["Total"]),
                BicConvert.ToDouble(reader["Tax"]),
                BicConvert.ToInt32(reader["Priority"]),
                BicConvert.ToBoolean(reader["IsActive"]));
        }

        /// <summary>
        /// Returns a collection with all the OrderDetails
        /// </summary>
        public override List<OrderDetailEntity> GetAllOrderDetails()
        {
            List<OrderDetailEntity> _OrderDetailEntity = null;
            using (SqlConnection cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SELECT_ALL_ORDERDETAIL, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                _OrderDetailEntity = GetOrderDetailCollectionFromReader(DataAccess.ExecuteReader(cmd));
                cn.Close();
            }
            return _OrderDetailEntity;
        }

        /// <summary>
        /// Returns a list orderdetail object get by ordermenuID
        /// added: 2014/09/04 by sontt
        /// </summary>
        /// <param name="orderMenuID"></param>
        /// <returns></returns>
        public override List<OrderDetailEntity> GetOrderDetailByOrderMenuID(int orderMenuID)
        {
            List<OrderDetailEntity> orderDetailEntity;
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(SELECT_ORDERDETAIL_BY_ORDERMENU_ID, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@OrderMenuID", SqlDbType.Int).Value = orderMenuID;
                cn.Open();
                orderDetailEntity = GetOrderDetailCollectionFromReader(ExecuteReader(cmd));
                cn.Close();
            }
            return orderDetailEntity;
        }

        /// <summary>
        /// Returns a collection of OrderDetailEntity objects with the data read from the input DataReader
        /// </summary>
        private List<OrderDetailEntity> GetOrderDetailCollectionFromReader(IDataReader reader)
        {
            List<OrderDetailEntity> orderdetailEntity = new List<OrderDetailEntity>();
            while (reader.Read())
                orderdetailEntity.Add(GetOrderDetailFromReader(reader));
            return orderdetailEntity;
        }



    }
}

