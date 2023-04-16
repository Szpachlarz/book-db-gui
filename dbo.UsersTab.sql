CREATE TABLE [dbo].[UsersTab]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Surname] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [Passwd] NVARCHAR(50) NOT NULL, 
    [Country] NVARCHAR(50) NOT NULL
)
