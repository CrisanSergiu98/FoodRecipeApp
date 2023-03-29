CREATE PROCEDURE [dbo].[spRecipeStep_Get]
	@RecipeId int,
	@StepNumber int
AS
begin
	select * from dbo.Recipe_Step
	where RecipeId = @RecipeId and Number=@StepNumber;
end
