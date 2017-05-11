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