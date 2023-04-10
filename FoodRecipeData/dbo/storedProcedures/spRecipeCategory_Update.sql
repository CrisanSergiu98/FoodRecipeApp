CREATE PROCEDURE [dbo].[spRecipeCategory_Update]
	@Id int,
	@Name nvarchar(100),
	@Description nvarchar(500),
	@PictureUrl nvarchar(2048)
AS
begin
	update dbo.Recipe_Category
	set [Name]=@Name, [Description] = @Description, PictureUrl=@PictureUrl
	where Id=@Id;
end
