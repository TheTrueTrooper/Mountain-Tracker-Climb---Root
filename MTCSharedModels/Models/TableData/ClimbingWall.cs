using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class ClimbingWall
    {
        //public ZoneArea OwningZoneArea { get; set; } = null;
        [APIPostRequired(nameof(AreaID))]
        public int? AreaID { get; set; }
        [SQLIdentityID]
        public int? ID { get; set; }
        [APIPostRequired(nameof(EnglishFullName)), APIMinimumLength(1, nameof(EnglishFullName)), APIMaximumLength(100, nameof(EnglishFullName))]
        public string EnglishFullName { get; set; }
        [APIPostRequired(nameof(WallCode)), APIMinimumLength(1, nameof(WallCode)), APIMaximumLength(5, nameof(WallCode))]
        public string WallCode { get; set; }
        [SQLIgnore]
        public List<RockClimbingRoute> RockClimbingRoutes { get; set; } = null;
    }
}
