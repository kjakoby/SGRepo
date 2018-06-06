--USE master
--GO
 
--CREATE LOGIN DvdLibraryApp WITH PASSWORD='testing123'
--GO

-----------------------------------------------------------------

--USE DvdLibrary
--GO
 
--CREATE USER DvdLibraryApp FOR LOGIN DvdLibraryApp
--GO

------------------------------------------------------------------

--/* CREATE A NEW ROLE */
--CREATE ROLE db_executor
 
--/* GRANT EXECUTE TO THE ROLE */
--GRANT EXECUTE TO db_executor
 
--/* ADD THE USER TO THE ROLE */
--ALTER ROLE db_executor ADD MEMBER DvdLibraryApp

-----------------------------------------------------------------

--USE DvdLibrary
--GO
--EXEC sp_addrolemember N'db_datawriter', N'DvdLibraryApp'
--GO
--EXEC sp_addrolemember N'db_datareader', N'DvdLibraryApp'
--GO
