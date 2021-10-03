SELECT
	c.ContinentCode, c.CurrencyCode, c.[Currency Usage]
	FROM 
	(SELECT ContinentCode, CurrencyCode,  COUNT(CurrencyCode) AS [Currency Usage], DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC)
                AS [Rank] FROM Countries
	GROUP BY CurrencyCode, ContinentCode
	) AS c
WHERE c.Rank = 1 AND c.[Currency Usage] != 1
ORDER BY ContinentCode