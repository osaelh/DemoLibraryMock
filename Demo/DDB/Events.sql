CREATE TABLE [dbo].[Events]
(
	[EventId] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NULL, 
    [Subject] CHAR(11) NULL, 
    [Date] DATE NULL, 
    [StartAt] TIME(0) NULL, 
    [EndAt] TIME(0) NULL, 
    [Comment] TEXT NULL, 
    [TimeStamp] TIMESTAMP NULL
)
