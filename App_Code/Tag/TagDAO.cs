using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BIC.Entity;
using BIC.Utils;
namespace BIC.DAO
{
    public class TagDAO : TagProvider
    {
        #region Stored Procedure names
        private const string INSERT_TAG = "[dbo].TagInsert";
        private const string UPDATE_TAG = "[dbo].TagUpdate";
        private const string DELETE_TAG = "[dbo].TagDelete";
        private const string SELECT_TAG_BYID = "[dbo].TagGetByID";
        private const string SELECT_ALL_TAG = "[dbo].TagsGetAll";
        private const string TAGSBYKEYWORD = "[dbo].TagsBykeyword";

        #endregion

        /// <summary>
        /// Create a new TagEntity
        /// </summary>
        public override bool InsertTag(TagEntity entity)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BicWebConfig.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(INSERT_TAG, cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = entity.Keyword;
                    cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = entity.Id;
                    cmd.Parameters.Add("@TypeID", SqlDbType.Int).Value = entity.TypeID;
                    cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = entity.Priority;
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                    cmd.Parameters.Add("@TagID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cn.Open();
                    int ret = ExecuteNonQuery(cmd);
                    entity.TagID = (Int32)cmd.Parameters["@TagID"].Value;
                    cn.Close();
                    return (ret == 1);
                }
            }
            catch (Exception ex)
            {
                BIC.Handler.LogEvent.LogToFile(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Update a TagEntity
        /// </summary>
        public override bool UpdateTag(TagEntity entity)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BicWebConfig.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(UPDATE_TAG, cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TagID", SqlDbType.Int).Value = entity.TagID;
                    cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = entity.Keyword;
                    cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = entity.Id;
                    cmd.Parameters.Add("@TypeID", SqlDbType.Int).Value = entity.TypeID;
                    cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = entity.Priority;
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                    cn.Open();
                    int ret = DataAccess.ExecuteNonQuery(cmd);
                    cn.Close();
                    return (ret == 1);
                }
            }
            catch (Exception ex)
            {
                BIC.Handler.LogEvent.LogToFile(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Deletes a TagEntity
        /// </summary>
        public override bool DeleteTag(int _TagID)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BicWebConfig.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(DELETE_TAG, cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TagID", SqlDbType.Int).Value = _TagID;
                    cn.Open();
                    int ret = DataAccess.ExecuteNonQuery(cmd);
                    cn.Close();
                    return (ret == 1);
                }
            }
            catch (Exception ex)
            {
                BIC.Handler.LogEvent.LogToFile(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Returns an existing Tag with the specified ID
        /// </summary>
        public override TagEntity GetTagByID(int _TagID)
        {
            TagEntity _TagEntity = null;
            using (SqlConnection cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SELECT_TAG_BYID, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TagID", SqlDbType.Int).Value = _TagID;
                cn.Open();
                IDataReader reader = DataAccess.ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    _TagEntity = GetTagFromReader(reader);
                }
                cn.Close();
            }
            return _TagEntity;
        }


        /// <summary>
        /// Returns a new TagEntity instance filled with the DataReader's current record data
        /// </summary>
        private TagEntity GetTagFromReader(IDataReader reader)
        {
            return new TagEntity(
                BicConvert.ToInt32(reader["TagID"]),
                reader["Keyword"].ToString().Trim(),
                reader["ID"].ToString().Trim(),
                BicConvert.ToInt32(reader["TypeID"]),
                BicConvert.ToInt32(reader["Priority"]),
                BicConvert.ToBoolean(reader["IsActive"]));
        }

        /// <summary>
        /// Returns a collection with all the Tags
        /// </summary>
        public override List<TagEntity> GetAllTags()
        {
            List<TagEntity> _TagEntity = null;
            using (SqlConnection cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SELECT_ALL_TAG, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                _TagEntity = GetTagCollectionFromReader(DataAccess.ExecuteReader(cmd));
                cn.Close();
            }
            return _TagEntity;
        }

        /// <summary>
        /// Returns a collection of TagEntity objects with the data read from the input DataReader
        /// </summary>
        private List<TagEntity> GetTagCollectionFromReader(IDataReader reader)
        {
            List<TagEntity> tagEntity = new List<TagEntity>();
            while (reader.Read())
                tagEntity.Add(GetTagFromReader(reader));
            return tagEntity;
        }

        public override TagEntity TagsBykeyword(object Keyword, object TypeID)
        {
            TagEntity _TagEntity = null;
            using (SqlConnection cn = new SqlConnection(BicWebConfig.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(TAGSBYKEYWORD, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = Keyword;
                cmd.Parameters.Add("@TypeID", SqlDbType.Int).Value = TypeID;
                cn.Open();
                IDataReader reader = DataAccess.ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    _TagEntity = GetTagFromReader(reader);
                }
                cn.Close();
            }
            return _TagEntity;
        }

    }
}

