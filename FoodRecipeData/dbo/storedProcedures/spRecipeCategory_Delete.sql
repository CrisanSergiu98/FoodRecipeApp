CREATE PROCEDURE [dbo].[spRecipeCategory_Delete]
	@Id int
AS
begin
	delete from dbo.Recipe_Category
	where Id = @Id
end
