CREATE TABLE [dbo].[UserAccessTokens]
(
	[UserID] INT NOT NULL,
	CONSTRAINT [FK_UserAccessTokens_Users] FOREIGN KEY ([UserID]) REFERENCES [Users]([ID]),

	[ID] INT NOT NULL PRIMARY KEY IDENTITY(0,1),
	[UserToken] CHAR(44),
	[UserTokenIssueDate] DATETIME DEFAULT GETDATE(),
	[UserTokenValidTill] DATETIME,
	[DaysValid] INT DEFAULT 0 --0 = forever phones should be forever however web app will be 24 hours
)
