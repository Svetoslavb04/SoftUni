SELECT TOP(5)
*
FROM
(SELECT 
	c.CountryName, r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF') AS cr
ORDER BY cr.CountryName