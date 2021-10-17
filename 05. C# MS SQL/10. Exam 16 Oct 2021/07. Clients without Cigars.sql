SELECT Id, CONCAT(FirstName, ' ', LastName), Email AS [ClientName] FROM Clients AS c
LEFT JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
WHERE cc.ClientId IS NULL
ORDER BY [FirstName] ASC