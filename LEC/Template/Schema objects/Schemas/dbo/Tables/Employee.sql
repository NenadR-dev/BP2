CREATE TABLE [dbo].[Employee]
(
	[EmployeeID] INT NOT NULL IDENTITY(1,1), 
    [FirstName] VARCHAR(20) NOT NULL, 
    [LastName] VARCHAR(20) NOT NULL, 
    [InGameName] VARCHAR(20) NOT NULL, 
    [BirthDate] DATETIME NOT NULL 
)
