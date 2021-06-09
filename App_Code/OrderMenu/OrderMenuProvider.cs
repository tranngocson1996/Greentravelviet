using System.Collections.Generic;
using System.Data;
using BIC.Entity;

namespace BIC.DAO
{
    public abstract class OrderMenuProvider : DataAccess
    {
        public abstract bool InsertOrderMenu(OrderMenuEntity entity);
        public abstract bool UpdateOrderMenu(OrderMenuEntity entity);
        public abstract bool DeleteOrderMenu(int _OrderMenuID);
        public abstract OrderMenuEntity GetOrderMenuByID(int _OrderMenuID);
        public abstract List<OrderMenuEntity> GetAllOrderMenus();
    }
}

