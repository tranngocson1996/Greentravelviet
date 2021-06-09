using System.Collections.Generic;
using System.Data;
using BIC.Entity;

namespace BIC.DAO
{
    public abstract class MenuAdminProvider : DataAccess
    {
        public abstract bool InsertMenuAdmin(MenuAdminEntity entity);
        public abstract bool UpdateMenuAdmin(MenuAdminEntity entity);
        public abstract bool DeleteMenuAdmin(int menuAdminId);
        public abstract MenuAdminEntity GetMenuAdminByID(int menuAdminId);
        public abstract MenuAdminEntity GetMenuAdminByControlID(int controlId);
        public abstract List<MenuAdminEntity> GetAllMenuAdmins();
        public abstract bool ChangePosition(int curId, int destId, int dropPosition);
        public abstract bool MenuAdminUpDown(int menuAdminId, bool isUp);
        public abstract DataTable GetMenuAdminTree();
        public abstract DataTable MenuAdminGetByUserName(string userName, int typeOfMenu);
    }
}