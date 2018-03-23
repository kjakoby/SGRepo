USE Northwind
GO

--OUTER JOIN Ex.s----------------------------------

--SELECT CustomerID, OrderDate, LastName
--FROM Orders
--	LEFT JOIN Employees ON
--		Orders.EmployeeID = Employees.EmployeeID
--WHERE OrderID BETWEEN 10248 AND 10255


SELECT CustomerID, OrderDate, ISNULL(LastName, 'Online') AS LastName
FROM Orders
	LEFT JOIN Employees ON
		Orders.EmployeeID = Employees.EmployeeID
WHERE OrderID BETWEEN 10248 AND 10255


