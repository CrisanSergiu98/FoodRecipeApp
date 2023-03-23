CREATE PROCEDURE [dbo].[spUnit_Get]
	@Id int
AS
begin
	select *
	from dbo.Unit
	where Id=@Id
end

