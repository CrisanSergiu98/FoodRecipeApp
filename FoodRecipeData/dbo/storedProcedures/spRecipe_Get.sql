CREATE PROCEDURE [dbo].[spRecipe_Get]
	@Id int
AS
begin
	select * from dbo.Recipe
	where Id = @Id
end
