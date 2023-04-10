CREATE PROCEDURE [dbo].[spIngredient_Insert]
	@Name nvarchar(100),
	@Description nvarchar(500),
	@PictureUrl nvarchar(2048),
	@CategoryId int,
	@MesurementType nvarchar (100)
AS
begin
	insert into dbo.Ingredient ([Name],[Description],PictureUrl, CategoryId, MesurementType)
	values(@Name,@Description,@PictureUrl, @CategoryId, @MesurementType)
end
