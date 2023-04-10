CREATE TABLE [dbo].[Recipe_Step]
(
	[RecipeId] INT NOT NULL CONSTRAINT [FK_UnitRecipe] FOREIGN KEY ([RecipeId])
    REFERENCES Recipe(Id) , 
    [Number] INT NOT NULL CHECK (Number>0), 
    [Description] NVARCHAR(500) NOT NULL, 
    [PictureUrl] NVARCHAR(2048) NOT NULL

)
