namespace BIC.Biz
{
    using BIC.DAO;
    using BIC.Data;
    using BIC.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Web.UI.WebControls;

    public class SearchBiz : BaseSearch
    {
        public static bool DeleteSearch(int _SearchID)
        {
            bool flag = new SearchDAO().DeleteSearch(_SearchID);
            BizObject.PurgeCacheItems("Search_Search");
            return flag;
        }

        public static List<SearchEntity> GetAllSearchs()
        {
            List<SearchEntity> data = null;
            string key = "Search_Search";
            if (BizObject.Cache[key] != null)
            {
                return (List<SearchEntity>) BizObject.Cache[key];
            }
            data = new SearchDAO().GetAllSearchs();
            BizObject.CacheData(key, data);
            return data;
        }

        public static SearchEntity GetSearchByID(int _SearchID)
        {
            SearchEntity data = null;
            string key = "Search_Search_" + _SearchID.ToString();
            if (BizObject.Cache[key] != null)
            {
                return (SearchEntity) BizObject.Cache[key];
            }
            data = new SearchDAO().GetSearchByID(_SearchID);
            BizObject.CacheData(key, data);
            return data;
        }

        public static bool InsertSearch(SearchEntity searchEntity)
        {
            bool flag = new SearchDAO().InsertSearch(searchEntity);
            BizObject.PurgeCacheItems("Search_Search");
            return flag;
        }

        public static void PositionWithPriorityAdd(DropDownList ddlPosition)
        {
            DataHelper helper = new DataHelper();
            for (int i = 1; i <= (helper.CountItem("SearchId", "Search") + 1); i++)
            {
                ddlPosition.Items.Add(new ListItem(i.ToString()));
            }
        }

        public static void PositionWithPriorityEdit(DropDownList ddlPosition)
        {
            DataTable table = new DataHelper().PositionWithPriority("SearchId", "Search");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                int num2 = i + 1;
                ddlPosition.Items.Add(new ListItem(num2.ToString(), table.Rows[i]["Priority"].ToString()));
            }
        }

        public static List<SearchEntity> SearchByKeyword(object keyword)
        {
            List<SearchEntity> data = null;
            string key = "Search_Search_" + keyword;
            if (BizObject.Cache[key] != null)
            {
                return (List<SearchEntity>) BizObject.Cache[key];
            }
            data = new SearchDAO().SearchByKeyWord(keyword);
            BizObject.CacheData(key, data);
            return data;
        }

        public static List<SearchEntity> SearchByKeyword(object keyword, object N)
        {
            List<SearchEntity> data = null;
            string key = "Search_Search_" + N + keyword;
            if (BizObject.Cache[key] != null)
            {
                return (List<SearchEntity>) BizObject.Cache[key];
            }
            data = new SearchDAO().SearchByKeyWord(keyword, N);
            BizObject.CacheData(key, data);
            return data;
        }

        public static List<SearchEntity> SearchByKeyword(object keyword, object N, object LanguageKey)
        {
            List<SearchEntity> data = null;
            string key = string.Concat(new object[] { "Search_Search_", LanguageKey, N, keyword });
            if (BizObject.Cache[key] != null)
            {
                return (List<SearchEntity>) BizObject.Cache[key];
            }
            data = new SearchDAO().SearchByKeyWord(keyword, N, LanguageKey);
            BizObject.CacheData(key, data);
            return data;
        }

        public static bool UpdateSearch(SearchEntity searchEntity)
        {
            bool flag = new SearchDAO().UpdateSearch(searchEntity);
            BizObject.PurgeCacheItems("Search_Search_" + searchEntity.SearchID);
            BizObject.PurgeCacheItems("Search_Search");
            return flag;
        }
    }
}

