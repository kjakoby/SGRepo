/*
	Get the count of how many employees 
	report to someone else in the company 
	without using a WHERE clause.
*/

USE Northwind;
GO

SELECT COUNT(ReportsTo) AS [Report To Someone]
FROM Employees e