CREATE PROCEDURE [dbo].[sp_DeleteEmployee]
	@Id int
	
AS
BEGIN
	delete from Employees where [Id]=@Id
END