using System.Collections.Generic;
using System.Data;
using BIC.Entity;

namespace BIC.DAO
{
	public abstract class OrderDetailProvider : DataAccess
	{
		public abstract bool InsertOrderDetail(OrderDetailEntity entity );
		public abstract bool UpdateOrderDetail(OrderDetailEntity entity );
		public abstract bool DeleteOrderDetail(int _OrderDetailID);
		public abstract OrderDetailEntity GetOrderDetailByID(int _OrderDetailID);
		public abstract List<OrderDetailEntity> GetAllOrderDetails();
	    public abstract List<OrderDetailEntity> GetOrderDetailByOrderMenuID(int orderMenuID);
	}
}

