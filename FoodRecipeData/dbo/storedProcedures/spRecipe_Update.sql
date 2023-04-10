CREATE PROCEDURE [dbo].[spRecipe_Update]
	@Id int,
	@Title nvarchar(100),
	@Description nvarchar(500),
	@Published bit,
	@PictureUrl nvarchar(2048),
	@CategoryId int
AS
begin
	update dbo.Recipe
	set Title = @Title,
	[Description]=@Description,
	Published=@Published,
	PictureUrl=@PictureUrl,
	CategoryId=@CategoryId
	where Id=@Id
end
