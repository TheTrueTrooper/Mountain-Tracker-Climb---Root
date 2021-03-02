using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Mountain_Tracker_Climb___API.App_Start;
using System.Reflection;
using MTCSharedModels.Models;
using System.Net.Http.Headers;
using WebGrease.Css.Extensions;

namespace Mountain_Tracker_Climb___API.DBModelContexts
{
    internal abstract class RootDBContext<T> : IDisposable, IDBRootContext where T : new()
    {

        public SqlConnection DB { protected set; get; }

        public RootDBContext()
        {
            DB = new SqlConnection(StaticVars.DBConnectionsString);
            DB.Open();
        }

        public RootDBContext(SqlConnection DB)
        {
            this.DB = DB;
        }

        string _DBTable { get; set; }
        public virtual string DBTable
        {
            get
            {
                if (_DBTable == null)
                    _DBTable = $"dbo.{typeof(T).Name}s";
                return _DBTable;
            }
        }

        static List<string> _DBListOfColumns;
        public static List<string> DBListOfColumns
        {
            get
            {
                if (_DBListOfColumns == null)
                {
                    _DBListOfColumns = new List<string>();
                    PropertyInfo[] Properties = typeof(T).GetProperties();
                    foreach (PropertyInfo x in Properties)
                    {
                        //Type T = x.PropertyType;
                        if (!Attribute.IsDefined(x, typeof(SQLIgnoreAttribute)))
                            _DBListOfColumns.Add(x.Name);
                    }
                }
                return _DBListOfColumns;
            }
        }

        public static string DBStringListOfColumns
        {
            get
            {
                string Return = "";
                DBListOfColumns.ForEach(x =>
                {
                    Return += $"{x},";
                });
                Return = Return.Remove(Return.Length - 1, 1);
                return Return;
            }
        }

        protected string BasicSelect(string Where = null)
        {
            if (Where == null)
                return $"select {DBStringListOfColumns} from {DBTable}";
            return $"select {DBStringListOfColumns} from {DBTable} where {Where}";
        }

        protected string BasicSelect(string Columns, string Table, string Where = null)
        {
            if (Where == null)
                return $"select {Columns} from {Table}";
            return $"select {Columns} from {Table} where {Where}";
        }

        protected string[] GenerateInsertValueString(T Object)
        {
            string[] Return = new string[2];
            Return[0] = "";
            Return[1] = "";
            Type TType = typeof(T);
            PropertyInfo[] Properties = TType.GetProperties();
            foreach (PropertyInfo x in Properties)
            {
                if (!Attribute.IsDefined(x, typeof(SQLIgnoreAttribute)) && !Attribute.IsDefined(x, typeof(SQLIdentityIDAttribute)) && !Attribute.IsDefined(x, typeof(SQLComputedColumn)))
                {
                    Return[0] += $"{x.Name},";
                    if (x.PropertyType.Name == typeof(string).Name)
                        Return[1] += $"'{x.GetValue(Object)}',";
                    else if (x.PropertyType.FullName == typeof(bool?).FullName)
                    {
                        bool Value = (bool)Convert.ChangeType(x.GetValue(Object), typeof(bool));
                        if (Value)
                            Return[1] += $"1,";
                        else
                            Return[1] += $"0,";
                    }
                    else
                        Return[1] += $"{x.GetValue(Object)},";
                }
            }
            Return[0] = Return[0].Remove(Return[0].Length - 1, 1);
            Return[1] = Return[1].Remove(Return[1].Length - 1, 1);
            return Return;
        }

        protected string GenerateUpdateValueString(T Object)
        {
            //UPDATE suppliers SET supplier_id = 50,supplier_name = 'Apple',city = 'Cupertino' WHERE supplier_name = 'Google';
            string Return = "";
            Type TType = typeof(T);
            PropertyInfo[] Properties = TType.GetProperties();
            foreach (PropertyInfo x in Properties)
            {
                //Type T = x.PropertyType;
                if (!Attribute.IsDefined(x, typeof(SQLIgnoreAttribute)) && !Attribute.IsDefined(x, typeof(SQLIdentityIDAttribute)) && !Attribute.IsDefined(x, typeof(SQLComputedColumn)))
                {
                    object Obj = x.GetValue(Object);
                    if (Obj != null)
                        if (x.PropertyType.Name == typeof(string).Name)
                            Return += $"{x.Name} = '{Obj}',";
                        else if (x.PropertyType.FullName == typeof(bool?).FullName)
                        {
                            bool Value = (bool)Convert.ChangeType(x.GetValue(Object), typeof(bool));
                            if (Value)
                                Return += $"{x.Name} = 1,";
                            else
                                Return += $"{x.Name} = 0,";
                        }
                        else
                            Return += $"{x.Name} = {Obj},";
                }
            }
            Return = Return.Remove(Return.Length - 1, 1);
            return Return;
        }


        protected Dictionary<string, List<string>> GenerateValueDictionary(IEnumerable<T> ObjectList)
        {
            Dictionary<string, List<string>> Return = new Dictionary<string, List<string>>();
            Type TType = typeof(T);
            PropertyInfo[] Properties = TType.GetProperties();
            foreach (PropertyInfo x in Properties)
            {
                if (!Attribute.IsDefined(x, typeof(SQLIgnoreAttribute)) && !Attribute.IsDefined(x, typeof(SQLIdentityIDAttribute)) && !Attribute.IsDefined(x, typeof(SQLComputedColumn)))
                {
                    Return.Add(x.Name, new List<string>());
                    foreach (T Object in ObjectList)
                    {
                        if (x.PropertyType.Name == typeof(string).Name)
                            Return[x.Name].Add($"'{x.GetValue(Object)}'");
                        else if (x.PropertyType.FullName == typeof(bool?).FullName)
                        {
                            bool Value = (bool)Convert.ChangeType(x.GetValue(Object), typeof(bool));
                            if (Value)
                                Return[x.Name].Add($"1");
                            else
                                Return[x.Name].Add($"0");
                        }
                        else
                            Return[x.Name].Add($"{x.GetValue(Object)}");
                    }
                }
            }
            return Return;
        }

        protected string BasicInsert(string Table, T Object)
        {
            string[] Values = GenerateInsertValueString(Object);
            return $"insert into {Table} ({Values[0]}) values ({Values[1]})";
        }

        protected string BasicInsert(string Table, IEnumerable<T> Objects)
        {
            Dictionary<string, List<string>> ValueDiction = GenerateValueDictionary(Objects);
            string Columns = "";
            List<string> Values = new List<string>();
            foreach(KeyValuePair<string, List<string>> KP in ValueDiction)
            {
                int i = 0;
                Columns += $"{KP.Key},";
                foreach(string Value in KP.Value)
                {
                    if (Values[i] == null)
                        Values[i] = "";
                    Values[i] += $"{Value},";
                    i++;
                }
            }
            Values.ForEach(x =>
            {
                x = x.Remove(x.Length - 1, 1);
            });
            Columns = Columns.Remove(Columns.Length - 1, 1);

            string Return = $"insert into {Table} ({Columns}) values ";
            foreach (string Item in Values)
            {
                Return += $"({Item}),";
            }
            Return = Return.Remove(Return.Length - 1, 1);
            Return += ";";
            return Return;
        }

        protected string BasicInsert(T Object)
        {
            string[] Values = GenerateInsertValueString(Object);
            return $"insert into {DBTable} ({Values[0]}) values ({Values[1]})";
        }

        protected string BasicInsert(IEnumerable<T> Objects)
        {
            Dictionary<string, List<string>> ValueDiction = GenerateValueDictionary(Objects);
            string Columns = "";
            List<string> Values = new List<string>();
            foreach (KeyValuePair<string, List<string>> KP in ValueDiction)
            {
                int i = 0;
                Columns += $"{KP.Key},";
                foreach (string Value in KP.Value)
                {
                    if (Values[i] == null)
                        Values[i] = "";
                    Values[i] += $"{Value},";
                    i++;
                }
            }
            Values.ForEach(x =>
            {
                x.Remove(x.Length - 1, 1);
            });
            Columns.Remove(Columns.Length - 1, 1);

            string Return = $"insert into {DBTable} ({Columns}) values ";
            foreach (string Item in Values)
            {
                Return += $"({Item}),";
            }
            Return = Return.Remove(Return.Length - 1, 1);
            Return += ";";
            return Return;
        }

        protected string BasicUpdate(string Table, T Object, string Where)
        {
            string Values = GenerateUpdateValueString(Object);
            return $"update {Table} set {Values} where {Where}";
            //UPDATE suppliers SET supplier_id = 50,supplier_name = 'Apple',city = 'Cupertino' WHERE supplier_name = 'Google';
        }

        protected string BasicUpdate(T Object, string Where)
        {
            string Values = GenerateUpdateValueString(Object);
            return $"update {DBTable} set {Values} where {Where}";
            //UPDATE suppliers SET supplier_id = 50,supplier_name = 'Apple',city = 'Cupertino' WHERE supplier_name = 'Google';
        }

        protected string BasicDelete(string Table, string Where)
        {
            return $"delete {Table} where {Where}";
        }

        protected string BasicDelete(string Where)
        {
            return $"delete {DBTable} where {Where}";
        }

        protected IEnumerable<T> GetListOf()
        {
            List<T> Items = new List<T>();
            string QueryString = BasicSelect();
            using (SqlCommand Command = new SqlCommand(QueryString, DB))
            using (SqlDataReader DataReader = Command.ExecuteReader())
                while (DataReader.Read())
                {
                    int i = 0;
                    T NewObj = new T();
                    Type TType = typeof(T);
                    DBListOfColumns.ForEach(x =>
                    {
                        if (DataReader[i] == null || DataReader[i] == DBNull.Value)
                            TType.GetProperty(x).SetValue(NewObj, null);
                        else
                            TType.GetProperty(x).SetValue(NewObj, DataReader[i]);
                        i++;
                    });
                    Items.Add(NewObj);
                }
            return Items;
        }

        protected IEnumerable<T> GetListOf(string Where)
        {
            List<T> Items = new List<T>();
            string QueryString = BasicSelect(Where);
            using (SqlCommand Command = new SqlCommand(QueryString, DB))
            using (SqlDataReader DataReader = Command.ExecuteReader())
                while (DataReader.Read())
                {
                    int i = 0;
                    T NewObj = new T();
                    Type TType = typeof(T);
                    DBListOfColumns.ForEach(x =>
                    {
                        if(DataReader[i] == null || DataReader[i] == DBNull.Value)
                            TType.GetProperty(x).SetValue(NewObj, null);
                        else
                            TType.GetProperty(x).SetValue(NewObj, DataReader[i]);
                        i++;
                    });
                    Items.Add(NewObj);
                }
            return Items;
        }
        
        protected int InsertData(T Object)
        {
            string QueryString = BasicInsert(Object);
            using (SqlCommand Command = new SqlCommand(QueryString, DB))
                return Command.ExecuteNonQuery();
        }

        protected int InsertData(IEnumerable<T> Object)
        {
            string QueryString = BasicInsert(Object);
            using (SqlCommand Command = new SqlCommand(QueryString, DB))
                return Command.ExecuteNonQuery();
        }

        protected int UpdateData(T Object, string Where)
        {
            string QueryString = BasicUpdate(Object, Where);
            using (SqlCommand Command = new SqlCommand(QueryString, DB))
                return Command.ExecuteNonQuery();
        }

        protected int DeleteData(string Where)
        {
            string QueryString = BasicDelete(Where);
            using (SqlCommand Command = new SqlCommand(QueryString, DB))
                return Command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            try
            {
                DB.Dispose();
            }
            finally
            {

            }
        }
    }
}