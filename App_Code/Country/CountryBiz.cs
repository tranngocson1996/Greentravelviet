using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using BIC.DAO;
using BIC.Data;
using BIC.Entity;

namespace BIC.Biz
{
    public class CountryBiz : BaseCountry
    {
        /// <summary>
        /// Create a new Country
        /// </summary>
        public static bool InsertCountry(CountryEntity countryEntity)
        {
            var countryDA0 = new CountryDAO();
            bool ret = countryDA0.InsertCountry(countryEntity);
            PurgeCacheItems("Country_Country");
            return ret;
        }

        /// <summary>
        /// Update a CountryEntity
        /// </summary>
        public static bool UpdateCountry(CountryEntity countryEntity)
        {
            var countryDA0 = new CountryDAO();
            bool ret = countryDA0.UpdateCountry(countryEntity);
            PurgeCacheItems("Country_Country_" + countryEntity.CountryId);
            PurgeCacheItems("Country_Country");
            return ret;
        }

        /// <summary>
        /// Delete a CountryEntity
        /// </summary>
        public static bool DeleteCountry(int _CountryID)
        {
            var countryDA0 = new CountryDAO();
            bool ret = countryDA0.DeleteCountry(_CountryID);
            PurgeCacheItems("Country_Country");
            return ret;
        }

        /// <summary>
        /// Returns an existing Country with the specified ID
        /// </summary>
        public static CountryEntity GetCountryByID(int _CountryID)
        {
            CountryEntity countryEntity = null;
            string key = "Country_Country_" + _CountryID;
            if (Cache[key] != null)
            {
                countryEntity = (CountryEntity)Cache[key];
            }
            else
            {
                var countryDA0 = new CountryDAO();
                countryEntity = countryDA0.GetCountryByID(_CountryID);
                CacheData(key, countryEntity);
            }
            return countryEntity;
        }

        /// <summary>
        /// Returns a collection with all the Countrys
        /// </summary>
        public static List<CountryEntity> GetAllCountrys()
        {
            List<CountryEntity> CountrysEntity = null;
            string key = "Country_Country";

            if (Cache[key] != null)
            {
                CountrysEntity = (List<CountryEntity>)Cache[key];
            }
            else
            {
                var countryDA0 = new CountryDAO();
                CountrysEntity = countryDA0.GetAllCountrys();
                CacheData(key, CountrysEntity);
            }
            return CountrysEntity;
        }

        public static void PositionWithPriorityEdit(DropDownList ddlPosition)
        {
            var dh = new DataHelper();
            DataTable dt = dh.PositionWithPriority("CountryId", "Country");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlPosition.Items.Add(new ListItem((i + 1).ToString(), dt.Rows[i]["Priority"].ToString()));
            }
        }

        public static void PositionWithPriorityAdd(DropDownList ddlPosition)
        {
            var dh = new DataHelper();

            for (int i = 1; i <= dh.CountItem("CountryId", "Country") + 1; i++)
            {
                ddlPosition.Items.Add(new ListItem(i.ToString()));
            }
        }
    }
}