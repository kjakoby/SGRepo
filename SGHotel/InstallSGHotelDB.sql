USE master
GO
IF EXISTS(SELECT * FROM sys.databases WHERE name='SGHotelDB')
	DROP DATABASE SGHotelDB;
GO

CREATE DATABASE SGHotelDB;
GO

USE SGHotelDB;

CREATE TABLE Customer (
	CustomerID INT NOT NULL primary key identity(1,1),
	CustomerName varchar(50) NOT NULL,
	Phone varchar(15) NOT NULL,
	Email varchar(50)
);

CREATE TABLE AddOn (
	AddOnID INT NOT NULL primary key identity(1,1),
	AddOnName varchar(50) NOT NULL,
	Price INT NOT NULL
);

CREATE TABLE Promotion (
	PromoID INT NOT NULL primary key identity(1,1),
	PromoName varchar(50) NOT NULL,
	PromoDescription varchar(50) NOT NULL,
	PercentOff INT NULL,
	DollarOff INT NULL,
	PromoStart date NOT NULL,
	PromoEnd date NOT NULL
);

CREATE TABLE Guests (
	ReservationID INT NULL,
	GuestName varchar(50) NULL,
	GuestAge INT NULL
);

CREATE TABLE Room (
	RoomNumber INT NOT NULL primary key identity (1,1),
	[Floor] INT NOT NULL,
	Occupancy INT NOT NULL,
	RoomType varchar(20) NOT NULL,
	RoomRate INT NOT NULL
);

CREATE TABLE CustomerReservations (
	CustomerID INT NOT NULL,
	ReservationID INT NOT NULL
);

CREATE TABLE Reservation (
	ReservationID INT NOT NULL primary key identity (1,1),
	PromoID INT NULL,
	ReservationStart date NOT NULL,
	ReservationEnd date NOT NULL,
	ReductionID INT NULL
);

CREATE TABLE Ammenity (
	AmmenityID INT NOT NULL primary key identity (1,1),
	AmmenityType varchar(20) NOT NULL,
	AmmenityDescription varchar(50) NOT NULL
);

CREATE TABLE ReservationAddOns (
	ReservationID INT NOT NULL,
	AddOnID INT NOT NULL
);

CREATE TABLE RoomAmmenities (
	RoomNumber INT NOT NULL,
	AmmenityID INT NOT NULL
);

CREATE TABLE ReservationRooms (
	ReservationID INT NOT NULL,
	RoomNumber INT NOT NULL
);

CREATE TABLE RateReduction (
	ReductionID INT NOT NULL primary key identity (1,1),
	ReductionDescription varchar(50) NOT NULL,
	ReductionStart date NOT NULL,
	ReductionEnd date NOT NULL,
	RateDrop INT NOT NULL
);

ALTER TABLE ReservationRooms
	ADD CONSTRAINT reservationRooms_reservation FOREIGN KEY (ReservationID) REFERENCES reservation (ReservationID);
ALTER TABLE ReservationRooms
	ADD CONSTRAINT reservationRooms_room FOREIGN KEY (RoomNumber) REFERENCES room (RoomNumber);

ALTER TABLE RoomAmmenities
	ADD CONSTRAINT roomAmmenities_room FOREIGN KEY (RoomNumber) REFERENCES room (RoomNumber);
ALTER TABLE RoomAmmenities
	ADD CONSTRAINT roomAmmenities_ammenity FOREIGN KEY (AmmenityID) REFERENCES ammenity (AmmenityID);

ALTER TABLE ReservationAddOns
	ADD CONSTRAINT reservationAddOns_reservation FOREIGN KEY (ReservationID) REFERENCES reservation (ReservationID);
ALTER TABLE ReservationAddOns
	ADD CONSTRAINT reservationAddOns_addOn FOREIGN KEY (AddOnID) REFERENCES addOn (AddOnID);

ALTER TABLE Reservation
	ADD CONSTRAINT reservation_promotion FOREIGN KEY (PromoID) REFERENCES promotion (PromoID);
ALTER TABLE Reservation
	ADD CONSTRAINT reservation_rateReduction FOREIGN KEY (ReductionID) REFERENCES rateReduction (ReductionID);

ALTER TABLE CustomerReservations
	ADD CONSTRAINT customerReservations_customer FOREIGN KEY (CustomerID) REFERENCES customer (CustomerID);
ALTER TABLE CustomerReservations
	ADD CONSTRAINT customerReservations_reservation FOREIGN KEY (ReservationID) REFERENCES reservation (ReservationID);

ALTER TABLE Guests
	ADD CONSTRAINT guests_reservation FOREIGN KEY (ReservationID) REFERENCES reservation (ReservationID);
