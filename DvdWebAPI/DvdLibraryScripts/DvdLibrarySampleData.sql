USE DvdLibrary
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

	--DELETE FROM AspNetUsers WHERE id IN ('00000000-0000-0000-0000-000000000000', '00000000-1111-1111-0000-000000000000');
	DELETE FROM Dvd;
	--DELETE FROM Note;
	DELETE FROM ReleaseYear;
	DELETE FROM Rating;
	DELETE FROM Director;
	

DBCC CHECKIDENT ('ReleaseYear', RESEED, 1)
DBCC CHECKIDENT ('Rating', RESEED, 1)
DBCC CHECKIDENT ('Director', RESEED, 1)
DBCC CHECKIDENT ('Dvd', RESEED, 1)
--DBCC CHECKIDENT ('Note', RESEED, 1)

--INSERT INTO AspNetUsers (Id, EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)
--	VALUES ('00000000-0000-0000-0000-000000000000', 0, 0, 'test@test.com', 0, 0, 0, 'test'),
--	('00000000-1111-1111-0000-000000000000', 0, 0, 'test2@test.com', 0, 0, 0, 'testtwo')


SET IDENTITY_INSERT ReleaseYear ON;
INSERT INTO ReleaseYear(ReleaseID, [Year])
VALUES (1, 1996),
(2, 2013),
(3, 2004),
(4, 2018),
(5, 1993)
SET IDENTITY_INSERT ReleaseYear OFF;

SET IDENTITY_INSERT Rating ON;
INSERT INTO Rating(RatingID, RatingValue)
VALUES (1, 'G'),
(2, 'PG'),
(3, 'PG-13'),
(4, 'R'),
(5, 'NC-17')
SET IDENTITY_INSERT Rating OFF;

SET IDENTITY_INSERT Director ON;
INSERT INTO Director(DirectorID, DirectorName)
VALUES (1, 'Jeff Burr'),
(2, 'Guillermo Del Toro'),
(3, 'Steven Spielberg')
SET IDENTITY_INSERT Director OFF;

--SET IDENTITY_INSERT Note ON;
--INSERT INTO Note(NoteID, NoteInfo)
--VALUES (1, 'Its time to play the music.'),
--(2, 'Its time to light the lights.'),
--(3, 'Just two good ol boys would not change if they could.'),
--(4, 'Sunny Days sweeping the clouds away.'),
--(5, 'Well we are moving on up to the east side.')
--SET IDENTITY_INSERT Note OFF;

SET IDENTITY_INSERT Dvd ON;
INSERT INTO Dvd(DvdID, Title, ReleaseID, DirectorID, RatingID, Note)
VALUES (1, 'BeetleBorgs', 1, 1, 2, 'Just two good ol boys would not change if they could.'),
(2, 'Pacific Rim', 2, 2, 3, 'Well we are moving on up to the east side.'),
(3, 'HellBoy', 3, 2, 4, 'Its time to light the lights.'),
(4, 'Ready Player One', 4, 3, 3, 'Its time to play the music.'),
(5, 'Jurassic Park', 5, 3, 3, 'Sunny Days sweeping the clouds away.'),
(6, 'Pumpkinhead 2', 5, 1, 4, null)
SET IDENTITY_INSERT Dvd OFF;

END

--EXEC DbReset