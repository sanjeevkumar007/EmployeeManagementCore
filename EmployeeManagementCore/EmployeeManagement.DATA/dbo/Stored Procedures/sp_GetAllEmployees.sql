CREATE PROCEDURE [dbo].[sp_GetAllEmployees]
AS
BEGIN
	select * from Employees with (nolock)
END

	 

