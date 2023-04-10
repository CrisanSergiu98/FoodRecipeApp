CREATE PROCEDURE [dbo].[spIngredient_Update]
	@Id int,
	@Name nvarchar(100),
	@Description nvarchar(500),
	@PictureUrl nvarchar(2048),
	@CategoryId int,
	@MesurementType nvarchar(100)
	
AS
begin
	update dbo.Ingredient
	set [Name]=@Name, [Description] = @Description, PictureUrl=@PictureUrl, CategoryId = @CategoryId, MesurementType = @MesurementType
	where Id=@Id;
end
