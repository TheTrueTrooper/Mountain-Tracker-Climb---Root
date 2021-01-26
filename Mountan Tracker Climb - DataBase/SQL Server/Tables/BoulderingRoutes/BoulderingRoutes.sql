CREATE TABLE [dbo].[BoulderingRoutes]
(
	[ClimbingWallID] INT NOT NULL,
	CONSTRAINT [FK_BoulderingRoutes_ClimbingWalls] FOREIGN KEY ([ClimbingWallID]) REFERENCES [ClimbingWalls]([ID]),

	[ID] INT NOT NULL PRIMARY KEY, 
)
