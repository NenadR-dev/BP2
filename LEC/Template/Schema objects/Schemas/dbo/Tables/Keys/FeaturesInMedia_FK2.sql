ALTER TABLE [dbo].[FeaturesInMedia]
	ADD CONSTRAINT [FeaturesInMedia_FK2]
	FOREIGN KEY (WorksForTeamID)
	REFERENCES [WorksForTeam] (WorksForTeamID)
