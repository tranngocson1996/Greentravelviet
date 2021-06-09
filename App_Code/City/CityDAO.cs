using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BIC.Entity;
using BIC.Utils;

namespace BIC.DAO
{
    public class CityDAO : CityProvider
    {
        #region Stored Procedure names

        private const string INSERT_CITY = "[dbo].CityInsert";
        private const string UPDATE_CITY = "[dbo].CityUpdate";
        private const string DELETE_CITY = "[dbo].CityDelete";
        private const string SELECT_CITY_BYID = "[dbo].CityGetByID";
        private const string SELECT_ALL_CITY = "[dbo].CitiesGetAll";

        #endregion Stored Procedure names

        /// <summary>
        /// Create a new CityEntity
        /// </summary>
        public override bool InsertCity(CityEntity entity)
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(INSERT_CITY, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@CityName", SqlDbType.NVarChar).Value = entity.CityName;
                cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = entity.Priority;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                cmd.Parameters.Add("@ChuyenNhanh", SqlDbType.NVarChar).Value = entity.ChuyenNhanh;
                cmd.Parameters.Add("@ChuyenCham", SqlDbType.NVarChar).Value = entity.ChuyenCham;
                cmd.Parameters.Add("@MienPhiNhanh", SqlDbType.NVarChar).Value = entity.MienPhiNhanh;
                cmd.Parameters.Add("@MienPhiCham", SqlDbType.NVarChar).Value = entity.MienPhiCham;
                cmd.Parameters.Add("@NewColumn1", SqlDbType.NVarChar).Value = entity.NewColumn1;
                cmd.Parameters.Add("@NewColumn2", SqlDbType.NVarChar).Value = entity.NewColumn2;
                cmd.Parameters.Add("@NewColumn3", SqlDbType.NVarChar).Value = entity.NewColumn3;
                cmd.Parameters.Add("@CityID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                var ret = ExecuteNonQuery(cmd);
                entity.CityID = (Int32)cmd.Parameters["@CityID"].Value;
                cn.Close();
                return (ret == 1);
            }
        }

        /// <summary>
        /// Update a CityEntity
        /// </summary>
        public override bool UpdateCity(CityEntity entity)
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(UPDATE_CITY, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = entity.CityID;
                cmd.Parameters.Add("@CityName", SqlDbType.NVarChar).Value = entity.CityName;
                cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = entity.Priority;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                cmd.Parameters.Add("@ChuyenNhanh", SqlDbType.NVarChar).Value = entity.ChuyenNhanh;
                cmd.Parameters.Add("@ChuyenCham", SqlDbType.NVarChar).Value = entity.ChuyenCham;
                cmd.Parameters.Add("@MienPhiNhanh", SqlDbType.NVarChar).Value = entity.MienPhiNhanh;
                cmd.Parameters.Add("@MienPhiCham", SqlDbType.NVarChar).Value = entity.MienPhiCham;
                cmd.Parameters.Add("@NewColumn1", SqlDbType.NVarChar).Value = entity.NewColumn1;
                cmd.Parameters.Add("@NewColumn2", SqlDbType.NVarChar).Value = entity.NewColumn2;
                cmd.Parameters.Add("@NewColumn3", SqlDbType.NVarChar).Value = entity.NewColumn3;
                cn.Open();
                var ret = ExecuteNonQuery(cmd);
                cn.Close();
                return (ret == 1);
            }
        }

        /// <summary>
        /// Deletes a CityEntity
        /// </summary>
        public override bool DeleteCity(int _CityID)
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(DELETE_CITY, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = _CityID;
                cn.Open();
                var ret = ExecuteNonQuery(cmd);
                cn.Close();
                return (ret == 1);
            }
        }

        /// <summary>
        /// Returns an existing City with the specified ID
        /// </summary>
        public override CityEntity GetCityByID(int _CityID)
        {
            CityEntity _CityEntity = null;
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(SELECT_CITY_BYID, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = _CityID;
                cn.Open();
                var reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    _CityEntity = GetCityFromReader(reader);
                }
                cn.Close();
            }
            return _CityEntity;
        }

        /// <summary>
        /// Returns a new CityEntity instance filled with the DataReader's current record data
        /// </summary>
        private CityEntity GetCityFromReader(IDataReader reader)
        {
            return new CityEntity(
                BicConvert.ToInt32(reader["CityID"]),
                reader["CityName"].ToString().Trim(),
                BicConvert.ToInt32(reader["Priority"]),
                BicConvert.ToBoolean(reader["IsActive"]),
                reader["ChuyenNhanh"].ToString().Trim(),
                reader["ChuyenCham"].ToString().Trim(),
                reader["MienPhiNhanh"].ToString().Trim(),
                reader["MienPhiCham"].ToString().Trim(),
                reader["NewColumn1"].ToString().Trim(),
                reader["NewColumn2"].ToString().Trim(),
                reader["NewColumn3"].ToString().Trim());
        }

        /// <summary>
        /// Returns a collection with all the Citys
        /// </summary>
        public override List<CityEntity> GetAllCitys()
        {
            List<CityEntity> _CityEntity;
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(SELECT_ALL_CITY, cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                _CityEntity = GetCityCollectionFromReader(ExecuteReader(cmd));
                cn.Close();
            }
            return _CityEntity;
        }

        /// <summary>
        /// Returns a collection of CityEntity objects with the data read from the input DataReader
        /// </summary>
        private List<CityEntity> GetCityCollectionFromReader(IDataReader reader)
        {
            var cityEntity = new List<CityEntity>();
            while (reader.Read())
                cityEntity.Add(GetCityFromReader(reader));
            return cityEntity;
        }
    }
}