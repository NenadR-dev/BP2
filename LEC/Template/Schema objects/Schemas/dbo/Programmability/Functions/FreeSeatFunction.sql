CREATE FUNCTION [dbo].[FreeSeatFunction]
(
	@row INT = NULL,
	@seat INT = NULL,
	@matchName VARCHAR(50) = NULL
)
RETURNS INT
AS
BEGIN
	DECLARE @retValue INT
	SET @retValue = (SELECT COUNT(TicketID) FROM [dbo].Ticket t1 WHERE t1.Seat = @seat AND t1.Row = @row AND t1.MatchName = @matchName)
	RETURN @retValue
END