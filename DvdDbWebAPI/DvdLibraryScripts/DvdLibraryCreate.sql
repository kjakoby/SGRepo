USE master
GO
IF EXISTS(SELECT * FROM sys.databases WHERE name='DvdLibrary')
	DROP DATABASE DvdLibrary;
GO

CREATE DATABASE DvdLibrary;
GO

USE DvdLibrary;

CREATE TABLE Note (
	NoteID INT NOT NULL primary key identity(1,1),
	NoteInfo varchar(50) NOT NULL,
	DvdID INT NOT NULL
);

CREATE TABLE ReleaseYear (
	ReleaseID INT NOT NULL primary key identity(1,1),
	[Year] INT NOT NULL
);

CREATE TABLE Rating (
	RatingID INT NOT NULL primary key identity(1,1),
	RatingValue varchar(5) NOT NULL,
	RatingDescription varchar(50) NOT NULL
);

CREATE TABLE Director (
	DirectorID INT NOT NULL primary key identity(1,1),
	GuestName varchar(50) NULL
);

CREATE TABLE Dvd (
	DvdID INT NOT NULL primary key identity (1,1),
	Title INT NOT NULL,
	ReleaseID INT NOT NULL,
	DirectorID INT NOT NULL,
	RatingID INT NOT NULL
);


ALTER TABLE Note
	ADD CONSTRAINT note_dvd FOREIGN KEY (DvdID) REFERENCES dvd (DvdID);

ALTER TABLE Dvd
	ADD CONSTRAINT dvd_releaseYear FOREIGN KEY (ReleaseID) REFERENCES releaseYear (ReleaseID);
ALTER TABLE Dvd
	ADD CONSTRAINT dvd_director FOREIGN KEY (DirectorID) REFERENCES director (DirectorID);
ALTER TABLE Dvd
	ADD CONSTRAINT dvd_rating FOREIGN KEY (RatingID) REFERENCES rating (RatingID);

