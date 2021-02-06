using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class ClimbingWall
    {
        public ZoneArea OwningZoneArea { get; set; }
        public uint OwningZoneAreaID { get; set; }
        public uint ID { get; set; }
        public string EnglishFullName { get; set; }
        public string CountryCode { get; set; }
        public List<RockClimbingRoute> RockClimbingRoutes { get; set; }
    }
}
