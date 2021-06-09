namespace BIC.Biz
{
    using System;

    public abstract class BaseSearch : BizObject
    {
        protected BaseSearch()
        {
        }

        protected static void CacheDataSearch(string key, object data)
        {
            if (data != null)
            {
                BizObject.Cache.Insert(key, data, null, DateTime.Now.AddSeconds(6000.0), TimeSpan.Zero);
            }
        }
    }
}

