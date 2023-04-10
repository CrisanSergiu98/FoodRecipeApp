CREATE TABLE [dbo].[Recipe_Ingredient]
(
	[RecipeId] INT NOT NULL CONSTRAINT FK_RecipeIngredientRecipe FOREIGN KEY ([RecipeId])
    REFERENCES Recipe(Id), 
    [IngredientId] INT NOT NULL CONSTRAINT FK_RecipeIngredientIngredinet FOREIGN KEY ([IngredientId])
    REFERENCES Ingredient(Id), 
    [Quantity] REAL NOT NULL CHECK ([Quantity] > 0), 
    [UnitId] INT NOT NULL CONSTRAINT FK_RecipeIngredientUnit FOREIGN KEY ([UnitId])
    REFERENCES Unit(Id),
)
