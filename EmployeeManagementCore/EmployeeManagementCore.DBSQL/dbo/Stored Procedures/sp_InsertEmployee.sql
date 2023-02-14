CREATE PROCEDURE [dbo].[sp_InsertEmployee]
    @Id int,
    @FirstName VARCHAR(50), 
    @LastName VARCHAR(50), 
    @EmailAddress NVARCHAR(255), 
    @Gender int, 
    @Salary DECIMAL, 
    @Department int,
    @Role int,
    @CreatedDate DATETIME, 
    @ModifiedDate DATETIME
AS
BEGIN
    insert into Employees ([FirstName],[LastName],[EmailAddress], [Gender],[Salary],[Department],[Role],[CreatedDate],[ModifiedDate])
    values
    (@FirstName,@LastName,@EmailAddress,@Gender,@Salary,@Department,@Role,@CreatedDate,@ModifiedDate);
END