CREATE PROCEDURE [dbo].[spUnit_Insert]
	@Name nvarchar(100),
	@Symbol nvarchar(100),
	@MesurementType nvarchar(100),
	@MetricUnitValue float,
	@MetricUnitId int
AS
begin
	insert into dbo.Unit ([Name], [Symbol], MesurementType, MetricUnitValue, MetricUnitId)
	values(@Name,@Symbol,@MesurementType,@MetricUnitValue,@MetricUnitId)
end
