using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using BIC.DAO;
using BIC.Data;
using BIC.Entity;

namespace BIC.Biz
{
    public class CityBiz : BaseCity
    {
        /// <summary>
        /// Create a new City
        /// </summary>
        public static bool InsertCity(CityEntity cityEntity)
        {
            var cityDA0 = new CityDAO();
            bool ret = cityDA0.InsertCity(cityEntity);
            PurgeCacheItems("City_City");
            return ret;
        }

        /// <summary>
        /// Update a CityEntity
        /// </summary>
        public static bool UpdateCity(CityEntity cityEntity)
        {
            var cityDA0 = new CityDAO();
            bool ret = cityDA0.UpdateCity(cityEntity);
            PurgeCacheItems("City_City_" + cityEntity.CityID);
            PurgeCacheItems("City_City");
            return ret;
        }

        /// <summary>
        /// Delete a CityEntity
        /// </summary>
        public static bool DeleteCity(int _CityID)
        {
            var cityDA0 = new CityDAO();
            bool ret = cityDA0.DeleteCity(_CityID);
            PurgeCacheItems("City_City");
            return ret;
        }

        /// <summary>
        /// Returns an existing City with the specified ID
        /// </summary>
        public static CityEntity GetCityByID(int _CityID)
        {
            CityEntity cityEntity = null;
            string key = "City_City_" + _CityID;
            if (Cache[key] != null)
            {
                cityEntity = (CityEntity)Cache[key];
            }
            else
            {
                var cityDA0 = new CityDAO();
                cityEntity = cityDA0.GetCityByID(_CityID);
                CacheData(key, cityEntity);
            }
            return cityEntity;
        }

        /// <summary>
        /// Returns a collection with all the Citys
        /// </summary>
        public static List<CityEntity> GetAllCitys()
        {
            List<CityEntity> CitysEntity = null;
            string key = "City_City";

            if (Cache[key] != null)
            {
                CitysEntity = (List<CityEntity>)Cache[key];
            }
            else
            {
                var cityDA0 = new CityDAO();
                CitysEntity = cityDA0.GetAllCitys();
                CacheData(key, CitysEntity);
            }
            return CitysEntity;
        }

        public static void PositionWithPriorityEdit(DropDownList ddlPosition)
        {
            var dh = new DataHelper();
            DataTable dt = dh.PositionWithPriority("CityId", "City");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlPosition.Items.Add(new ListItem((i + 1).ToString(), dt.Rows[i]["Priority"].ToString()));
            }
        }

        public static void PositionWithPriorityAdd(DropDownList ddlPosition)
        {
            var dh = new DataHelper();

            for (int i = 1; i <= dh.CountItem("CityId", "City") + 1; i++)
            {
                ddlPosition.Items.Add(new ListItem(i.ToString()));
            }
        }
    }
}