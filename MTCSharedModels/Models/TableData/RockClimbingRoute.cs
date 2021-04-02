using System.Collections.Generic;

namespace MTCSharedModels.Models
{
	//_RockClimbingRoutesAPIController
	public class RockClimbingRoute
    {
		//public ClimbingWall OwningClimbingWall { get; set; } = null;
		[APIPostRequired(nameof(ClimbingWallID))]
		public int? ClimbingWallID { get; set; }
		//needs a type for
		[APIPostRequired(nameof(TypeID))]
		public byte? TypeID { get; set; }
		[SQLIgnore]
		public ClimbingType RouteType { get; set; }
		//needs a type for
		[APIPostRequired(nameof(DifficultyID))]
		public byte? DifficultyID { get; set; }
		[SQLIgnore]
		public RockClimbingDifficulty Difficulty { get; set; }
		[SQLIgnore]
		public List<RouteGear> RoutesGear { get; set; } = null;
		[SQLIdentityID]
		public int? ID { get; set; }
		[APIPostRequired(nameof(EnglishFullName))]
		[APIMinimumLength(1, nameof(EnglishFullName))]
		[APIMaximumLength(100, nameof(EnglishFullName))]
		public string EnglishFullName { get; set; }
		[APIPostRequired(nameof(RouteCode))]
		[APIRegexCheck("[0-9][0-9][0-9]", "RouteCode Format", nameof(RouteCode), "Please ensure the route follows the following format '###' or '[0-9][0-9][0-9]'")]
		public string RouteCode { get; set; }
		[APIPostRequired(nameof(RouteWallNumber))]
		public int? RouteWallNumber { get; set; }
		[APIPostRequired(nameof(Rating))]
		public byte? Rating { get; set; }
		[APIPostRequired(nameof(HieghtInMeters))]
		public double? HieghtInMeters { get; set; }
		[SQLComputedColumn]
		public double? HieghtInFeet { get; set; } // calcualated from db as Meters * 3.xxxx
		//[Anchors] handled by gear
		[APIPostRequired(nameof(NumberOfPitchs))]
		public byte? NumberOfPitchs { get; set; }
		[APIMinimumLength(1, nameof(FirstAscent)), APIMaximumLength(100, nameof(FirstAscent))]
		public string FirstAscent { get; set; }
		[APIMinimumLength(1, nameof(FirstFreeAscent)), APIMaximumLength(100, nameof(FirstFreeAscent))]
		public string FirstFreeAscent { get; set; }
		[APIPostRequired(nameof(SunAM))]
		public bool? SunAM { get; set; }
		[APIPostRequired(nameof(SunPM))]
		public bool? SunPM { get; set; }
		[APIPostRequired(nameof(Filtered))]
		public bool? Filtered { get; set; }
		[APIPostRequired(nameof(Sunny))]
		public bool? Sunny { get; set; }
		[APIPostRequired(nameof(Shady))]
		public bool? Shady { get; set; }
		[APIPostRequired(nameof(DriesFast))]
		public bool? DriesFast { get; set; }
		[APIPostRequired(nameof(DryInRain))]
		public bool? DryInRain { get; set; }
		[APIPostRequired(nameof(Windy))]
		public bool? Windy { get; set; }
		[APIPostRequired(nameof(ClimbAnglesHaveSlabs))]
		public bool? ClimbAnglesHaveSlabs { get; set; }
		[APIPostRequired(nameof(ClimbAnglesHaveVerticals))]
		public bool? ClimbAnglesHaveVerticals { get; set; }
		[APIPostRequired(nameof(ClimbAnglesHaveOverHangs))]
		public bool? ClimbAnglesHaveOverHangs { get; set; }
		[APIPostRequired(nameof(ClimbAnglesHaveRoofs))]
		public bool? ClimbAnglesHaveRoofs { get; set; }
		[APIPostRequired(nameof(RockFalls))]
		public bool? RockFalls { get; set; }
		[APIPostRequired(nameof(Seepage))]
		public bool? Seepage { get; set; }
		[APIPostRequired(nameof(StickClip))]
		public bool? StickClip { get; set; }
		[APIPostRequired(nameof(Runout))]
		public bool? Runout { get; set; }
		[APIPostRequired(nameof(Reachy))]
		public bool? Reachy { get; set; }
		[APIPostRequired(nameof(Dyno))]
		public bool? Dyno { get; set; }
		[APIPostRequired(nameof(Pumpy))]
		public bool? Pumpy { get; set; }
		[APIPostRequired(nameof(Techy))]
		public bool? Techy { get; set; }
		[APIPostRequired(nameof(Power))]
		public bool? Power { get; set; }
		[APIPostRequired(nameof(PockSlashHole))]
		public bool? PockSlashHole { get; set; }
		[APIPostRequired(nameof(Crimpy))]
		public bool? Crimpy { get; set; }
		[APIPostRequired(nameof(SeatStart))]
		public bool? SeatStart { get; set; }
		[APIMinimumLength(1, nameof(RouteInfo)), APIMaximumLength(5000, nameof(RouteInfo))]
		public string RouteInfo { get; set; }
	}
}
