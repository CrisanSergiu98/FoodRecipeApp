CREATE TABLE [dbo].[CookBook]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [PictureUrl] NVARCHAR(MAX) NOT NULL
)
