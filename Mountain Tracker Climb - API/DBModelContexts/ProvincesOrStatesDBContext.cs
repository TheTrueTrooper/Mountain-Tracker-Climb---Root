﻿using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts
{
    internal class ProvincesOrStatesDBContext : RootDBContext<ProvinceOrState>
    {
        public override string DBTable => "dbo.ProvincesOrStates";

        public ProvincesOrStatesDBContext() : base() { }

        public ProvincesOrStatesDBContext(IDBRootContext Context) : base(Context.DB) { }

        public IEnumerable<ProvinceOrState> GetListOfProvincesOrStates()
        {
            return GetListOf();
        }

        public IEnumerable<ProvinceOrState> GetListOfProvincesOrStates(int CountryID)
        {
            return GetListOf($"CountryID = {CountryID}");
        }

        public ProvinceOrState GetProvinceOrState(int ID)
        {
            return GetListOf($"ID = {ID}").FirstOrDefault();
        }
    }
}