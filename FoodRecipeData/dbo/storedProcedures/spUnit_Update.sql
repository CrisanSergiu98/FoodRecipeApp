CREATE PROCEDURE [dbo].[spUnit_Update]
	@Id int,
	@Name nvarchar(50),
	@Symbol nvarchar(50),
	@MesurementType nvarchar(50),
	@MetricUnitValue float,
	@MetricUnitId int
AS
begin
	update dbo.Unit
	set [Name] = @Name, [Symbol] = @Symbol, MesurementType = @MesurementType, MetricUnitValue = @MetricUnitValue, MetricUnitId=@MetricUnitId
	where Id=@Id;
end
