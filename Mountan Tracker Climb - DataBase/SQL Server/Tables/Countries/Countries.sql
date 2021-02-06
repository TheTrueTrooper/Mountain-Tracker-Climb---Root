CREATE TABLE [dbo].[Countries]
(
	[ID] TINYINT NOT NULL PRIMARY KEY, 
    [EnglishFullName] VARCHAR(44) NOT NULL, 
    [CountryCode] CHAR(2) NOT NULL

	UNIQUE ([EnglishFullName])
	UNIQUE ([CountryCode])
)
