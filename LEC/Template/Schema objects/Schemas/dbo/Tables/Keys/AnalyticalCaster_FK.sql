ALTER TABLE [dbo].[AnalyticalCaster]
	ADD CONSTRAINT [AnalyticalCaster_FK]
	FOREIGN KEY (ACasterID)
	REFERENCES [Employee] (EmployeeID)
