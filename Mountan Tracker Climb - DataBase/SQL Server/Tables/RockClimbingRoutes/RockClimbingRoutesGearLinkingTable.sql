--this table is to allow multiple gear to be tied to a single Route
CREATE TABLE [dbo].[RockClimbingRoutesGearLinkingTable]
(
	[RockClimbingRoutesID] INT NOT NULL,
	CONSTRAINT [FK_RockClimbingRoutesGearLinkingTable_RockClimbingRoutes] FOREIGN KEY ([RockClimbingRoutesID]) REFERENCES [RockClimbingRoutes]([ID]),
	[GearID] TINYINT NOT NULL,
	CONSTRAINT [FK_RockClimbingRoutesGearLinkingTable_RockClimbingGearID] FOREIGN KEY ([GearID]) REFERENCES [Gear]([ID]),

	PRIMARY KEY([RockClimbingRoutesID], [GearID])
)
