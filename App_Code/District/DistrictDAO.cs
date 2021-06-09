using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BIC.Entity;
using BIC.Utils;

namespace BIC.DAO
{
    public class DistrictDAO : DistrictProvider
    {
        #region Stored Procedure names

        private const string INSERT_DISTRICT = "[dbo].DistrictInsert";
        private const string UPDATE_DISTRICT = "[dbo].DistrictUpdate";
        private const string DELETE_DISTRICT = "[dbo].DistrictDelete";
        private const string SELECT_DISTRICT_BYID = "[dbo].DistrictGetByID";
        private const string SELECT_ALL_DISTRICT = "[dbo].DistrictsGetAll";
        private const string SELECT_DISTRICT_BY_CITYID = "[dbo].DistrictGetByCityID";

        #endregion Stored Procedure names

        /// <summary>
        /// Create a new DistrictEntity
        /// </summary>
        public override bool InsertDistrict(DistrictEntity entity)
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(INSERT_DISTRICT, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@DistrictName", SqlDbType.NVarChar).Value = entity.DistrictName;
                cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = entity.CityID;
                cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = entity.Priority;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                cmd.Parameters.Add("@ChuyenNhanh", SqlDbType.NVarChar).Value = entity.ChuyenNhanh;
                cmd.Parameters.Add("@ChuyenCham", SqlDbType.NVarChar).Value = entity.ChuyenCham;
                cmd.Parameters.Add("@MienPhiNhanh", SqlDbType.NVarChar).Value = entity.MienPhiNhanh;
                cmd.Parameters.Add("@MienPhiCham", SqlDbType.NVarChar).Value = entity.MienPhiCham;
                cmd.Parameters.Add("@NewColumn1", SqlDbType.NVarChar).Value = entity.NewColumn1;
                cmd.Parameters.Add("@NewColumn2", SqlDbType.NVarChar).Value = entity.NewColumn2;
                cmd.Parameters.Add("@NewColumn3", SqlDbType.NVarChar).Value = entity.NewColumn3;
                cmd.Parameters.Add("@DistrictID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                var ret = ExecuteNonQuery(cmd);
                entity.DistrictID = (Int32)cmd.Parameters["@DistrictID"].Value;
                cn.Close();
                return (ret == 1);
            }
        }

        /// <summary>
        /// Update a DistrictEntity
        /// </summary>
        public override bool UpdateDistrict(DistrictEntity entity)
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(UPDATE_DISTRICT, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@DistrictID", SqlDbType.Int).Value = entity.DistrictID;
                cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = entity.CityID;
                cmd.Parameters.Add("@DistrictName", SqlDbType.NVarChar).Value = entity.DistrictName;
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
        /// Deletes a DistrictEntity
        /// </summary>
        public override bool DeleteDistrict(int _DistrictID)
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(DELETE_DISTRICT, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@DistrictID", SqlDbType.Int).Value = _DistrictID;
                cn.Open();
                var ret = ExecuteNonQuery(cmd);
                cn.Close();
                return (ret == 1);
            }
        }

        /// <summary>
        /// Returns an existing District with the specified ID
        /// </summary>
        public override DistrictEntity GetDistrictByID(int _DistrictID)
        {
            DistrictEntity _DistrictEntity = null;
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(SELECT_DISTRICT_BYID, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@DistrictID", SqlDbType.Int).Value = _DistrictID;
                cn.Open();
                var reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    _DistrictEntity = GetDistrictFromReader(reader);
                }
                cn.Close();
            }
            return _DistrictEntity;
        }

        /// <summary>
        /// Returns a new DistrictEntity instance filled with the DataReader's current record data
        /// </summary>
        private DistrictEntity GetDistrictFromReader(IDataReader reader)
        {
            return new DistrictEntity(
                BicConvert.ToInt32(reader["DistrictID"]),
                BicConvert.ToInt32(reader["CityID"]),
                reader["DistrictName"].ToString().Trim(),
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
        /// Returns a collection with all the Districts
        /// </summary>
        public override List<DistrictEntity> GetAllDistricts()
        {
            List<DistrictEntity> _DistrictEntity;
            using (var cn = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand(SELECT_ALL_DISTRICT, cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                _DistrictEntity = GetDistrictCollectionFromReader(ExecuteReader(cmd));
                cn.Close();
            }
            return _DistrictEntity;
        }

        /// <summary>
        /// Returns a collection of DistrictEntity objects with the data read from the input DataReader
        /// </summary>
        private List<DistrictEntity> GetDistrictCollectionFromReader(IDataReader reader)
        {
            var districtEntity = new List<DistrictEntity>();
            while (reader.Read())
                districtEntity.Add(GetDistrictFromReader(reader));
            return districtEntity;
        }

        /// <summary>
        /// Returns a collection of Districts has specified CityID
        /// </summary>
        public override List<DistrictEntity> GetDistrictByCityID(int CityID)
        {
            List<DistrictEntity> _DistrictEntity;
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(SELECT_DISTRICT_BY_CITYID, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID;
                cn.Open();
                _DistrictEntity = GetDistrictCollectionFromReader(ExecuteReader(cmd));
                cn.Close();
            }
            return _DistrictEntity;
        }
    }
}