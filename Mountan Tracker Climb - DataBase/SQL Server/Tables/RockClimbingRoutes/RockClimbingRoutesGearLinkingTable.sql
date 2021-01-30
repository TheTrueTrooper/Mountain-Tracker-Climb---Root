--this table is to allow multiple gear to be tied to a single Route
--* to * relationship
CREATE TABLE [dbo].[RockClimbingRoutesGearLinkingTable]
(
	[RockClimbingRoutesID] INT NOT NULL,
	CONSTRAINT [FK_RockClimbingRoutesGearLinkingTable_RockClimbingRoutes] FOREIGN KEY ([RockClimbingRoutesID]) REFERENCES [RockClimbingRoutes]([ID]),
	[GearID] TINYINT NOT NULL,
	CONSTRAINT [FK_RockClimbingRoutesGearLinkingTable_Gear] FOREIGN KEY ([GearID]) REFERENCES [Gear]([ID]),
	[GearSizeID] TINYINT NOT NULL,
	CONSTRAINT [FK_RockClimbingRoutesGearLinkingTable_GearSizeID] FOREIGN KEY ([GearSizeID]) REFERENCES [GearSizes]([ID]),

	[NumberRequired] SMALLINT NOT NULL DEFAULT 1,

	PRIMARY KEY([RockClimbingRoutesID], [GearID], [GearSizeID])
)
