SELECT TOP(1)
AVG(Salary) AS [Avg] 
FROM Employees 
GROUP BY DepartmentID
ORDER BY [Avg]