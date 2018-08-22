CREATE TABLE [dbo].[Play]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(50) NULL, 
    [ImagePath] NVARCHAR(MAX) NULL, 
    [Description] NVARCHAR(MAX) NULL,
	[ImageVirtualPath] NVARCHAR(MAX) NULL,
	[ImageType] NVARCHAR(10) NULL,
    [ScheduledTime] DATETIME NULL
)
