﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class Region
    {
        //public ProvinceOrState OwningProvinceOrState { get; set; }
        public int ProvinceOrStateID { get; set; }
        public int ID { get; set; }
        public string EnglishFullName { get; set; }
        public string RegionCode { get; set; }
        [SQLIgnore]
        public List<District> Districts { get; set; } = null;
    }
}
