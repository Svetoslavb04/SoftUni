SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic, j.[Status], j.IssueDate FROM Mechanics AS m
LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId