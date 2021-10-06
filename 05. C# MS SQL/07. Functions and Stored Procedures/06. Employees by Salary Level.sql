CREATE PROC usp_EmployeesBySalaryLevel (@levelOfSalary NVARCHAR(20))
AS
BEGIN
	SELECT FirstName, LastName FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @levelOfSalary
END