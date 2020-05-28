using System;
using System.Collections.Generic;

namespace BookingPlatform.Common.CacheManage
{

    /// <summary>
    /// 缓存通用接口类
    /// </summary>
    public interface IDataCache
    {

        /// <summary>
        /// 获取所有的keys 暂未实现
        /// </summary>
        /// <returns></returns>
        List<String> GetKeys();

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存key</param>
        /// <returns></returns>
        String Get(string key);
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetNoPrefix(string key);
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key);
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="depFile"></param>
        /// <returns></returns>
        T Get<T>(string key, string depFile);

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存key</param>
        /// <param name="value">缓存值</param>
        /// <returns>返回值，表示：是否写入成功</returns>
        bool Set<T>(string key, T value);

        /// <summary>
        /// 写入缓存，设置过期时间点
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存key</param>
        /// <param name="value">缓存值</param>
        /// <param name="expiresAt">过期时间点</param>
        /// <returns>返回值，表示：是否写入成功</returns>
        bool Set<T>(string key, T value, DateTime expiresAt);
        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        bool Set<T>(string key, T value, TimeSpan timeSpan);

        /// <summary>
        /// 写入缓存，设置过期秒数
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存key</param>
        /// <param name="value">缓存值</param>
        /// <param name="expiresSecond">过期秒数</param>
        /// <returns>返回值，表示：是否写入成功</returns>
        bool Set<T>(string key, T value, int expiresSecond);

        bool Set<T>(string key, T value, string depFile);

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <returns></returns>
        int Delete(string key);

        /// <summary>
        /// 删除多个缓存
        /// </summary>
        /// <param name="keys">缓存key数组</param>
        /// <returns></returns>
        int Delete(string[] keys);
        /// <summary>
        /// 清空缓存
        /// </summary>
        void Clear();
    }
}

