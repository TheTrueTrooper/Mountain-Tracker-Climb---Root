select * from Countries
select * from ProvincesOrStates
select * from ProvincesOrStates as POS join Countries as C on POS.CountryID = C.ID
select POS.EnglishFullName as Provence, C.EnglishFullName as Country from ProvincesOrStates as POS join Countries as C on POS.CountryID = C.ID
select POS.EnglishFullName as Provence, C.EnglishFullName as Country 
	from ProvincesOrStates as POS join Countries as C on POS.CountryID = C.ID 
		where C.EnglishFullName = 'Canada'