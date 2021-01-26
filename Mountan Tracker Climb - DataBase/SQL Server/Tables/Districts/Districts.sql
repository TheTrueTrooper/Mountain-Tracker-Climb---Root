CREATE TABLE [dbo].[Districts]
(
	[RegionID] INT NOT NULL,
	CONSTRAINT [FK_Districts_Regions] FOREIGN KEY ([RegionID]) REFERENCES [Regions]([ID]),

	[ID] INT NOT NULL PRIMARY KEY, 
    [EngishFullName] VARCHAR(100) NOT NULL, 
    [DistrictCode] CHAR(10) NOT NULL
)
