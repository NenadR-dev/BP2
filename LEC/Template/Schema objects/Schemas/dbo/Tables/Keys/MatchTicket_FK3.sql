ALTER TABLE [dbo].[MatchTicket]
	ADD CONSTRAINT [MatchTicket_FK3]
	FOREIGN KEY (TicketID)
	REFERENCES [Ticket] (TicketID)
