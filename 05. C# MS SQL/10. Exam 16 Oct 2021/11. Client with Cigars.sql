CREATE FUNCTION udf_ClientWithCigars (@name VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @countCigars INT 
	SET @countCigars = (SELECT COUNT(*) FROM ClientsCigars AS cc JOIN Clients AS c ON cc.ClientId = c.Id WHERE c.FirstName = @name);
	RETURN @countCigar
END
