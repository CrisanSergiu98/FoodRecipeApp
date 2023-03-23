CREATE PROCEDURE [dbo].[spIngredient_Update]
	@Id int,
	@Name nvarchar(50),
	@Description nvarchar(MAX),
	@PictureUrl nvarchar(MAX),
	@CategoryId int,
	@MesurementType nvarchar(50)
	
AS
begin
	update dbo.Ingredient
	set [Name]=@Name, [Description] = @Description, PictureUrl=@PictureUrl, CategoryId = @CategoryId, MesurementType = @MesurementType
	where Id=@Id;
end
