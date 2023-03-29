CREATE PROCEDURE [dbo].[spRecipeStep_Delete]
	@RecipeId int,
	@StepNumber int
AS
begin
	delete from dbo.Recipe_Step
	where RecipeId=@RecipeId and Number = @StepNumber
end
