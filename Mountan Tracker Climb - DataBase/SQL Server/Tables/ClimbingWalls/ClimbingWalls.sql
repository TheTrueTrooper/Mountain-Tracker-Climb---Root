CREATE TABLE [dbo].[ClimbingWalls]
(
	[AreaID] INT NOT NULL,
	CONSTRAINT [FK_ClimbingWalls_ZoneAreas] FOREIGN KEY ([AreaID]) REFERENCES [ZoneAreas]([ID]),

	[ID] INT NOT NULL PRIMARY KEY IDENTITY(0,1), 
    [EnglishFullName] VARCHAR(100) NOT NULL, 
    [WallCode] CHAR(5) NOT NULL

	CONSTRAINT [UQ_ClimbingWalls_Name] UNIQUE ([AreaID], [EnglishFullName])
	CONSTRAINT [UQ_ClimbingWalls_Code] UNIQUE ([AreaID], [WallCode])
)
