using System;
using System.Data;
using System.Collections.Generic;
using BIC.Entity;
using BIC.DAO;
using System.Web.UI.WebControls;
using BIC.Utils;
using BIC.Data;

namespace BIC.Biz
{
    public class TagBiz : BaseTag
    {
        /// <summary>
        /// Create a new Tag
        /// </summary>
        public static bool InsertTag(TagEntity tagEntity)
        {
            TagDAO tagDA0 = new TagDAO();
            bool ret = tagDA0.InsertTag(tagEntity);
            BizObject.PurgeCacheItems("Tag_Tag");
            return ret;
        }

        /// <summary>
        /// Update a TagEntity
        /// </summary>
        public static bool UpdateTag(TagEntity tagEntity)
        {
            TagDAO tagDA0 = new TagDAO();
            bool ret = tagDA0.UpdateTag(tagEntity);
            BizObject.PurgeCacheItems("Tag_Tag_" + tagEntity.TagID);
            BizObject.PurgeCacheItems("Tag_Tag");
            return ret;
        }

        /// <summary>
        /// Delete a TagEntity
        /// </summary>
        public static bool DeleteTag(int _TagID)
        {
            TagDAO tagDA0 = new TagDAO();
            bool ret = tagDA0.DeleteTag(_TagID);
            BizObject.PurgeCacheItems("Tag_Tag");
            return ret;
        }

        /// <summary>
        /// Returns an existing Tag with the specified ID
        /// </summary>
        public static TagEntity GetTagByID(int _TagID)
        {
            TagEntity tagEntity = null;
            string key = "Tag_Tag_" + _TagID.ToString();
            if (BizObject.Cache[key] != null)
            {
                tagEntity = (TagEntity)BizObject.Cache[key];
            }
            else
            {
                TagDAO tagDA0 = new TagDAO();
                tagEntity = tagDA0.GetTagByID(_TagID);
                BaseTag.CacheData(key, tagEntity);
            }
            return tagEntity;
        }

        public static TagEntity GetTagByKey(object Keyword, object TypeID)
        {
            TagEntity tagEntity = null;
            string key = "Tag_Tag_Type" + TypeID + "_key_" + Keyword.ToString();
            if (BizObject.Cache[key] != null)
            {
                tagEntity = (TagEntity)BizObject.Cache[key];
            }
            else
            {
                TagDAO tagDA0 = new TagDAO();
                tagEntity = tagDA0.TagsBykeyword(Keyword, TypeID);
                BaseTag.CacheData(key, tagEntity);
            }
            return tagEntity;
        }
        public static TagEntity GetTagByKey(object Keyword, object TypeID,out bool hasTag)
        {
            TagEntity tagEntity = null;
            string key = "Tag_Tag_Type" + TypeID + "_key_" + Keyword.ToString();
            if (BizObject.Cache[key] != null)
            {
                tagEntity = (TagEntity)BizObject.Cache[key];
            }
            else
            {
                TagDAO tagDA0 = new TagDAO();
                tagEntity = tagDA0.TagsBykeyword(Keyword, TypeID);
                BaseTag.CacheData(key, tagEntity);
            }
            hasTag = tagEntity != null;
            return tagEntity;
        }
        public static bool GetTagByKey(object Keyword, object TypeID, out TagEntity tagEntity)
        {

            string key = "Tag_Tag_Type" + TypeID + "_key_" + Keyword.ToString();
            if (BizObject.Cache[key] != null)
            {
                tagEntity = (TagEntity)BizObject.Cache[key];
            }
            else
            {
                TagDAO tagDA0 = new TagDAO();
                tagEntity = tagDA0.TagsBykeyword(Keyword, TypeID);
                BaseTag.CacheData(key, tagEntity);
            }
            return tagEntity != null;
        }
        /// <summary>
        /// Returns a collection with all the Tags
        /// </summary>
        public static List<TagEntity> GetAllTags()
        {
            List<TagEntity> TagsEntity = null;
            string key = "Tag_Tag";

            if (BizObject.Cache[key] != null)
            {
                TagsEntity = (List<TagEntity>)BizObject.Cache[key];
            }
            else
            {
                TagDAO tagDA0 = new TagDAO();
                TagsEntity = tagDA0.GetAllTags();
                BaseTag.CacheData(key, TagsEntity);
            }
            return TagsEntity;
        }


        public static void PositionWithPriorityEdit(DropDownList ddlPosition)
        {
            var dh = new DataHelper();
            DataTable dt = dh.PositionWithPriority("TagId", "Tag");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlPosition.Items.Add(new ListItem((i + 1).ToString(), dt.Rows[i]["Priority"].ToString()));
            }
        }

        public static void PositionWithPriorityAdd(DropDownList ddlPosition)
        {
            var dh = new DataHelper();

            for (int i = 1; i <= dh.CountItem("TagId", "Tag") + 1; i++)
            {
                ddlPosition.Items.Add(new ListItem(i.ToString()));
            }
        }
    }
}

