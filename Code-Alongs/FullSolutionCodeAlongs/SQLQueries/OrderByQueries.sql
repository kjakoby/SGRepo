USE Northwind
GO

--ORDER BY single column Ex.--------------------------------------

--SELECT CategoryName, ProductName, UnitPrice, UnitsInStock
--FROM Categories
--	INNER JOIN Products ON
--		Products.CategoryID = Categories.CategoryID
--ORDER BY CategoryName

--ORDER BY multi columns Ex.--------------------------------------

--SELECT CategoryName, ProductName, UnitPrice, UnitsInStock
--FROM Categories
--	INNER JOIN Products ON
--		Categories.CategoryID = Products.CategoryID
--ORDER BY CategoryName, ProductName

--Descending order Ex.--------------------------------------------

--SELECT CategoryName, ProductName, UnitPrice, UnitsInStock
--FROM Categories
--	INNER JOIN Products ON
--		Categories.CategoryID = Products.CategoryID
--ORDER BY CategoryName, UnitPrice DESC

--FETCH and OFSET Ex.s--------------------------------------------

SELECT CategoryName, ProductName, UnitPrice, UnitsInStock
FROM Categories
	INNER JOIN Products ON
		Categories.CategoryID = Products.CategoryID
WHERE CategoryName = 'Confections'
ORDER BY UnitPrice DESC
	OFFSET 0 ROWS 
	FETCH NEXT 5 ROWS ONLY

SELECT CategoryName, ProductName, UnitPrice, UnitsInStock
FROM Categories
	INNER JOIN Products ON
		Categories.CategoryID = Products.CategoryID
WHERE CategoryName = 'Confections'
ORDER BY UnitPrice DESC
	OFFSET 5 ROWS 
	FETCH NEXT 5 ROWS ONLY