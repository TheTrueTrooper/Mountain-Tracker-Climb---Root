
namespace MTCSharedModels.Models
{
    public class RouteGear
    {
        //[RockClimbingRoutesGearLinkingTable]
        public int? RockClimbingRoutesID { get; set; }
        public byte? GearSizeID { get; set; }
        public short? NumberRequired { get; set; }

        //[SQLIgnoreAttribute]
        //public RockClimbingRoute RockClimbingRoute { get; set; }

        [SQLIgnoreAttribute]
        public GearSize Gear { get; set; }
    }
}
