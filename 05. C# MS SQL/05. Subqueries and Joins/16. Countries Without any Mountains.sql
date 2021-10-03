SELECT COUNT(c.CountryCode) AS [Count] FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
WHERE MountainId IS NULL
