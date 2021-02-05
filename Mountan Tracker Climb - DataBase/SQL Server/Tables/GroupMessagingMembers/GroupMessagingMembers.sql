CREATE TABLE [dbo].[GroupMessagingMembers]
(
	[UserID] INT NOT NULL,
	CONSTRAINT [FK_GroupMessagingMembers_Users] FOREIGN KEY ([UserID]) REFERENCES [Users]([ID]),

	[GroupMessagingID] INT NOT NULL,
	CONSTRAINT [FK_GroupMessagingMembers_GroupMessaging] FOREIGN KEY ([GroupMessagingID]) REFERENCES [GroupMessaging]([ID]),

	[TimeInvited] DATETIME NOT NULL DEFAULT GETDATE(),
	[TimeJoined] DATETIME NULL,
	[AcceptedInvite] BIT NOT NULL DEFAULT 0, 

	PRIMARY KEY([UserID], [GroupMessagingID])
)
