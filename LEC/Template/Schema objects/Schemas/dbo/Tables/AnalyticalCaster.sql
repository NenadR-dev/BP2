CREATE TABLE [dbo].[AnalyticalCaster]
(
	[ACasterID] INT NOT NULL IDENTITY(1,1), 
    [PredictionRate] FLOAT NOT NULL, 
    [Expertise] NCHAR(10) NULL
)
