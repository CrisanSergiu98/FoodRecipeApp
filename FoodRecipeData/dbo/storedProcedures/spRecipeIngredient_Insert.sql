CREATE PROCEDURE [dbo].[spRecipeIngredient_Insert]
	@RecipeId int,
	@IngredientId int,
	@Quantity float,
	@UnitId int
AS
begin
	insert into dbo.Recipe_Ingredient (RecipeId,IngredientId,Quantity,UnitId)
	values(@RecipeId,@IngredientId,@Quantity,@UnitId)
end