ALTER TABLE [dbo].[ScheduledMatch]
	ADD CONSTRAINT [ScheduledMatch_FK2]
	FOREIGN KEY (MatchID)
	REFERENCES [Match] (MatchID)
