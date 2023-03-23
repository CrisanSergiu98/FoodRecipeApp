CREATE PROCEDURE [dbo].[spIngredient_Insert]
	@Name nvarchar(50),
	@Description nvarchar(MAX),
	@PictureUrl nvarchar(MAX),
	@CategoryId int,
	@MesurementType nvarchar (50)
AS
begin
	insert into dbo.Ingredient ([Name],[Description],PictureUrl, CategoryId, MesurementType)
	values(@Name,@Description,@PictureUrl, @CategoryId, @MesurementType)
end
