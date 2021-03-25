﻿CREATE TABLE [dbo].[RockClimbingRoutes]
(
--data normalized out
	[ClimbingWallID] INT NOT NULL,
	CONSTRAINT [FK_RockClimbingRoutes_ClimbingWalls] FOREIGN KEY ([ClimbingWallID]) REFERENCES [ClimbingWalls]([ID]),

	[TypeID] TINYINT NOT NULL,
	CONSTRAINT [FK_RockClimbingRoutes_RockWallClimbingTypes] FOREIGN KEY ([TypeID]) REFERENCES [ClimbingTypes]([ID]),

	[DifficultyID] TINYINT NOT NULL,
	CONSTRAINT [FK_RockClimbingRoutes_RockWallClimbingDifficulties] FOREIGN KEY ([DifficultyID]) REFERENCES [RockClimbingDifficulties]([ID]),

	--[Gear] TINYINT NOT NULL,* - * so needs a linking table as RockClimbingRoutesGearLinkingTable

	--Normalized Data
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(0,1), 
    [EnglishFullName] VARCHAR(100) NOT NULL, 
    [RouteCode] CHAR(5) NOT NULL,
	[RouteWallNumber] INT NOT NULL,
	[Rating] TINYINT NOT NULL,
	[HieghtInMeters] FLOAT NOT NULL,
	[HieghtInFeet] As 3.28084 * [HieghtInMeters],
	--[Anchors] TINYINT NOT NULL, handled by gear
	[NumberOfPitchs] TINYINT NOT NULL, 
	[FirstAscent] VARCHAR(100) NOT NULL DEFAULT 'Unknown', --Could be unknown
	[FirstFreeAscent] VARCHAR(100) NOT NULL DEFAULT 'Unknown', 
	[SunAM] BIT NOT NULL DEFAULT 0, --bools for could haves
	[SunPM] BIT NOT NULL DEFAULT 0,
	[Filtered] BIT NOT NULL DEFAULT 0,
	[Sunny] BIT NOT NULL DEFAULT 0,
	[Shady] BIT NOT NULL DEFAULT 0,
	[DriesFast] BIT NOT NULL DEFAULT 0,
	[DryInRain] BIT NOT NULL DEFAULT 0,
	[Windy] BIT NOT NULL DEFAULT 0,
	[ClimbAnglesHaveSlabs] BIT NOT NULL DEFAULT 0, --will be grouped in model after database
	[ClimbAnglesHaveVerticals] BIT NOT NULL DEFAULT 0,
	[ClimbAnglesHaveOverHangs] BIT NOT NULL DEFAULT 0,
	[ClimbAnglesHaveRoofs] BIT NOT NULL DEFAULT 0, --end grouping
	[RockFalls] BIT NOT NULL DEFAULT 0,
	[Seepage] BIT NOT NULL DEFAULT 0,
	[StickClip] BIT NOT NULL DEFAULT 0,
	[Runout] BIT NOT NULL DEFAULT 0, 
	[Reachy] BIT NOT NULL DEFAULT 0, 
	[Dyno] BIT NOT NULL DEFAULT 0, 
	[Pumpy] BIT NOT NULL DEFAULT 0, 
	[Techy] BIT NOT NULL DEFAULT 0, 
	[Power] BIT NOT NULL DEFAULT 0,
	[PockSlashHole] BIT NOT NULL DEFAULT 0,
	[Crimpy] BIT NOT NULL DEFAULT 0,
	[SeatStart] BIT NOT NULL DEFAULT 0,
	[RouteInfo] VARCHAR(5000) NULL

	CONSTRAINT [UQ_RockClimbingRoutes_Name] UNIQUE ([ClimbingWallID], [EnglishFullName])
	CONSTRAINT [UQ_RockClimbingRoutes_Code] UNIQUE ([ClimbingWallID], [RouteCode])
	CONSTRAINT [UQ_RockClimbingRoutes_RouteWallNumber] UNIQUE ([ClimbingWallID], [RouteWallNumber])
)
