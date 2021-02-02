CREATE TABLE [dbo].[Regions]
(
	[ProvinceOrStateID] SMALLINT NOT NULL,
	CONSTRAINT [FK_Regions_ProvincesOrStates] FOREIGN KEY ([ProvinceOrStateID]) REFERENCES [ProvincesOrStates]([ID]),

	[ID] INT NOT NULL PRIMARY KEY IDENTITY(0,1), 
    [EngishFullName] VARCHAR(100) NOT NULL, 
    [RegionCode] CHAR(10) NOT NULL
)
