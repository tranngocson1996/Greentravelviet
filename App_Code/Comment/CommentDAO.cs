using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Bic.Core;
using BIC.Entity;
using BIC.Handler;
using BIC.Utils;

namespace BIC.DAO
{
    public class CommentDAO : CommentProvider
    {
        #region Stored Procedure names

        private const string INSERT_COMMENT = "[dbo].CommentInsert";
        private const string UPDATE_COMMENT = "[dbo].CommentUpdate";
        private const string DELETE_COMMENT = "[dbo].CommentDelete";
        private const string SELECT_COMMENT_BYID = "[dbo].CommentGetByID";
        private const string SELECT_ALL_COMMENT = "[dbo].CommentsGetAll";

        #endregion Stored Procedure names

        /// <summary>
        /// Create a new CommentEntity
        /// </summary>
        public override bool InsertComment(CommentEntity entity)
        {
            try
            {
                using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
                {
                    var cmd = new SqlCommand(INSERT_COMMENT, cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = entity.Title;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = entity.Id;
                    cmd.Parameters.Add("@TypeOfComment", SqlDbType.NVarChar).Value = entity.TypeOfComment;
                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = entity.Address;
                    cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = entity.FullName;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = entity.Email;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = entity.Description;
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                    cmd.Parameters.Add("@DongY", SqlDbType.Int).Value = entity.DongY;
                    cmd.Parameters.Add("@KhongDongY", SqlDbType.Int).Value = entity.KhongDongY;
                    cmd.Parameters.Add("@Parent", SqlDbType.Int).Value = entity.Parent;
                    cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = entity.GioiTinh;
                    cmd.Parameters.Add("@IsHot", SqlDbType.Bit).Value = entity.IsHot;
                    cmd.Parameters.Add("@TempPass", SqlDbType.NVarChar).Value = entity.TempPass;
                    cmd.Parameters.Add("@LanguageKey", SqlDbType.NChar).Value = entity.LanguageKey;
                    cmd.Parameters.Add("@CommentID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cn.Open();
                    int ret = ExecuteNonQuery(cmd);
                    entity.CommentID = (Int32)cmd.Parameters["@CommentID"].Value;
                    cn.Close();
                    return (ret == 1);
                }
            }
            catch (Exception ex)
            {
                LogEvent.LogToFile(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Update a CommentEntity
        /// </summary>
        public override bool UpdateComment(CommentEntity entity)
        {
            try
            {
                using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
                {
                    var cmd = new SqlCommand(UPDATE_COMMENT, cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.Add("@CommentID", SqlDbType.Int).Value = entity.CommentID;
                    cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = entity.Title;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = entity.Id;
                    cmd.Parameters.Add("@TypeOfComment", SqlDbType.NVarChar).Value = entity.TypeOfComment;
                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = entity.Address;
                    cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = entity.FullName;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = entity.Email;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = entity.Description;
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = entity.IsActive;
                    cmd.Parameters.Add("@DongY", SqlDbType.Int).Value = entity.DongY;
                    cmd.Parameters.Add("@KhongDongY", SqlDbType.Int).Value = entity.KhongDongY;
                    cmd.Parameters.Add("@Parent", SqlDbType.Int).Value = entity.Parent;
                    cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = entity.GioiTinh;
                    cmd.Parameters.Add("@IsHot", SqlDbType.Bit).Value = entity.IsHot;
                    cmd.Parameters.Add("@TempPass", SqlDbType.NVarChar).Value = entity.TempPass;
                    cmd.Parameters.Add("@LanguageKey", SqlDbType.NChar).Value = entity.LanguageKey;
                    cn.Open();
                    int ret = ExecuteNonQuery(cmd);
                    cn.Close();
                    return (ret == 1);
                }
            }
            catch (Exception ex)
            {
                LogEvent.LogToFile(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Deletes a CommentEntity
        /// </summary>
        public override bool DeleteComment(int commentID)
        {
            try
            {
                using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
                {
                    var cmd = new SqlCommand(DELETE_COMMENT, cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.Add("@CommentID", SqlDbType.Int).Value = commentID;
                    cn.Open();
                    int ret = ExecuteNonQuery(cmd);
                    cn.Close();
                    return (ret == 1);
                }
            }
            catch (Exception ex)
            {
                LogEvent.LogToFile(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Returns an existing Comment with the specified ID
        /// </summary>
        public override CommentEntity GetCommentByID(int commentID)
        {
            CommentEntity commentEntity = null;
            try
            {
                using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
                {
                    var cmd = new SqlCommand(SELECT_COMMENT_BYID, cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.Add("@CommentID", SqlDbType.Int).Value = commentID;
                    cn.Open();
                    IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                    if (reader.Read())
                    {
                        commentEntity = GetCommentFromReader(reader);
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                LogEvent.LogToFile(ex.ToString());
            }
            return commentEntity;
        }

        public override List<Comment> GetByParent(int parentId)
        {
            List<Comment> commentEntity = null;
            try
            {
                using (var db = DefaultDataContext.CreateDefault())
                {
                    var query = from c in db.Comments
                                where c.Parent == parentId && c.IsActive == true
                                orderby c.CreateDate descending
                                select c;
                    commentEntity = query.ToList();
                    db.Dispose();
                }
            }
            catch (Exception ex)
            {
                LogEvent.LogToFile(ex.ToString());
            }
            return commentEntity;
        }

        public override List<Comment> GetByParent(int parentId, int pagesize, int pageindex, out int total)
        {
            try
            {
                using (var db = DefaultDataContext.CreateDefault())
                {
                    total = db.Comments.Count(c => c.Parent == parentId && c.IsActive == true);
                    var query = from c in db.Comments
                                where c.Parent == parentId && c.IsActive == true
                                orderby c.CreateDate descending
                                select c;
                    var result = query.Skip(pageindex * pagesize).Take(pagesize).ToList();
                    db.Dispose();
                    return result;
                }
            }
            catch (Exception ex)
            {
                LogEvent.LogToFile(ex.ToString());
                total = 0;
                return null;
            }
        }

        /// <summary>
        /// Đếm số lượng comment trong 1 bản ghi tin tức hoặc sản phẩm
        /// Demo gọi store từ linq to store
        /// </summary>
        /// <param name="id">id của tin tức hoặc sản phẩm</param>
        /// <param name="typeOfComment">Kiểu comment</param>
        /// <returns></returns>
        public override int CommentCount(int id, int typeOfComment)
        {
            var count = 0;
            try
            {
                using (var db = DefaultDataContext.CreateDefault())
                {
                    count = BicConvert.ToInt32(db.CommentCount(id, typeOfComment.ToString()).ReturnValue);
                    db.Dispose();
                }
            }
            catch (Exception ex)
            {
                LogEvent.LogToFile(ex.ToString());
            }
            return count;
        }

        /// <summary>
        /// Returns a new CommentEntity instance filled with the DataReader's current record data
        /// </summary>
        private static CommentEntity GetCommentFromReader(IDataReader reader)
        {
            try
            {
                return new CommentEntity(BicConvert.ToInt32(reader["CommentID"]), reader["Title"].ToString().Trim(), BicConvert.ToInt32(reader["ID"]), reader["TypeOfComment"].ToString().Trim(), BicConvert.ToDateTime(reader["CreateDate"]), reader["Address"].ToString().Trim(), reader["FullName"].ToString().Trim(), reader["Email"].ToString().Trim(), reader["Description"].ToString().Trim(), BicConvert.ToInt32(reader["Priority"]), BicConvert.ToBoolean(reader["IsActive"]), BicConvert.ToDateTime(reader["ModifiedDate"]), BicConvert.ToInt32(reader["DongY"]), BicConvert.ToInt32(reader["KhongDongY"]), BicConvert.ToInt32(reader["Parent"]), BicConvert.ToBoolean(reader["GioiTinh"]), BicConvert.ToBoolean(reader["IsHot"]), reader["TempPass"].ToString().Trim(), reader["LanguageKey"].ToString());
            }
            catch (Exception ex)
            {
                LogEvent.LogToFile(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Returns a collection with all the Comments
        /// </summary>
        public override List<CommentEntity> GetAllComments()
        {
            List<CommentEntity> commentEntity = null;
            try
            {
                using (var cn = new SqlConnection(ConnectionString))
                {
                    var cmd = new SqlCommand(SELECT_ALL_COMMENT, cn) { CommandType = CommandType.StoredProcedure };
                    cn.Open();
                    commentEntity = GetCommentCollectionFromReader(ExecuteReader(cmd));
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                LogEvent.LogToFile(ex.ToString());
            }
            return commentEntity;
        }

        /// <summary>
        /// Returns a collection of CommentEntity objects with the data read from the input DataReader
        /// </summary>
        private static List<CommentEntity> GetCommentCollectionFromReader(IDataReader reader)
        {
            var commentEntity = new List<CommentEntity>();
            try
            {
                while (reader.Read())
                    commentEntity.Add(GetCommentFromReader(reader));
            }
            catch (Exception ex)
            {
                LogEvent.LogToFile(ex.ToString());
            }
            return commentEntity;
        }
    }
}