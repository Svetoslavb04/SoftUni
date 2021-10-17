SELECT cu.FullName, cu.Country, cu.ZIP, CONCAT('$', cu.maxPrice) AS [CigarPrice] FROM (SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName, a.Country, a.ZIP, MAX(ci.PriceForSingleCigar) AS maxPrice FROM Clients AS c
JOIN Addresses AS a ON c.AddressId = a.Id
JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
JOIN Cigars AS ci ON ci.Id = cc.CigarId
WHERE ZIP NOT LIKE '%[^0-9]%' 
GROUP BY c.FirstName, c.LastName, a.Country, a.ZIP) AS cu
ORDER BY cu.FullName ASC