CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(200), @word NVARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @count INT = 1;
	DECLARE @letter NVARCHAR;

	WHILE @count <= LEN(@word)
	BEGIN
		
		SET @letter = SUBSTRING(@word, @count, 1)

		IF @setOfLetters NOT LIKE '%' + @letter + '%'
			RETURN 0

		SET @count += 1;
	END;

	RETURN 1
END