ALTER TABLE [dbo].[Host]
	ADD CONSTRAINT [Host_FK]
	FOREIGN KEY (HostID)
	REFERENCES [Employee] (EmployeeID)
