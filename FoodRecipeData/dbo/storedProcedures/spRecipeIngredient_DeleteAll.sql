CREATE PROCEDURE [dbo].[spRecipeIngredient_DeleteAll]
	@RecipeId int
AS
begin
	delete from dbo.Recipe_Ingredient
	where RecipeId = @RecipeId
end
