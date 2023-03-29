CREATE PROCEDURE [dbo].[spRecipeStep_GetAll]
	@Id int
AS
begin
	select * from dbo.Recipe_Step
	where RecipeId = @Id;
end
