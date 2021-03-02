using System.Collections.Generic;

namespace MTCSharedModels.Models
{
    public class ZoneArea
    {
        //public DistrictZone OwningDistrictZone { get; set; }
        public int? DistrictZoneID { get; set; }
        [SQLIdentityID]
        public int? ID { get; set; }
        public string EnglishFullName { get; set; }
        public string AreaCode { get; set; }
        [SQLIgnore]
        public List<ClimbingWall> ClimbingWalls { get; set; } = null;
    }
}
