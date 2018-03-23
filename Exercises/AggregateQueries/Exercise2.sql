/*
	Find the gross total (sum of quantity * unit price) for 
	all orders placed by B's Beverages and Chop-suey Chinese.
*/

USE Northwind;
GO

SELECT SUM(Quantity * UnitPrice) AS [Gross Total]
FROM Orders o
	INNER JOIN Customers c ON
		c.CustomerID = o.CustomerID
	INNER JOIN [Order Details] od ON
		od.OrderID = o.OrderID
WHERE c.CompanyName IN ('B''s Beverages', 'Chop-suey Chinese')