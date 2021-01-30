CREATE TABLE [dbo].[GearLinkingTableForGearType]
(
	[GearClimbingTypeID] TINYINT NOT NULL,
	CONSTRAINT [FK_GearLinkingTableForGearType_GearClimbingTypes] FOREIGN KEY ([GearClimbingTypeID]) REFERENCES [GearClimbingTypes]([ID]),
	[GearID] TINYINT NOT NULL,
	CONSTRAINT [FK_GearLinkingTableForGearType_Gear] FOREIGN KEY ([GearID]) REFERENCES [Gear]([ID]),

	PRIMARY KEY([GearID], [GearClimbingTypeID])
)
