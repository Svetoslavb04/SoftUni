SELECT u.Username, c.[Name] FROM Reports AS r
JOIN Users AS u ON r.UserId = u.Id
JOIN Categories AS c ON c.Id = r.CategoryId
WHERE CONCAT(DAY(u.Birthdate),MONTH(u.Birthdate)) = CONCAT(DAY(r.Opendate),MONTH(r.Opendate))
ORDER BY u.Username, c.[Name]