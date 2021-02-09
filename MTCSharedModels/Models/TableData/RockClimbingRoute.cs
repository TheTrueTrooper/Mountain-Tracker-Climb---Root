using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class RockClimbingRoute
    {
		//public ClimbingWall OwningClimbingWall { get; set; } = null;
		public uint ClimbingWallID { get; set; }
		//needs a type for
		public byte TypeID { get; set; }
		//needs a type for
		public byte DifficultyID { get; set; }
		//Needs a type for List<GearEntry> from RockClimbingRoutesGearLinkingTable
		public uint ID { get; set; }
		public string EnglishFullName { get; set; }
		public string RouteCode { get; set; }
		public uint RouteWallNumber { get; set; }
		public byte Rating { get; set; }
		public float HieghtInMeters { get; set; }
		public float HieghtInFeet { get; set; } // calcualated from db as Meters * 3.xxxx
		//[Anchors] handled by gear
		public byte NumberOfPitchs { get; set; }
		public string FirstAscent { get; set; }
		public string FirstFreeAscent { get; set; }
		public bool SunAM { get; set; }
		public bool SunPM { get; set; }
		public bool Filtered { get; set; }
		public bool Sunny { get; set; }
		public bool Shady { get; set; }
		public bool DriesFast { get; set; }
		public bool DryInRain { get; set; }
		public bool Windy { get; set; }
		public bool ClimbAnglesHaveSlabs { get; set; }
		public bool ClimbAnglesHaveVerticals { get; set; }
		public bool ClimbAnglesHaveOverHangs { get; set; }
		public bool ClimbAnglesHaveRoofs { get; set; }
		public bool RockFalls { get; set; }
		public bool Seepage { get; set; }
		public bool StickClip { get; set; }
		public bool Runout { get; set; }
		public bool Reachy { get; set; }
		public bool Dyno { get; set; }
		public bool Pumpy { get; set; }
		public bool Techy { get; set; }
		public bool Power { get; set; }
		public bool PockSlashHole { get; set; }
		public bool Crimpy { get; set; }
		public bool SeatStart { get; set; }
		public string Picture360 { get; set; }
		public string Picture3603D { get; set; }
		public string RouteInfo { get; set; }
	}
}
