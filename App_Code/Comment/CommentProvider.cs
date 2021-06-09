using System.Collections.Generic;
using Bic.Core;
using BIC.Entity;

namespace BIC.DAO
{
    public abstract class CommentProvider : DataAccess
    {
        public abstract bool InsertComment(CommentEntity entity);
        public abstract bool UpdateComment(CommentEntity entity);
        public abstract bool DeleteComment(int _CommentID);
        public abstract CommentEntity GetCommentByID(int _CommentID);
        public abstract List<CommentEntity> GetAllComments();
        public abstract List<Comment> GetByParent(int parentId);
        public abstract List<Comment> GetByParent(int parentId, int pagesize, int pageindex, out int total); 
        public abstract int CommentCount(int id, int typeOfComment);
    }
}