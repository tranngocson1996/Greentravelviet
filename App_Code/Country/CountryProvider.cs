using System.Collections.Generic;
using BIC.Entity;

namespace BIC.DAO
{
    public abstract class CountryProvider : DataAccess
    {
        public abstract bool InsertCountry(CountryEntity entity);

        public abstract bool UpdateCountry(CountryEntity entity);

        public abstract bool DeleteCountry(int _CountryID);

        public abstract CountryEntity GetCountryByID(int _CountryID);

        public abstract List<CountryEntity> GetAllCountrys();
    }
}