CREATE TRIGGER [StandingsTrigger]
	ON [dbo].[Standing]
	FOR UPDATE
	AS
	BEGIN
		UPDATE Standing SET Rank = r.r
		FROM Standing d
		INNER JOIN (
			SELECT TeamID
				, r = RANK() OVER(ORDER BY Wins DESC, Loses ASC) 
			FROM Standing
		) r ON d.TeamID = r.TeamID
	END
