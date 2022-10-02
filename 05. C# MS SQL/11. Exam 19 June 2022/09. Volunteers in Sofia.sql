SELECT 
  v.Name,
  v.PhoneNumber,
  SUBSTRING(v.Address, PATINDEX('%[1234567890]%', v.Address), LEN(v.Address)) as Address
FROM Volunteers AS v
WHERE 
	v.DepartmentId = (
		SELECT Id FROM VolunteersDepartments 
		WHERE DepartmentName = 'Education program assistant' 
	)
	AND
	v.Address LIKE '%Sofia%'
ORDER BY v.Name ASC