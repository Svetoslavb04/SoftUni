CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	DECLARE @hours INT = CONVERT(int,DATEDIFF(mi, @StartDate, @EndDate) / 60)

	RETURN @hours
END