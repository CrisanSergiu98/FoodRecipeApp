CREATE PROCEDURE [dbo].[spRecipeStep_Update]
	@RecipeId int,
	@Number int,
	@Description nvarchar(MAX),
	@PictureUrl nvarchar(MAX)
AS
begin
	update dbo.Recipe_Step
	set [Description] = @Description, PictureUrl = @PictureUrl
	where RecipeId=@RecipeId and Number = @Number
end
