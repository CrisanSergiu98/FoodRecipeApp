CREATE PROCEDURE [dbo].[spRecipeIngredient_Update]
	@RecipeId int,
	@IngredientId int,
	@Quantity float,
	@UnitId int
AS
begin
	update dbo.Recipe_Ingredient
	set Quantity=@Quantity,UnitId=@UnitId
	where RecipeId=@RecipeId and IngredientId=@IngredientId
end
