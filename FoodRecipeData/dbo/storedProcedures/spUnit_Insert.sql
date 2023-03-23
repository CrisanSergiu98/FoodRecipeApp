CREATE PROCEDURE [dbo].[spUnit_Insert]
	@Name nvarchar(50),
	@Symbol nvarchar(50),
	@MesurementType nvarchar(50),
	@MetricUnitValue float,
	@MetricUnitId int
AS
begin
	insert into dbo.Unit ([Name], [Symbol], MesurementType, MetricUnitValue, MetricUnitId)
	values(@Name,@Symbol,@MesurementType,@MetricUnitValue,@MetricUnitId)
end
