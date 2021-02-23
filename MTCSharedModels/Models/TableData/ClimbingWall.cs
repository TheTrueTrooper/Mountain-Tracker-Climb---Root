using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class ClimbingWall
    {
        //public ZoneArea OwningZoneArea { get; set; } = null;
        public int? AreaID { get; set; }
        [SQLIdentityID]
        public int? ID { get; set; }
        public string EnglishFullName { get; set; }
        public string WallCode { get; set; }
        [SQLIgnore]
        public List<RockClimbingRoute> RockClimbingRoutes { get; set; } = null;
    }
}
