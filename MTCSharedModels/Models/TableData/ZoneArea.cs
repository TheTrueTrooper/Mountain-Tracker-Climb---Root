using System.Collections.Generic;

namespace MTCSharedModels.Models
{
    public class ZoneArea
    {
        //public DistrictZone OwningDistrictZone { get; set; }
        [APIPostRequired(nameof(DistrictZoneID))]
        public int? DistrictZoneID { get; set; }
        [SQLIdentityID]
        public int? ID { get; set; }
        [APIPostRequired(nameof(EnglishFullName))]
        [APIMinimumLength(1, nameof(EnglishFullName))]
        [APIMaximumLength(100, nameof(EnglishFullName))]
        public string EnglishFullName { get; set; }
        [APIPostRequired(nameof(AreaCode))]
        [APIMinimumLength(1, nameof(AreaCode))]
        [APIMaximumLength(5, nameof(AreaCode))]
        [APIRegexCheck("^[W][0-9][0-9][0-9]$|^[B][0-9][0-9][0-9]$", "AreaCode Format", nameof(AreaCode), "Please ensure the route follows the following format 'B###' or 'W###'. That is it must be 'W[0-9][0-9][0-9]' or 'B[0-9][0-9][0-9]'.")]
        public string AreaCode { get; set; }
        [SQLIgnore]
        public List<ClimbingWall> ClimbingWalls { get; set; } = null;
    }
}
