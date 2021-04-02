using System.Collections.Generic;

namespace MTCSharedModels.Models
{
    public class ClimbingWall
    {
        //public ZoneArea OwningZoneArea { get; set; } = null;
        [APIPostRequired(nameof(AreaID))]
        public int? AreaID { get; set; }
        [SQLIdentityID]
        public int? ID { get; set; }
        [APIPostRequired(nameof(EnglishFullName))]
        [APIMinimumLength(1, nameof(EnglishFullName))]
        [APIMaximumLength(100, nameof(EnglishFullName))]
        public string EnglishFullName { get; set; }
        [APIPostRequired(nameof(WallCode))]
        [APIMinimumLength(1, nameof(WallCode))]
        [APIMaximumLength(5, nameof(WallCode))]
        [APIRegexCheck("[0-9][0-9][0-9]", "WallCode Format", nameof(WallCode), "Please ensure the route follows the following format '###' or '[0-9][0-9][0-9]'")]
        public string WallCode { get; set; }
        [SQLIgnore]
        public List<RockClimbingRoute> RockClimbingRoutes { get; set; } = null;
    }
}
