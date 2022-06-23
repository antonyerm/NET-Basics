CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(50) NULL, 
    [Description] NCHAR(50) NULL, 
    [Weight] FLOAT NULL, 
    [Height] FLOAT NULL, 
    [Width] FLOAT NULL, 
    [Length] FLOAT NULL
)
