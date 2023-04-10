CREATE TABLE [dbo].[Ingredient_Category]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NOT NULL UNIQUE, 
    [Description] NVARCHAR(500) NOT NULL, 
    [PictureUrl] NVARCHAR(2048) NOT NULL

)
