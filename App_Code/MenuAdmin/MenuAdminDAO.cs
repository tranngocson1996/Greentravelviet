using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BIC.Entity;
using BIC.Utils;

namespace BIC.DAO
{
    public class MenuAdminDAO : MenuAdminProvider
    {
        #region Stored Procedure names

        private const string INSERT_MENUADMIN = "[dbo].MenuAdminInsert";
        private const string UPDATE_MENUADMIN = "[dbo].MenuAdminUpdate";
        private const string DELETE_MENUADMIN = "[dbo].MenuAdminDelete";
        private const string SELECT_MENUADMIN_BYID = "[dbo].MenuAdminGetByID";
        private const string SELECT_MENUADMIN_BYCONTROLID = "[dbo].MenuAdminGetByControlID";
        private const string SELECT_ALL_MENUADMIN = "[dbo].MenuAdminsGetAll";
        private const string GET_MENUADMIN_TREE = "[dbo].MenuAdminTree";
        private const string MENUADMIN_CHANGE_POSITION = "[dbo].MenuAdminChangePosition";
        private const string MENUADMIN_UP_DOWN = "[dbo].MenuAdminUpDown";
        private const string MENUADMIN_GET_BY_USERNAME = "[dbo].MenuAdminGetByUserName";
        #endregion

        /// <summary>
        /// Create a new MenuAdminEntity
        /// </summary>
        public override bool InsertMenuAdmin(MenuAdminEntity entity)
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(INSERT_MENUADMIN, cn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = entity.Name;
                cmd.Parameters.Add("@MenuUrl", SqlDbType.NVarChar).Value = entity.MenuUrl;
                cmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = entity.ParentID;
                cmd.Parameters.Add("@ControlID", SqlDbType.Int).Value = entity.ControlID;
                cmd.Parameters.Add("@Target", SqlDbType.NVarChar).Value = entity.Target;
                cmd.Parameters.Add("@Icon", SqlDbType.NVarChar).Value = entity.Icon;
                cmd.Parameters.Add("@TypeOfMenu", SqlDbType.Int).Value = entity.TypeOfMenu;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = entity.Description;
                cmd.Parameters.Add("@KeyBoard", SqlDbType.NVarChar).Value = entity.KeyBoard;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                cn.Close();
                return (ret == 1);
            }
        }

        /// <summary>
        /// Update a MenuAdminEntity
        /// </summary>
        public override bool UpdateMenuAdmin(MenuAdminEntity entity)
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(UPDATE_MENUADMIN, cn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.Add("@MenuAdminID", SqlDbType.Int).Value = entity.MenuAdminID;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = entity.Name;
                cmd.Parameters.Add("@MenuUrl", SqlDbType.NVarChar).Value = entity.MenuUrl;
                cmd.Parameters.Add("@ControlID", SqlDbType.Int).Value = entity.ControlID;
                cmd.Parameters.Add("@Target", SqlDbType.NVarChar).Value = entity.Target;
                cmd.Parameters.Add("@Icon", SqlDbType.NVarChar).Value = entity.Icon;
                cmd.Parameters.Add("@TypeOfMenu", SqlDbType.Int).Value = entity.TypeOfMenu;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = entity.Description;
                cmd.Parameters.Add("@KeyBoard", SqlDbType.NVarChar).Value = entity.KeyBoard;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                cn.Close();
                return (ret == 1);
            }
        }

        /// <summary>
        /// Deletes a MenuAdminEntity
        /// </summary>
        public override bool DeleteMenuAdmin(int menuAdminId)
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(DELETE_MENUADMIN, cn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.Add("@MenuAdminID", SqlDbType.Int).Value = menuAdminId;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                cn.Close();
                return (ret == 1);
            }
        }

        /// <summary>
        /// Returns an existing MenuAdmin with the specified ID
        /// </summary>
        public override MenuAdminEntity GetMenuAdminByID(int menuAdminId)
        {
            MenuAdminEntity menuAdminEntity = null;
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(SELECT_MENUADMIN_BYID, cn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.Add("@MenuAdminID", SqlDbType.Int).Value = menuAdminId;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    menuAdminEntity = GetMenuAdminFromReader(reader);
                }
                cn.Close();
            }
            return menuAdminEntity;
        }


        /// <summary>
        /// Returns an existing MenuAdmin with the specified ControlID
        /// </summary>
        public override MenuAdminEntity GetMenuAdminByControlID(int controlId)
        {
            MenuAdminEntity menuAdminEntity = null;
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(SELECT_MENUADMIN_BYCONTROLID, cn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.Add("@ControlID", SqlDbType.Int).Value = controlId;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    menuAdminEntity = GetMenuAdminFromReader(reader);
                }
                cn.Close();
            }
            return menuAdminEntity;
        }

        /// <summary>
        /// Returns a new MenuAdminEntity instance filled with the DataReader's current record data
        /// </summary>
        private MenuAdminEntity GetMenuAdminFromReader(IDataReader reader)
        {
            return new MenuAdminEntity(
                BicConvert.ToInt32(reader["MenuAdminID"]),
                reader["Name"].ToString().Trim(),
                reader["MenuUrl"].ToString().Trim(),
                BicConvert.ToInt32(reader["Priority"]),
                BicConvert.ToInt32(reader["ParentID"]),
                BicConvert.ToInt32(reader["ControlID"]),
                reader["Target"].ToString().Trim(),
                reader["Icon"].ToString().Trim(),
                BicConvert.ToInt32(reader["TypeOfMenu"]),
                reader["Description"].ToString().Trim(),
                BicConvert.ToString(reader["NavigatePath"]),
                BicConvert.ToBoolean(reader["IsActive"]),  reader["KeyBoard"].ToString().Trim() );
        }

        /// <summary>
        /// Returns a collection with all the MenuAdmins
        /// </summary>
        public override List<MenuAdminEntity> GetAllMenuAdmins()
        {
            List<MenuAdminEntity> menuAdminEntity;
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(SELECT_ALL_MENUADMIN, cn) {CommandType = CommandType.StoredProcedure};
                cn.Open();
                menuAdminEntity = GetMenuAdminCollectionFromReader(ExecuteReader(cmd));
                cn.Close();
            }
            return menuAdminEntity;
        }

        /// <summary>
        /// Returns a collection of MenuAdminEntity objects with the data read from the input DataReader
        /// </summary>
        private List<MenuAdminEntity> GetMenuAdminCollectionFromReader(IDataReader reader)
        {
            var menuadminEntity = new List<MenuAdminEntity>();
            while (reader.Read())
                menuadminEntity.Add(GetMenuAdminFromReader(reader));
            return menuadminEntity;
        }

        /// <summary>
        /// Returns a tree data with all the MenuAdmins
        /// </summary>
        public override DataTable GetMenuAdminTree()
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(GET_MENUADMIN_TREE, cn) {CommandType = CommandType.StoredProcedure};
                DataTable tb = ExecuteProcedure(cmd);
                return tb;
            }
        }

        /// <summary>
        /// Changing position of a item in MenuAdmin
        /// </summary>
        public override bool ChangePosition(int curId, int destId, int dropPosition)
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(MENUADMIN_CHANGE_POSITION, cn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.Add("@CurID", SqlDbType.Int).Value = curId;
                cmd.Parameters.Add("@DestID", SqlDbType.Int).Value = destId;
                cmd.Parameters.Add("@DropPosition", SqlDbType.Int).Value = dropPosition;
                cn.Open();
                bool ret = Convert.ToBoolean(ExecuteScalar(cmd));
                cn.Close();
                return ret;
            }
        }

        /// <summary>
        /// Up or down a item in MenuAdmin 
        /// </summary>
        public override bool MenuAdminUpDown(int menuAdminId, bool isUp)
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(MENUADMIN_UP_DOWN, cn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.Add("@MenuAdminID", SqlDbType.Int).Value = menuAdminId;
                cmd.Parameters.Add("@IsUp", SqlDbType.Int).Value = isUp;
                cn.Open();
                bool ret = Convert.ToBoolean(ExecuteScalar(cmd));
                cn.Close();
                return ret;
            }
        }

        public override DataTable MenuAdminGetByUserName(string userName, int typeOfMenu)
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(MENUADMIN_GET_BY_USERNAME, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userName;
                cmd.Parameters.Add("@TypeOfMenu", SqlDbType.Int).Value = typeOfMenu;
                var tb = ExecuteProcedure(cmd);
                return tb;
            }
        }
    }
}