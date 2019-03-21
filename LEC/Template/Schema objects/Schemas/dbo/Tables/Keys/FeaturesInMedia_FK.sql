ALTER TABLE [dbo].[FeaturesInMedia]
	ADD CONSTRAINT [FeaturesInMedia_FK]
	FOREIGN KEY (MediaID)
	REFERENCES [Media] (MediaID)
