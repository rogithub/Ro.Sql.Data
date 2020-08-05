using System;
using System.Data;
using System.Xml;

namespace Ro.Sql.Data
{
    public static class DataReaderHelpers
    {
        public static DateTime GetDate(this IDataReader dr, string key)
        {
            return MapperHelpers.ToDate(dr[key]);
        }

        public static string GetString(this IDataReader dr, string key)
        {
            return MapperHelpers.ToStr(dr[key]);
        }

        public static decimal GetDecilmal(this IDataReader dr, string key)
        {
            return MapperHelpers.ToDecilmal(dr[key]);
        }

        public static float GetFloat(this IDataReader dr, string key)
        {
            return MapperHelpers.ToFloat(dr[key]);
        }

        public static int GetInt(this IDataReader dr, string key)
        {
            return MapperHelpers.ToInt(dr[key]);
        }

        public static long GetLong(this IDataReader dr, string key, long ifNull = 0)
        {
            return MapperHelpers.ToLong(dr[key]);
        }

        public static Guid GetGuid(this IDataReader dr, string key)
        {
            return MapperHelpers.ToGuid(dr[key]);
        }

        public static Guid? ToGuidNullable(this IDataReader dr, string key)
        {
            return MapperHelpers.ToGuidNullable(dr[key]);
        }

        public static XmlDocument GetXml(this IDataReader dr, string key)
        {
            return MapperHelpers.ToXml(dr[key]);
        }

        public static T GetValue<T>(this IDataReader dr, string key)
        {
            return MapperHelpers.ToVal<T>(dr[key]);
        }
    }
}
