CREATE TABLE [dbo].[DistrictZones]
(
	[DistrictID] INT NOT NULL,
	CONSTRAINT [FK_DistrictZones_Districts] FOREIGN KEY ([DistrictID]) REFERENCES [Districts]([ID]),

	[ID] INT NOT NULL PRIMARY KEY IDENTITY(0,1), 
    [EnglishFullName] VARCHAR(100) NOT NULL, 
    [ZoneCode] CHAR(10) NOT NULL
)
