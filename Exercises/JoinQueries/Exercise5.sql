/*
	Find a list of all the Employees who have never found a Grant
*/

USE SWCCorp;
GO

SELECT e.*
FROM Employee e
	LEFT JOIN [Grant] ON
		e.EmpID = [Grant].EmpID
WHERE [Grant].EmpID IS NULL