SELECT 
  CONCAT(o.Name, '-',a.Name) AS OwnersAnimals,
  o.PhoneNumber, ac.CageId
FROM Animals AS a
JOIN AnimalsCages AS ac ON ac.AnimalId = a.Id
JOIN Owners AS o ON a.OwnerId = o.Id
ORDER BY o.Name ASC, a.Name DESC