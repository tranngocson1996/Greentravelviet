using System;
using System.Data;
using System.Collections.Generic;
using BIC.Entity;
using BIC.DAO;
using System.Web.UI.WebControls;
using BIC.Utils;
using BIC.Data;

namespace BIC.Biz
{
	public class OrderDetailBiz : BaseOrderDetail
	{
		/// <summary>
		/// Create a new OrderDetail
		/// </summary>
		public static bool InsertOrderDetail( OrderDetailEntity orderdetailEntity )
		{
			OrderDetailDAO orderdetailDA0 = new OrderDetailDAO();
			bool ret = orderdetailDA0.InsertOrderDetail(orderdetailEntity);
			BizObject.PurgeCacheItems("OrderDetail_OrderDetail");
			return ret;
		}
		
		/// <summary>
    	/// Update a OrderDetailEntity
    	/// </summary>
		public static bool UpdateOrderDetail(OrderDetailEntity orderdetailEntity)
		{
			OrderDetailDAO orderdetailDA0 = new OrderDetailDAO();
			bool ret = orderdetailDA0.UpdateOrderDetail(orderdetailEntity);
			BizObject.PurgeCacheItems("OrderDetail_OrderDetail_" + orderdetailEntity.OrderDetailID);
			BizObject.PurgeCacheItems("OrderDetail_OrderDetail");
         	return ret;
		}
	
		/// <summary>
    	/// Delete a OrderDetailEntity
    	/// </summary>
		public static bool DeleteOrderDetail(int _OrderDetailID)
		{
			OrderDetailDAO orderdetailDA0 = new OrderDetailDAO();
			bool ret =  orderdetailDA0.DeleteOrderDetail(_OrderDetailID);
			BizObject.PurgeCacheItems("OrderDetail_OrderDetail");
			return ret;
		}
		
		/// <summary>
        /// Returns an existing OrderDetail with the specified ID
        /// </summary>
		public static OrderDetailEntity GetOrderDetailByID(int _OrderDetailID)
		{
			OrderDetailEntity orderdetailEntity = null;
			string key = "OrderDetail_OrderDetail_" + _OrderDetailID.ToString();
			if (BizObject.Cache[key] != null)
			{
				orderdetailEntity = (OrderDetailEntity)BizObject.Cache[key];
			}
			else
			{
				OrderDetailDAO orderdetailDA0 = new OrderDetailDAO();
				orderdetailEntity = orderdetailDA0.GetOrderDetailByID(_OrderDetailID);
				BaseOrderDetail.CacheData(key, orderdetailEntity);
			}
			return orderdetailEntity;
		}
        /// <summary>
        /// Trả về list object orderdetail lấy theo ordermenuId
        /// added: 2014/09/04 by sontt
        /// </summary>
        /// <param name="orderMenuId"></param>
        /// <returns></returns>
	    public static List<OrderDetailEntity> GetOrderDetailByOrderMenuID(int orderMenuId)
	    {
            var orderdetailEntity = new List<OrderDetailEntity>();
            var key = "OrderDetail_OrderDetail_" + orderMenuId;
            if (Cache[key] != null)
            {
                orderdetailEntity = ((List<OrderDetailEntity>)Cache[key]);
            }
            else
            {
                var orderdetailDA0 = new OrderDetailDAO();
                orderdetailEntity = orderdetailDA0.GetOrderDetailByOrderMenuID(orderMenuId);
                CacheData(key, orderdetailEntity);
            }
            return orderdetailEntity;
	    }

		/// <summary>
        /// Returns a collection with all the OrderDetails
        /// </summary>
		public static List<OrderDetailEntity> GetAllOrderDetails()
		{
			List<OrderDetailEntity> OrderDetailsEntity = null;
			string key = "OrderDetail_OrderDetail";
			
			if (BizObject.Cache[key] != null)
			{
				OrderDetailsEntity = (List<OrderDetailEntity>)BizObject.Cache[key];
			}
			else
			{
				OrderDetailDAO orderdetailDA0 = new OrderDetailDAO();
				OrderDetailsEntity =  orderdetailDA0.GetAllOrderDetails();
				BaseOrderDetail.CacheData(key, OrderDetailsEntity);
			}
			return OrderDetailsEntity;
		}

		
		public static void PositionWithPriorityEdit(DropDownList ddlPosition)
        {
            var dh = new DataHelper();
            DataTable dt = dh.PositionWithPriority("OrderDetailId", "OrderDetail");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlPosition.Items.Add(new ListItem((i + 1).ToString(), dt.Rows[i]["Priority"].ToString()));
            }
        }

        public static void PositionWithPriorityAdd(DropDownList ddlPosition)
        {
            var dh = new DataHelper();

            for (int i = 1; i <= dh.CountItem("OrderDetailId", "OrderDetail") + 1; i++)
            {
                ddlPosition.Items.Add(new ListItem(i.ToString()));
            }
        }
	}
}

