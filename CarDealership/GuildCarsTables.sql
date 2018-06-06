USE GuildCars

IF EXISTS(SELECT * FROM sys.tables WHERE name='Purchase')
	DROP TABLE Purchase;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Vehicle')
	DROP TABLE Vehicle;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Model')
	DROP TABLE Model;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='BodyStyle')
	DROP TABLE BodyStyle;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Specials')
	DROP TABLE Specials;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Contact')
	DROP TABLE Contact;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Color')
	DROP TABLE Color;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Type')
	DROP TABLE [Type];
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Make')
	DROP TABLE [Make];
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Transmission')
	DROP TABLE Transmission;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Interior')
	DROP TABLE Interior;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='PurchaseType')
	DROP TABLE PurchaseType;
GO
--Should not be needed----------------------------------------

--IF EXISTS(SELECT * FROM sys.tables WHERE name='User')
--	DROP TABLE [User];
--GO

--CREATE TABLE [User] (
--	UserID INT NOT NULL primary key identity(1,1),
--	LastName varchar(50) NOT NULL,
--	FirstName varchar(50) NOT NULL,
--	Email varchar(50) NOT NULL,
--	[Role] varchar(50) NOT NULL
--);

-----------------------------------------------------------------

CREATE TABLE BodyStyle (
	BodyID INT NOT NULL primary key identity(1,1),
	BodyStyleName varchar(50) NOT NULL
);

CREATE TABLE [Type] (
	TypeID INT NOT NULL primary key identity(1,1),
	TypeName varchar(50) NOT NULL
);

CREATE TABLE Color (
	ColorID INT NOT NULL primary key identity(1,1),
	ColorName varchar(50) NOT NULL
);

CREATE TABLE Contact (
	ContactID INT NOT NULL primary key identity(1,1),
	ContactName varchar(50) NOT NULL,
	ContactEmail varchar(50) NULL,
	ContactPhone varchar(15) NULL,
	[Message] varchar(300) NOT NULL
);

CREATE TABLE Specials (
	SpecialID INT NOT NULL primary key identity(1,1),
	SpecialTitle varchar(50) NOT NULL,
	SpecialDescription varchar(300) NOT NULL
);

CREATE TABLE [Make] (
	MakeID INT NOT NULL primary key identity(1,1),
	MakeName varchar(50) NOT NULL,
	MakeDateAdded datetime2 NOT NULL,
	UserID nvarchar(128) NOT NULL
);

CREATE TABLE Transmission (
	TransmissionID INT NOT NULL primary key identity(1,1),
	TransmissionType varchar(50)
);

CREATE TABLE Interior (
	InteriorID INT NOT NULL primary key identity(1,1),
	InteriorColor varchar(50)
);

CREATE TABLE PurchaseType (
	PurchaseTypeID INT NOT NULL primary key identity(1,1),
	PurchaseTypeName varchar(50)
);

CREATE TABLE Model (
	ModelID INT NOT NULL primary key identity(1,1),
	MakeID INT NOT NULL foreign key references Make(MakeID),
	ModelName varchar(50) NOT NULL,
	ModelDateAdded datetime2 NOT NULL,
	UserID nvarchar(128) NOT NULL
);

CREATE TABLE Vehicle (
	VehicleID INT NOT NULL primary key identity(1,1),
	[Year] INT NOT NULL,
	Mileage INT NOT NULL,
	MSRP INT NOT NULL,
	SalesPrice INT NOT NULL,
	[Description] varchar(300) NULL,
	Picture varchar(50) NOT NULL,
	Featured bit NOT NULL,
	VIN varchar(50) NOT NULL,
	UserID nvarchar(128) NOT NULL,
	BodyID INT NOT NULL foreign key references BodyStyle(BodyID), 
	ModelID INT NOT NULL foreign key references Model(ModelID),
	ColorID INT NOT NULL foreign key references Color(ColorID),
	TypeID INT NOT NULL foreign key references [Type](TypeID),
	TransmissionID INT NOT NULL foreign key references Transmission(TransmissionID),
	InteriorID INT NOT NULL foreign key references Interior(InteriorID)
);

CREATE TABLE Purchase (
	PurchaseID INT NOT NULL primary key identity(1,1),
	SellName varchar(50) NOT NULL,
	SellPhone varchar(50) NULL,
	SellEmail varchar(50) NULL,
	SellStreet1 varchar(50) NULL,
	SellStreet2 varchar(50) NULL,
	City varchar(50) NOT NULL,
	[State] varchar(2) NOT NULL,
	ZipCode INT NOT NULL,
	PurchasePrice INT NOT NULL,
	PurchaseTypeID INT NOT NULL,
	UserID nvarchar(128) NOT NULL,
	VehicleID INT NOT NULL foreign key references Vehicle(VehicleID)
);