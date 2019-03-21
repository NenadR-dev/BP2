CREATE TABLE [dbo].[Schedule]
(
	[ScheduleID] INT NOT NULL IDENTITY(1,1), 
    [Name] VARCHAR(20) NOT NULL, 
    [MatchOfTheDay] VARCHAR(20) NOT NULL, 
    [MatchDescription] VARCHAR(100) NULL 
)
