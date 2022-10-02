/****** Script for SelectTopNRows command from SSMS  ******/
DELETE FROM Volunteers
WHERE DepartmentId = 
(
  SELECT TOP(1) id from VolunteersDepartments
  WHERE DepartmentName = 'Education program assistant'
)

DELETE FROM VolunteersDepartments
WHERE DepartmentName = 'Education program assistant'
