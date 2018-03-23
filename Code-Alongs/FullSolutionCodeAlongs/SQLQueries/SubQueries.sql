USE Northwind
GO

--Simple SubQuery---------------------------------------------------

--SELECT DISTINCT(o.OrderID), OrderDate, CompanyName
--FROM Orders o 
--	INNER JOIN Customers c ON o.CustomerID = c.CustomerID
--	INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
--WHERE od.ProductID IN 
--    -- subquery
--	(SELECT TOP 3 ProductID
--	 FROM Products
--	 ORDER BY UnitPrice DESC)
--ORDER BY CompanyName, OrderID

--JOIN SubQuery---------------------------------------------------

--SELECT DISTINCT(o.OrderID), OrderDate, CompanyName
--FROM Orders o 
--	INNER JOIN Customers c ON o.CustomerID = c.CustomerID
--	INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
--	INNER JOIN (SELECT TOP 3 ProductID
--	 FROM Products
--	 ORDER BY UnitPrice DESC) AS TopProducts 
--		ON od.ProductID = TopProducts.ProductID
--ORDER BY CompanyName, OrderID

--SELECT SubQuery----------------------------------------------

SELECT o.OrderID, o.OrderDate,
    (SELECT MAX(od.UnitPrice)
     FROM [Order Details] od
     WHERE o.OrderID = od.OrderID) AS MaxUnitPrice
FROM Orders o