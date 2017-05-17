CREATE PROCEDURE SP_GetAllUsers AS
BEGIN
SELECT Username, Email, PermissionLevel
FROM Users
END

CREATE PROCEDURE SP_GetAllRooms AS
BEGIN
SELECT Building, FloorNr, Nr, MaxPeople, MinPermissionLevel
FROM Rooms
END

CREATE PROCEDURE SP_GetAllReservations AS
BEGIN
SELECT ID, PeopleNr, DateTo, DateFrom, Building, FloorNr, Nr, Username
FROM Reservations
END

CREATE PROCEDURE SP_InsertUser (@Username NVarChar(100),
								@Email NVarChar(MAX),
								@PermissionLevel Int) AS
BEGIN
INSERT INTO Users (Username, Email, PermissionLevel) VALUES
				  (@Username, @Email, @PermissionLevel)
UPDATE Change set Identifier = 1 WHERE PrimaryKey = @Username
END

CREATE PROCEDURE SP_InsertRoom (@Building Char,
								@FloorNr NVarChar(max),
								@Nr NVarChar(max),
								@MaxPeople Int,
								@MinPermissionLevel Int) AS
BEGIN
INSERT INTO Rooms (Building, FloorNr, Nr, MaxPeople, MinPermissionLevel) VALUES
				  (@Building, @FloorNr, @Nr, @MaxPeople, @MinPermissionLevel)
UPDATE Change set Identifier = 1 WHERE PrimaryKey = @Building +';' + @FloorNr + ';' + @Nr
END

CREATE PROCEDURE SP_InsertReservation (@PeopleNr Int,
								       @DateTo DateTime2,
								       @DateFrom DateTime2,
									   @Building Char,
									   @FloorNr Int,
									   @Nr Int,
									   @Username NVarChar(100)) AS
BEGIN
INSERT INTO Reservations (PeopleNr, DateTo, DateFrom, Building, FloorNr, Nr, Username) VALUES
--(@PeopleNr, @DateTo, @DateFrom, (SELECT Building FROM Rooms WHERE Building = @Building AND FloorNr = @FloorNr AND Nr = @Nr), (SELECT FloorNr FROM Rooms WHERE Building = @Building AND FloorNr = @FloorNr AND Nr = @Nr), (SELECT Nr FROM Rooms WHERE Building = @Building AND FloorNr = @FloorNr AND Nr = @Nr), (SELECT Username FROM Users WHERE Username = @Username))
(@PeopleNr, @DateTo, @DateFrom, @Building, @FloorNr, @Nr, @Username)
UPDATE Change set Identifier = 1 WHERE PrimaryKey = CAST(SCOPE_IDENTITY() AS NVarChar(100))
END

CREATE PROCEDURE SP_DeleteReservation (@ID Int) AS
BEGIN
DELETE FROM Reservations
WHERE ID = @ID
UPDATE Change set Identifier = 1 WHERE PrimaryKey = CAST (@ID AS NVarChar(100))
END

CREATE PROCEDURE SP_DeleteRoom (@Building Char,
								@FloorNr NVarChar(max),
								@Nr NVarChar(max)) AS
BEGIN
DELETE FROM Rooms
WHERE Building = @Building AND FloorNr = @FloorNr AND Nr = @Nr
UPDATE Change set Identifier = 1 WHERE PrimaryKey = @Building + ';' + @FloorNr + ';' + @Nr
END

CREATE PROCEDURE SP_DeleteUser (@Username NVarChar(100)) AS
BEGIN
--UPDATE Change set PrimaryKey = @Username
DELETE FROM Users
WHERE Username = @Username
UPDATE Change set Identifier = 1 WHERE PrimaryKey = @Username
END

