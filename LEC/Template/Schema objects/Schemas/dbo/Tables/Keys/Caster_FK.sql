ALTER TABLE [dbo].[Caster]
	ADD CONSTRAINT [Caster_FK]
	FOREIGN KEY (CasterID)
	REFERENCES [Employee] (EmployeeID)
