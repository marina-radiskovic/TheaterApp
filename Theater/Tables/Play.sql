CREATE TABLE [dbo].[Play]
(
	[PlayId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(50) NULL, 
    [ImagePath] NVARCHAR(MAX) NULL, 
    [Description] NVARCHAR(MAX) NULL,
	[ImageVirtualPath] NVARCHAR(MAX) NULL,
	[ImageType] NVARCHAR(10) NULL,
    [StartDate] DATE NULL, 
    [EndDate] DATE NULL, 
    [Time] TIME NULL, 
    [Duration] TIME NULL, 
    [Canceled] BIT DEFAULT 'FALSE'
)
