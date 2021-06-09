using System.Collections.Generic;
using BIC.Entity;

namespace BIC.DAO
{
    public abstract class CategoryProvider : DataAccess
    {
        public abstract bool InsertCategory(CategoryEntity entity);
        public abstract bool UpdateCategory(CategoryEntity entity);
        public abstract bool DeleteCategory(int _CategoryID);
        public abstract CategoryEntity GetCategoryByID(int _CategoryID);
        public abstract List<CategoryEntity> GetAllCategorys();
        public abstract List<CategoryEntity> GetCategoriesByType(int type);
    }
}

