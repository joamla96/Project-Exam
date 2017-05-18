EXECUTE SP_InsertUser @Username = 'matt2694', @Email = 'matt2694@eal.dk', @PermissionLevel = 2

EXECUTE SP_InsertRoom @Building = 'A', @FloorNr = 1, @Nr = 15, @MaxPeople = 4, @MinPermissionLevel = 2

EXECUTE SP_InsertReservation @PeopleNr = 8, @DateTo = '2017-05-15 18:00:00.00', @DateFrom = '2017-05-15 19:00:00.00', @Building = 'A', @FloorNr = 1, @Nr = 15, @Username = 'matt2694'

EXECUTE SP_DeleteReservation @ID = 12

EXECUTE SP_DeleteUser @Username = 'matt2694'

EXECUTE SP_DeleteRoom @Building = 'A', @FloorNr = 1, @Nr = 15