USE Northwind
GO

--COUNT with  NO NULLs----------------------

SELECT COUNT(Region)
FROM Customers

--COUNT with NULLs---------------------

SELECT COUNT(*)
FROM Customers
