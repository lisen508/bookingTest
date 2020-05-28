using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BookingPlatform.Common.CacheManage
{
    /// <summary>
    /// 配置说明：
    /// cacheType 1 redis
    /// cachePrefix 缓存前缀 可以不设置 防止和其他程序冲突 默认是 default
    /// redisAddress redis 地址  多个用“,”隔开
    /// redisNum 使用redis哪一个库 默认使用第五个
    /// 比如：只配置了 redisAddress 则使用 redis，cacheType 可以不配置
    /// 
    /// 所有的配置如下 不需要每一项都配置
    /// <add key="cacheType" value="1"/>   //必须
    /// <add key="cachePrefix" value="default"/>
    /// <add key="redisAddress" value="192.168.0.224:6379"/> //必须
    /// <add key="redisNum" value="5"/>
    /// 
    /// </summary>
    public static class DataCache
    {
        private static IDataCache _instance = null;
        private static readonly object _locker = new object();
        /// <summary>
        /// 静态实例，外部可直接调用
        /// redis缓存实例
        /// </summary>
        public static IDataCache Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        if (_instance == null)
                        {

                            String cacheType = ConfigExtensions.Configuration["Cache:cacheType"];
                            String redisAddress = ConfigExtensions.Configuration["Cache:redisAddress"];
                            //  String cacheType = ConfigurationManager.AppSettings["cacheType"];
                            //String redisAddress = ConfigurationManager.AppSettings["redisAddress"];
                            if (cacheType != "3") // 其他情况（除了为3的情况）都使用redis
                            {
                                if (_instance == null && !String.IsNullOrEmpty(redisAddress))
                                {
                                    try
                                    {
                                        _instance = new RedisCache();
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                }
                            }
                        }
                    }
                }

                return _instance;
            }
        }
    }

    /// <summary>
    /// Redis缓存服务器
    /// 服务器和客户端下载：
    ///  https://github.com/MSOpenTech/redis/releases
    ///  https://github.com/ServiceStack/ServiceStack.Redis
    /// </summary>
    public class RedisCache : IDataCache
    {

        /// <summary>
        /// db
        /// </summary>
        public static IDatabase db
        {
            get
            {
                if (connectionMultiplexer != null)
                {
                    return connectionMultiplexer.GetDatabase(redisNum);
                }
                return null;
            }
        }

        //ConnectionMultiplexer 对象只需要一个
        private static int redisNum = 5;
        private static ConnectionMultiplexer _connectionMultiplexer = null;
        /// <summary>
        /// 链接串
        /// </summary>
        public static ConnectionMultiplexer connectionMultiplexer
        {
            get
            {
                if (_connectionMultiplexer == null)
                {
                    initConnectionMultiplexer();
                }
                return _connectionMultiplexer;
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public RedisCache()
        {
            if (_connectionMultiplexer == null)
            {
                initConnectionMultiplexer();
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private static void initConnectionMultiplexer()
        {
            String redisAddress = ConfigExtensions.Configuration["Cache:redisAddress"];
            // String redisAddress = ConfigurationManager.AppSettings["redisAddress"];
            if (!String.IsNullOrWhiteSpace(redisAddress))
            {
                _connectionMultiplexer = ConnectionMultiplexer.Connect(redisAddress);
            }
            String redisNumStr = ConfigExtensions.Configuration["Cache:redisNum"];

            // String redisNumStr = ConfigurationManager.AppSettings["redisNum"];
            if (!int.TryParse(redisNumStr, out redisNum))
            {
                redisNum = 5;//默认选择第五个库 
            }
        }

        /// <summary>
        /// ~RedisCache
        /// </summary>
        ~RedisCache()
        {
            if (_connectionMultiplexer != null)
            {
                _connectionMultiplexer.Close();
            }
        }

        /// <summary>
        /// 获取keys
        /// </summary>
        /// <returns></returns>
        public List<string> GetKeys()
        {
            var endpoints = _connectionMultiplexer.GetEndPoints();
            List<string> keyList = new List<string>();
            foreach (var ep in endpoints)
            {
                var server = _connectionMultiplexer.GetServer(ep);
                String reg = CacheUtils.getPrefixKey("*");
                var keys = server.Keys(redisNum, reg);
                foreach (var item in keys)
                {
                    keyList.Add((string)item);
                }
            }
            return keyList;
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 获取key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            key = CacheUtils.getPrefixKey(key);


            return db.StringGet(key);
        }
        /// <summary>
        /// GetNoPrefix
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetNoPrefix(string key)
        {
            return db.StringGet(key);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">类型（对象必须可序列化，否则可以作为object类型取出再类型转换，不然会报错）</typeparam>
        /// <param name="key">缓存key</param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            key = CacheUtils.getPrefixKey(key);
            RedisValue value = db.StringGet(key);
            return CacheUtils.ConvertObj<T>(value);
        }
        /// <summary>
        /// 获取扩展方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="depFile"></param>
        /// <returns></returns>
        public T Get<T>(string key, string depFile)
        {

            key = CacheUtils.getPrefixKey(key);
            string timeKey = key + "_time";
            if (db.KeyExists(timeKey) && db.KeyExists(key))
            {
                DateTime obj_time = Get<DateTime>(timeKey);
                T obj_cache = Get<T>(key);
                if (File.Exists(depFile))
                {
                    FileInfo fi = new FileInfo(depFile);
                    if (obj_time != fi.LastWriteTime)
                    {
                        Delete(key);
                        Delete(timeKey);
                        return default(T);
                    }
                    else return obj_cache;
                }
                else
                {
                    throw new Exception("文件(" + depFile + ")不存在！");
                }
            }
            else return default(T);

        }
        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存key</param>
        /// <param name="value">缓存值</param>
        /// <returns>返回值，表示：是否写入成功</returns>
        public bool Set<T>(string key, T value)
        {
            key = CacheUtils.getPrefixKey(key);
            return db.StringSet(key, CacheUtils.ConvertJson(value));
        }
        /// <summary>
        /// 写入缓存，设置过期时间点
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存key</param>
        /// <param name="value">缓存值</param>
        /// <param name="expiresAt">过期时间点</param>
        /// <returns>返回值，表示：是否写入成功</returns>
        public bool Set<T>(string key, T value, DateTime expiresAt)
        {
            key = CacheUtils.getPrefixKey(key);
            return db.StringSet(key, CacheUtils.ConvertJson(value), expiresAt - new DateTime());

        }
        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, TimeSpan timeSpan)
        {
            key = CacheUtils.getPrefixKey(key);

            return db.StringSet(key, CacheUtils.ConvertJson(value), timeSpan);
        }

        /// <summary>
        /// 写入缓存，设置过期秒数
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存key</param>
        /// <param name="value">缓存值</param>
        /// <param name="expiresSecond">过期秒数</param>
        /// <returns>返回值，表示：是否写入成功</returns>
        public bool Set<T>(string key, T value, int expiresSecond)
        {
            key = CacheUtils.getPrefixKey(key);
            return db.StringSet(key, CacheUtils.ConvertJson(value), DateTime.Now.AddSeconds(expiresSecond) - new DateTime());
        }
        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="depFile"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, string depFile)
        {
            key = CacheUtils.getPrefixKey(key);
            bool ret1 = db.StringSet(key, CacheUtils.ConvertJson(value));
            if (ret1 && File.Exists(depFile))
            {
                FileInfo fi = new FileInfo(depFile);
                DateTime lastWriteTime = fi.LastWriteTime;
                return db.StringSet(key + "_time", CacheUtils.ConvertJson(lastWriteTime));
            }
            return false;
        }
        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <returns></returns>
        public int Delete(string key)
        {
            key = CacheUtils.getPrefixKey(key);
            return db.KeyDelete(key) ? 1 : 0;
        }
        /// <summary>
        /// 删除多个缓存
        /// </summary>
        /// <param name="keys">缓存key数组</param>
        /// <returns></returns>
        public int Delete(string[] keys)
        {

            if (keys == null || keys.Length == 0)
            {
                return 0;
            }
            return keys.Count(key => db.KeyDelete(CacheUtils.getPrefixKey(key)));
        }
        /// <summary>
        /// 清空缓存
        /// </summary>
        public void Clear()
        {
            var list = GetKeys();
            string[] keys = list.ToArray();
            Delete(keys);
        }


    }
}
