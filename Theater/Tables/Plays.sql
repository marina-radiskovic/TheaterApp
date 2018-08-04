CREATE TABLE [dbo].[Plays]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Title] VARCHAR(50) NULL, 
    [Image] IMAGE NULL, 
    [Description] VARCHAR(MAX) NULL, 
    [ScheduledTime] DATETIME NULL, 
    [FKRating] INT NULL, 
    [FKReservation] INT NULL
)
