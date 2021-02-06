using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class ZoneArea
    {
        public DistrictZone OwningDistrictZone { get; set; }
        public uint DistrictZoneID { get; set; }
        public uint ID { get; set; }
        public string EnglishFullName { get; set; }
        public string CountryCode { get; set; }
        public List<ClimbingWall> Districts { get; set; }
    }
}
