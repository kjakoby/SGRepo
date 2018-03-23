USE SWCCorp
GO

--RIGHT JOIN Ex.---------------------------------------

--SELECT City, LastName
--FROM Employee
--	RIGHT JOIN [Location] ON
--		[Location].LocationID = Employee.LocationID

--LEFT JOIN Ex.--------------------------------------------

--SELECT City, LastName
--FROM Employee
--	LEFT JOIN [Location] ON
--		[Location].LocationID = Employee.LocationID

--FULL OUTER JOIN Ex.--------------------------------------

--SELECT City, LastName
--FROM Employee
--	FULL OUTER JOIN [Location] ON
--		[Location].LocationID = Employee.LocationID

--Unmatched Query--------------------------------------------

--SELECT FirstName, LastName
--FROM Employee
--	LEFT JOIN [Grant] ON
--		Employee.EmpID = [Grant].EmpID
--WHERE [Grant].EmpID IS NULL

--SELF JOIN Ex.---------------------------------------------------------------------------------

--SELECT E1.FirstName, E1.LastName, E2.LastName + ',' + e2.FirstName AS ManagerName
--FROM Employee AS E1
--	INNER JOIN Employee AS E2 ON
--		E1.ManagerID = E2.EmpID

--Re-name Tables Ex.------------------------

--SELECT e.LastName, l.City
--FROM Employee e
--	INNER JOIN [Location] l ON
--		e.LocationID = l.LocationID

--CROSS JOIN Ex.-----------------------------

SELECT e.FirstName, e.LastName, m.ClassName
FROM Employee e
	CROSS JOIN MgmtTraining m
WHERE e.EmpID = 1

