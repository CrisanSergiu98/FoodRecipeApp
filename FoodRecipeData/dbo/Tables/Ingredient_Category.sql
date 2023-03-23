CREATE TABLE [dbo].[Ingredient_Category]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [PictureUrl] NVARCHAR(MAX) NOT NULL

)
