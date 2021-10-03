SELECT 
* 
FROM (SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation FROM MountainsCountries AS mc
JOIN Mountains AS m ON mc.MountainId = m.Id
JOIN Countries AS c ON mc.CountryCode = c.CountryCode 
JOIN Peaks AS p ON p.MountainId = m.Id) AS mcp
WHERE mcp.Elevation >= 2835 AND mcp.CountryCode = 'BG'
ORDER BY mcp.Elevation DESC