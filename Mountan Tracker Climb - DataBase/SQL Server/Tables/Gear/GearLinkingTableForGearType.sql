CREATE TABLE [dbo].[GearLinkingTableForGearType]
(
	[ClimbingTypeID] TINYINT NOT NULL,
	CONSTRAINT [FK_GearLinkingTableForGearType_ClimbingTypes] FOREIGN KEY ([ClimbingTypeID]) REFERENCES [ClimbingTypes]([ID]),
	[GearID] TINYINT NOT NULL,
	CONSTRAINT [FK_GearLinkingTableForGearType_Gear] FOREIGN KEY ([GearID]) REFERENCES [Gear]([ID]),

	PRIMARY KEY([GearID], [ClimbingTypeID])
)
