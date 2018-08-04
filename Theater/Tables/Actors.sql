CREATE TABLE [dbo].[Actors]
(
	[Id] INT IDENTITY (1,1) NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(50) NULL, 
    [LastName] VARCHAR(50) NULL, 
    [FKRating] INT NULL 
)
