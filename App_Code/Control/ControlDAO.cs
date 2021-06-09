using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BIC.Entity;
using BIC.Utils;

namespace BIC.DAO
{
    public class ControlDAO : ControlProvider
    {
        #region Stored Procedure names

        private const string INSERT_CONTROL = "[dbo].ControlInsert";
        private const string UPDATE_CONTROL = "[dbo].ControlUpdate";
        private const string DELETE_CONTROL = "[dbo].ControlDelete";
        private const string SELECT_CONTROL_BYID = "[dbo].ControlGetByID";
        private const string SELECT_ALL_CONTROL = "[dbo].ControlsGetAll";

        #endregion

        /// <summary>
        /// Create a new ControlEntity
        /// </summary>
        public override bool InsertControl(ControlEntity entity)
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(INSERT_CONTROL, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ControlName", SqlDbType.NVarChar).Value = entity.ControlName;
                cmd.Parameters.Add("@FolderName", SqlDbType.NVarChar).Value = entity.FolderName;
                cmd.Parameters.Add("@ControlUrl", SqlDbType.NVarChar).Value = entity.ControlUrl;
                cmd.Parameters.Add("@LoadUrl", SqlDbType.Bit).Value = entity.LoadUrl;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                cmd.Parameters.Add("@ControlID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                entity.ControlID = (Int32) cmd.Parameters["@ControlID"].Value;
                cn.Close();
                return (ret == 1);
            }
        }

        /// <summary>
        /// Update a ControlEntity
        /// </summary>
        public override bool UpdateControl(ControlEntity entity)
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(UPDATE_CONTROL, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ControlID", SqlDbType.Int).Value = entity.ControlID;
                cmd.Parameters.Add("@ControlName", SqlDbType.NVarChar).Value = entity.ControlName;
                cmd.Parameters.Add("@FolderName", SqlDbType.NVarChar).Value = entity.FolderName;
                cmd.Parameters.Add("@ControlUrl", SqlDbType.NVarChar).Value = entity.ControlUrl;
                cmd.Parameters.Add("@LoadUrl", SqlDbType.Bit).Value = entity.LoadUrl;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                cn.Close();
                return (ret == 1);
            }
        }

        /// <summary>
        /// Deletes a ControlEntity
        /// </summary>
        public override bool DeleteControl(int _ControlID)
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(DELETE_CONTROL, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ControlID", SqlDbType.Int).Value = _ControlID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                cn.Close();
                return (ret == 1);
            }
        }

        /// <summary>
        /// Returns an existing Control with the specified ID
        /// </summary>
        public override ControlEntity GetControlByID(int _ControlID)
        {
            ControlEntity _ControlEntity = null;
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(SELECT_CONTROL_BYID, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ControlID", SqlDbType.Int).Value = _ControlID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    _ControlEntity = GetControlFromReader(reader);
                }
                cn.Close();
            }
            return _ControlEntity;
        }


        /// <summary>
        /// Returns a new ControlEntity instance filled with the DataReader's current record data
        /// </summary>
        private ControlEntity GetControlFromReader(IDataReader reader)
        {
            return new ControlEntity(
                BicConvert.ToInt32(reader["ControlID"]),
                reader["ControlName"].ToString().Trim(),
                reader["FolderName"].ToString().Trim(),
                reader["ControlUrl"].ToString().Trim(),
                BicConvert.ToBoolean(reader["LoadUrl"]),
                BicConvert.ToInt32(reader["Priority"]),
                BicConvert.ToBoolean(reader["IsActive"]));
        }

        /// <summary>
        /// Returns a collection with all the Controls
        /// </summary>
        public override List<ControlEntity> GetAllControls()
        {
            List<ControlEntity> _ControlEntity = null;
            using (var cn = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand(SELECT_ALL_CONTROL, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                _ControlEntity = GetControlCollectionFromReader(ExecuteReader(cmd));
                cn.Close();
            }
            return _ControlEntity;
        }

        /// <summary>
        /// Returns a collection of ControlEntity objects with the data read from the input DataReader
        /// </summary>
        private List<ControlEntity> GetControlCollectionFromReader(IDataReader reader)
        {
            var controlEntity = new List<ControlEntity>();
            while (reader.Read())
                controlEntity.Add(GetControlFromReader(reader));
            return controlEntity;
        }
    }
}