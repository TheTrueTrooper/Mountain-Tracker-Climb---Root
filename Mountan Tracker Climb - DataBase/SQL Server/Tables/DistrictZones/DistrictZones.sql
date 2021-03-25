CREATE TABLE [dbo].[DistrictZones]
(
	[DistrictID] INT NOT NULL,
	CONSTRAINT [FK_DistrictZones_Districts] FOREIGN KEY ([DistrictID]) REFERENCES [Districts]([ID]),

	[ID] INT NOT NULL PRIMARY KEY IDENTITY(0,1), 
    [EnglishFullName] VARCHAR(100) NOT NULL, 
    [ZoneCode] CHAR(5) NOT NULL

	CONSTRAINT [UQ_DistrictZones_Name] UNIQUE ([DistrictID], [EnglishFullName])
	CONSTRAINT [UQ_DistrictZones_Code] UNIQUE ([DistrictID], [ZoneCode])
)
