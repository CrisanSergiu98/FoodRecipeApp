CREATE PROCEDURE [dbo].[spIngredientCategory_Get]
	@Id int
AS
begin
	Select * 
	from dbo.Ingredient_Category
	where Id=@Id;
end

