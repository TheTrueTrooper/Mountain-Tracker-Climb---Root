CREATE TABLE [dbo].[UsersRockClimbTracker]
(
	[RockClimbingRoutesID] INT NOT NULL,
	CONSTRAINT [FK_UsersRockClimbTracker_RockClimbingRoutes] FOREIGN KEY ([RockClimbingRoutesID]) REFERENCES [RockClimbingRoutes]([ID]),
	
	[UserID] INT NOT NULL,
	CONSTRAINT [FK_UsersRockClimbTracker_Users] FOREIGN KEY ([UserID]) REFERENCES [Users]([ID]),

	[ClimbID] TINYINT PRIMARY KEY IDENTITY(0,1) NOT NULL,
	[Time] DATETIME NOT NULL DEFAULT GETDATE(),
	[Comments] VARCHAR(250) NOT NULL,
)
