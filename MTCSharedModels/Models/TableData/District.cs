using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class District
    {
        //public Region OwningRegion { get; set; } = null;
        public int? RegionID { get; set; }
        [SQLIdentityID]
        public int? ID { get; set; }
        public string EnglishFullName { get; set; }
        public string DistrictCode { get; set; }
        [SQLIgnore]
        public List<DistrictZone> Zones { get; set; } = null;
    }
}
