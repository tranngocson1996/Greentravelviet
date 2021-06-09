using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BIC.Entity;
using BIC.Utils;
namespace BIC.DAO
{
    public class CategoryDAO : CategoryProvider
    {
        #region Stored Procedure names
        private const string INSERT_CATEGORY = "[dbo].CategoryInsert";
        private const string UPDATE_CATEGORY = "[dbo].CategoryUpdate";
        private const string DELETE_CATEGORY = "[dbo].CategoryDelete";
        private const string SELECT_CATEGORY_BYID = "[dbo].CategoryGetByID";
        private const string SELECT_ALL_CATEGORY = "[dbo].CategoriesGetAll";
        private const string SELECT_CATEGORY_BY_TYPE = "[dbo].CategoriesGetByType";

        #endregion

        /// <summary>
        /// Create a new CategoryEntity
        /// </summary>
        public override bool InsertCategory(CategoryEntity entity)
        {

            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(INSERT_CATEGORY, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = entity.Name;
                cmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = entity.Value;
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = entity.Note;
                cmd.Parameters.Add("@TypeOfCategory", SqlDbType.Int).Value = entity.TypeOfCategory;
                cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = entity.Priority;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                var ret = ExecuteNonQuery(cmd);
                entity.CategoryID = (Int32)cmd.Parameters["@CategoryID"].Value;
                cn.Close();
                return (ret == 1);
            }

        }

        /// <summary>
        /// Update a CategoryEntity
        /// </summary>
        public override bool UpdateCategory(CategoryEntity entity)
        {

            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(UPDATE_CATEGORY, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = entity.CategoryID;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = entity.Name;
                cmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = entity.Value;
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = entity.Note;
                cmd.Parameters.Add("@TypeOfCategory", SqlDbType.Int).Value = entity.TypeOfCategory;
                cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = entity.Priority;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                cn.Open();
                var ret = ExecuteNonQuery(cmd);
                cn.Close();
                return (ret == 1);
            }

        }

        /// <summary>
        /// Deletes a CategoryEntity
        /// </summary>
        public override bool DeleteCategory(int _CategoryID)
        {

            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(DELETE_CATEGORY, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = _CategoryID;
                cn.Open();
                var ret = ExecuteNonQuery(cmd);
                cn.Close();
                return (ret == 1);
            }

        }

        /// <summary>
        /// Returns an existing Category with the specified ID
        /// </summary>
        public override CategoryEntity GetCategoryByID(int _CategoryID)
        {
            CategoryEntity _CategoryEntity = null;
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(SELECT_CATEGORY_BYID, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = _CategoryID;
                cn.Open();
                var reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    _CategoryEntity = GetCategoryFromReader(reader);
                }
                cn.Close();
            }
            return _CategoryEntity;
        }


        /// <summary>
        /// Returns a new CategoryEntity instance filled with the DataReader's current record data
        /// </summary>
        private CategoryEntity GetCategoryFromReader(IDataReader reader)
        {
            return new CategoryEntity(
                BicConvert.ToInt32(reader["CategoryID"]),
                reader["Name"].ToString().Trim(),
                reader["Value"].ToString().Trim(),
                reader["Note"].ToString().Trim(),
                BicConvert.ToInt32(reader["TypeOfCategory"]),
                BicConvert.ToInt32(reader["Priority"]),
                BicConvert.ToBoolean(reader["IsActive"]));
        }

        /// <summary>
        /// Returns a collection with all the Categorys
        /// </summary>
        public override List<CategoryEntity> GetAllCategorys()
        {
            List<CategoryEntity> _CategoryEntity;
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(SELECT_ALL_CATEGORY, cn) { CommandType = CommandType.StoredProcedure };
                cn.Open();
                _CategoryEntity = GetCategoryCollectionFromReader(ExecuteReader(cmd));
                cn.Close();
            }
            return _CategoryEntity;
        }
        /// <summary>
        /// Get Categories by Type
        /// </summary>
        /// <param name="type">giá trị của trường Type (int)</param>
        /// <returns>Trả về một list Category lấy theo trường Type</returns>
        public override List<CategoryEntity> GetCategoriesByType(int type)
        {
            var lstCategoryEntities = new List<CategoryEntity>();
            using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                var cmd = new SqlCommand(SELECT_CATEGORY_BY_TYPE, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@CategoryType", SqlDbType.Int).Value = type;
                cn.Open();
                lstCategoryEntities = GetCategoryCollectionFromReader(ExecuteReader(cmd));
                cn.Close();
            }
            return lstCategoryEntities;
        }

        /// <summary>
        /// Returns a collection of CategoryEntity objects with the data read from the input DataReader
        /// </summary>
        private List<CategoryEntity> GetCategoryCollectionFromReader(IDataReader reader)
        {
            var categoryEntity = new List<CategoryEntity>();
            while (reader.Read())
                categoryEntity.Add(GetCategoryFromReader(reader));
            return categoryEntity;
        }
    }
}

