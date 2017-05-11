CREATE PROCEDURE GetAllUsers AS
BEGIN
SELECT Username, Email, PermissionLevel
FROM Users
END

CREATE PROCEDURE GetAllRooms AS
BEGIN
SELECT Building, FloorNr, Nr, MaxPeople, MinPermissionLevel
FROM Rooms
END

CREATE PROCEDURE GetAllReservations AS
BEGIN
SELECT ID, PeopleNr, DateTo, DateFrom, Building, FloorNr, Nr, Username
FROM Reservations
END