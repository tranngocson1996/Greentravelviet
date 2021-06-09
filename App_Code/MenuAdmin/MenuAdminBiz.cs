using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using BIC.DAO;
using BIC.Entity;
using BIC.Utils;
using Telerik.Web.UI;

namespace BIC.Biz
{
    public class MenuAdminBiz : BaseMenuAdmin
    {
        /// <summary>
        /// Create a new MenuAdmin
        /// </summary>
        public static bool InsertMenuAdmin(MenuAdminEntity menuadminEntity)
        {
            var menuAdminDao = new MenuAdminDAO();
            bool ret = menuAdminDao.InsertMenuAdmin(menuadminEntity);
            PurgeCacheItems("MenuAdmin_MenuAdmin");
            return ret;
        }

        /// <summary>
        /// Update a MenuAdminEntity
        /// </summary>
        public static bool UpdateMenuAdmin(MenuAdminEntity menuadminEntity)
        {
            var menuAdminDao = new MenuAdminDAO();
            bool ret = menuAdminDao.UpdateMenuAdmin(menuadminEntity);
            PurgeCacheItems("MenuAdmin_MenuAdmin_" + menuadminEntity.MenuAdminID);
            PurgeCacheItems("MenuAdmin_MenuAdmin");
            return ret;
        }

        /// <summary>
        /// Delete a MenuAdminEntity
        /// </summary>
        public static bool DeleteMenuAdmin(int menuAdminId)
        {
            var menuAdminDao = new MenuAdminDAO();
            bool ret = menuAdminDao.DeleteMenuAdmin(menuAdminId);
            PurgeCacheItems("MenuAdmin_MenuAdmin");
            return ret;
        }

        /// <summary>
        /// Returns an existing MenuAdmin with the specified ID
        /// </summary>
        public static MenuAdminEntity GetMenuAdminByID(int menuAdminId)
        {
            MenuAdminEntity menuadminEntity;
            string key = "MenuAdmin_MenuAdmin_" + menuAdminId;
            if (Cache[key] != null)
            {
                menuadminEntity = (MenuAdminEntity)Cache[key];
            }
            else
            {
                var menuAdminDao = new MenuAdminDAO();
                menuadminEntity = menuAdminDao.GetMenuAdminByID(menuAdminId);
                CacheData(key, menuadminEntity);
            }
            return menuadminEntity;
        }

     /// <summary>
        /// Returns an existing MenuAdmin with the specified Control ID
        /// </summary>
        public static MenuAdminEntity GetMenuAdminByControlID(int controlId)
        {
            MenuAdminEntity menuadminEntity;
            string key = "MenuAdmin_MenuAdmin_control_" + controlId;
            if (Cache[key] != null)
            {
                menuadminEntity = (MenuAdminEntity)Cache[key];
            }
            else
            {
                var menuAdminDao = new MenuAdminDAO();
                menuadminEntity = menuAdminDao.GetMenuAdminByControlID(controlId);
                CacheData(key, menuadminEntity);
            }
            return menuadminEntity;
        }

        /// <summary>
        /// Returns a collection with all the MenuAdmins
        /// </summary>
        public static List<MenuAdminEntity> GetAllMenuAdmins()
        {
            List<MenuAdminEntity> menuAdminsEntity;
            const string key = "MenuAdmin_MenuAdmin";

            if (Cache[key] != null)
            {
                menuAdminsEntity = (List<MenuAdminEntity>)Cache[key];
            }
            else
            {
                var menuAdminDao = new MenuAdminDAO();
                menuAdminsEntity = menuAdminDao.GetAllMenuAdmins();
                CacheData(key, menuAdminsEntity);
            }
            return menuAdminsEntity;
        }

        /// <summary>
        /// Changing position of a item in MenuAdmin
        /// </summary>
        public static bool ChangePosition(int curId, int destId, int dropPosition)
        {
            var menuAdminDao = new MenuAdminDAO();
            bool ret = menuAdminDao.ChangePosition(curId, destId, dropPosition);
            PurgeCacheItems("MenuAdmin_MenuAdmin");
            return ret;
        }

        /// <summary>
        /// Up or down a item in MenuAdmin 
        /// </summary>
        public static bool MenuAdminUpDown(int menuAdminId, bool isUp)
        {
            var menuAdminDao = new MenuAdminDAO();
            bool ret = menuAdminDao.MenuAdminUpDown(menuAdminId, isUp);
            PurgeCacheItems("MenuAdmin_MenuAdmin");
            return ret;
        }

        /// <summary>
        /// Returns a tree data with all the MenuAdmins
        /// </summary>
        private static DataTable GetMenuAdminTree()
        {
            DataTable data;
            const string key = "MenuAdmin_MenuAdminTree";

            if (Cache[key] != null)
            {
                data = (DataTable)Cache[key];
            }
            else
            {
                var menuAdminDao = new MenuAdminDAO();
                data = menuAdminDao.GetMenuAdminTree();
                CacheData(key, data);
            }
            return data;
        }


        public static void BuildMenuAdminTree(DropDownList ddlMenuAdmin)
        {
            ddlMenuAdmin.Items.Clear();
            DataRow[] arrProductRow = GetMenuAdminTree().Select();
            foreach (DataRow dr in arrProductRow)
            {
                int iParentId = BicConvert.ToInt32(dr[MenuAdminEntity.FIELD_PARENTID]);
                int iMenuAdminId = BicConvert.ToInt32(dr[MenuAdminEntity.FIELD_MENUADMINID]);

                //Khoi tao list Item
                var lt = new ListItem
                             {
                                 Value = iMenuAdminId.ToString(),
                                 Text = BicConvert.ToString(dr[MenuAdminEntity.FIELD_NAME])

                             };

                //Kiem tra xem item hien tai co phai la danh muc goc khong);
                if (iParentId == 0)
                {
                    lt.Text = BicConvert.ToString(dr[MenuAdminEntity.FIELD_NAME]);
                    ddlMenuAdmin.Items.Add(lt);
                }
                else
                {
                    ListItem subLt =
                        ddlMenuAdmin.Items.FindByValue(BicConvert.ToString(dr[MenuAdminEntity.FIELD_PARENTID]));
                    if (subLt != null)
                    {
                        ddlMenuAdmin.Items.Insert(ddlMenuAdmin.Items.IndexOf(subLt) + 1, lt);
                    }
                    else
                    {
                        ddlMenuAdmin.Items.Add(lt);
                    }
                }
            }
            ddlMenuAdmin.Items.Insert(0, new ListItem("<<Danh mục gốc>>", "0"));
        }

        private static DataTable MenuAdminGetByUserName(string userName, int typeOfMenu)
        {
            DataTable data;
            string key = "MenuAdmin_MenuAdminGetByUserName" + userName + typeOfMenu;

            if (Cache[key] != null)
            {
                data = (DataTable)Cache[key];
            }
            else
            {
                var menuAdminDao = new MenuAdminDAO();
                data = menuAdminDao.MenuAdminGetByUserName(userName, typeOfMenu);
                CacheData(key, data);
            }
            return data;
        }

        public static void BuiltMenuAdmin(RadMenu rmnuHorizontal, int typeOfMenu)
        {
            DataTable dt = MenuAdminGetByUserName(BicMemberShip.CurrentUserName, typeOfMenu);
            DataRow[] arrMenuAdminRow = dt.Select();
            //Khoi tao hashtable luu vet parentID cua tung element

            foreach (DataRow dr in arrMenuAdminRow)
            {
                int iParentId = BicConvert.ToInt32(dr[MenuAdminEntity.FIELD_PARENTID]);
                int iMenuId = BicConvert.ToInt32(dr[MenuAdminEntity.FIELD_MENUADMINID]);
                string sUrl = BicConvert.ToString(dr[MenuAdminEntity.FIELD_MENUURL]);
                string sName = BicConvert.ToString(dr[MenuAdminEntity.FIELD_NAME]);
                string icon = BicConvert.ToString(dr[MenuAdminEntity.FIELD_ICON]);
                //Khoi tao RadMenuItem
                var category = new RadMenuItem
                                {
                                    Text = BicResource.GetValue("Admin",sName),
                                    Value = iMenuId.ToString(),
                                    Target = BicConvert.ToString(dr[MenuAdminEntity.FIELD_TARGET]),
                                    AccessKey = BicConvert.ToString(dr[MenuAdminEntity.FIELD_KEYBOARD]),
                                };
                if (icon != string.Empty)
                {
                    category.ImageUrl = string.Format("{0}admin/Styles/icon/{1}", BicApplication.URLRoot, icon);
                }

                //Kiem tra neu la link tu nguon khac, he thong se khong build link nua.
                if (!sUrl.Equals(string.Empty))
                    if (sUrl.Contains("http") || sUrl.Contains("https"))
                        category.NavigateUrl = sUrl;
                    else
                    {
                        sUrl = string.Format("{0}admin/default.aspx?mid={1}" + sUrl, BicApplication.URLRoot, iMenuId);
                        if (sUrl.IndexOf("l=") == -1)
                            sUrl += "&l=" + BicHtml.GetRequestString("l", BicXML.ToString("DefaultLanguageAdmin", "SearchEngine"));
                    }
                else
                    sUrl = "#";
                category.NavigateUrl = sUrl;
                if (iParentId == 0)
                    rmnuHorizontal.Items.Add(category);
                else
                {
                    using (RadMenuItem subCategory = rmnuHorizontal.FindItemByValue(iParentId.ToString()))
                    {
                        if (subCategory != null)
                            subCategory.Items.Add(category);
                    }
                }
            }

            // Selected menuitem

            if (BicHtml.GetRequestString("cid") != string.Empty)
            {
                int iMenuId = BicHtml.GetRequestString("cid", 0);
                if (iMenuId != 0)
                {
                    RadMenuItem radMenuItem = rmnuHorizontal.FindItemByValue(iMenuId.ToString());
                    if (radMenuItem != null)
                        radMenuItem.CssClass = "expanded";
                }
            }
        }
    }
}