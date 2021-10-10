SELECT r.[Description], c.[Name] AS [CategoryName] FROM Reports AS r
LEFT JOIN Categories AS c ON r.CategoryId = c.Id
ORDER BY r.[Description], c.[Name]