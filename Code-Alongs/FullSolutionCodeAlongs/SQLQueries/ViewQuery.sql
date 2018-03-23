USE Northwind
GO

CREATE VIEW ProductsAndCategories AS
SELECT p.ProductID, p.ProductName, c.CategoryName, s.CompanyName
FROM Products p 
	INNER JOIN Categories c ON p.CategoryID = c.CategoryID
	INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID
 
GO

SELECT *
FROM ProductsAndCategories