using BookingPlatform.Models.LogManage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;

namespace BookingPlatform.Common
{

    public static class IEnumerableEx
    {


        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static IEnumerable<T> CopyToCopy<T1, T>(this IEnumerable<T1> t) where T : class, new()
                                                                    where T1 : class, new()
        {
            if (t == null || !t.Any())
            {
                return new List<T>();
            }
            var list = new List<T>();
            var tlps = typeof(T1).GetProperties().ToList();
            var tps = typeof(T).GetProperties().ToList();
            t.ToList().ForEach(o =>
            {
                var nobj = new T();
                tlps.ForEach(p =>
                {
                    try
                    {
                        var tp = tps.FirstOrDefault(n => n.Name == p.Name);
                        if (tp == null) return;
                        var objval = p.GetValue(o);
                        if (tp.Name != "_primarykey")
                            tp.SetValue(nobj, objval);
                    }
                    catch (Exception ex)
                    {
                        LogManage.LogError(ex);
                    }
                });
                list.Add(nobj);
            });
            return list;
        }

        /// <summary>
        ///  Performs the specified action on each element of the System.Collections.Generic.List`1.
        /// </summary>
        /// <typeparam name="TSource">The System.Action`1 delegate to perform on each element of the System.Collections.Generic.List`1.</typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IList<TSource> ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            if (source == null) return null;
            var ls = source.ToList();
            ls.ForEach(action);
            return ls;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static string XJoin<TSource>(this IEnumerable<TSource> source, string splicstr)
        {
            return string.Join(splicstr, source);
        }

        /// <summary>
        ///  Performs the specified action on each element of the System.Collections.Generic.List`1.
        /// </summary>
        /// <typeparam name="TSource">The System.Action`1 delegate to perform on each element of the System.Collections.Generic.List`1.</typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IList<TSource> SetNo<TSource>(this IEnumerable<TSource> source, Action<TSource, int> selector)
        {
            if (source == null) return null;
            var ls = source.ToList();
            for (int i = 0; i < ls.Count; i++)
            {
                selector.Invoke(ls[i], i);
            }
            return ls;
        }
    }


    /// <summary>
    /// DateTime类型转换String扩展类
    /// </summary>
    public static class Date2StringEx
    {
        /// <summary>
        /// 转换yyyy-MM-dd
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDate1(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 转换yyyy-MM-dd 00:00:00
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDate1_First(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd 00:00:00");
        }

        /// <summary>
        /// 转换yyyy-MM-dd 23:59:59
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDate1_Last(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd 23:59:59");
        }
        /// <summary>
        /// 转换yyyy-MM-dd HH:mm
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDate3(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm");
        }
        /// <summary>
        /// 转换yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDate4(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// 转换yyyyMMdd
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDate5(this DateTime dt)
        {
            return dt.ToString("yyyyMMdd");
        }
        /// <summary>
        /// 转换HH:mm
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDate6(this DateTime dt)
        {
            return dt.ToString("HH:mm");
        }
        /// <summary>
        /// 转换HH
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDate7(this DateTime dt)
        {
            return dt.ToString("HH");
        }
    }

    /// <summary>
    /// String类型转换int扩展类
    /// </summary>
    public static class StringIntEx
    {
        /// <summary>
        /// JSON反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <returns></returns>
        public static T JSONDeserialize<T>(this string @this) where T : class
        {
            if (@this.IsNullOrEmpty())
                return null;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(@this);
        }


        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
        /// <summary>
        /// 是否是Int类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt(this string str)
        {
            int odt = 0;
            return int.TryParse(str, out odt);
        }


        /// <summary>
        /// 转换日期格式，如果不能转换返回当前日期
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt(this string str)
        {
            if (str.IsInt())
                return int.Parse(str);
            return 0;
        }
    }

    /// <summary>
    ///String类型转换DateTime扩展类
    /// </summary>
    public static class StringDateEx
    {
        /// <summary>
        /// 是否日期格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDateTime(this string str)
        {
            DateTime odt = DateTime.Now;
            return DateTime.TryParse(str, out odt);
        }

        /// <summary>
        /// 是否日期格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDateTimeOrNull(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return true;
            DateTime odt = DateTime.Now;
            return DateTime.TryParse(str, out odt);
        }

        /// <summary>
        /// 转换日期格式，如果不能转换返回当前日期
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string str)
        {
            if (str.IsDateTime())
                return DateTime.Parse(str);
            return DateTime.Now;
        }


        /// <summary>
        /// 转换日期格式，如果不能转换返回Null
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime? ToDateTimeOrNull(this string str)
        {
            if (str.IsDateTime())
                return DateTime.Parse(str);
            return null;
        }
    }

    /// <summary>
    /// 帮助类
    /// </summary>
    public class Helper
    {

        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static SortedList<int, string> GetItems<T>()
        {
            var result = new SortedList<int, string>();
            var t = typeof(T);
            Array arrays = Enum.GetValues(t);
            for (int i = 0; i < arrays.LongLength; i++)
            {
                var test = arrays.GetValue(i);
                var fieldInfo = test.GetType().GetField(test.ToString());
                var attribArray = fieldInfo.GetCustomAttributes(false);
                var attrib = (DescriptionAttribute)attribArray[0];
                result.Add(Convert.ToInt32(test), attrib.Description);
            }
            return result;
        }


        /// <summary>
        /// 内网服务器地址
        /// </summary>
        public static string SurgerAppointmentApiAddress
        {
            get
            {
                return ConfigExtensions.Configuration["appSettings:SurgerAppointment_ApiAddress"];
            }
        }


        /// <summary>
        /// 内网服务器地址
        /// </summary>
        public static string Patient_ApiAddress
        {
            get
            {
                return ConfigExtensions.Configuration["appSettings:Patient_ApiAddress"];
            }
        }

    }



    public static class ExtendMethod
    {
        /// <summary>
        /// DataTable转成List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ToDataList<T>(this DataTable dt)
        {
            var list = new List<T>();
            var plist = new List<PropertyInfo>(typeof(T).GetProperties());
            foreach (DataRow item in dt.Rows)
            {
                T s = Activator.CreateInstance<T>();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    PropertyInfo info = plist.Find(p => p.Name.ToUpper() == dt.Columns[i].ColumnName.ToUpper());
                    if (info != null)
                    {
                        try
                        {
                            if (!Convert.IsDBNull(item[i]))
                            {
                                object v = null;
                                if (info.PropertyType.ToString().Contains("System.Nullable"))
                                {
                                    v = Convert.ChangeType(item[i], Nullable.GetUnderlyingType(info.PropertyType));
                                }
                                else
                                {
                                    v = Convert.ChangeType(item[i], info.PropertyType);
                                }
                                info.SetValue(s, v, null);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("字段[" + info.Name + "]转换出错," + ex.Message);
                        }
                    }
                }
                list.Add(s);
            }
            return list;
        }

        /// <summary>
        /// DataTable转成Dto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static T ToDataDto<T>(this DataTable dt)
        {
            T s = Activator.CreateInstance<T>();
            if (dt == null || dt.Rows.Count == 0)
            {
                return s;
            }
            var plist = new List<PropertyInfo>(typeof(T).GetProperties());
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                PropertyInfo info = plist.Find(p => p.Name == dt.Columns[i].ColumnName);
                if (info != null)
                {
                    try
                    {
                        if (!Convert.IsDBNull(dt.Rows[0][i]))
                        {
                            object v = null;
                            if (info.PropertyType.ToString().Contains("System.Nullable"))
                            {
                                v = Convert.ChangeType(dt.Rows[0][i], Nullable.GetUnderlyingType(info.PropertyType));
                            }
                            else
                            {
                                v = Convert.ChangeType(dt.Rows[0][i], info.PropertyType);
                            }
                            info.SetValue(s, v, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("字段[" + info.Name + "]转换出错," + ex.Message);
                    }
                }
            }
            return s;
        }

        /// <summary>
        /// 将实体集合转换为DataTable
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entities">实体集合</param>
        public static DataTable ToDataTable<T>(List<T> entities)
        {
            var result = CreateTable<T>();
            FillData(result, entities);
            return result;
        }

        /// <summary>
        /// 创建表
        /// </summary>
        private static DataTable CreateTable<T>()
        {
            var result = new DataTable();
            var type = typeof(T);
            foreach (var property in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                var propertyType = property.PropertyType;
                if ((propertyType.IsGenericType) && (propertyType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    propertyType = propertyType.GetGenericArguments()[0];
                result.Columns.Add(property.Name, propertyType);
            }
            return result;
        }

        /// <summary>
        /// 填充数据
        /// </summary>
        private static void FillData<T>(DataTable dt, IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                dt.Rows.Add(CreateRow(dt, entity));
            }
        }

        /// <summary>
        /// 创建行
        /// </summary>
        private static DataRow CreateRow<T>(DataTable dt, T entity)
        {
            DataRow row = dt.NewRow();
            var type = typeof(T);
            foreach (var property in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                row[property.Name] = property.GetValue(entity) ?? DBNull.Value;
            }
            return row;
        }
    }
}