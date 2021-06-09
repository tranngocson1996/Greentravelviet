namespace BIC.DAO
{
    using BIC.Entity;
    using System;
    using System.Collections.Generic;

    public abstract class SearchProvider : DataAccess
    {
        protected SearchProvider()
        {
        }

        public abstract bool DeleteSearch(int _SearchID);
        public abstract List<SearchEntity> GetAllSearchs();
        public abstract SearchEntity GetSearchByID(int _SearchID);
        public abstract bool InsertSearch(SearchEntity entity);
        public abstract List<SearchEntity> SearchByKeyWord(object keyword);
        public abstract List<SearchEntity> SearchByKeyWord(object keyword, object N);
        public abstract List<SearchEntity> SearchByKeyWord(object keyword, object N, object LanguageKey);
        public abstract bool UpdateSearch(SearchEntity entity);
    }
}

