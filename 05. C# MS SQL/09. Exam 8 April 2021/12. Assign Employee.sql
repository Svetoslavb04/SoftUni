CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
	
	DECLARE @employeeDep INT = (SELECT DepartmentId FROM Employees WHERE Id = @EmployeeId);
	DECLARE @reportCatDep INT = (SELECT c.DepartmentId FROM Reports AS r JOIN Categories AS c ON r.CategoryId = c.Id WHERE r.Id = @ReportId);
		
	IF(@employeeDep <> @reportCatDep)
	BEGIN
		THROW 50001, 'Employee doesn''t belong to the appropriate department!',1;
	END

	UPDATE Reports
		SET EmployeeId = @EmployeeId
		WHERE Id = @ReportId
END

