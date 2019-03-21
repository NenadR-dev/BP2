ALTER TABLE [dbo].[MatchTicket]
	ADD CONSTRAINT [MatchTicket_FK2]
	FOREIGN KEY (UserID)
	REFERENCES [User] (UserID)
