CREATE PROCEDURE [dbo].[spRecipeIngredient_Get]
	@RecipeId int,
	@IngredientId int
AS
begin
	select * from dbo.Recipe_Ingredient
	where RecipeId = @RecipeId and IngredientId = @IngredientId
end
