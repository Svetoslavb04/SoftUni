CREATE PROC usp_SearchByTaste(@taste NVARCHAR(20))
AS
BEGIN
	SELECT 
	c.CigarName
	, CONCAT('$',c.PriceForSingleCigar) AS Price
	, t.TasteType
	, b.BrandName
	, CONCAT(s.[Length], ' cm') AS [CigarLength]
	, CONCAT(s.RingRange, ' cm') AS [CigarRingRange] 
FROM Cigars AS c
JOIN Sizes AS s ON c.SizeId =s.Id
JOIN Tastes AS t ON c.TastId = t.Id
JOIN Brands AS b ON c.BrandId = b.Id
WHERE t.TasteType = @taste
ORDER BY CigarLength ASC, CigarRingRange DESC
END 