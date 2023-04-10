CREATE PROCEDURE [dbo].[spRecipeStep_Insert]
	@RecipeId int,
	@Number int,
	@Description nvarchar(500),
	@PictureUrl nvarchar(2048)
AS
begin
	insert into dbo.Recipe_Step (RecipeId, [Number], [Description], PictureUrl)
	values(@RecipeId, @Number, @Description, @PictureUrl)
end
