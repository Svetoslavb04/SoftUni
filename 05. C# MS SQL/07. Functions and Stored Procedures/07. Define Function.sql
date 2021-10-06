CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(100), @word NVARCHAR(100))
RETURNS INT
AS
BEGIN
	DECLARE @Count INT = 1
	DECLARE @Letter VARCHAR(1)

	WHILE (LEN(@word) >= @Count)
	BEGIN
		SET @Letter = SUBSTRING(@word, @Count, 1)

		IF @setOfLetters NOT LIKE '%' + @Letter + '%'
			RETURN 0

		SET @Count += 1
	END
	RETURN 1 
END