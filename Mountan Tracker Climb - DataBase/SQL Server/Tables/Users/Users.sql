CREATE TABLE [dbo].[Users]
(
	[ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [MiddleName] NCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [UserName] NVARCHAR(50) NOT NULL,
    [PrimaryPersonalEmail] VARCHAR(320) NOT NULL, 
	[PrimaryPhone] VARCHAR(15) NULL,

    --Security
    [HashedPassword] NCHAR(50) NOT NULL, 
	[Salt] CHAR(28) NOT NULL,

	--Profile stuff
	--size is 2 tothe 16 - 1 = 65,536 - 1 bytes 
    --[Picture] VARBINARY(16) NULL, 
    [PicturePath] VARCHAR(16) NULL,
    [Bio] NVARCHAR(250) NULL, 

    --linkable page to something extra
	[ProfileURL] NVARCHAR(100) NULL,
)
