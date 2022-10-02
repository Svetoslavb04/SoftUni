SELECT TOP(5) 
  o.Name AS Name,
  COUNT(a.Id) AS CountOfAnimals
FROM Owners AS o
JOIN Animals AS a ON a.OwnerId = o.Id
GROUP BY o.Name
ORDER BY CountOfAnimals DESC