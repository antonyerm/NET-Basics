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
    FOR INSERT
    AS
    BEGIN
        SET NoCount ON;
        IF NOT EXISTS (SELECT * FROM [Company] WHERE [Company].[Name] = [inserted].[CompanyName])
            INSERT INTO [Company] ([Name], [AddressId])
            VALUES ([inserted].[CompanyName], [inserted].[AddressId])
    END;