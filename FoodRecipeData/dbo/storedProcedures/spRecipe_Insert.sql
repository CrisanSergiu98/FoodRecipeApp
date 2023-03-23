CREATE PROCEDURE [dbo].[spRecipe_Insert]
	@Title nvarchar(50),
	@Description nvarchar(MAX),
	@Published bit,
	@PictureUrl nvarchar(MAX),
	@CategoryId int,
	@UserId nvarchar(Max)
AS
begin
	insert into dbo.Recipe (Title, [Description], Published, PictureUrl, CategoryId, UserId)
	values(@Title,@Description,@Published,@PictureUrl,@CategoryId,@UserId)
end
