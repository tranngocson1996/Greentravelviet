using System;
using System.Collections.Generic;
using Bic.Core;
using BIC.DAO;
using BIC.Entity;
using BIC.Handler;

namespace BIC.Biz
{
    public class CommentBiz : BaseComment
    {
        /// <summary>
        /// Create a new Comment
        /// </summary>
        public static bool InsertComment(CommentEntity commentEntity)
        {
            commentEntity.ModifiedDate = DateTime.Now;
            var commentDA0 = new CommentDAO();
            bool ret = commentDA0.InsertComment(commentEntity);
            PurgeCacheItems("Comment_Comment");
            return ret;
        }

        /// <summary>
        /// Update a CommentEntity
        /// </summary>
        public static bool UpdateComment(CommentEntity commentEntity)
        {
            commentEntity.ModifiedDate = DateTime.Now;
            var commentDA0 = new CommentDAO();
            bool ret = commentDA0.UpdateComment(commentEntity);
            PurgeCacheItems("Comment_Comment_" + commentEntity.CommentID);
            PurgeCacheItems("Comment_Comment");
            return ret;
        }

        /// <summary>
        /// Delete a CommentEntity
        /// </summary>
        public static bool DeleteComment(int commentID)
        {
            var commentDA0 = new CommentDAO();
            bool ret = commentDA0.DeleteComment(commentID);
            PurgeCacheItems("Comment_Comment");
            return ret;
        }

        /// <summary>
        /// Returns an existing Comment with the specified ID
        /// </summary>
        public static CommentEntity GetCommentByID(int commentID)
        {
            var commentEntity = new CommentEntity();
            try
            {
                string key = "Comment_Comment_" + commentID;
                if (Cache[key] != null)
                {
                    commentEntity = (CommentEntity)Cache[key];
                }
                else
                {
                    var commentDA0 = new CommentDAO();
                    commentEntity = commentDA0.GetCommentByID(commentID);
                    CacheData(key, commentEntity);
                }
            }
            catch (Exception ex)
            {
                LogEvent.LogToFile(ex.ToString());
            }
            return commentEntity;
        }

        /// <summary>
        /// Returns a collection with all the Comments
        /// </summary>
        public static List<CommentEntity> GetAllComments()
        {
            var commentsEntity = new List<CommentEntity>();
            try
            {
                const string key = "Comment_Comment";
                if (Cache[key] != null)
                {
                    commentsEntity = (List<CommentEntity>)Cache[key];
                }
                else
                {
                    var commentDA0 = new CommentDAO();
                    commentsEntity = commentDA0.GetAllComments();
                    CacheData(key, commentsEntity);
                }
            }
            catch (Exception ex)
            {
                LogEvent.LogToFile(ex.ToString());
            }
            return commentsEntity;
        }

        public static List<Comment> GetByParent(int parentId)
        {
            var commentsEntity = new List<Comment>();
            try
            {
                var commentDAO = new CommentDAO();
                commentsEntity = commentDAO.GetByParent(parentId);
            }
            catch (Exception ex)
            {
                LogEvent.LogToFile(ex.ToString());
            }
            return commentsEntity;
        }

        public static List<Comment> GetByParent(int parentId, int pagesize, int pageindex, out int total)
        {
            try
            {
                var commentDAO = new CommentDAO();
                var commentsEntity = commentDAO.GetByParent(parentId, pagesize, pageindex, out total);
                return commentsEntity;
            }
            catch (Exception ex)
            {
                LogEvent.LogToFile(ex.ToString());
                total = 0;
                return null;
            }
        }

        public static int CommentCount(int id, int typeOfComment)
        {
            var count = 0;
            try
            {
                var commentDao = new CommentDAO();
                count = commentDao.CommentCount(id, typeOfComment);
            }
            catch (Exception ex)
            {
                LogEvent.LogToFile(ex.ToString());
            }
            return count;
        }
    }
}