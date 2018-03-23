/*
	Get the count of how many employees work for the 
	company
*/

USE Northwind;
GO

SELECT COUNT(EmployeeID) AS Employees
FROM Employees e
