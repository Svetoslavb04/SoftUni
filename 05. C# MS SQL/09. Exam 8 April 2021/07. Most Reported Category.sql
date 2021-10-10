SELECT TOP(5) c.[Name] AS [CategoryName], COUNT(r.Id) AS [ReportsNumber] FROM Categories AS c
LEFT JOIN Reports AS r ON c.Id = r.CategoryId
GROUP BY c.[Name]
ORDER BY [ReportsNumber] DESC, c.[Name]