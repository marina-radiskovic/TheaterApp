CREATE TABLE [dbo].[PlayActor]
(
    [ActorId] INT NOT NULL, 
    [PlayId] INT NOT NULL,
	CONSTRAINT [FK_ActorPlay_Play] FOREIGN KEY ([PlayId]) REFERENCES [Play] ([PlayId]),
	CONSTRAINT [FK_ActorPlay_Actor] FOREIGN KEY ([ActorId]) REFERENCES [Actor] ([ActorId]), 
    CONSTRAINT [PK_PlayActor] PRIMARY KEY ([ActorId], [PlayId])
)
