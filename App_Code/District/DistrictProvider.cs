using System.Collections.Generic;
using BIC.Entity;

namespace BIC.DAO
{
    public abstract class DistrictProvider : DataAccess
    {
        public abstract bool InsertDistrict(DistrictEntity entity);

        public abstract bool UpdateDistrict(DistrictEntity entity);

        public abstract bool DeleteDistrict(int _DistrictID);

        public abstract DistrictEntity GetDistrictByID(int _DistrictID);

        public abstract List<DistrictEntity> GetAllDistricts();

        public abstract List<DistrictEntity> GetDistrictByCityID(int CityID);
    }
}