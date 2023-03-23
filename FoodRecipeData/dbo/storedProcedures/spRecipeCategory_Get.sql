CREATE PROCEDURE [dbo].[spRecipeCategory_Get]
	@Id int
AS
begin
	select * from dbo.Recipe_Category
	where Id=@Id
end
