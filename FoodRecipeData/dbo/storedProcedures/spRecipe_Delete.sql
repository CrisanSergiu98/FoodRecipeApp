CREATE PROCEDURE [dbo].[spRecipe_Delete]
	@Id int
AS
begin
	delete from dbo.Recipe
	where Id=@Id
end
