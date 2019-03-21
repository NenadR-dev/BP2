ALTER TABLE [dbo].[IsOnMedia]
	ADD CONSTRAINT [IsOnMedia_FK2]
	FOREIGN KEY (ACasterID)
	REFERENCES [AnalyticalCaster] (ACasterID)
