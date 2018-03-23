USE GuildCars

IF EXISTS(SELECT * FROM sys.tables WHERE name='BodyStyle')
	DROP TABLE BodyStyle;
GO
CREATE TABLE BodyStyle (
	BodyID INT NOT NULL primary key identity(1,1),
	BodyStyleName varchar(50) NOT NULL
);


IF EXISTS(SELECT * FROM sys.tables WHERE name='Specials')
	DROP TABLE Specials;
GO
CREATE TABLE Specials (
	SpecialID INT NOT NULL primary key identity(1,1),
	SpecialTitle varchar(50) NOT NULL,
	SpecialDescription varchar(50) NOT NULL
);


IF EXISTS(SELECT * FROM sys.tables WHERE name='Contact')
	DROP TABLE Contact;
GO
CREATE TABLE Contact (
	ContactID INT NOT NULL primary key identity(1,1),
	ContactName varchar(50) NOT NULL,
	ContactEmail varchar(50) NULL,
	ContactPhone INT NULL,
	[Message] varchar(50) NOT NULL
);


IF EXISTS(SELECT * FROM sys.tables WHERE name='Color')
	DROP TABLE Color;
GO
CREATE TABLE Color (
	ColorID INT NOT NULL primary key identity(1,1),
	ColorName varchar(50) NOT NULL
);


IF EXISTS(SELECT * FROM sys.tables WHERE name='Type')
	DROP TABLE [Type];
GO
CREATE TABLE [Type] (
	TypeID INT NOT NULL primary key identity(1,1),
	TypeName varchar(50) NOT NULL
);


IF EXISTS(SELECT * FROM sys.tables WHERE name='User')
	DROP TABLE [User];
GO
CREATE TABLE [User] (
	UserID INT NOT NULL primary key identity(1,1),
	LastName varchar(50) NOT NULL,
	FirstName varchar(50) NOT NULL,
	Email varchar(50) NOT NULL,
	[Role] varchar(50) NOT NULL
);