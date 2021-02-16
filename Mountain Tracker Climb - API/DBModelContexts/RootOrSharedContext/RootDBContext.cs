using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Mountain_Tracker_Climb___API.App_Start;
using System.Reflection;
using MTCSharedModels.Models;

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
                    foreach(PropertyInfo x in Properties)
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

        protected string GenerateValueString(T Object)
        {
            string Return = "";
            Type TType = typeof(T);
            DBListOfColumns.ForEach(x =>
            {
                PropertyInfo PInfo = TType.GetProperty(x);
                if(PInfo.PropertyType.Name == typeof(string).Name)
                    Return += $"'{PInfo.GetValue(Object)}',";
                else
                    Return += $"{PInfo.GetValue(Object)},";
            });
            Return = Return.Remove(Return.Length - 1, 1);
            return Return;
        }
        protected List<string> GenerateValueStrings(IEnumerable<T> ObjectList)
        {
            List<string> Return = new List<string>();
            Type TType = typeof(T);
            foreach (T Object in ObjectList)
            {
                string ItemReturn = "";
                DBListOfColumns.ForEach(x =>
                {
                    PropertyInfo PInfo = TType.GetProperty(x);
                    if (PInfo.PropertyType.Name == typeof(string).Name)
                        ItemReturn += $"'{PInfo.GetValue(Object)}',";
                    else
                        ItemReturn += $"{PInfo.GetValue(Object)},";
                });
                ItemReturn = ItemReturn.Remove(ItemReturn.Length - 1, 1);
                Return.Add(ItemReturn);
            }
            return Return;
        }

        protected string BasicInsert(string Columns, string Table, T Object)
        {
            //INSERT INTO Countries([ID], [EnglishFullName], [CountryCode]) VALUES (0, 'Afghanistan', 'AF')
            return $"insert into {Table} ({Columns}) values ({GenerateValueString(Object)})";
        }

        protected string BasicInsert(string Columns, string Table, IEnumerable<T> Object)
        {
            //INSERT INTO Countries([ID], [EnglishFullName], [CountryCode]) VALUES (0, 'Afghanistan', 'AF')
            string Return = $"insert into {Table} ({Columns}) values ";
            foreach (string Item in GenerateValueStrings(Object))
            {
                Return += $"({Item}),";
            }
            Return = Return.Remove(Return.Length - 1, 1);
            Return += ";";
            return Return;
        }

        protected string BasicInsert(T Object)
        {
            //INSERT INTO Countries([ID], [EnglishFullName], [CountryCode]) VALUES (0, 'Afghanistan', 'AF')
            return $"insert into {DBTable} ({DBStringListOfColumns}) values ({GenerateValueString(Object)})";
        }

        protected string BasicInsert(IEnumerable<T> Object)
        {
            //INSERT INTO Countries([ID], [EnglishFullName], [CountryCode]) VALUES (0, 'Afghanistan', 'AF')
            string Return = $"insert into {DBTable} ({DBStringListOfColumns}) values ";
            foreach (string Item in GenerateValueStrings(Object))
            {
                Return += $"({Item}),";
            }
            Return = Return.Remove(Return.Length - 1, 1);
            Return += ";";
            return Return;
        }

        protected string BasicDelete(string Table, string Where)
        {
            //INSERT INTO Countries([ID], [EnglishFullName], [CountryCode]) VALUES (0, 'Afghanistan', 'AF')
            return $"delete {Table} where {Where}";
        }

        protected string BasicDelete(string Where)
        {
            //INSERT INTO Countries([ID], [EnglishFullName], [CountryCode]) VALUES (0, 'Afghanistan', 'AF')
            return $"delete {DBTable} where {Where}";
        }

        protected IEnumerable<T> GetListOf()
        {
            List<T> Countries = new List<T>();
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
                        TType.GetProperty(x).SetValue(NewObj, DataReader[i]);
                        i++;
                    });
                    Countries.Add(NewObj);
                }
            return Countries;
        }

        protected IEnumerable<T> GetListOf(string Where)
        {
            List<T> Countries = new List<T>();
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
                        TType.GetProperty(x).SetValue(NewObj, DataReader[i]);
                        i++;
                    });
                    Countries.Add(NewObj);
                }
            return Countries;
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