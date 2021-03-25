CREATE TABLE [dbo].[Districts]
(
	[RegionID] INT NOT NULL,
	CONSTRAINT [FK_Districts_Regions] FOREIGN KEY ([RegionID]) REFERENCES [Regions]([ID]),

	[ID] INT NOT NULL PRIMARY KEY IDENTITY(0,1), 
    [EnglishFullName] VARCHAR(100) NOT NULL, 
    [DistrictCode] CHAR(5) NOT NULL

	CONSTRAINT [UQ_Districts_Name] UNIQUE ([RegionID], [EnglishFullName])
	CONSTRAINT [UQ_Districts_Code] UNIQUE ([RegionID], [DistrictCode])
)
