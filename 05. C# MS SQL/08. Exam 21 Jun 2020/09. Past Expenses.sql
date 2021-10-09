SELECT pq.JobId, SUM(pq.TotalPrice) AS Total FROM (SELECT j.JobId, pn.Quantity * p.Price AS [TotalPrice] FROM Jobs AS j
JOIN PartsNeeded AS pn ON j.JobId = pn.JobId
JOIN Parts AS p ON p.PartId = pn.PartId
WHERE j.[Status] = 'Finished') AS pq
GROUP BY pq.JobId
ORDER BY Total DESC, pq.JobId ASC
