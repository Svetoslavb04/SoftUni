SELECT COALESCE(IIF(CONCAT(e.FirstName	, ' ', e.LastName)=' ', NULL, CONCAT(e.FirstName	, ' ', e.LastName)), 'None') AS [Employee]
	, COALESCE(d.[Name], 'None') AS [Department]
	, c.[Name] AS [Category]
	, r.[Description]
	, FORMAT(r.Opendate, 'dd.MM.yyyy')
	, s.[Label] AS [Statuss]
	, u.[Name]
FROM Reports AS r
LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
LEFT JOIN Users AS u ON r.UserId = u.Id
LEFT JOIN Departments AS d ON d.Id = e.DepartmentId
LEFT JOIN Categories AS c ON r.CategoryId = c.Id
LEFT JOIN [Status] AS s ON r.StatusId = s.Id
ORDER BY e.FirstName DESC, e.LastName DESC, d.[Name], c.[Name], r.[Description], r.Opendate, Statuss, u.[Name]
