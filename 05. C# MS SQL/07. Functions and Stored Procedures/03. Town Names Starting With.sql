CREATE PROC usp_GetTownsStartingWith (@startingLetter NVARCHAR(max))
AS
BEGIN
	SELECT [Name] FROM Towns WHERE [NAME] LIKE @startingLetter + '%'
END