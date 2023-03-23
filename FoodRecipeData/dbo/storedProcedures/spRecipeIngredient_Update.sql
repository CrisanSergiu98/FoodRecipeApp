CREATE PROCEDURE [dbo].[spRecipeIngredient_Update]
	@RecipeId int,
	@IngredientId int,
	@Quantity float,
	@UnitId int
AS
begin
	update dbo.Recipe_Ingredient
	set RecipeId=@RecipeId,IngredientId=@IngredientId,Quantity=@Quantity,UnitId=@UnitId
end
