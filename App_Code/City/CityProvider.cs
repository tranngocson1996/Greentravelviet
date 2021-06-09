using System.Collections.Generic;
using BIC.Entity;

namespace BIC.DAO
{
    public abstract class CityProvider : DataAccess
    {
        public abstract bool InsertCity(CityEntity entity);

        public abstract bool UpdateCity(CityEntity entity);

        public abstract bool DeleteCity(int _CityID);

        public abstract CityEntity GetCityByID(int _CityID);

        public abstract List<CityEntity> GetAllCitys();
    }
}