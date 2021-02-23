using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts
{
    internal class ClimbingWallsDBContext : RootDBContext<ClimbingWall>
    {
        public ClimbingWallsDBContext() : base() { }

        public ClimbingWallsDBContext(IDBRootContext Context) : base(Context.DB) { }

        public IEnumerable<ClimbingWall> GetListOfClimbingWalls()
        {
            return GetListOf();
        }

        public IEnumerable<ClimbingWall> GetListOfClimbingWalls(int AreaID)
        {
            return GetListOf($"AreaID = {AreaID}");
        }

        public ClimbingWall GetClimbingWall(int id)
        {
            return GetListOf($"ID = {id}").First();
        }

        public int AddClimbingWall(ClimbingWall Values)
        {
            return InsertData(Values);
        }

        public int UpdateClimbingWall(int ID, ClimbingWall Values)
        {
            return UpdateData(Values, $"ID = {ID}");
        }

        public int DeleteClimbingWall(int ID)
        {
            return DeleteData($"ID = {ID}");
        }
    }
}