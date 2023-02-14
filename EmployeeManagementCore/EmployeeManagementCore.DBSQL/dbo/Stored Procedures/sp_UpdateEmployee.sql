CREATE PROCEDURE [dbo].[sp_UpdateEmployee]
	@Id int,
    @FirstName VARCHAR(50), 
    @LastName VARCHAR(50), 
    @EmailAddress NVARCHAR(255), 
    @Gender INT, 
    @Salary DECIMAL, 
    @Department INT,
    @Role INT, 
    @ModifiedDate DATETIME
AS
BEGIN
    update Employees set
    [FirstName]=@FirstName,
    [LastName]=@LastName,
    [EmailAddress]=@EmailAddress,
    [Gender]=@Gender,
    [Salary]=@Salary,
    [Department]=@Department,
    [Role]=@Role,
    [ModifiedDate]=@ModifiedDate

    where [Id]=@Id
END