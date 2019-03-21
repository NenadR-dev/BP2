ALTER TABLE [dbo].[WorksForTeam]
	ADD CONSTRAINT [WorksForTeam_FK2]
	FOREIGN KEY (TeamStaffID)
	REFERENCES [TeamStaff] (TeamStaffID)
