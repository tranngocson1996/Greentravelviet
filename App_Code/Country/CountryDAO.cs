using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BIC.Entity;
using BIC.Utils;

namespace BIC.DAO
{
    public class CountryDAO : CountryProvider
    {
        #region Stored Procedure names

        private const string INSERT_COUNTRY = "[dbo].CountryInsert";
        private const string UPDATE_COUNTRY = "[dbo].CountryUpdate";
        private const string DELETE_COUNTRY = "[dbo].CountryDelete";
        private const string SELECT_COUNTRY_BYID = "[dbo].CountryGetByID";
        private const string SELECT_ALL_COUNTRY = "[dbo].CountriesGetAll";

        #endregion Stored Procedure names

        /// <summary>
        /// Create a new CountryEntity
        /// </summary>
        public override bool InsertCountry(CountryEntity entity)
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(INSERT_COUNTRY, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CountryName", SqlDbType.NVarChar).Value = entity.CountryName;
                cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = entity.Priority;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                cmd.Parameters.Add("@CountryID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                entity.CountryId = (Int32)cmd.Parameters["@CountryID"].Value;
                cn.Close();
                return (ret == 1);
            }
        }

        /// <summary>
        /// Update a CountryEntity
        /// </summary>
        public override bool UpdateCountry(CountryEntity entity)
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(UPDATE_COUNTRY, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = entity.CountryId;
                cmd.Parameters.Add("@CountryName", SqlDbType.NVarChar).Value = entity.CountryName;
                cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = entity.Priority;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                cn.Close();
                return (ret == 1);
            }
        }

        /// <summary>
        /// Deletes a CountryEntity
        /// </summary>
        public override bool DeleteCountry(int _CountryID)
        {
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(DELETE_COUNTRY, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = _CountryID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                cn.Close();
                return (ret == 1);
            }
        }

        /// <summary>
        /// Returns an existing Country with the specified ID
        /// </summary>
        public override CountryEntity GetCountryByID(int _CountryID)
        {
            CountryEntity _CountryEntity = null;
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(SELECT_COUNTRY_BYID, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = _CountryID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    _CountryEntity = GetCountryFromReader(reader);
                }
                cn.Close();
            }
            return _CountryEntity;
        }

        /// <summary>
        /// Returns a new CountryEntity instance filled with the DataReader's current record data
        /// </summary>
        private CountryEntity GetCountryFromReader(IDataReader reader)
        {
            return new CountryEntity(
                BicConvert.ToInt32(reader["CountryId"]),
                reader["CountryName"].ToString().Trim(),
                BicConvert.ToInt32(reader["Priority"]),
                BicConvert.ToBoolean(reader["IsActive"]));
        }

        /// <summary>
        /// Returns a collection with all the Countrys
        /// </summary>
        public override List<CountryEntity> GetAllCountrys()
        {
            List<CountryEntity> _CountryEntity = null;
            using (var cn = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand(SELECT_ALL_COUNTRY, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                _CountryEntity = GetCountryCollectionFromReader(ExecuteReader(cmd));
                cn.Close();
            }
            return _CountryEntity;
        }

        /// <summary>
        /// Returns a collection of CountryEntity objects with the data read from the input DataReader
        /// </summary>
        private List<CountryEntity> GetCountryCollectionFromReader(IDataReader reader)
        {
            var countryEntity = new List<CountryEntity>();
            while (reader.Read())
                countryEntity.Add(GetCountryFromReader(reader));
            return countryEntity;
        }
    }
}