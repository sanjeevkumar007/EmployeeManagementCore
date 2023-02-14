CREATE TABLE [dbo].[Employees] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (50)   NOT NULL,
    [LastName]     VARCHAR (50)   NULL,
    [EmailAddress] NVARCHAR (255) NOT NULL,
    [Gender]       INT            NOT NULL,
    [Salary]       DECIMAL (18)   NOT NULL,
    [Department]   INT            NOT NULL,
    [Role]         INT            NOT NULL,
    [CreatedDate]  DATETIME       DEFAULT getdate() NOT NULL,
    [ModifiedDate] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

