SELECT c.Id, CigarName, PriceForSingleCigar, t.TasteType, t.TasteStrength FROM Cigars AS c
JOIN Tastes AS t ON c.TastId = t.Id
WHERE t.Id IN (2,3)
ORDER BY PriceForSingleCigar DESC