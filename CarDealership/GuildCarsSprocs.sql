USE GuildCars
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'BodyStyleSelectAll')
		DROP PROCEDURE BodyStyleSelectAll
GO

CREATE PROCEDURE BodyStyleSelectAll AS
BEGIN
	SELECT BodyID, BodyStyleName 
	FROM BodyStyle
END
GO

--EXEC BodyStyleSelectAll

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ColorSelectAll')
		DROP PROCEDURE ColorSelectAll
GO

CREATE PROCEDURE ColorSelectAll AS
BEGIN
	SELECT ColorID, ColorName 
	FROM Color
END
GO

--EXEC ColorSelectAll

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ContactSelectAll')
		DROP PROCEDURE ContactSelectAll
GO

CREATE PROCEDURE ContactSelectAll AS
BEGIN
	SELECT ContactID, ContactName, ContactPhone, ContactEmail, [Message]
	FROM Contact
END
GO

--EXEC ContactSelectAll

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'InteriorSelectAll')
		DROP PROCEDURE InteriorSelectAll
GO

CREATE PROCEDURE InteriorSelectAll AS
BEGIN
	SELECT InteriorID, InteriorColor 
	FROM Interior
END
GO

--EXEC InteriorSelectAll

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakeSelectAll')
		DROP PROCEDURE MakeSelectAll
GO

CREATE PROCEDURE MakeSelectAll AS
BEGIN
	SELECT MakeID, MakeName, MakeDateAdded, UserID 
	FROM Make
END
GO

--EXEC MakeSelectAll

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelSelectAll')
		DROP PROCEDURE ModelSelectAll
GO

CREATE PROCEDURE ModelSelectAll AS
BEGIN
	SELECT ModelID, MakeID, ModelName, ModelDateAdded, UserID  
	FROM Model
END
GO

--EXEC ModelSelectAll

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchaseSelectAll')
		DROP PROCEDURE PurchaseSelectAll
GO

CREATE PROCEDURE PurchaseSelectAll AS
BEGIN
	SELECT PurchaseID, SellName, SellPhone, SellEmail, SellStreet1, SellStreet2, City, [State], ZipCode, PurchasePrice, PurchaseTypeID, UserID, VehicleID
	FROM Purchase
END
GO

--EXEC PurchaseSelectAll

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchaseTypeSelectAll')
		DROP PROCEDURE PurchaseTypeSelectAll
GO

CREATE PROCEDURE PurchaseTypeSelectAll AS
BEGIN
	SELECT PurchaseTypeID, PurchaseTypeName
	FROM PurchaseType
END
GO

--EXEC PurchaseTypeSelectAll

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialsSelectAll')
		DROP PROCEDURE SpecialsSelectAll
GO

CREATE PROCEDURE SpecialsSelectAll AS
BEGIN
	SELECT SpecialID, SpecialTitle, SpecialDescription 
	FROM Specials
END
GO

--EXEC SpecialsSelectAll

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'TransmissionSelectAll')
		DROP PROCEDURE TransmissionSelectAll
GO

CREATE PROCEDURE TransmissionSelectAll AS
BEGIN
	SELECT TransmissionID, TransmissionType 
	FROM Transmission
END
GO

--EXEC TransmissionSelectAll

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'TypeSelectAll')
		DROP PROCEDURE TypeSelectAll
GO

CREATE PROCEDURE TypeSelectAll AS
BEGIN
	SELECT TypeID, TypeName 
	FROM [Type]
END
GO

--EXEC TypeSelectAll

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleSelectAll')
		DROP PROCEDURE VehicleSelectAll
GO

CREATE PROCEDURE VehicleSelectAll AS
BEGIN
	SELECT VehicleID, [Year], Mileage, MSRP, SalesPrice, [Description], Picture, Featured, VIN, UserID, ModelID, ColorID, TypeID, TransmissionID, InteriorID, BodyID
	FROM Vehicle
END
GO

--EXEC VehicleSelectAll

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'AllFeaturedVehiclesShort')
		DROP PROCEDURE AllFeaturedVehiclesShort
GO

CREATE PROCEDURE AllFeaturedVehiclesShort AS
BEGIN
	SELECT VehicleID, [Year], SalesPrice, Picture, Featured, Model.ModelName, Make.MakeName
	FROM Vehicle
		INNER JOIN Model ON
			Vehicle.ModelID = Model.ModelID
		INNER JOIN Make ON
			Model.MakeID= Make.MakeID
	WHERE Featured = 1
	ORDER BY [Year] DESC
END
GO

--EXEC AllFeaturedVehiclesShort

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakeList')
		DROP PROCEDURE MakeList
GO

CREATE PROCEDURE MakeList AS
BEGIN
	SELECT MakeID, Make.MakeName, Make.UserID, MakeDateAdded, AspNetUsers.Email
	FROM Make
		INNER JOIN AspNetUsers ON
			Make.UserID = AspNetUsers.Id
		
	ORDER BY MakeName
END
GO

--EXEC MakeList

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelList')
		DROP PROCEDURE ModelList
GO

CREATE PROCEDURE ModelList AS
BEGIN
	SELECT Model.MakeID, Make.MakeName, Model.ModelID, Model.ModelName, Model.UserID, ModelDateAdded, AspNetUsers.Email
	FROM Model
		INNER JOIN AspNetUsers ON
			Model.UserID = AspNetUsers.Id
		INNER JOIN Make ON
			Make.MakeID = Model.MakeID
		
	ORDER BY MakeName, ModelName
END
GO

--EXEC ModelList

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'NewVehicleSearch')
--		DROP PROCEDURE NewVehicleSearch
--GO

--CREATE PROCEDURE NewVehicleSearch AS
--BEGIN
--	SELECT VehicleID, [Year], MakeName, ModelName, BodyStyleName, TransmissionType, ColorName, InteriorColor, Mileage, MSRP, SalesPrice, Picture, VIN
--	FROM Vehicle
--		INNER JOIN Model ON 
--			Vehicle.ModelID = Model.ModelID
--		INNER JOIN Make ON
--			Model.MakeID = Make.MakeID
--		INNER JOIN BodyStyle ON
--			Vehicle.BodyID = BodyStyle.BodyID
--		INNER JOIN Transmission ON
--			Vehicle.TransmissionID = Transmission.TransmissionID
--		INNER JOIN Color ON
--			Color.ColorID = Vehicle.ColorID
--		INNER JOIN Interior ON
--			Vehicle.InteriorID = Interior.InteriorID
--		INNER JOIN [Type] ON 
--			Vehicle.TypeID = [Type].TypeID
--	WHERE TypeName = 'New'
--END
--GO

----EXEC NewVehicleSearch

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'UsedVehicleSearch')
--		DROP PROCEDURE UsedVehicleSearch
--GO

--CREATE PROCEDURE UsedVehicleSearch AS
--BEGIN
--	SELECT VehicleID, [Year], MakeName, ModelName, BodyStyleName, TransmissionType, ColorName, InteriorColor, Mileage, MSRP, SalesPrice, Picture, VIN
--	FROM Vehicle
--		INNER JOIN Model ON 
--			Vehicle.ModelID = Model.ModelID
--		INNER JOIN Make ON
--			Model.MakeID = Make.MakeID
--		INNER JOIN BodyStyle ON
--			Vehicle.BodyID = BodyStyle.BodyID
--		INNER JOIN Transmission ON
--			Vehicle.TransmissionID = Transmission.TransmissionID
--		INNER JOIN Color ON
--			Color.ColorID = Vehicle.ColorID
--		INNER JOIN Interior ON
--			Vehicle.InteriorID = Interior.InteriorID
--		INNER JOIN [Type] ON 
--			Vehicle.TypeID = [Type].TypeID
--	WHERE TypeName = 'Used'
--END
--GO

----EXEC UsedVehicleSearch

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SingleVehicle')
		DROP PROCEDURE SingleVehicle
GO

CREATE PROCEDURE SingleVehicle(
	@VehicleID INT
		) AS
BEGIN
	SELECT VehicleID, [Year], Mileage, MSRP, SalesPrice, [Description], Picture, Featured, VIN, UserID, ModelID, ColorID, TypeID, TransmissionID, InteriorID, BodyID
	FROM Vehicle
	WHERE VehicleID = @VehicleID
END
GO

--EXEC SingleVehicle

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleDetails')
		DROP PROCEDURE VehicleDetails
GO

CREATE PROCEDURE VehicleDetails(
	@VehicleID INT
		) AS
BEGIN
	SELECT VehicleID, [Year], MakeName, ModelName, BodyStyleName, TransmissionType, ColorName, InteriorColor, Mileage, MSRP, SalesPrice, Picture, VIN, [Description], Model.MakeID, Vehicle.ModelID, Vehicle.BodyID, Vehicle.InteriorID, Vehicle.TransmissionID, Vehicle.ColorID
	FROM Vehicle
		INNER JOIN Model ON 
			Vehicle.ModelID = Model.ModelID
		INNER JOIN Make ON
			Model.MakeID = Make.MakeID
		INNER JOIN BodyStyle ON
			Vehicle.BodyID = BodyStyle.BodyID
		INNER JOIN Transmission ON
			Vehicle.TransmissionID = Transmission.TransmissionID
		INNER JOIN Color ON
			Color.ColorID = Vehicle.ColorID
		INNER JOIN Interior ON
			Vehicle.InteriorID = Interior.InteriorID
		INNER JOIN [Type] ON 
			Vehicle.TypeID = [Type].TypeID
	WHERE VehicleID = @VehicleID
END
GO

--EXEC VehicleDetails

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SingleSpecial')
		DROP PROCEDURE SingleSpecial
GO

CREATE PROCEDURE SingleSpecial(
	@SpecialID INT
		) AS
BEGIN
	SELECT SpecialID, SpecialTitle, SpecialDescription
	FROM Specials
	WHERE SpecialID = @SpecialID
END
GO

--EXEC SingleSpecial

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchaseInsert')
		DROP PROCEDURE PurchaseInsert
GO

CREATE PROCEDURE PurchaseInsert( 
	@PurchaseID INT OUTPUT,
	@SellName varchar(50),
	@SellPhone varchar(50)= NULL,
	@SellEmail varchar(50)= NULL,
	@SellStreet1 varchar(50)= NULL,
	@SellStreet2 varchar(50)= NULL,
	@City varchar(50),
	@State varchar(2),
	@ZipCode INT,
	@PurchasePrice INT,
	@PurchaseTypeID INT,
	@VehicleID INT,
	@UserID nvarchar(128)
) AS
BEGIN
	INSERT INTO Purchase(SellName, SellPhone, SellEmail, SellStreet1, SellStreet2, City, [State], ZipCode, PurchasePrice, PurchaseTypeID, UserID, VehicleID)
	VALUES (@SellName, @SellPhone, @SellEmail, @SellStreet1, @SellStreet2, @City, @State, @ZipCode, @PurchasePrice, @PurchaseTypeID, @UserID, @VehicleID)
	SET @PurchaseID = SCOPE_IDENTITY();
END
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleInsert')
		DROP PROCEDURE VehicleInsert
GO

CREATE PROCEDURE VehicleInsert( 
	@VehicleID INT OUTPUT,
	--@MakeID INT,
	@ModelID INT,
	@TypeID INT,
	@BodyID INT,
	@Year INT,
	@TransmissionID INT,
	@ColorID INT,
	@InteriorID INT,
	@Mileage INT,
	@VIN varchar(50),
	@MSRP INT,
	@SalesPrice INT,
	@Description varchar(300) = NULL,
	@Picture varchar(50),
	@UserID nvarchar(128), 
	@Featured BIT
) AS
BEGIN
	INSERT INTO Vehicle([Year], ModelID, TypeID, TransmissionID, ColorID, InteriorID, Mileage, VIN, MSRP, SalesPrice, UserID, [Description], BodyID, Picture, Featured)
	VALUES (@Year, @ModelID, @TypeID, @TransmissionID, @ColorID, @InteriorID, @Mileage, @VIN, @MSRP, @SalesPrice, @UserID, @Description, @BodyID, @Picture, @Featured)
	SET @VehicleID = SCOPE_IDENTITY();
END
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleUpdate')
		DROP PROCEDURE VehicleUpdate
GO

CREATE PROCEDURE VehicleUpdate( 
	@VehicleID INT,
	--@MakeID INT,
	@ModelID INT,
	@TypeID INT,
	@BodyID INT,
	@Year INT,
	@TransmissionID INT,
	@ColorID INT,
	@InteriorID INT,
	@Mileage INT,
	@VIN varchar(50),
	@MSRP INT,
	@SalesPrice INT,
	@Description varchar(300),
	@Picture varchar(50),
	@UserID nvarchar(128),
	@Featured BIT
) AS
BEGIN
	UPDATE Vehicle SET
	[Year] = @Year, 
	ModelID = @ModelID, 
	TypeID = @TypeID,
	BodyID = @BodyID, 
	TransmissionID = @TransmissionID, 
	ColorID = @ColorID, 
	InteriorID = @InteriorID, 
	Mileage = @Mileage, 
	VIN = @VIN, 
	MSRP = @MSRP, 
	SalesPrice = @SalesPrice, 
	UserID = @UserID, 
	[Description] = @Description,
	Picture = @Picture,
	Featured = @Featured
	WHERE VehicleID = @VehicleID
END
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleDelete')
		DROP PROCEDURE VehicleDelete
GO

CREATE PROCEDURE VehicleDelete(
	@VehicleID INT
		) AS
BEGIN
	BEGIN TRANSACTION
	DELETE FROM Purchase WHERE VehicleID = @VehicleID
	DELETE FROM Vehicle WHERE VehicleID = @VehicleID
	COMMIT TRANSACTION
END
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ContactInsert')
		DROP PROCEDURE ContactInsert
GO

CREATE PROCEDURE ContactInsert( 
	@ContactID INT OUTPUT,
	@ContactName varchar(50),
	@ContactEmail varchar(50)= NULL,
	@ContactPhone varchar(15)= NULL,
	@Message varchar(300)
) AS
BEGIN
	INSERT INTO Contact (ContactName, ContactEmail, ContactPhone, [Message])
	VALUES (@ContactName, @ContactEmail, @ContactPhone, @Message)
	SET @ContactID = SCOPE_IDENTITY();		
END
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UserList')
		DROP PROCEDURE UserList
GO

CREATE PROCEDURE UserList AS
BEGIN
	SELECT ANU.Id AS UserID, FirstName, LastName, Email, ANR.Name AS Role
	FROM AspNetUsers ANU
		LEFT JOIN AspNetUserRoles ANUR ON ANU.Id = ANUR.UserId
		LEFT JOIN AspNetRoles ANR ON ANUR.RoleId = ANR.Id
END
GO

--EXEC UserList

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'UserInsert')
--		DROP PROCEDURE UserInsert
--GO

--CREATE PROCEDURE UserInsert( 
--	@ContactID INT OUTPUT,
--	@ContactName varchar(50),
--	@ContactEmail varchar(50),
--	@ContactPhone varchar(25),
--	@Message varchar(300)
--) AS
--BEGIN
--	INSERT INTO Contact (ContactName, ContactEmail, ContactPhone, [Message])
--	VALUES (@ContactName, @ContactEmail, @ContactPhone, @Message)
--	SET @ContactID = SCOPE_IDENTITY();		
--END
--GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'UserUpdate')
--		DROP PROCEDURE UserUpdate
--GO

--CREATE PROCEDURE UserUpdate( 
--	@VehicleID INT OUTPUT,
--	@MakeID varchar(50),
--	@ModelID varchar(50),
--	@UserID nvarchar(128)
--) AS
--BEGIN
--	UPDATE Vehicle SET
--	ModelID = @ModelID,  
--	UserID = @UserID
--	WHERE VehicleID = @VehicleID
--END
--GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakeInsert')
		DROP PROCEDURE MakeInsert
GO

CREATE PROCEDURE MakeInsert( 
	@MakeID INT OUTPUT,
	@MakeName varchar(50),
	@MakeDateAdded date,
	@UserID nvarchar(128)
) AS
BEGIN
	INSERT INTO Make(MakeName, MakeDateAdded, UserID)
	VALUES (@MakeName, @MakeDateAdded, @UserID)
	SET @MakeID = SCOPE_IDENTITY();		
END
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelInsert')
		DROP PROCEDURE ModelInsert
GO

CREATE PROCEDURE ModelInsert( 
	@ModelID INT OUTPUT,
	@MakeID INT,
	@ModelName varchar(50),
	@ModelDateAdded date,
	@UserID nvarchar(128)
) AS
BEGIN
	INSERT INTO Model(MakeID, ModelName, ModelDateAdded, UserID)
	VALUES (@MakeID, @ModelName, @ModelDateAdded, @UserID)
	SET @ModelID = SCOPE_IDENTITY();		
END
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialInsert')
		DROP PROCEDURE SpecialInsert
GO

CREATE PROCEDURE SpecialInsert( 
	@SpecialID INT OUTPUT,
	@SpecialTitle varchar(50),
	@SpecialDescription varchar(300)
) AS
BEGIN
	INSERT INTO Specials(SpecialTitle, SpecialDescription)
	VALUES (@SpecialTitle, @SpecialDescription)
	SET @SpecialID = SCOPE_IDENTITY();		
END
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialDelete')
		DROP PROCEDURE SpecialDelete
GO

CREATE PROCEDURE SpecialDelete(
	@SpecialID INT
		) AS
BEGIN
	BEGIN TRANSACTION
	DELETE FROM Specials WHERE SpecialID = @SpecialID
	COMMIT TRANSACTION
END
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'NewInventory')
		DROP PROCEDURE NewInventory
GO

CREATE PROCEDURE NewInventory AS
BEGIN
	SELECT [Year], Model.MakeID, Make.MakeName, Model.ModelID, Model.ModelName, COUNT(Model.ModelID) AS [Count], SUM(Vehicle.SalesPrice) AS StockValue
	FROM Vehicle
		INNER JOIN Model ON
			Model.ModelID = Vehicle.ModelID
		INNER JOIN Make ON
			Make.MakeID = Model.MakeID
	WHERE Vehicle.TypeID = 1
	GROUP BY [Year], Model.MakeID, Make.MakeName, Model.ModelID, Model.ModelName, Vehicle.ModelID
	ORDER BY [Year] DESC, MakeName, ModelName
END
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UsedInventory')
		DROP PROCEDURE UsedInventory
GO

CREATE PROCEDURE UsedInventory AS
BEGIN
	SELECT [Year], Model.MakeID, Make.MakeName, Model.ModelID, Model.ModelName, COUNT(Model.ModelID) AS [Count], SUM(Vehicle.SalesPrice) AS StockValue
	FROM Vehicle
		INNER JOIN Model ON
			Model.ModelID = Vehicle.ModelID
		INNER JOIN Make ON
			Make.MakeID = Model.MakeID
	WHERE Vehicle.TypeID = 2
	GROUP BY [Year], Model.MakeID, Make.MakeName, Model.ModelID, Model.ModelName, Vehicle.ModelID
	ORDER BY [Year] DESC, MakeName, ModelName
END
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'NewVehicleSearch')
--		DROP PROCEDURE NewVehicleSearch
--GO

--CREATE PROCEDURE NewVehicleSearch(
	

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'UsedVehicleSearch')
--		DROP PROCEDURE UsedVehicleSearch
--GO

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'NewAndUsedVehicleSearch')
--		DROP PROCEDURE NewAndUsedVehicleSearch
--GO

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'SalesReportSearch')
--		DROP PROCEDURE SalesReportSearch
--GO






