CREATE PROCEDURE [dbo].[spUnit_Update]
	@Id int,
	@Name nvarchar(100),
	@Symbol nvarchar(10),
	@MesurementType nvarchar(100),
	@MetricUnitValue float,
	@MetricUnitId int
AS
begin
	update dbo.Unit
	set [Name] = @Name, [Symbol] = @Symbol, MesurementType = @MesurementType, MetricUnitValue = @MetricUnitValue, MetricUnitId=@MetricUnitId
	where Id=@Id;
end
