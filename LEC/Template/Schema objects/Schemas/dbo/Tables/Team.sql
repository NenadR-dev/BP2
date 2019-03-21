CREATE TABLE [dbo].[Team]
(
	[TeamID] INT NOT NULL IDENTITY(1,1), 
    [TeamName] VARCHAR(20) NOT NULL, 
    [Description] VARCHAR(200) NOT NULL, 
    [HeadQuarters] VARCHAR(20) NOT NULL 
)
