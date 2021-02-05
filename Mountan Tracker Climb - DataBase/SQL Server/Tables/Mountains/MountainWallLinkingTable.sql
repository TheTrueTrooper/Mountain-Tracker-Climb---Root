CREATE TABLE [dbo].[MountainToWallLinkingTable]
(
	[MountainID] INT NOT NULL,
	CONSTRAINT [FK_MountainToWallLinkingTable_Mountains] FOREIGN KEY ([MountainID]) REFERENCES [Mountains]([ID]),

	[ClimbingWallsID] INT NOT NULL,
	CONSTRAINT [FK_MountainToWallLinkingTable_ClimbingWalls] FOREIGN KEY ([ClimbingWallsID]) REFERENCES [ClimbingWalls]([ID]),

	PRIMARY KEY([MountainID], [ClimbingWallsID])
)
