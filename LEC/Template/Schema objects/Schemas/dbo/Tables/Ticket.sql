CREATE TABLE [dbo].[Ticket]
(
	[TicketID] INT NOT NULL IDENTITY(1,1), 
    [Row] INT NOT NULL, 
    [Seat] INT NOT NULL, 
    [Price] FLOAT NOT NULL, 
    [Location] VARCHAR(20) NOT NULL, 
    [MatchName] VARCHAR(20) NOT NULL 
)
