ALTER TABLE [dbo].[Standing]
	ADD CONSTRAINT [Standing_FK]
	FOREIGN KEY (TeamID)
	REFERENCES [Team] (TeamID)
