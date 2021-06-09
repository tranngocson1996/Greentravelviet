using System;
using System.Collections.Generic;
using BIC.Entity;
using BIC.DAO;
using System.Web.UI.WebControls;
using BIC.Data;

namespace BIC.Biz
{
	public class OrderMenuBiz : BaseOrderMenu
	{
		/// <summary>
		/// Create a new OrderMenu
		/// </summary>
		public static bool InsertOrderMenu( OrderMenuEntity ordermenuEntity )
		{
                
			ordermenuEntity.ModifiedBy = CurrentUserName;
			ordermenuEntity.ModifiedDate = DateTime.Now;
			var ordermenuDA0 = new OrderMenuDAO();
			var ret = ordermenuDA0.InsertOrderMenu(ordermenuEntity);
			PurgeCacheItems("OrderMenu_OrderMenu");
			return ret;
		}
		
		/// <summary>
    	/// Update a OrderMenuEntity
    	/// </summary>
		public static bool UpdateOrderMenu(OrderMenuEntity ordermenuEntity)
		{
			ordermenuEntity.ModifiedBy = CurrentUserName;
			ordermenuEntity.ModifiedDate = DateTime.Now;
			var ordermenuDA0 = new OrderMenuDAO();
			var ret = ordermenuDA0.UpdateOrderMenu(ordermenuEntity);
			PurgeCacheItems("OrderMenu_OrderMenu_" + ordermenuEntity.OrderMenuID);
			PurgeCacheItems("OrderMenu_OrderMenu");
         	return ret;
		}
	
		/// <summary>
    	/// Delete a OrderMenuEntity
    	/// </summary>
		public static bool DeleteOrderMenu(int _OrderMenuID)
		{
			var ordermenuDA0 = new OrderMenuDAO();
			var ret =  ordermenuDA0.DeleteOrderMenu(_OrderMenuID);
			PurgeCacheItems("OrderMenu_OrderMenu");
			return ret;
		}
		
		/// <summary>
        /// Returns an existing OrderMenu with the specified ID
        /// </summary>
		public static OrderMenuEntity GetOrderMenuByID(int _OrderMenuID)
		{
			OrderMenuEntity ordermenuEntity;
			var key = "OrderMenu_OrderMenu_" + _OrderMenuID;
			if (Cache[key] != null)
			{
				ordermenuEntity = (OrderMenuEntity)Cache[key];
			}
			else
			{
				var ordermenuDA0 = new OrderMenuDAO();
				ordermenuEntity = ordermenuDA0.GetOrderMenuByID(_OrderMenuID);
				CacheData(key, ordermenuEntity);
			}
			return ordermenuEntity;
		}

        public static List<OrderMenuEntity> GetOrderMenByCusID(string _CusId)
        {
            List<OrderMenuEntity> ordermenuEntity;
            var key = "OrderMenu_OrderMenu_" + _CusId;
            if (Cache[key] != null)
            {
                ordermenuEntity = (List<OrderMenuEntity>)Cache[key];
            }
            else
            {
                var ordermenuDA0 = new OrderMenuDAO();
                ordermenuEntity = ordermenuDA0.GetOrderMenuByCusID(_CusId);
                CacheData(key, ordermenuEntity);
            }
            return ordermenuEntity;
        }
		/// <summary>
        /// Returns a collection with all the OrderMenus
        /// </summary>
		public static List<OrderMenuEntity> GetAllOrderMenus()
		{
			List<OrderMenuEntity> OrderMenusEntity;
			const string key = "OrderMenu_OrderMenu";
			
			if (Cache[key] != null)
			{
				OrderMenusEntity = (List<OrderMenuEntity>)Cache[key];
			}
			else
			{
				var ordermenuDA0 = new OrderMenuDAO();
				OrderMenusEntity =  ordermenuDA0.GetAllOrderMenus();
				CacheData(key, OrderMenusEntity);
			}
			return OrderMenusEntity;
		}

		
		public static void PositionWithPriorityEdit(DropDownList ddlPosition)
        {
            var dh = new DataHelper();
            var dt = dh.PositionWithPriority("OrderMenuId", "OrderMenu");
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                ddlPosition.Items.Add(new ListItem((i + 1).ToString(), dt.Rows[i]["Priority"].ToString()));
            }
        }

        public static void PositionWithPriorityAdd(DropDownList ddlPosition)
        {
            var dh = new DataHelper();

            for (var i = 1; i <= dh.CountItem("OrderMenuId", "OrderMenu") + 1; i++)
            {
                ddlPosition.Items.Add(new ListItem(i.ToString()));
            }
        }
	}
}

