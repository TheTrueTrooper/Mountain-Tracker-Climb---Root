CREATE TABLE [dbo].[UsersRockClimbTracker]
(
	[RockClimbingRoutesID] INT NOT NULL,
	CONSTRAINT [FK_UsersRockClimbTracker_RockClimbingRoutes] FOREIGN KEY ([RockClimbingRoutesID]) REFERENCES [RockClimbingRoutes]([ID]),
	
	[UserID] INT NOT NULL,
	CONSTRAINT [FK_UsersRockClimbTracker_GearSizeID] FOREIGN KEY ([UserID]) REFERENCES [Users]([ID]),

	[NumberOfTimes] TINYINT NOT NULL DEFAULT 1,
	[Time] DATETIME NOT NULL,
	[RelatedTime] VARCHAR(2000) NOT NULL,

	PRIMARY KEY([RockClimbingRoutesID], [UserID])
)
