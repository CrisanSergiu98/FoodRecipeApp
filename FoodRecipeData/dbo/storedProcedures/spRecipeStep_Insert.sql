CREATE PROCEDURE [dbo].[spRecipeStep_Insert]
	@RecipeId int,
	@Number int,
	@Description nvarchar(MAX),
	@PictureUrl nvarchar(MAX)
AS
begin
	insert into dbo.Recipe_Step (RecipeId, [Number], [Description], PictureUrl)
	values(@RecipeId, @Number, @Description, @PictureUrl)
end
