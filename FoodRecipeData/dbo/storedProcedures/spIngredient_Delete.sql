CREATE PROCEDURE [dbo].[spIngredient_Delete]
	@Id int
AS
begin
	delete
	from dbo.Ingredient
	where Id=@Id;
end
