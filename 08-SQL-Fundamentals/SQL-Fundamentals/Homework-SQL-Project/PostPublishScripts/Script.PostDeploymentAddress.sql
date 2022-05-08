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
IF NOT EXISTS (SELECT 1 FROM [Address])
BEGIN
    INSERT INTO [Address] ([Street], [City], [State], [ZipCode])
    VALUES ('West Main','Liverpool','-','04030'),
           ('Abbey Road','London','-','594590'),
           ('East Lake','New York','NY','343566'),
           ('Hill','Denver','CO','54567'),
           ('Oak','Boston','MA','35678')
END