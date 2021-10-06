CREATE PROC usp_GetHoldersWithBalanceHigherThan (@amount MONEY)
AS
BEGIN
	SELECT FirstName AS [First Name], LastName AS [Last Name] FROM dbo.AccountHolders AS ah
	JOIN dbo.Accounts AS a ON a.AccountHolderId = ah.Id
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @amount
	ORDER BY FirstName, LastName
END