CREATE TABLE [dbo].[ActorsPlays]
(
	[Id] INT IDENTITY (1,1) NOT NULL PRIMARY KEY, 
    [FKActors] INT NULL REFERENCES Actors(Id), 
    [FKPlays] INT NULL REFERENCES Plays(Id)
)
