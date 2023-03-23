CREATE PROCEDURE [dbo].[spIngredientCategory_Update]
	@Id int,
	@Name nvarchar(50),
	@Description nvarchar(MAX),
	@PictureUrl nvarchar(MAX)
AS
begin
	update dbo.Ingredient_Category
	set [Name]=@Name, [Description] = @Description, PictureUrl=@PictureUrl
	where Id=@Id;
end