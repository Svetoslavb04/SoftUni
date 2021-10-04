SELECT TOP(10) FirstName, LastName, e.DepartmentID FROM Employees AS e
JOIN 
(SELECT DepartmentID, AVG(Salary) AS AVGSALARY FROM Employees
GROUP BY DepartmentID) AS [as] ON e.DepartmentID = [as].DepartmentID
WHERE e.Salary > [as].AVGSALARY
ORDER BY DepartmentID 