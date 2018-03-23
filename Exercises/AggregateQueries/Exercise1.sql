/*
	Find the average freight paid for orders 
	placed by companies in the USA
*/

USE Northwind;
GO

--SELECT AVG()
SELECT AVG(Freight) AS [Freight Average]
FROM Orders o
	INNER JOIN Customers c ON
		c.CustomerID = o.CustomerID
WHERE c.Country='USA'