CREATE PROCEDURE [dbo].[spUnit_Delete]
	@Id int
AS
begin
	delete 
	from dbo.Unit
	where Id = @Id
end
