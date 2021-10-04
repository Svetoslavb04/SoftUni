SELECT DISTINCT Left(FirstName, 1) AS FirstLetter FROM WizzardDeposits
GROUP BY FirstName, DepositGroup
HAVING DepositGroup = 'Troll Chest'
ORDER BY FirstLetter