ALTER TABLE [dbo].[WorksForTeam]
	ADD CONSTRAINT [WorksForTeam_FK]
	FOREIGN KEY (TeamID)
	REFERENCES [Team] (TeamID)
