USE master
GO

IF EXISTS(
	SELECT *
	FROM sys.databases
	WHERE [Name]='MovieCatalog')
DROP DATABASE MovieCatalog
GO

CREATE DATABASE MovieCatalog
GO

---------------------------------------------

USE MovieCatalog
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Movie')
	DROP TABLE Movie
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Rating')
	DROP TABLE Rating
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Genre')
	DROP TABLE Genre
GO

CREATE TABLE Genre (
	GenreId int identity(1,1) primary key not null,
	GenreType varchar(50) not null
)

CREATE TABLE Rating (
	RatingId int identity(1,1) primary key not null,
	RatingName varchar(50) not null
)

CREATE TABLE Movie (
	MovieId int identity(1,1) primary key not null,
	RatingId int foreign key references Rating(RatingId) null,
	GenreId int foreign key references Genre(GenreId) not null,
	Title varchar(50) not null
)

--------------------------------------------

CREATE PROCEDURE MovieInsert (
	@MovieId int output,
	@GenreId int,
	@RatingId int,
	@Title Varchar(50)
)
AS
	INSERT INTO Movie (GenreId, RatingId, Title)
	VALUES (@GenreId, @RatingId, @Title)

	SET @MovieId = SCOPE_IDENTITY()
GO

-----------------------------------------------------

SET IDENTITY_INSERT Genre ON

INSERT INTO Genre (GenreId, GenreType)
VALUES (1, 'Action'),
		(2, 'Horror'),
		(3, 'Kids'),
		(4, 'Mystery'),
		(5, 'Romance'),
		(6, 'Sci-Fi')
SET IDENTITY_INSERT Genre OFF
