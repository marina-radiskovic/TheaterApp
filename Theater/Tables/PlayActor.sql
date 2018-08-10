CREATE TABLE [dbo].[PlayActor]
(
	[Id] INT IDENTITY (1,1) NOT NULL PRIMARY KEY, 
    [ActorId] INT NOT NULL, 
    [PlayId] INT NOT NULL,
	CONSTRAINT [FK_ActorPlay_Play] FOREIGN KEY ([Id]) REFERENCES [Play] ([Id]),
	CONSTRAINT [FK_ActorPlay_Actor] FOREIGN KEY ([Id]) REFERENCES [Actor] ([Id])
)
