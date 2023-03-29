CREATE PROCEDURE [dbo].[spRecipe_Update]
	@Id int,
	@Title nvarchar(50),
	@Description nvarchar(MAX),
	@Published bit,
	@PictureUrl nvarchar(MAX),
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
