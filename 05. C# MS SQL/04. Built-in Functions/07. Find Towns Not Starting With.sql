SELECT TownID,[Name] FROM Towns
WHERE [Name] LIKE '[^R,B,D]%'
ORDER BY [Name] 