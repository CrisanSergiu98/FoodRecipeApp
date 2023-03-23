CREATE PROCEDURE [dbo].[spRecipeStep_Get]
	@RecipeId int
AS
begin
	select * from dbo.Recipe_Step
	where RecipeId = @RecipeId
end
