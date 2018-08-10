CREATE TABLE [dbo].[Play]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(50) NULL, 
    [Image] NVARCHAR(MAX) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [ScheduledTime] DATETIME NULL
)
