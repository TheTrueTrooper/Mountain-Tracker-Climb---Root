using MTCSharedModels.Models;
using MTCSharedModels.Models.TableData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts
{
    internal class ClimbingTypeDBContext : RootDBContext<ClimbingType>
    {
        public ClimbingTypeDBContext() : base() { }

        public ClimbingTypeDBContext(IDBRootContext Context) : base(Context.DB) { }

        public IEnumerable<ClimbingType> GetListOfClimbingType()
        {
            return GetListOf();
        }

        public ClimbingType GetClimbingType(byte id)
        {
            return GetListOf($"ID = {id}").First();
        }

        public int AddClimbingType(ClimbingType Values)
        {
            return InsertData(Values);
        }

        public int UpdateClimbingType(int ID, ClimbingType Values)
        {
            return UpdateData(Values, $"ID = {ID}");
        }

        public int DeleteClimbingType(int ID)
        {
            return DeleteData($"ID = {ID}");
        }
    }
}