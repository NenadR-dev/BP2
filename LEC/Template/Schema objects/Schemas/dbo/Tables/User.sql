CREATE TABLE [dbo].[User]
(
	[UserID] INT NOT NULL IDENTITY(1,1), 
    [Username] VARCHAR(20) NOT NULL, 
    [Password] VARCHAR(20) NOT NULL, 
    [Email] VARCHAR(20) NOT NULL, 
    [FirstName] VARCHAR(20) NOT NULL, 
    [LastName] VARCHAR(20) NOT NULL 
)
