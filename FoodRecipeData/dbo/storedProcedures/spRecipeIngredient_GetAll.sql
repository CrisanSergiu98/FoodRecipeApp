CREATE PROCEDURE [dbo].[spRecipeIngredient_GetAll]
	@RecipeId int
AS
begin
	select * from dbo.Recipe_Ingredient
	where RecipeId=@RecipeId
end

