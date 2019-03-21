ALTER TABLE [dbo].[Match]
	ADD CONSTRAINT [Match_FK3]
	FOREIGN KEY (Caster_ID)
	REFERENCES [Caster] (CasterID)
