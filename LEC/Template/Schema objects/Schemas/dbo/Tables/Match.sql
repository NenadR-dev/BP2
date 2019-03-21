CREATE TABLE [dbo].[Match]
(
	[MatchID] INT NOT NULL IDENTITY(1,1), 
    [MatchName] VARCHAR(20) NOT NULL, 
    [StartTime] DATETIME NOT NULL, 
    [MatchFavorite] VARCHAR(20) NULL, 
    [TeamA_ID] INT NOT NULL, 
    [TeamB_ID] INT NOT NULL, 
    [Caster_ID] INT NOT NULL 
)
