/*
	Find the gross total of all orders (sum of quantity * unit price) 
	for each customer, order it in descending order by the total.
*/

USE Northwind;
GO

SELECT SUM(Quantity * UnitPrice) AS [Gross Total], CompanyName
FROM Customers c
	INNER JOIN Orders o ON
		o.CustomerID = c.CustomerID
	INNER JOIN [Order Details] od ON
		od.OrderID = o.OrderID
GROUP BY CompanyName
ORDER BY [Gross Total] DESC
