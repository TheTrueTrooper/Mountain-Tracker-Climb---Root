﻿select * from Countries
select * from ProvincesOrStates
select * from ProvincesOrStates as POS join Countries as C on POS.CountryID = C.ID
select POS.EnglishFullName as Provence, C.EnglishFullName as Country from ProvincesOrStates as POS join Countries as C on POS.CountryID = C.ID
select POS.EnglishFullName as Provence, C.EnglishFullName as Country 
	from ProvincesOrStates as POS join Countries as C on POS.CountryID = C.ID 
		where C.EnglishFullName = 'Canada'


select * from ClimbingTypes

select * from GearSizes
select * from Gear

select G.EnglishFullName as TypeOfGear, GS.EnglishFullName as SizingName 
from GearSizes as GS join Gear as G on G.ID = GS.GearID

select GS.EnglishFullName as SizingName, G.EnglishFullName as TypeOfGear 
	from GearSizes as GS join Gear as G on G.ID = GS.GearID
		where G.EnglishFullName = 'Anchor'

select GS.EnglishFullName as SizingName, G.EnglishFullName as TypeOfGear, CT.EnglishFullName as GearsType
	from GearSizes as GS 
		join Gear as G on G.ID = GS.GearID
		join GearLinkingTableForGearType as CLGT on CLGT.GearID = G.ID
		join ClimbingTypes as CT on CLGT.ClimbingTypeID = CT.ID
			where G.EnglishFullName = 'Anchor'

select max(len(EnglishFullName)) from Countries
select max(len(EnglishCode)) from RockClimbingDifficulties

INSERT INTO dbo.Countries ([ID], [EnglishFullName], [CountryCode])
VALUES ( 0, 'Afghanistan', 'AF')

select * from dbo.Gear
select Count(ID) from dbo.Gear

insert into [RockClimbingRoutesGearLinkingTable] ([RockClimbingRoutesID], [GearSizeID], [NumberRequired]) values (1 ,1, 2)
insert into [RockClimbingRoutesGearLinkingTable] ([RockClimbingRoutesID], [GearSizeID], [NumberRequired]) values (1 ,12, 30)

select * from [ClimbingTypes]