/*
	Write a query to show every combination of employee and location.
*/

USE SWCCorp;
GO

SELECT e.*, l.*
FROM Employee e CROSS JOIN [Location] l