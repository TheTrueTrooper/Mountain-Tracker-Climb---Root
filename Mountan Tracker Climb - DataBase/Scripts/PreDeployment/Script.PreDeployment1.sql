/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
--reset the table for data by deleting old data to make a clean alter\
--Gear drill down reset
IF EXISTS(SELECT 1 FROM sys.Objects WHERE  Object_id = OBJECT_ID(N'dbo.GearLinkingTableForGearType') AND Type = N'U')
	delete [GearLinkingTableForGearType] where 1=1
IF EXISTS(SELECT 1 FROM sys.Objects WHERE  Object_id = OBJECT_ID(N'dbo.ClimbingTypes') AND Type = N'U')
	delete [ClimbingTypes] where 1=1
IF EXISTS(SELECT 1 FROM sys.Objects WHERE  Object_id = OBJECT_ID(N'dbo.GearSizes') AND Type = N'U')
	delete GearSizes where 1=1
IF EXISTS(SELECT 1 FROM sys.Objects WHERE  Object_id = OBJECT_ID(N'dbo.Gear') AND Type = N'U')
	delete Gear where 1=1
--Wall drill down reset
IF EXISTS(SELECT 1 FROM sys.Objects WHERE  Object_id = OBJECT_ID(N'dbo.ProvincesOrStates') AND Type = N'U')
	delete ProvincesOrStates where 1=1
IF EXISTS(SELECT 1 FROM sys.Objects WHERE  Object_id = OBJECT_ID(N'dbo.Countries') AND Type = N'U')
	delete Countries where 1=1
IF EXISTS(SELECT 1 FROM sys.Objects WHERE  Object_id = OBJECT_ID(N'dbo.RockClimbingDifficulties') AND Type = N'U')
	delete RockClimbingDifficulties where 1=1
go