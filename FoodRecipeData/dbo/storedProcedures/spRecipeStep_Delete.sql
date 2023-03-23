CREATE PROCEDURE [dbo].[spRecipeStep_Delete]
	@RecipeId int,
	@Number int
AS
begin
	delete from dbo.Recipe_Step
	where RecipeId=@RecipeId and Number = @Number
end
