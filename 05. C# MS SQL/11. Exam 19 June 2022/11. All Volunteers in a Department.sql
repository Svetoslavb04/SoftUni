CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(max))
RETURNS INT
AS
BEGIN
	
	DECLARE @volunteersCount INT;

	SET @volunteersCount = (
		SELECT COUNT(Name) FROM Volunteers
		WHERE DepartmentId = (
			SELECT Id FROM VolunteersDepartments
			WHERE DepartmentName = @VolunteersDepartment
		)
		GROUP BY DepartmentId
	)

	RETURN @volunteersCount;
END