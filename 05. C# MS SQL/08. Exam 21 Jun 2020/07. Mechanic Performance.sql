SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic , AVG(DATEDIFF(day, j.IssueDate, j.FinishDate)) AS [Average Days] FROM Mechanics AS m
JOIN Jobs AS j ON m.MechanicId = j.MechanicId
WHERE j.[Status] = 'Finished'
GROUP BY m.MechanicId, m.FirstName, m.LastName, j.[Status]
ORDER BY m.MechanicId ASC
