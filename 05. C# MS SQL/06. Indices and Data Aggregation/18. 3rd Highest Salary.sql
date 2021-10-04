SELECT e.DepartmentID, e.Salary FROM
(SELECT DepartmentID, Salary, DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Rank] FROM Employees
GROUP BY DepartmentID, Salary) AS e
WHERE e.Rank = 3
ORDER BY e.DepartmentID