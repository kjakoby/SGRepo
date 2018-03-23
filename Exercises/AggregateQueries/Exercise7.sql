/*
	Find the total sales by supplier 
	ordered from most to least.
*/

USE Northwind;
GO

SELECT s.CompanyName, SUM(od.Quantity * od.UnitPrice) AS [Total Sales]
FROM Suppliers s
	INNER JOIN Products p ON
		p.SupplierID = s.SupplierID
	INNER JOIN [Order Details] od ON
		p.ProductID = od.ProductID
GROUP BY s.CompanyName
ORDER BY [Total Sales] DESC