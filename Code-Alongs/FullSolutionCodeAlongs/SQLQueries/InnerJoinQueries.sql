USE Northwind
GO

--INNER JOIN EX.s--------------------

--SELECT CategoryID, CategoryName
--FROM Categories
--WHERE CategoryName IN ('Dairy Products', 'Condiments')


--SELECT ProductID, CategoryID, ProductName, UnitsInStock
--FROM Products
--WHERE CategoryID IN (2,4) AND UnitsInStock > 0


--SELECT ProductID, Products.CategoryID, CategoryName, ProductName, UnitsInStock
--FROM Products
--	INNER JOIN Categories
--		ON Products.CategoryID = Categories.CategoryID
--WHERE Products.CategoryID IN (2,4) AND UnitsInStock > 0

---------------------------------------------------------------

--SELECT OrderDate, ProductName, [Order Details].UnitPrice, Quantity
--FROM Orders
--	INNER JOIN [Order Details] ON
--		Orders.OrderID = [Order Details].OrderID
--	INNER JOIN Products ON
--		Products.ProductID = [Order Details].ProductID
--WHERE CustomerID = 'AROUT'


--SELECT OrderDate, ProductName, [Order Details].UnitPrice, Quantity, CategoryName
--FROM Orders
--	INNER JOIN [Order Details] ON
--		Orders.OrderID = [Order Details].OrderID
--	INNER JOIN Products ON
--		Products.ProductID = [Order Details].ProductID
--	INNER JOIN Categories ON
--		Categories.CategoryID = Products.CategoryID
--WHERE CustomerID = 'AROUT'

----------------------------------------------------------------

--SELECT OrderID, CustomerID, EmployeeID, OrderDate
--FROM Orders


SELECT CustomerID, OrderDate, LastName
FROM Orders
	INNER JOIN Employees ON
		Orders.EmployeeID = Employees.EmployeeID
WHERE OrderID BETWEEN 10248 AND 10255