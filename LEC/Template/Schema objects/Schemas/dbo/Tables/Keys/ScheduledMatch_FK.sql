ALTER TABLE [dbo].[ScheduledMatch]
	ADD CONSTRAINT [ScheduledMatch_FK]
	FOREIGN KEY (ScheduleID)
	REFERENCES [Schedule] (ScheduleID)
