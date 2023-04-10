CREATE PROCEDURE [dbo].[spRecipe_Lookup]
	@Title nvarchar(100)	
AS
begin
	select ID from dbo.Recipe
	where Title=@Title
end
