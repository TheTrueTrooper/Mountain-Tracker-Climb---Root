﻿using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts
{
    internal class RockClimbingDifficultiesDBContext : RootDBContext<RockClimbingDifficulty>
    {
        public override string DBTable => "dbo.RockClimbingDifficulties";

        public RockClimbingDifficultiesDBContext() : base() { }

        public RockClimbingDifficultiesDBContext(IDBRootContext Context) : base(Context.DB) { }

        public IEnumerable<RockClimbingDifficulty> GetListOfRockClimbingDifficulties()
        {
            return GetListOf();
        }

        public RockClimbingDifficulty GetRockClimbingDifficulty(byte ID)
        {
            return GetListOf($"ID = {ID}").FirstOrDefault();
        }

        public int AddRockClimbingDifficulty(RockClimbingDifficulty Values)
        {
            return InsertData(Values);
        }

        public int UpdateRockClimbingDifficulty(int ID, RockClimbingDifficulty Values)
        {
            return UpdateData(Values, $"ID = {ID}");
        }

        public int DeleteRockClimbingDifficulty(int ID)
        {
            return DeleteData($"ID = {ID}");
        }
    }
}