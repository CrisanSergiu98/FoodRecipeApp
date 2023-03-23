CREATE PROCEDURE [dbo].[spIngredientCategory_Insert]
	@Name nvarchar(50),
	@Description nvarchar(MAX),
	@PictureUrl nvarchar(MAX)
AS
begin
	insert into dbo.Ingredient_Category ([Name],[Description],PictureUrl)
	values(@Name,@Description,@PictureUrl)
end
