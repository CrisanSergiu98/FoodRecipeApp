CREATE PROCEDURE [dbo].[spRecipeStep_DeleteAll]
	@RecipeId int
AS
begin
	delete from dbo.Recipe_Step
	where RecipeId = @RecipeId
end