﻿CREATE TABLE [dbo].[ZoneAreas]
(
	[DistrictZoneID] INT NOT NULL,
	CONSTRAINT [FK_ZoneAreas_DistrictZones] FOREIGN KEY ([DistrictZoneID]) REFERENCES [DistrictZones]([ID]),

	[ID] INT NOT NULL PRIMARY KEY IDENTITY(0,1), 
    [EngishFullName] VARCHAR(100) NOT NULL, 
    [AreaCode] CHAR(10) NOT NULL
)
