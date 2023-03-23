CREATE PROCEDURE [dbo].[spIngredientCategory_Delete]
	@Id int
AS
begin
	delete
	from dbo.Ingredient_Category
	where Id=@Id;
end
