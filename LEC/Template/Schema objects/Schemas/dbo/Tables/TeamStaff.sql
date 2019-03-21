CREATE TABLE [dbo].[TeamStaff]
(
	[TeamStaffID] INT NOT NULL IDENTITY(1,1), 
    [FirstName] VARCHAR(20) NOT NULL, 
    [LastName] VARCHAR(20) NOT NULL, 
    [InGameName] VARCHAR(20) NOT NULL, 
    [Salary] INT NOT NULL, 
    [Country] VARCHAR(20) NOT NULL, 
    [Position] VARCHAR(20) NOT NULL 
)
