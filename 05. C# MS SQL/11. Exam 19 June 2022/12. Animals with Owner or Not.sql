CREATE PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(max))
AS
	SELECT
		@AnimalName AS Name,
		CASE
			WHEN o.Name IS NULL THEN 'For adoption'
			ELSE o.Name
		END AS OwnersName
	FROM Animals AS a
	LEFT JOIN Owners AS o ON a.OwnerId = o.Id
	WHERE a.Name = @AnimalName