using System.Collections.Generic;
using System.Data;
using BIC.Entity;

namespace BIC.DAO
{
    public abstract class TagProvider : DataAccess
    {
        public abstract bool InsertTag(TagEntity entity);
        public abstract bool UpdateTag(TagEntity entity);
        public abstract bool DeleteTag(int _TagID);
        public abstract TagEntity GetTagByID(int _TagID);
        public abstract List<TagEntity> GetAllTags();
        public abstract TagEntity TagsBykeyword(object Keyword, object TypeID);


    }
}

