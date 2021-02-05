﻿CREATE TABLE [dbo].[Users]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(0,1), 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [MiddleName] NCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [UserName] NVARCHAR(50) NOT NULL, 
    [PrimaryPersonalEmail] VARCHAR(320) NOT NULL, 
    [EmailValidated] BIT NOT NULL DEFAULT 0, -- Have they validated their email to prove a valid account
	[PrimaryPhone] VARCHAR(15) NOT NULL, 
    [PhoneValidated] BIT NOT NULL DEFAULT 0, -- Have they validated their phone for 2 step verification or for a more valid account
    [KeepPrivate] BIT NOT NULL DEFAULT 0, 

    --Security
    [HashedPassword] NCHAR(50) NOT NULL, 
	[Salt] CHAR(28) NOT NULL, 

	--Profile stuff
	--Size is 2 to the 16 - 1 = 65,536 - 1 bytes 
    --[Picture] VARBINARY(16) NULL, 
    [PicturePath] VARCHAR(16) NULL, 
    [Bio] NVARCHAR(250) NULL, 

    --linkable page to something extra
	[ProfileURL] NVARCHAR(100) NULL

    UNIQUE ([PrimaryPersonalEmail])
	UNIQUE ([UserName])
)
