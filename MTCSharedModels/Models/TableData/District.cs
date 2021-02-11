using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class District
    {
        //public Region OwningRegion { get; set; } = null;
        public uint RegionID { get; set; }
        public uint ID { get; set; }
        public string EnglishFullName { get; set; }
        public string DistrictCode { get; set; }
        public List<DistrictZone> Districts { get; set; } = null;
    }
}
