USE Northwind 
GO

--Simple GROUP BY-------------------------------

--SELECT COUNT(*) AS NumProducts, CategoryName
--FROM Products p
--	INNER JOIN Categories c ON
--		c.CategoryID = p.CategoryID
--GROUP BY CategoryName

--Complex GROUP BY------------------------------

--SELECT SUM(od.UnitPrice * od.Quantity) AS Total, Country
--FROM Orders o
--	INNER JOIN [Order Details] od ON
--		od.OrderID = o.OrderID
--	INNER JOIN Customers c ON
--		c.CustomerID = o.CustomerID
--WHERE o.OrderDate BETWEEN '1/1/1996' AND '12/31/1996'
--GROUP BY Country
--ORDER BY Total DESC

--HAVING Ex.---------------------------------------------

--SELECT FirstName, LastName, SUM(UnitPrice * Quantity) AS TotalSales
--FROM Orders o 
--	INNER JOIN [Order Details] od ON
--		o.OrderID = od.OrderID
--	INNER JOIN Employees e ON 
--		o.EmployeeID = e.EmployeeID
--GROUP BY FirstName, LastName
--HAVING SUM(UnitPrice * Quantity) > 200000
--ORDER BY TotalSales DESC

--Multi aggregates Ex.-------------------------------------

SELECT Country,
	SUM(UnitPrice * Quantity) AS TotalSales,
	MIN(UnitPrice * Quantity) AS SmallestOrder,
	MAX(UnitPrice * Quantity) AS LargestOrder,
	AVG(UnitPrice * Quantity) AS AverageOrder,
	COUNT(o.OrderID) AS TotalOrders
FROM Orders o 
	INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
	INNER JOIN Customers c ON o.CustomerID = c.CustomerID
GROUP BY Country
ORDER BY TotalSales DESC