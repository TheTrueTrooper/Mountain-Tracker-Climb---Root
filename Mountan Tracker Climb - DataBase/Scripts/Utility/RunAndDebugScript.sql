select * from Countries
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


exec UserLogin @UserName = 'Aman', @HashedPassword = 'l/CUlG5fTJG2JfqVwF3I2smpglr9P/kmaBpRWferPKg='

select DATEADD(day, 30, GETDATE())

drop proc [dbo].[CheckTokenWithAccessLevel]
go
CREATE PROCEDURE [dbo].[CheckTokenWithAccessLevel]
	@UserID int,
	@UserToken CHAR(44),
	@UserRequiredAccessLevelID int
AS
begin
	--set up some more vars we need
	declare @Valid as bit, @AccessLevelID as int, @TokenID as int, @ExtendValue as int
	--set our default stance as fail
	set @Valid = 0
	--clear old tokens to start
	delete from UserAccessTokens where UserTokenValidTill < GETDATE()
	--If we have a value after clearing old ones then we must have had a valid log on in time with this token
	if(exists(select UAT.UserToken from Users as U
		join UserAccessTokens as UAT on U.ID = UAT.UserID
			where not U.AccessLevelID > @UserRequiredAccessLevelID and U.ID = @UserID and UAT.UserToken = @UserToken))
		begin
			--get the time to extend
			select @ExtendValue = UAT.DaysValid, @AccessLevelID = U.AccessLevelID from Users as U
			join UserAccessTokens as UAT on U.ID = UAT.UserID
				where U.ID = @UserID and UAT.UserToken = @UserToken
			--extend that much time
			update UserAccessTokens
			set
			UserTokenValidTill = DATEADD(day, @ExtendValue, GETDATE())
			where UserToken = @UserToken
			--Set ourselves as a valid log on
			set @Valid = 1
		end
	--return the results
	select @Valid, @AccessLevelID
	RETURN 0
end

