using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts
{
    internal static class SQLHelper
    {
        public static string EscapeSQLString(string Str)
        {
            return Str.Replace("'","''");
        }

        public static string ObjectAsSQLString(object Object)
        {
            Type ObjectsType = Object.GetType();
            if (ObjectsType.Name == typeof(string).Name)
                return $"'{EscapeSQLString((string)Object)}'";
            else if (ObjectsType.FullName == typeof(bool?).FullName)
            {
                if (Object == null)
                    return "NULL";

                bool Value = (bool)Convert.ChangeType(Object, typeof(bool));

                if (Value)
                    return "1";
                else
                    return "0";
            }
            else if (ObjectsType.FullName == typeof(bool).FullName)
            {
                bool Value = (bool)Object;

                if (Value)
                    return "1";
                else
                    return "0";
            }
            else if (ObjectsType.FullName == typeof(byte[]).FullName)
                return $"0x{BitConverter.ToString((byte[])Object).Replace("-", "")}";
            else if (ObjectsType.FullName == typeof(DateTime).FullName)
                return ((DateTime)Object).ToString("yyyy-MM-dd HH:mm:ss.fff");
            return Object.ToString();
        }
    }
}