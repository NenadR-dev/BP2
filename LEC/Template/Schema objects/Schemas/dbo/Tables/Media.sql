CREATE TABLE [dbo].[Media]
(
	[MediaID] INT NOT NULL IDENTITY(1,1), 
    [ShowName] VARCHAR(20) NOT NULL, 
    [Length] TIME NOT NULL, 
    [ReleaseDate] DATE NOT NULL 
)
