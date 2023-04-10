CREATE PROCEDURE [dbo].[spRecipeStep_Update]
	@RecipeId int,
	@Number int,
	@Description nvarchar(500),
	@PictureUrl nvarchar(2048)
AS
begin
	update dbo.Recipe_Step
	set [Description] = @Description, PictureUrl = @PictureUrl
	where RecipeId=@RecipeId and Number = @Number
end
