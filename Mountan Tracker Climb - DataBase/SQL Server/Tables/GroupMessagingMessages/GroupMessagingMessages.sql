CREATE TABLE [dbo].[GroupMessagingMessages]
(
	[UserID] INT NOT NULL,
	CONSTRAINT [FK_GroupMessagingMessages_Users] FOREIGN KEY ([UserID]) REFERENCES [Users]([ID]),

	[GroupMessagingID] INT NOT NULL,
	CONSTRAINT [FK_GroupMessagingMessages_GroupMessaging] FOREIGN KEY ([GroupMessagingID]) REFERENCES [GroupMessaging]([ID]),

	[ID] INT NOT NULL PRIMARY KEY IDENTITY(0,1), 
    [Message] NVARCHAR(1000) NOT NULL, 
    [Time] DATETIME NOT NULL DEFAULT GETDATE()

)
