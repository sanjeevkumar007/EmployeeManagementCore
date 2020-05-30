CREATE PROCEDURE [dbo].[sp_GetEmployeeById]
	@Id int

AS
BEGIN
	select * from Employees with (nolock) where Id=@Id;
END
	
