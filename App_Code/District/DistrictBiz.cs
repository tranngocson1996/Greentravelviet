using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using BIC.DAO;
using BIC.Data;
using BIC.Entity;

namespace BIC.Biz
{
    public class DistrictBiz : BaseDistrict
    {
        /// <summary>
        /// Create a new District
        /// </summary>
        public static bool InsertDistrict(DistrictEntity districtEntity)
        {
            var districtDA0 = new DistrictDAO();
            bool ret = districtDA0.InsertDistrict(districtEntity);
            PurgeCacheItems("District_District");
            return ret;
        }

        /// <summary>
        /// Update a DistrictEntity
        /// </summary>
        public static bool UpdateDistrict(DistrictEntity districtEntity)
        {
            var districtDA0 = new DistrictDAO();
            bool ret = districtDA0.UpdateDistrict(districtEntity);
            PurgeCacheItems("District_District_" + districtEntity.DistrictID);
            PurgeCacheItems("District_District");
            return ret;
        }

        /// <summary>
        /// Delete a DistrictEntity
        /// </summary>
        public static bool DeleteDistrict(int _DistrictID)
        {
            var districtDA0 = new DistrictDAO();
            bool ret = districtDA0.DeleteDistrict(_DistrictID);
            PurgeCacheItems("District_District");
            return ret;
        }

        /// <summary>
        /// Returns an existing District with the specified ID
        /// </summary>
        public static DistrictEntity GetDistrictByID(int _DistrictID)
        {
            DistrictEntity districtEntity = null;
            string key = "District_District_" + _DistrictID;
            if (Cache[key] != null)
            {
                districtEntity = (DistrictEntity)Cache[key];
            }
            else
            {
                var districtDA0 = new DistrictDAO();
                districtEntity = districtDA0.GetDistrictByID(_DistrictID);
                CacheData(key, districtEntity);
            }
            return districtEntity;
        }

        /// <summary>
        /// Returns an existing District with the specified CityID
        /// </summary>
        public static List<DistrictEntity> GetDistrictByCityID(int _CityID)
        {
            List<DistrictEntity> DistrictsEntity = null;

            DistrictDAO districtDA0 = new DistrictDAO();
            DistrictsEntity = districtDA0.GetDistrictByCityID(_CityID);

            return DistrictsEntity;
        }

        /// <summary>
        /// Returns a collection with all the Districts
        /// </summary>
        public static List<DistrictEntity> GetAllDistricts()
        {
            List<DistrictEntity> DistrictsEntity = null;
            string key = "District_District";

            if (Cache[key] != null)
            {
                DistrictsEntity = (List<DistrictEntity>)Cache[key];
            }
            else
            {
                var districtDA0 = new DistrictDAO();
                DistrictsEntity = districtDA0.GetAllDistricts();
                CacheData(key, DistrictsEntity);
            }
            return DistrictsEntity;
        }

        public static void PositionWithPriorityEdit(DropDownList ddlPosition)
        {
            var dh = new DataHelper();
            DataTable dt = dh.PositionWithPriority("DistrictId", "District");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlPosition.Items.Add(new ListItem((i + 1).ToString(), dt.Rows[i]["Priority"].ToString()));
            }
        }

        public static void PositionWithPriorityAdd(DropDownList ddlPosition)
        {
            var dh = new DataHelper();

            for (int i = 1; i <= dh.CountItem("DistrictId", "District") + 1; i++)
            {
                ddlPosition.Items.Add(new ListItem(i.ToString()));
            }
        }
    }
}