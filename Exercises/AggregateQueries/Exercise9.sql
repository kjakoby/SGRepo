/*
	Challenge: 
	Show the total amount of orders by
	year and country.  Data should be ordered 
	by year ascending and total descending.
	
	TotalSales    Year     Country
	41907.80      1996     USA
	37804.60      1996     Germany
	etc...
	
	Hint: Research the DatePart() function
*/

USE Northwind;
GO

SELECT SUM(od.Quantity * od.UnitPrice) AS [Total Sales], DATEPART(year,o.OrderDate) AS [Year], c.Country AS Country
FROM Orders o 
	INNER JOIN [Order Details] od ON
		od.OrderID = o.OrderID
	INNER JOIN Customers c ON
		c.CustomerID = o.CustomerID
GROUP BY DATEPART(year,o.OrderDate), c.Country
ORDER BY DATEPART(year,o.OrderDate), [Total Sales] DESC

