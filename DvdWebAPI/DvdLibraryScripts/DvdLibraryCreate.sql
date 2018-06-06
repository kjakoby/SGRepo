
--------Create DataBase---------------------------------------------

--USE master
--GO

--IF EXISTS(SELECT * FROM sys.databases WHERE name='DvdLibrary')
--	DROP DATABASE DvdLibrary;
--GO

--CREATE DATABASE DvdLibrary;
--GO

--------Create Tables Below------------------------------------------

USE DvdLibrary
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Dvd')
	DROP TABLE Dvd;
GO

--IF EXISTS(SELECT * FROM sys.tables WHERE name='Note')
--	DROP TABLE Note;
--GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Director')
	DROP TABLE Director;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Rating')
	DROP TABLE Rating;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='ReleaseYear')
	DROP TABLE ReleaseYear;
GO

CREATE TABLE ReleaseYear (
	ReleaseID INT NOT NULL primary key identity(1,1),
	[Year] INT NOT NULL
);

CREATE TABLE Rating (
	RatingID INT NOT NULL primary key identity(1,1),
	RatingValue varchar(5) NOT NULL
);

CREATE TABLE Director (
	DirectorID INT NOT NULL primary key identity(1,1),
	DirectorName varchar(50) NULL
);

--CREATE TABLE Note (
--	NoteID INT NOT NULL primary key identity(1,1),
--	NoteInfo varchar(300) NOT NULL,
--	--DvdID INT NOT NULL foreign key references Dvd(DvdID)
--);

CREATE TABLE Dvd (
	DvdID INT NOT NULL primary key identity (1,1),
	Title varchar(50) NOT NULL,
	ReleaseID INT NOT NULL foreign key references ReleaseYear(ReleaseID),
	DirectorID INT NOT NULL foreign key references Director(DirectorID),
	RatingID INT NOT NULL foreign key references Rating(RatingID),
	Note varchar(300) NULL 
		--foreign key references Note(NoteID)
);


--ALTER TABLE Note
--	ADD CONSTRAINT note_dvd FOREIGN KEY (DvdID) REFERENCES dvd (DvdID);

--ALTER TABLE Dvd
--	ADD CONSTRAINT dvd_releaseYear FOREIGN KEY (ReleaseID) REFERENCES releaseYear (ReleaseID);
--ALTER TABLE Dvd
--	ADD CONSTRAINT dvd_director FOREIGN KEY (DirectorID) REFERENCES director (DirectorID);
--ALTER TABLE Dvd
--	ADD CONSTRAINT dvd_rating FOREIGN KEY (RatingID) REFERENCES rating (RatingID);

