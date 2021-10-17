SELECT LastName, AVG(s.[Length]) AS CiagrLength, CEILING(AVG(s.RingRange)) AS CiagrRingRange FROM Clients AS c
JOIN ClientsCigars AS cc on cc.ClientId = c.Id
JOIN Cigars AS ci ON ci.Id = cc.CigarId
JOIN Sizes AS s ON s.Id = ci.SizeId
GROUP BY LastName
ORDER BY AVG(s.[Length]) DESC