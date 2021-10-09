SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Available FROM Mechanics AS m
LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId
WHERE (SELECT COUNT(*) FROM Mechanics AS mc
LEFT JOIN Jobs AS j ON mc.MechanicId = j.MechanicId
WHERE j.[Status] = 'Finished' AND mc.MechanicId = m.MechanicId) - (SELECT COUNT(*) FROM Mechanics AS mc
LEFT JOIN Jobs AS j ON mc.MechanicId = j.MechanicId
WHERE mc.MechanicId = m.MechanicId) = 0
GROUP BY m.MechanicId, m.FirstName, m.LastName
ORDER BY m.MechanicId

/*
SELECT CONCAT([FirstName], ' ',[LastName]) AS [Available] 
  FROM [Mechanics]
 WHERE [MechanicId] NOT IN (
                                SELECT [MechanicId] FROM [Jobs]
                                WHERE [Status] = 'In Progress' 
                                GROUP BY [MechanicId]
                            )*/