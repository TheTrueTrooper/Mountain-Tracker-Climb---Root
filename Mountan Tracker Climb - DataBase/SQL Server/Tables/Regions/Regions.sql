CREATE TABLE [dbo].[Regions]
(
	[ProvinceOrStateID] SMALLINT NOT NULL,
	CONSTRAINT [FK_Regions_ProvincesOrStates] FOREIGN KEY ([ProvinceOrStateID]) REFERENCES [ProvincesOrStates]([ID]),
	                                           
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(0,1), 
    [EnglishFullName] VARCHAR(100) NOT NULL, 
    [RegionCode] CHAR(5) NOT NULL

	CONSTRAINT [UQ_Region_Name] UNIQUE ([ProvinceOrStateID], [EnglishFullName])
	CONSTRAINT [UQ_Region_Code] UNIQUE ([ProvinceOrStateID], [RegionCode])
)
