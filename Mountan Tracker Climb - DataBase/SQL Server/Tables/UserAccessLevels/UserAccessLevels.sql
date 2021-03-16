CREATE TABLE [dbo].[UserAccessLevels]
(
	[ID] TINYINT NOT NULL PRIMARY KEY,
	[EnglishName] VARCHAR(50)

	UNIQUE([EnglishName])
)
