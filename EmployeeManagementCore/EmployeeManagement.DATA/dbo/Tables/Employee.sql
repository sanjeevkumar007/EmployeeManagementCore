CREATE TABLE [dbo].[Employees]
(
	[Id] int identity primary key, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NULL, 
    [EmailAddress] NVARCHAR(255) NOT NULL, 
    [Gender] INT NOT NULL, 
    [Salary] DECIMAL NOT NULL, 
    [Department] INT NOT NULL,
    [Role] INT NOT NULL,
    [CreatedDate] DATETIME NOT NULL DEFAULT getdate(), 
    [ModifiedDate] DATETIME NULL,

)
