CREATE PROCEDURE [dbo].[spRecipeCategory_Insert]
	@Name nvarchar(50),
	@Description nvarchar(MAX),
	@PictureUrl nvarchar(MAX)
AS
begin
	insert into dbo.Recipe_Category ([Name],[Description],PictureUrl)
	values(@Name,@Description,@PictureUrl)
end
