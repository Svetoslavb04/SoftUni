SELECT TOP(5)
	    k.CountryName AS Country,
	    ISNULL(k.PeakName, '(no highest peak)') AS [Highest Peak Name],
	    ISNULL(k.[Highest Peak Elevation], 0) AS [Highest Peak Elevation],
	    ISNULL(k.Mountain, '(no mountain)') AS [Mountain]
	FROM (SELECT c.CountryName, MAX(p.Elevation) AS [Highest Peak Elevation], m.MountainRange AS [Mountain],
	 DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY MAX(p.Elevation) DESC) AS [Rank], p.PeakName
	FROM Countries c
		LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
		LEFT JOIN Mountains m ON mc.MountainId = m.Id
		LEFT JOIN Peaks p ON m.Id = p.MountainId
	GROUP BY c.CountryName, m.MountainRange, p.PeakName) AS k
	WHERE k.Rank = 1
 ORDER BY Country, [Highest Peak Name]