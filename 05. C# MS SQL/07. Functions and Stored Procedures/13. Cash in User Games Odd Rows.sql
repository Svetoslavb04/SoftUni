CREATE FUNCTION ufn_CashInUsersGames(@name NVARCHAR(50))
RETURNS MONEY
AS
BEGIN
	DECLARE @result MONEY;

	SET @result = (SELECT SUM(s.Cash) AS [SumCash] FROM
	(SELECT us.Cash, ROW_NUMBER() OVER (ORDER BY us.Id DESC) AS [Row] FROM UsersGames AS us
	JOIN Games As g ON g.Id = us.GameId
	WHERE g.Name = @name) AS s
	GROUP BY s.[Row]
	HAVING s.[Row] % 2 = 1)

	RETURN @result
END