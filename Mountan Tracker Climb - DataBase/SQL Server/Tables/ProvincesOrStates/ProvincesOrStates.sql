﻿CREATE TABLE [dbo].[ProvincesOrStates]
(
	[CountryID] TINYINT NOT NULL,
	CONSTRAINT [FK_ProvincesOrStates_Countries] FOREIGN KEY ([CountryID]) REFERENCES [Countries]([ID]),

	[ID] SMALLINT NOT NULL PRIMARY KEY, 
    [EnglishFullName] VARCHAR(100) NOT NULL, 
    [RegionCode] CHAR(2) NOT NULL

	UNIQUE ([CountryID], [EnglishFullName])
	UNIQUE ([CountryID], [RegionCode])
)
