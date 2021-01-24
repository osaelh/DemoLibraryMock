CREATE TABLE [dbo].[Users]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserName] VARCHAR(50) NULL, 
    [Email] VARCHAR(250) NULL, 
    [Password] VARCHAR(50) NULL, 
    [Access] INT NULL, 
    [IsStudent] BIT NULL, 
    [TimeStamp] TIMESTAMP NULL
)
