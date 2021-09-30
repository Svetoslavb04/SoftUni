SELECT
	e.FirstName, e. LastName, e.HireDate, d.[Name]
FROM Employees AS e
LEFT JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE YEAR(e.HireDate) >= 1999 AND MONTH(e.HireDate) >= 1 AND DAY(e.HireDate) >= 1 AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.EmployeeID