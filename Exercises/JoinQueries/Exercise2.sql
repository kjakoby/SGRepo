/*
	Get the Company Name, Order Date, and each order detail’s 
	Product name for USA customers only.
*/

USE Northwind;
GO

SELECT c.CompanyName, o.OrderDate, p.ProductName
FROM Orders o
	INNER JOIN Customers c ON
		c.CustomerID = o.CustomerID
	INNER JOIN [Order Details] od ON
		od.OrderID = o.OrderID
	INNER JOIN Products p ON
		p.ProductID = od.ProductID
WHERE c.Country = 'USA'
