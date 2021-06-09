using System.Collections.Generic;
using BIC.Entity;
using BIC.DAO;
using System.Web.UI.WebControls;
using BIC.Data;

namespace BIC.Biz
{
    public class CategoryBiz : BaseCategory
    {
        /// <summary>
        /// Create a new Category
        /// </summary>
        public static bool InsertCategory(CategoryEntity categoryEntity)
        {
            var categoryDA0 = new CategoryDAO();
            var ret = categoryDA0.InsertCategory(categoryEntity);
            PurgeCacheItems("Category_Category");
            return ret;
        }

        /// <summary>
        /// Update a CategoryEntity
        /// </summary>
        public static bool UpdateCategory(CategoryEntity categoryEntity)
        {
            var categoryDA0 = new CategoryDAO();
            var ret = categoryDA0.UpdateCategory(categoryEntity);
            PurgeCacheItems("Category_Category_" + categoryEntity.CategoryID);
            PurgeCacheItems("Category_Category");
            return ret;
        }

        /// <summary>
        /// Delete a CategoryEntity
        /// </summary>
        public static bool DeleteCategory(int _CategoryID)
        {
            var categoryDA0 = new CategoryDAO();
            var ret = categoryDA0.DeleteCategory(_CategoryID);
            PurgeCacheItems("Category_Category");
            return ret;
        }

        /// <summary>
        /// Returns an existing Category with the specified ID
        /// </summary>
        public static CategoryEntity GetCategoryByID(int _CategoryID)
        {
            CategoryEntity categoryEntity;
            var key = "Category_Category_" + _CategoryID;
            if (Cache[key] != null)
            {
                categoryEntity = (CategoryEntity)Cache[key];
            }
            else
            {
                var categoryDA0 = new CategoryDAO();
                categoryEntity = categoryDA0.GetCategoryByID(_CategoryID);
                CacheData(key, categoryEntity);
            }
            return categoryEntity;
        }
        /// <summary>
        /// Trả về một list Category lấy theo trường Type
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>
        public static List<CategoryEntity> GetCategoriesByType(int type)
        {
            List<CategoryEntity> CategorysEntity;
            var key = "Category_Category_Type" + type;

            if (Cache[key] != null)
            {
                CategorysEntity = (List<CategoryEntity>)Cache[key];
            }
            else
            {
                var categoryDA0 = new CategoryDAO();
                CategorysEntity = categoryDA0.GetCategoriesByType(type);
                CacheData(key, CategorysEntity);
            }
            return CategorysEntity;
        }
        /// <summary>
        /// Returns a collection with all the Categorys
        /// </summary>
        public static List<CategoryEntity> GetAllCategorys()
        {
            List<CategoryEntity> CategorysEntity;
            const string key = "Category_Category";

            if (Cache[key] != null)
            {
                CategorysEntity = (List<CategoryEntity>)Cache[key];
            }
            else
            {
                var categoryDA0 = new CategoryDAO();
                CategorysEntity = categoryDA0.GetAllCategorys();
                CacheData(key, CategorysEntity);
            }
            return CategorysEntity;
        }


        public static void PositionWithPriorityEdit(DropDownList ddlPosition)
        {
            var dh = new DataHelper();
            var dt = dh.PositionWithPriority("CategoryId", "Category");

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                ddlPosition.Items.Add(new ListItem((i + 1).ToString(), dt.Rows[i]["Priority"].ToString()));
            }
        }

        public static void PositionWithPriorityAdd(DropDownList ddlPosition)
        {
            var dh = new DataHelper();

            for (var i = 1; i <= dh.CountItem("CategoryId", "Category") + 1; i++)
            {
                ddlPosition.Items.Add(new ListItem(i.ToString()));
            }
        }
    }
}

