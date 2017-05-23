ALTER PROCEDURE SP_GetAllUsers AS
BEGIN
	SELECT Username, Email, PermissionLevel
	FROM Users
END

GO
ALTER PROCEDURE SP_GetAllRooms AS
BEGIN
	SELECT Building, FloorNr, Nr, MaxPeople, MinPermissionLevel
	FROM Rooms
END

GO
ALTER PROCEDURE SP_GetAllReservations AS
BEGIN
	SELECT ID, PeopleNr, DateTo, DateFrom, Building, FloorNr, Nr, Username
	FROM Reservations
END

GO
ALTER PROCEDURE SP_GetAllChanges AS
BEGIN
	SELECT ID, Command, TableName, PrimaryKey, Identifier
	FROM Change
END

GO
CREATE PROCEDURE SP_GetUser (@Username NVarChar(MAX)) AS
BEGIN
	SELECT Username, Email, PermissionLevel
	FROM Users
	WHERE Username = @Username
END

GO
CREATE PROCEDURE SP_GetRoom (
	@Building Char,
	@FloorNr int,
	@Nr int
) AS
BEGIN
	SELECT Building, FloorNr, Nr, MaxPeople, MinPermissionLevel
	FROM Rooms
	WHERE Building = @Building AND FloorNr = @FloorNr AND Nr = @Nr
END

GO
CREATE PROCEDURE SP_GetReservation (@ID int) AS
BEGIN
	SELECT PeopleNr, DateTo, DateFrom, Building, FloorNr, Nr, Username
	FROM Reservations
	WHERE ID = @ID
END

-- Insert 
GO
ALTER PROCEDURE SP_InsertUser (
	@Username NVarChar(100),
	@Email NVarChar(MAX),
	@PermissionLevel Int
) AS
BEGIN
	ALTER TABLE Users DISABLE TRIGGER trgInsertUser
	INSERT INTO Users (Username, Email, PermissionLevel) VALUES
	(@Username, @Email, @PermissionLevel)
	ALTER TABLE Users ENABLE TRIGGER trgInsertUser
END

GO
ALTER PROCEDURE SP_InsertRoom (
	@Building Char,
	@FloorNr NVarChar(max),
	@Nr NVarChar(max),
	@MaxPeople Int,
	@MinPermissionLevel Int
) AS
BEGIN
	ALTER TABLE Rooms DISABLE TRIGGER trgInsertRooms
	INSERT INTO Rooms (Building, FloorNr, Nr, MaxPeople, MinPermissionLevel) VALUES
	(@Building, @FloorNr, @Nr, @MaxPeople, @MinPermissionLevel)
	ALTER TABLE Rooms ENABLE TRIGGER trgInsertRooms
	
END

GO
ALTER PROCEDURE SP_InsertReservation (
	@PeopleNr Int,
	@DateTo DateTime2,
	@DateFrom DateTime2,
	@Building Char,
	@FloorNr Int,
	@Nr Int,
	@Username NVarChar(100)
) AS
BEGIN
	ALTER TABLE Reservations DISABLE TRIGGER trgInsertReservations
	INSERT INTO Reservations (PeopleNr, DateTo, DateFrom, Building, FloorNr, Nr, Username) VALUES
	(@PeopleNr, @DateTo, @DateFrom, @Building, @FloorNr, @Nr, @Username)
	ALTER TABLE Reservations ENABLE TRIGGER trgInsertReservations
END


-- Delete Specific
GO
ALTER PROCEDURE SP_DeleteReservation (
	@Username NVarChar(100),
	@DateFrom DateTime2,
	@DateTo DateTime 
) AS
BEGIN
	ALTER TABLE Reservations DISABLE TRIGGER trgDeleteReservations

	DELETE FROM Reservations WHERE Username = @Username AND DateFrom = @DateFrom AND DateTo = @DateTo;

	ALTER TABLE Reservations ENABLE TRIGGER trgDeleteReservations
END

GO
ALTER PROCEDURE SP_DeleteRoom (
	@Building Char,
	@FloorNr NVarChar(max),
	@Nr NVarChar(max)
) AS
BEGIN
	ALTER TABLE Reservations DISABLE TRIGGER trgDeleteReservations
	ALTER TABLE Rooms DISABLE TRIGGER trgDeleteRooms

	DELETE FROM Rooms WHERE Building = @Building AND FloorNr = @FloorNr AND Nr = @Nr

	ALTER TABLE Rooms ENABLE TRIGGER trgDeleteRooms
	ALTER TABLE Reservations ENABLE TRIGGER trgDeleteReservations
END

GO
ALTER PROCEDURE SP_DeleteUser (@Username NVarChar(100)) AS
BEGIN
	ALTER TABLE Reservations DISABLE TRIGGER trgDeleteReservations
	ALTER TABLE Users DISABLE TRIGGER trgDeleteUser

	DELETE FROM Users WHERE Username = @Username

	ALTER TABLE Users ENABLE TRIGGER trgDeleteUser
	ALTER TABLE Reservations ENABLE TRIGGER trgDeleteReservations
END

GO
ALTER PROCEDURE SP_DeleteChange (@ID int) AS
BEGIN
	DELETE FROM Change WHERE ID = @ID
END

GO
ALTER PROCEDURE SP_DeleteAllUser AS
BEGIN
	ALTER TABLE Reservations DISABLE TRIGGER trgDeleteReservations
	ALTER TABLE Users DISABLE TRIGGER trgDeleteUser

	DELETE FROM Users

	ALTER TABLE Users ENABLE TRIGGER trgDeleteUser
	ALTER TABLE Reservations ENABLE TRIGGER trgDeleteReservations
END

GO
ALTER PROCEDURE SP_DeleteAllRooms AS
BEGIN
	ALTER TABLE Reservations DISABLE TRIGGER trgDeleteReservations
	ALTER TABLE Rooms DISABLE TRIGGER trgDeleteRooms

	DELETE FROM Rooms

	ALTER TABLE Rooms DISABLE TRIGGER trgDeleteRooms
	ALTER TABLE Reservations ENABLE TRIGGER trgDeleteReservations
END

GO
ALTER PROCEDURE SP_DeleteAllReservation AS
BEGIN
	ALTER TABLE Reservations DISABLE TRIGGER trgDeleteReservations
	DELETE FROM Reservations
	ALTER TABLE Reservations ENABLE TRIGGER trgDeleteReservations
END

GO
ALTER PROCEDURE SP_DeleteAllChanges AS
BEGIN
	DELETE FROM Change
END