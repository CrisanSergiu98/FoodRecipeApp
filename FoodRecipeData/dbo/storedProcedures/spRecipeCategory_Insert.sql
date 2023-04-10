CREATE PROCEDURE [dbo].[spRecipeCategory_Insert]
	@Name nvarchar(100),
	@Description nvarchar(500),
	@PictureUrl nvarchar(2048)
AS
begin
	insert into dbo.Recipe_Category ([Name],[Description],PictureUrl)
	values(@Name,@Description,@PictureUrl)
end
