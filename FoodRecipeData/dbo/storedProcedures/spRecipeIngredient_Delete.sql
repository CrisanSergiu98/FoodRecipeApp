CREATE PROCEDURE [dbo].[spRecipeIngredient_Delete]
	@RecipeId int,
	@IngredientId int
AS
begin
	delete from dbo.Recipe_Ingredient
	where RecipeId=@RecipeId and IngredientId = @IngredientId
end
