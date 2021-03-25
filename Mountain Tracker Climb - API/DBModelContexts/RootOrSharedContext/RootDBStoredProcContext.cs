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
    /// <summary>
    /// Resposible for stored procedures 
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    internal abstract class RootDBStoredProcContext<T1, T2> : IDisposable, IDBRootContext where T2 : new()
    {
        public SqlConnection DB { protected set; get; }

        public RootDBStoredProcContext()
        {
            DB = new SqlConnection(StaticVars.DBConnectionsString);
            DB.Open();
        }

        public RootDBStoredProcContext(SqlConnection DB)
        {
            this.DB = DB;
        }

        protected abstract string DBStoredProcedure { get; }

        protected string GenerateExecValueString(T1 Object)
        {
            //UPDATE suppliers SET supplier_id = 50,supplier_name = 'Apple',city = 'Cupertino' WHERE supplier_name = 'Google';
            string Return = "";
            Type TType = typeof(T1);
            PropertyInfo[] Properties = TType.GetProperties();
            foreach (PropertyInfo x in Properties)
            {
                //Type T = x.PropertyType;
                if (!Attribute.IsDefined(x, typeof(SQLIgnoreAttribute)))
                {
                    object Obj = x.GetValue(Object);
                    if (Obj != null)
                        if (x.PropertyType.Name == typeof(string).Name)
                            Return += $"@{x.Name} = '{Obj}',";
                        else if (x.PropertyType.FullName == typeof(bool?).FullName)
                        {
                            bool Value = (bool)Convert.ChangeType(x.GetValue(Object), typeof(bool));
                            if (Value)
                                Return += $"@{x.Name} = 1,";
                            else
                                Return += $"@{x.Name} = 0,";
                        }
                        else
                            Return += $"@{x.Name} = {Obj},";
                    else
                        Return += $"@{x.Name} = NULL,";
                }
            }
            Return = Return.Remove(Return.Length - 1, 1);
            return Return;
        }

        //EXEC SelectAllCustomers @City = 'London', @PostalCode = 'WA1 1DP'; 

        protected string BasicExecute(T1 Object)
        {
            string Values = GenerateExecValueString(Object);
            return $"exec {DBStoredProcedure} {Values}";
        }

        protected IEnumerable<T2> Execute(T1 Object)
        {
            List<T2> Items = new List<T2>();
            string QueryString = BasicExecute(Object);
            Type TType = typeof(T2);
            PropertyInfo[] Properties = TType.GetProperties();
            using (SqlCommand Command = new SqlCommand(QueryString, DB))
            using (SqlDataReader DataReader = Command.ExecuteReader())
                while (DataReader.Read())
                {
                    int i = 0;
                    T2 NewObj = new T2();
                    Properties.ForEach(x =>
                    {
                        if (DataReader[i] == null || DataReader[i] == DBNull.Value)
                            x.SetValue(NewObj, null);
                        else
                            x.SetValue(NewObj, DataReader[i]);
                        i++;
                    });
                    Items.Add(NewObj);
                }
            return Items;
        }

        public void Dispose()
        {
            DB.Dispose();
        }
    }

    internal abstract class RootDBStoredProcContext<T1> : IDisposable, IDBRootContext
    {
        public SqlConnection DB { protected set; get; }

        public RootDBStoredProcContext()
        {
            DB = new SqlConnection(StaticVars.DBConnectionsString);
            DB.Open();
        }

        public RootDBStoredProcContext(SqlConnection DB)
        {
            this.DB = DB;
        }

        protected abstract string DBStoredProcedure { get; }

        protected string GenerateExecValueString(T1 Object)
        {
            //UPDATE suppliers SET supplier_id = 50,supplier_name = 'Apple',city = 'Cupertino' WHERE supplier_name = 'Google';
            string Return = "";
            Type TType = typeof(T1);
            PropertyInfo[] Properties = TType.GetProperties();
            foreach (PropertyInfo x in Properties)
            {
                //Type T = x.PropertyType;
                if (!Attribute.IsDefined(x, typeof(SQLIgnoreAttribute)))
                {
                    object Obj = x.GetValue(Object);
                    if (Obj != null)
                        if (x.PropertyType.Name == typeof(string).Name)
                            Return += $"@{x.Name} = '{Obj}',";
                        else if (x.PropertyType.FullName == typeof(bool?).FullName)
                        {
                            bool Value = (bool)Convert.ChangeType(x.GetValue(Object), typeof(bool));
                            if (Value)
                                Return += $"@{x.Name} = 1,";
                            else
                                Return += $"@{x.Name} = 0,";
                        }
                        else
                            Return += $"@{x.Name} = {Obj},";
                    else
                        Return += $"@{x.Name} = NULL,";
                }
            }
            Return = Return.Remove(Return.Length - 1, 1);
            return Return;
        }

        //EXEC SelectAllCustomers @City = 'London', @PostalCode = 'WA1 1DP'; 

        protected string BasicExecute(T1 Object)
        {
            string Values = GenerateExecValueString(Object);
            return $"exec {DBStoredProcedure} {Values}";
        }

        protected int Execute(T1 Object)
        {
            string QueryString = BasicExecute(Object);
            using (SqlCommand Command = new SqlCommand(QueryString, DB))
                return Command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}