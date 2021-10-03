SELECT 
mcp.CountryCode, COUNT(mcp.MountainRange)  
FROM (SELECT mc.CountryCode, m.MountainRange FROM MountainsCountries AS mc
JOIN Mountains AS m ON mc.MountainId = m.Id
JOIN Countries AS c ON mc.CountryCode = c.CountryCode) AS mcp
WHERE mcp.CountryCode IN ('BG', 'US', 'RU')
GROUP BY mcp.CountryCode