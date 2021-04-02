namespace MTCSharedModels.Models
{
    public class RouteGear
    {
        //[RockClimbingRoutesGearLinkingTable]
        [APIPostRequired(nameof(RockClimbingRoutesID))]
        public int? RockClimbingRoutesID { get; set; }
        [APIPostRequired(nameof(GearSizeID))]
        public byte? GearSizeID { get; set; }
        [APIPostRequired(nameof(NumberRequired))]
        public short? NumberRequired { get; set; }

        //[SQLIgnoreAttribute]
        //public RockClimbingRoute RockClimbingRoute { get; set; }

        [SQLIgnore]
        public GearSize Gear { get; set; }
    }
}
