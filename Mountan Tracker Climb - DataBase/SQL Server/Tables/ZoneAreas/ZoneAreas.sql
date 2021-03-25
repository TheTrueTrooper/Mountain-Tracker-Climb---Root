CREATE TABLE [dbo].[ZoneAreas]
(
	[DistrictZoneID] INT NOT NULL,
	CONSTRAINT [FK_ZoneAreas_DistrictZones] FOREIGN KEY ([DistrictZoneID]) REFERENCES [DistrictZones]([ID]),

	[ID] INT NOT NULL PRIMARY KEY IDENTITY(0,1), 
    [EnglishFullName] VARCHAR(100) NOT NULL, 
    [AreaCode] CHAR(5) NOT NULL

	CONSTRAINT [UQ_ZoneAreas_Name] UNIQUE ([DistrictZoneID], [EnglishFullName])
	CONSTRAINT [UQ_ZoneAreas_Code] UNIQUE ([DistrictZoneID], [AreaCode])
)
