using Newtonsoft.Json;
using StackExchange.Redis;
using System;

namespace BookingPlatform.Common.CacheManage
{

    /// <summary>
    /// cache 工具类
    /// </summary>
    class CacheUtils
    {
        // private static String _cachePrefix = ConfigExtensions.Configuration["DbConnection:MySqlConnectionString"];

        private static String _cachePrefix = null;

        public static String cachePrefix
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_cachePrefix))
                {
                    //_cachePrefix = ConfigurationManager.AppSettings["cachePrefix"];
                    _cachePrefix = ConfigExtensions.Configuration["Cache:cachePrefix"];
                    if (String.IsNullOrEmpty(_cachePrefix))
                    {
                        _cachePrefix = "default_";
                    }
                    else if (!_cachePrefix.EndsWith("_"))
                    {
                        _cachePrefix += "_";
                    }

                }
                return _cachePrefix;
            }
        }

        public static String getPrefixKey(String key)
        {
            if (!key.Contains(cachePrefix))
            {
                return cachePrefix + key;

            }
            return key;
        }


        public static String ConvertJson<T>(T value)
        {
            string result = value is string ? value.ToString() : JsonConvert.SerializeObject(value);
            return result;
        }

        public static T ConvertObj<T>(Object value)
        {
            String sValue = "";
            if (value == null)
            {
                return default(T);
            }
            if (value is RedisValue)
            {
                if (((RedisValue)value).IsNullOrEmpty)
                {
                    return default(T);
                }

            }
            return JsonConvert.DeserializeObject<T>(value.ToString());
        }
    }
}
