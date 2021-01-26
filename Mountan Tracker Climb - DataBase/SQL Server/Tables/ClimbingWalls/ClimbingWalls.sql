﻿CREATE TABLE [dbo].[ClimbingWalls]
(
	[AreaID] INT NOT NULL,
	CONSTRAINT [FK_ClimbingWalls_ZoneAreas] FOREIGN KEY ([AreaID]) REFERENCES [ZoneAreas]([ID]),

	[MountainID] INT NULL,
	CONSTRAINT [FK_ClimbingWalls_Mountains] FOREIGN KEY ([MountainID]) REFERENCES [Mountains]([ID]),

	[ID] INT NOT NULL PRIMARY KEY, 
    [EngishFullName] VARCHAR(100) NOT NULL, 
    [WallCode] CHAR(10) NOT NULL
)