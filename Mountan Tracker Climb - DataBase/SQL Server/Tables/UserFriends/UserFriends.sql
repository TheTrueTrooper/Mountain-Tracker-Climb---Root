CREATE TABLE [dbo].[UserFriends]
(
	[UserFromID] INT NOT NULL,
	CONSTRAINT [FK_UserFriends_Users_From] FOREIGN KEY ([UserFromID]) REFERENCES [Users]([ID]),
	
	[UserToID] INT NOT NULL,
	CONSTRAINT [FK_UserFriends_Users_To] FOREIGN KEY ([UserToID]) REFERENCES [Users]([ID]),

	[Accepted] Bit,

	Primary Key([UserFromID], [UserToID])
)
