CREATE TABLE [dbo].[Users]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(0,1), 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [MiddleName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [UserName] NVARCHAR(50) NOT NULL, 
    [PrimaryPersonalEmail] VARCHAR(320) NOT NULL, 
    [EmailValidated] BIT NOT NULL DEFAULT 0, -- Have they validated their email to prove a valid account
	[PrimaryPhone] VARCHAR(15) NOT NULL, 
    [PhoneValidated] BIT NOT NULL DEFAULT 0, -- Have they validated their phone for 2 step verification or for a more valid account
    [KeepPrivate] BIT NOT NULL DEFAULT 0, 

    --Security

    --(0, 'Admin'),
    --(1, 'Employee'),
    --(2, 'Guide'),
    --(3, 'PayedUser'),
    --(4, 'User');
    [AccessLevelID] TINYINT NOT NULL DEFAULT 5,
	CONSTRAINT [FK_UserAccessTokens_UserAccessLevels] FOREIGN KEY ([AccessLevelID]) REFERENCES [UserAccessLevels]([ID]),

    [HashedPassword] NCHAR(44) NOT NULL, 
	[Salt] CHAR(44) NOT NULL, 

	--Profile stuff
	--Size is 2 to the 16 - 1 = 65,536 - 1 bytes 
    --[Picture] VARBINARY(16) NULL, 
    [ProfilePicturePath] VARCHAR(16) NULL, 
    [BannerPicturePath] VARCHAR(16) NULL, 
    [Bio] NVARCHAR(2500) NULL, 

    --linkable page to something extra
	[ProfileURL] NVARCHAR(100) NULL

    UNIQUE ([PrimaryPersonalEmail])
    UNIQUE ([PrimaryPhone])
	UNIQUE ([UserName])
)
