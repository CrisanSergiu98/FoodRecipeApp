CREATE TABLE [dbo].[Recipe_Step]
(
	[RecipeId] INT NOT NULL PRIMARY KEY, 
    [Number] INT NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [PictureUrl] NVARCHAR(MAX) NULL

)
