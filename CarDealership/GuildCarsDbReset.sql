USE GuildCars;
GO

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'DbReset'
)
BEGIN
    DROP PROCEDURE DbReset
END
GO

CREATE PROCEDURE DbReset AS
BEGIN

	DELETE FROM AspNetUsers 
		--WHERE id IN ('00000000-0000-0000-0000-000000000000', '00000000-1111-1111-0000-000000000000');
	DELETE FROM Purchase;
	DELETE FROM Vehicle;
	DELETE FROM PurchaseType;
	DELETE FROM Model;
	DELETE FROM Make;
	DELETE FROM BodyStyle;
	DELETE FROM Color;
	DELETE FROM Contact;
	DELETE FROM Interior;
	DELETE FROM Specials;
	DELETE FROM Transmission;
	DELETE FROM [Type];
	

DBCC CHECKIDENT ('PurchaseType', RESEED, 1)
DBCC CHECKIDENT ('BodyStyle', RESEED, 1)
DBCC CHECKIDENT ('Color', RESEED, 1)
DBCC CHECKIDENT ('Contact', RESEED, 1)
DBCC CHECKIDENT ('Interior', RESEED, 1)
DBCC CHECKIDENT ('Make', RESEED, 1)
DBCC CHECKIDENT ('Model', RESEED, 1)
DBCC CHECKIDENT ('Purchase', RESEED, 1)
DBCC CHECKIDENT ('Specials', RESEED, 1)
DBCC CHECKIDENT ('Transmission', RESEED, 1)
DBCC CHECKIDENT ('Type', RESEED, 1)
DBCC CHECKIDENT ('Vehicle', RESEED, 1)

INSERT INTO AspNetUsers (Id, EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName, FirstName, LastName)
	VALUES ('00000000-0000-0000-0000-000000000000', 0, 0, 'test@test.com', 0, 0, 0, 'test', 'TestFirst', 'TestLast'),
	('00000000-1111-1111-0000-000000000000', 0, 0, 'test2@test.com', 0, 0, 0, 'testtwo', 'Test2First', 'Test2Last')

SET IDENTITY_INSERT BodyStyle ON;
INSERT INTO BodyStyle(BodyID, BodyStyleName)
VALUES (1, 'SUV'),
(2, 'Sedan'),
(3, 'Coupe'),
(4, 'Van'),
(5, 'Truck')
SET IDENTITY_INSERT BodyStyle OFF;

SET IDENTITY_INSERT Color ON;
INSERT INTO Color (ColorID, ColorName)
VALUES (1, 'White'),
(2, 'Black'),
(3, 'Green'),
(4, 'Red'),
(5, 'Blue')
SET IDENTITY_INSERT Color OFF;

SET IDENTITY_INSERT PurchaseType ON;
INSERT INTO PurchaseType (PurchaseTypeID, PurchaseTypeName)
VALUES (1, 'Family and Friend Sale'),
(2, 'Seasonal Sale'),
(3, 'Trade-in Sale'),
(4, 'Manager Sale'),
(5, 'Training Sale')
SET IDENTITY_INSERT PurchaseType OFF;

SET IDENTITY_INSERT Contact ON;
INSERT INTO Contact (ContactID, ContactName, ContactEmail, ContactPhone, [Message])
VALUES (1, 'Jim Bob', 'jb@farmin.com', '9543654478', 'I could use me a good ol truck.'),
(2, 'Ratchet', 'ratchet@clank.com','4659571236', 'I have been in need of a new metal companion....'),
(3, 'Doug Dimmadome', 'ddimma@ddproductions.com','3524568546', 'I am Doug Dimmadome, owner of the Dimmsdale Dimmadome!!'),
(4, 'Auntie Anne', 'auntieknowsbest@yeolde.com', '6589546675', 'I sure could use a van for Pretzels on the go.'),
(5, 'Ghost', 'poof@gone.com', '6547531254', 'It is very important to find a quiet running motor and built-in cloaking.')
SET IDENTITY_INSERT Contact OFF;

SET IDENTITY_INSERT Interior ON;
INSERT INTO Interior (InteriorID, InteriorColor)
VALUES (1, 'Black'),
(2, 'Grey'),
(3, 'Brown')
SET IDENTITY_INSERT Interior OFF;

SET IDENTITY_INSERT Make ON;
INSERT INTO Make (MakeID, MakeName, MakeDateAdded, UserID)
VALUES (1, 'Chevy', '1970-04-15', '00000000-0000-0000-0000-000000000000'),
(2, 'Ford', '1990-11-05','00000000-1111-1111-0000-000000000000'),
(3, 'Pontiac', '1980-11-05', '00000000-0000-0000-0000-000000000000'),
(4, 'Saturn', '2010-11-05','00000000-1111-1111-0000-000000000000'),
(5, 'Dodge','2000-11-05', '00000000-0000-0000-0000-000000000000')
SET IDENTITY_INSERT Make OFF;

SET IDENTITY_INSERT Model ON;
INSERT INTO Model (ModelID, ModelName, MakeID, ModelDateAdded, UserID)
VALUES (1,'Corvette', 1, '2003-04-15', '00000000-0000-0000-0000-000000000000'),
(2, 'Cruze', 1, '1999-11-05', '00000000-1111-1111-0000-000000000000'),
(3, 'F150', 2, '2000-03-28', '00000000-1111-1111-0000-000000000000'),
(4, 'GTO', 3, '2001-03-25', '00000000-0000-0000-0000-000000000000'),
(5, 'Aura', 4, '2013-05-12', '00000000-1111-1111-0000-000000000000')
SET IDENTITY_INSERT Model OFF;

SET IDENTITY_INSERT [Type] ON;
INSERT INTO [Type] (TypeID, TypeName)
VALUES (1, 'New'),
(2, 'Used')
SET IDENTITY_INSERT [Type] OFF;

SET IDENTITY_INSERT Transmission ON;
INSERT INTO Transmission (TransmissionID, TransmissionType)
VALUES (1, 'Automatic'),
(2, 'Manual')
SET IDENTITY_INSERT Transmission OFF;

SET IDENTITY_INSERT Vehicle ON;
INSERT INTO Vehicle (VehicleID, Year, Mileage, MSRP, UserID, SalesPrice, [Description], Picture, Featured, VIN, ModelID, ColorID, TypeID, TransmissionID, InteriorID, BodyID)
VALUES (1, 2017, 0, 55450, '00000000-1111-1111-0000-000000000000', 52980, 'Great car, makes you feel alive!', 'placeholder.png', 1, 'WBAVL1C50EVR93551', 1, 3, 1, 1, 2, 3), --corvette
(2, 2017, 100, 16975, '00000000-0000-0000-0000-000000000000', 11975, 'Great deal on a great car!','placeholder.png', 1, '1B4FK4036JX319656', 2, 1, 1, 1, 3, 2), --cruze
(3, 2007, 100546, 9587, '00000000-1111-1111-0000-000000000000', 7665, 'This car is decent, will get you from point A to B', 'placeholder.png', 0, '1FDAF56F3XEE61679', 5, 2, 2, 1, 2, 2), --aura
(4, 2011, 1566, 8544, '00000000-1111-1111-0000-000000000000', 7032, 'Great for muddin or packing it full of junk!', 'placeholder.png', 0, '2G1AW27K3B1406683', 3, 5, 2, 1, 1, 5), --f150
(5, 2010, 6045, 10000, '00000000-0000-0000-0000-000000000000', 8564, 'Great starter car for a teenager.', 'placeholder.png', 0, 'JYAVG04E9BA015855', 2, 1, 2, 1, 2, 2), --cruze
(6, 1968, 8566, 20665, '00000000-0000-0000-0000-000000000000', 19875, 'Nothing better than a classic.', 'placeholder.png', 1, '5J8TB3H53DL010021', 4, 4, 2, 2, 1, 3), --GTO
(7, 1965, 750, 35698, '00000000-1111-1111-0000-000000000000', 34560, 'Re-live the wonder years!', 'placeholder.png', 1, '3HTSPAAR82N519172', 1, 2, 2, 2, 3, 3), --corvette
(8, 2017, 1546, 64554, '00000000-0000-0000-0000-000000000000', 60223, 'One of the only trucks that look better clean.', 'placeholder.png', 0, 'KMHJF25FXYU864405', 3, 5, 1, 2, 1, 5) --f150
SET IDENTITY_INSERT Vehicle OFF;

SET IDENTITY_INSERT Purchase ON;
INSERT INTO Purchase (PurchaseID, SellName, SellPhone, SellEmail, SellStreet1, SellStreet2, City, [State], ZipCode, PurchasePrice, PurchaseTypeID, UserID, VehicleID)
VALUES (1,'John Cleaver', 8546754435, 'jcleaver@chop.com', '6752 cleaver st.', '963 chop ave.', 'Lexington', 'KY', 40515, 52980, 1, '00000000-0000-0000-0000-000000000000', 1),
(2, 'Paul Mall', 1674468955, 'paullymall@pm.com', '6555 appleseed rd.', null, 'Nashville', 'TN', 65447, 7665, 4, '00000000-0000-0000-0000-000000000000', 3),
(3, 'Jack Florence', 7567985541, 'FlorenceJs@jacks.com', '787 jackson dr.', '44558 horseshoe ave.', 'Atlanta', 'GA', 98544, 34560, 1, '00000000-1111-1111-0000-000000000000', 7),
(4, 'Jean Gray', 4685433255, 'Grey@jean.com', '4777 yorkshire ave.', null, 'New Albany', 'IN', 75477, 52980, 3, '00000000-1111-1111-0000-000000000000', 1),
(5, 'Azra Dabba', 9788887646, 'azra@kadabba.com', '1211 cobalt rd.', null, 'New York City', 'NY', 85422, 19875, 5, '00000000-1111-1111-0000-000000000000', 6)
SET IDENTITY_INSERT Purchase OFF;

SET IDENTITY_INSERT Specials ON;
INSERT INTO Specials (SpecialID, SpecialTitle, SpecialDescription)
VALUES (1,'Two for One Deal', 'Buy one, Get one doesnt just apply to the simple shopping. Come get one car and get a second for free!'),
(2, 'White Cars on a snow day', 'Any day that it snows, there is a markdown of 10% that you can take off of a car on the lot!'),
(3, 'Sale on Saturns', 'To try and reduce our Saturn Inventory, there will be major markdowns on select models.'),
(4, 'Accident Free Bonus', 'After completing a background check, there could be a markdown if you are accident free.')
SET IDENTITY_INSERT Specials OFF;

END

--These are for highlighting and manually running
--exec DbReset
--Select * from Item INNER JOIN ItemCategory ON Item.ItemId = ItemCategory.ItemId INNER JOIN Category ON ItemCategory.CategoryId = Category.CategoryId
--Select * from Article INNER JOIN Author ON Article.AuthorId = Author.AuthorId