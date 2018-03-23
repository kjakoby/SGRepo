/*
	Get the count of how many unique countries
	are represented by our suppliers.
*/

USE Northwind;
GO

SELECT COUNT( DISTINCT (Country)) AS Countries
FROM Suppliers