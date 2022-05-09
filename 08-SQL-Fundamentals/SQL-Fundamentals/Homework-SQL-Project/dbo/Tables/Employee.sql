CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AddressId] INT NOT NULL, 
    [PersonId] INT NOT NULL,
    [CompanyName] NVARCHAR(20) NOT NULL, 
    [Position] NVARCHAR(30) NULL, 
    [EmployeeName] NVARCHAR(100) NULL, 
    CONSTRAINT [FK_Employee_Address] FOREIGN KEY ([AddressId]) REFERENCES [Address]([Id]), 
    CONSTRAINT [FK_Employee_Person] FOREIGN KEY (PersonId) REFERENCES Person(Id)
)

GO

CREATE TRIGGER [dbo].[Trigger_EmployeeOnInsert]
    ON [dbo].[Employee]
    AFTER INSERT
    AS
    BEGIN
        SET NoCount ON;
        -- Do insert if there are no the same rows already.
        IF NOT EXISTS (SELECT * FROM [Company] c
                       INNER JOIN [inserted] i ON c.[Name] = i.[CompanyName]) AND c.[AddressId] = i.[AddressId]
        BEGIN
            -- Insert values into Company from rows of Inserted which do not already exist in Company.
            INSERT INTO [Company] ([Name], [AddressId])
            SELECT [CompanyName], [AddressId] FROM [inserted] i
            INNER JOIN [Company] c ON NOT (c.[Name] = i.[CompanyName] AND c.[AddressId] = i.[AddressId])
        END;
    END;