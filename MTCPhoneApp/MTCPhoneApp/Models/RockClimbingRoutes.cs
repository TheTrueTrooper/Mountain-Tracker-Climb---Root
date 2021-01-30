using System;
using System.Collections.Generic;
using System.Text;

namespace MTCPhoneApp.Models
{
	public class ClimbingRoute
    {
		public int RouteID { get; set; }
		public RockWallClimbingType WallType { get; set; }
		public string EnglishFullName { get; set; }
		public string RouteCode { get; set; }
		public int RouteWallNumber { get; set; }
		//[Difficulty] TINYINT NOT NULL,
		//[Rating] TINYINT NOT NULL,
		//[HieghtInMeters] FLOAT NOT NULL,
		//[HieghtInFeet] As 3.28084 * [HieghtInMeters],
		//--[Gear] TINYINT NOT NULL,* - * so needs a linking table as RockClimbingRoutesGearLinkingTable
		//[Anchors] TINYINT NOT NULL,
		//[NumberOfPitch] TINYINT NOT NULL, 
		//[FirstAscent] VARCHAR(100) NOT NULL DEFAULT 'Unknown', --Could be unknown
		//[FirstFreeAscent] VARCHAR(100) NOT NULL DEFAULT 'Unknown', 
		//[SunAM] BIT NOT NULL DEFAULT 0, --bools for could haves
		//[SunPM] BIT NOT NULL DEFAULT 0,
		//[Filtered] BIT NOT NULL DEFAULT 0,
		//[Sunny] BIT NOT NULL DEFAULT 0,
		//[Shady] BIT NOT NULL DEFAULT 0,
		//[DriesFast] BIT NOT NULL DEFAULT 0,
		//[DryInRain] BIT NOT NULL DEFAULT 0,
		//[Windy] BIT NOT NULL DEFAULT 0,
		//[ClimbAnglesHaveSlabs] BIT NOT NULL DEFAULT 0, --will be grouped in model after database
		//[ClimbAnglesHaveVerticals] BIT NOT NULL DEFAULT 0,
		//[ClimbAnglesHaveOverHangs] BIT NOT NULL DEFAULT 0,
		//[ClimbAnglesHaveRoofs] BIT NOT NULL DEFAULT 0, --end grouping
		//[RockFalls] BIT NOT NULL DEFAULT 0,
		//[Seepage] BIT NOT NULL DEFAULT 0,
		//[StickClip] BIT NOT NULL DEFAULT 0,
		//[Runout] BIT NOT NULL DEFAULT 0,
		//[Reachy] BIT NOT NULL DEFAULT 0,
		//[Dyno] BIT NOT NULL DEFAULT 0,
		//[Pumpy] BIT NOT NULL DEFAULT 0,
		//[Techy] BIT NOT NULL DEFAULT 0,
		//[Power] BIT NOT NULL DEFAULT 0,
		//[PockSlashHole] BIT NOT NULL DEFAULT 0,
		//[Crimpy] BIT NOT NULL DEFAULT 0,
		//[SeatStart] BIT NOT NULL DEFAULT 0,

	}
}
