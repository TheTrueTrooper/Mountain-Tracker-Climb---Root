CREATE TABLE [dbo].[Countries]
(
	[ID] TINYINT NOT NULL PRIMARY KEY, 
    [EngishFullName] VARCHAR(100) NOT NULL, 
    [CountryCode] CHAR(2) NOT NULL

	UNIQUE ([EngishFullName])
	UNIQUE ([CountryCode])
)
