CREATE PROCEDURE [dbo].[spRecipe_Insert]
	@Title nvarchar(100),
	@Description nvarchar(500),
	@Published bit,
	@PictureUrl nvarchar(2048),
	@CategoryId int,	
	@UserId nvarchar(50)
AS
begin
	insert into dbo.Recipe (Title, [Description], Published, PictureUrl, CategoryId, UserId)
	values(@Title,@Description,@Published,@PictureUrl,@CategoryId,@UserId);
	
end
