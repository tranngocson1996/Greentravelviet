using System;
namespace BIC.Biz
{
	public abstract class BaseOrderMenu : BizObject
	{
	
		/// <summary>
		/// Cache the input data, if caching is enabled
		/// </summary>
		protected static void CacheDataOrderMenu(string key, object data)
		{
			if (data != null)
			{
				Cache.Insert(key, data, null,
				DateTime.Now.AddSeconds(6000), TimeSpan.Zero);
			}
		}
	}
}

