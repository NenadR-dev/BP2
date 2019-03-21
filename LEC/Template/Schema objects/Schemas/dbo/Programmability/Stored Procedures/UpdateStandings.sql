CREATE PROCEDURE [dbo].[UpdateStandings]
	@teamID INT,
	@wins INT = NULL,
	@loses INT = NULL
AS
BEGIN
	UPDATE [dbo].[Standing]
	SET Wins = @wins,
		Loses = @loses
	WHERE TeamID = @teamID
END
