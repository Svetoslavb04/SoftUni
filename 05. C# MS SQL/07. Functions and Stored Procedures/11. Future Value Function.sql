CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL, @yearlyInterestedRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	DECLARE @futureValue DECIMAL(18,4);

	SET @futureValue = @sum * (POWER((1 + @yearlyInterestedRate), @numberOfYears))

	RETURN ROUND(@futureValue,4)
END
