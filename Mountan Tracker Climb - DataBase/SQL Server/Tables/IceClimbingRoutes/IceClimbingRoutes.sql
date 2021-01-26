CREATE TABLE [dbo].[IceClimbingRoutes]
(
	[ClimbingWallID] INT NOT NULL,
	CONSTRAINT [FK_IceClimbingRoutes_ClimbingWalls] FOREIGN KEY ([ClimbingWallID]) REFERENCES [ClimbingWalls]([ID]),

	[ID] INT NOT NULL PRIMARY KEY, 
)
