using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain_Tracker_Climb___API.DBModelContexts
{
    interface IDBRootContext
    {
        SqlConnection DB { get; }
    }
}
