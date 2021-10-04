SELECT *
  INTO EmployeesAverageSalaries
  FROM Employees
 WHERE Salary > 30000

DELETE FROM EmployeesAverageSalaries
WHERE ManagerID = 42

UPDATE EmployeesAverageSalaries
SET Salary = Salary + 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) FROM EmployeesAverageSalaries
GROUP BY DepartmentID