/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF NOT EXISTS (SELECT 1 FROM [Employee])
BEGIN
    INSERT INTO [Employee] ([PersonId], [AddressId], [EmployeeName], [Position], [CompanyName])
    VALUES (1,1,'John','Songwriter','The Beatles'),
           (2,1,'Paul','Songwriter','The Beatles'),
           (3,2,'Jim','Singer','The Doors'),
           (4,3,'Robby','Guitar player','The Doors')
END