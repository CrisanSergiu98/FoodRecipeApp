CREATE PROCEDURE [dbo].[spIngredient_Get]
	@Id int
AS
begin
	Select * 
	from dbo.Ingredient
	where Id=@Id;
end
