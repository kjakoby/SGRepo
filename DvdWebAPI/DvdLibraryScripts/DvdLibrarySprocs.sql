USE DvdLibrary
GO

------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DirectorSelectAll')
		DROP PROCEDURE DirectorSelectAll
GO

CREATE PROCEDURE DirectorSelectAll AS
BEGIN
	SELECT DirectorID, DirectorName 
	FROM Director
END
GO

--EXEC DirectorSelectAll

------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdSelectAll')
		DROP PROCEDURE DvdSelectAll
GO

CREATE PROCEDURE DvdSelectAll AS
BEGIN
	SELECT DvdID, Title, ReleaseID, DirectorID, RatingID, Note
	FROM Dvd
END
GO

--EXEC DvdSelectAll

------------------------------------------------------------------------------------------------------------------------------------------------------

--IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'NoteSelectAll')
--		DROP PROCEDURE NoteSelectAll
--GO

--CREATE PROCEDURE NoteSelectAll AS
--BEGIN
--	SELECT NoteID, NoteInfo
--	FROM Note
--END
--GO

--EXEC NoteSelectAll

------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'RatingSelectAll')
		DROP PROCEDURE RatingSelectAll
GO

CREATE PROCEDURE RatingSelectAll AS
BEGIN
	SELECT RatingID, RatingValue
	FROM Rating
END
GO

--EXEC RatingSelectAll

------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ReleaseYearSelectAll')
		DROP PROCEDURE ReleaseYearSelectAll
GO

CREATE PROCEDURE ReleaseYearSelectAll AS
BEGIN
	SELECT ReleaseID, [Year]
	FROM ReleaseYear
END
GO

--EXEC ReleaseYearSelectAll

------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SingleDvd')
		DROP PROCEDURE SingleDvd
GO

CREATE PROCEDURE SingleDvd(
	@DvdID INT
	) AS
BEGIN
	SELECT DvdID, Title, ReleaseID, DirectorID, RatingID, Note
	FROM Dvd
	WHERE DvdID = @DvdID
END
GO

------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdDetailsByID')
		DROP PROCEDURE DvdDetailsByID
GO

CREATE PROCEDURE DvdDetailsByID(
	@DvdID INT
	) AS
BEGIN
	SELECT DvdID, Title, [Year], RatingValue,  DirectorName, Note, Dvd.ReleaseID, Dvd.DirectorID, Dvd.RatingID
	FROM Dvd
		LEFT JOIN ReleaseYear ON
			ReleaseYear.ReleaseID = Dvd.ReleaseID
		LEFT JOIN Director ON
			Director.DirectorID = Dvd.DirectorID
		LEFT JOIN Rating ON
			Rating.RatingID = Dvd.RatingID
		--LEFT JOIN Note ON
		--	Note.NoteID = Dvd.NoteID
	WHERE Dvd.DvdID = @DvdID
END
GO

------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdDetailsByTitle')
		DROP PROCEDURE DvdDetailsByTitle
GO

CREATE PROCEDURE DvdDetailsByTitle(
	@Title varchar(50)
	) AS
BEGIN
	SELECT DvdID, Title, [Year], RatingValue,  DirectorName, Note, Dvd.ReleaseID, Dvd.DirectorID, Dvd.RatingID
	FROM Dvd
		LEFT JOIN ReleaseYear ON
			ReleaseYear.ReleaseID = Dvd.ReleaseID
		LEFT JOIN Director ON
			Director.DirectorID = Dvd.DirectorID
		LEFT JOIN Rating ON
			Rating.RatingID = Dvd.RatingID
		--LEFT JOIN Note ON
		--	Note.NoteID = Dvd.NoteID
	WHERE Dvd.Title LIKE '%' + @Title + '%'
END
GO

------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdDetailsByDirector')
		DROP PROCEDURE DvdDetailsByDirector
GO

CREATE PROCEDURE DvdDetailsByDirector(
	@DirectorName varchar(50)
	) AS
BEGIN
	SELECT DvdID, Title, [Year], RatingValue,  DirectorName, Note, Dvd.ReleaseID, Dvd.DirectorID, Dvd.RatingID
	FROM Dvd
		LEFT JOIN ReleaseYear ON
			ReleaseYear.ReleaseID = Dvd.ReleaseID
		LEFT JOIN Director ON
			Director.DirectorID = Dvd.DirectorID
		LEFT JOIN Rating ON
			Rating.RatingID = Dvd.RatingID
		--LEFT JOIN Note ON
		--	Note.NoteID = Dvd.NoteID
	WHERE Director.DirectorName LIKE '%' + @DirectorName + '%'
END
GO

------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdDetailsByRating')
		DROP PROCEDURE DvdDetailsByRating
GO

CREATE PROCEDURE DvdDetailsByRating(
	@RatingValue varchar(5)
	) AS
BEGIN
	SELECT DvdID, Title, [Year], RatingValue,  DirectorName, Note, Dvd.ReleaseID, Dvd.DirectorID, Dvd.RatingID
	FROM Dvd
		LEFT JOIN ReleaseYear ON
			ReleaseYear.ReleaseID = Dvd.ReleaseID
		LEFT JOIN Director ON
			Director.DirectorID = Dvd.DirectorID
		LEFT JOIN Rating ON
			Rating.RatingID = Dvd.RatingID
		--LEFT JOIN Note ON
		--	Note.NoteID = Dvd.NoteID
	WHERE Rating.RatingValue LIKE '%' + @RatingValue + '%'
END
GO

------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdDetailsByNote')
		DROP PROCEDURE DvdDetailsByNote
GO

CREATE PROCEDURE DvdDetailsByNote(
	@Note varchar(300)
	) AS
BEGIN
	SELECT DvdID, Title, [Year], RatingValue,  DirectorName, Note, Dvd.ReleaseID, Dvd.DirectorID, Dvd.RatingID
	FROM Dvd
		LEFT JOIN ReleaseYear ON
			ReleaseYear.ReleaseID = Dvd.ReleaseID
		LEFT JOIN Director ON
			Director.DirectorID = Dvd.DirectorID
		LEFT JOIN Rating ON
			Rating.RatingID = Dvd.RatingID
		--LEFT JOIN Note ON
		--	Note.NoteID = Dvd.NoteID
	WHERE dvd.Note LIKE '%' + @Note + '%'
END
GO

------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdDetailsByReleaseYear')
		DROP PROCEDURE DvdDetailsByReleaseYear
GO

CREATE PROCEDURE DvdDetailsByReleaseYear(
	@ReleaseYear varchar(4)
	) AS
BEGIN
	SELECT DvdID, Title, [Year], RatingValue,  DirectorName, Note, Dvd.ReleaseID, Dvd.DirectorID, Dvd.RatingID
	FROM Dvd
		LEFT JOIN ReleaseYear ON
			ReleaseYear.ReleaseID = Dvd.ReleaseID
		LEFT JOIN Director ON
			Director.DirectorID = Dvd.DirectorID
		LEFT JOIN Rating ON
			Rating.RatingID = Dvd.RatingID
		--LEFT JOIN Note ON
		--	Note.NoteID = Dvd.NoteID
	WHERE CAST(ReleaseYear.Year as varchar(4)) Like ('%' + @ReleaseYear + '%')
	--ReleaseYear.Year::TEXT LIKE '%' + @ReleaseYear + '%'
END
GO

------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'AllDvdsDetails')
		DROP PROCEDURE AllDvdsDetails
GO

CREATE PROCEDURE AllDvdsDetails AS
BEGIN
	SELECT DvdID, Title, [Year], RatingValue,  DirectorName, Note, Dvd.ReleaseID, Dvd.DirectorID, Dvd.RatingID
	FROM Dvd
		LEFT JOIN ReleaseYear ON
			ReleaseYear.ReleaseID = Dvd.ReleaseID
		LEFT JOIN Director ON
			Director.DirectorID = Dvd.DirectorID
		LEFT JOIN Rating ON
			Rating.RatingID = Dvd.RatingID
		--LEFT JOIN Note ON
		--	Note.NoteID = Dvd.NoteID
END
GO

------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdDelete')
		DROP PROCEDURE DvdDelete
GO

CREATE PROCEDURE DvdDelete(
	@DvdID INT
		) AS
BEGIN
	BEGIN TRANSACTION
	DELETE FROM Dvd WHERE DvdID = @DvdID
	COMMIT TRANSACTION
END
GO

------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdInsert')
		DROP PROCEDURE DvdInsert
GO

CREATE PROCEDURE DvdInsert( 
	@DvdID INT OUTPUT,
	@Title varchar(50),
	@Year INT,
	@DirectorName varchar(50)=NULL,
	@RatingValue varchar(5),
	@NoteInfo varchar(300)
) AS
BEGIN
	IF (select COUNT(ReleaseYear.ReleaseID) 
			from ReleaseYear where ReleaseYear.[Year] = @Year) = 0
	BEGIN
		INSERT INTO ReleaseYear([Year])
		VALUES (@Year)
	END
	IF (select COUNT(Rating.RatingID) 
			from Rating where Rating.RatingValue = @RatingValue) = 0
	BEGIN
		INSERT INTO Rating(RatingValue)
		VALUES (@RatingValue)
	END
	IF (select COUNT(Director.DirectorID) 
			from Director where Director.DirectorName = @DirectorName) = 0
	BEGIN
		INSERT INTO Director(DirectorName)
		VALUES (@DirectorName)
	END
	INSERT INTO Dvd(ReleaseID, DirectorID, RatingID, Title, Note)
	VALUES ((SELECT MIN(ReleaseID) FROM ReleaseYear WHERE [Year] = @Year),
			(SELECT MIN(DirectorID) FROM Director WHERE DirectorName = @DirectorName),
			(SELECT MIN(RatingID) FROM Rating WHERE RatingValue = @RatingValue),
			@Title, @NoteInfo)
	SET @DvdID = SCOPE_IDENTITY();
END
GO

------------------------------------------------------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdUpdate')
		DROP PROCEDURE DvdUpdate
GO

CREATE PROCEDURE DvdUpdate( 
	@DvdID INT,
	@Title varchar(50),
	@Year INT,
	@DirectorName varchar(50)=NULL,
	@RatingValue varchar(5),
	@NoteInfo varchar(300)
) AS
BEGIN
	IF (select COUNT(ReleaseYear.ReleaseID) 
			from ReleaseYear where ReleaseYear.[Year] = @Year) = 0
	BEGIN
		INSERT INTO ReleaseYear([Year])
		VALUES (@Year)
	END
	IF (select COUNT(Rating.RatingID) 
			from Rating where Rating.RatingValue = @RatingValue) = 0
	BEGIN
		INSERT INTO Rating(RatingValue)
		VALUES (@RatingValue)
	END
	IF (select COUNT(Director.DirectorID) 
			from Director where Director.DirectorName = @DirectorName) = 0
	BEGIN
		INSERT INTO Director(DirectorName)
		VALUES (@DirectorName)
	END
	UPDATE Dvd
	SET ReleaseID = (SELECT MIN(ReleaseID) FROM ReleaseYear WHERE [Year] = @Year),
		DirectorID = (SELECT MIN(DirectorID) FROM Director WHERE DirectorName = @DirectorName),
		RatingID = (SELECT MIN(RatingID) FROM Rating WHERE RatingValue = @RatingValue),
		Title = @Title, 
		Note= @NoteInfo
	WHERE DvdID = @DvdID
END
GO

