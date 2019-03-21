ALTER TABLE [dbo].[MatchTicket]
	ADD CONSTRAINT [MatchTicket_FK]
	FOREIGN KEY (MatchID)
	REFERENCES [Match] (MatchID)
