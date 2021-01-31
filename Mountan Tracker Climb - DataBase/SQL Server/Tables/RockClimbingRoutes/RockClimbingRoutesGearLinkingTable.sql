--this table is to allow multiple gear to be tied to a single Route
--* to * relationship
CREATE TABLE [dbo].[RockClimbingRoutesGearLinkingTable]
(
	[RockClimbingRoutesID] INT NOT NULL,
	CONSTRAINT [FK_RockClimbingRoutesGearLinkingTable_RockClimbingRoutes] FOREIGN KEY ([RockClimbingRoutesID]) REFERENCES [RockClimbingRoutes]([ID]),
	--dropped GearID from linking table as a gear Item can be derived from the size charts link. 
	[GearSizeID] TINYINT NOT NULL,
	CONSTRAINT [FK_RockClimbingRoutesGearLinkingTable_GearSizeID] FOREIGN KEY ([GearSizeID]) REFERENCES [GearSizes]([ID]),

	[NumberRequired] SMALLINT NOT NULL DEFAULT 1,

	PRIMARY KEY([RockClimbingRoutesID], [GearSizeID])
)
