CREATE TABLE [dbo].[Countries]
(
	[ID] TINYINT NOT NULL PRIMARY KEY, 
    [EnglishFullName] VARCHAR(44) NOT NULL, 
    [CountryCode] CHAR(2) NOT NULL

	CONSTRAINT [UQ_Countries_Name] UNIQUE ([EnglishFullName])
	CONSTRAINT [UQ_Countries_Code] UNIQUE ([CountryCode])
)
