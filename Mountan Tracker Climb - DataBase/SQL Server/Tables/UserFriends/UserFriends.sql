CREATE TABLE [dbo].[UserFriends]
(
	[UserFromID] INT NOT NULL,
	CONSTRAINT [FK_UserFriends_Users_From] FOREIGN KEY ([UserFromID]) REFERENCES [Users]([ID]),
	
	[UserToID] INT NOT NULL,
	CONSTRAINT [FK_UserFriends_Users_To] FOREIGN KEY ([UserToID]) REFERENCES [Users]([ID]),

	[RequestCreationDate] Datetime NOT NULL Default GETDATE(),
	[RequestAcceptDate] Datetime Default NULL,

	[Accepted] Bit NOT NULL Default 0,

	Primary Key([UserFromID], [UserToID]), 

    CONSTRAINT [CK_UserFriends_CannotFriendSelf] CHECK (not UserFromID = UserToID)
)
