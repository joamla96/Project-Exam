EXECUTE SP_InsertUser @Username = 'matt2694', @Email = 'matt2694@edu.eal.dk', @PermissionLevel = 0
EXECUTE SP_InsertUser @Username = 'alhe', @Email = 'alhe@eal.dk', @PermissionLevel = 1
EXECUTE SP_InsertUser @Username = 'frje', @Email = 'frje@eal.dk', @PermissionLevel = 2
EXECUTE SP_InsertUser @Username = 'hedv', @Email = 'hedv@edu.eal.dk', @PermissionLevel = 0
EXECUTE SP_InsertUser @Username = 'roxa0198', @Email = 'roxa0198@edu.eal.dk', @PermissionLevel = 0
EXECUTE SP_InsertUser @Username = 'student', @Email = '@edu.eal.dk', @PermissionLevel = 0
EXECUTE SP_InsertUser @Username = 'teacher', @Email = '@eal.dk', @PermissionLevel = 1
EXECUTE SP_InsertUser @Username = 'admin', @Email = '@eal.dk', @PermissionLevel = 2

EXECUTE SP_InsertRoom @Building = 'A', @FloorNr = 1, @Nr = 15, @MaxPeople = 4, @MinPermissionLevel = 2
EXECUTE SP_InsertRoom @Building = 'A', @FloorNr = 2, @Nr = 9, @MaxPeople = 6, @MinPermissionLevel = 0
EXECUTE SP_InsertRoom @Building = 'A', @FloorNr = 2, @Nr = 15, @MaxPeople = 6, @MinPermissionLevel = 1
EXECUTE SP_InsertRoom @Building = 'A', @FloorNr = 2, @Nr = 115, @MaxPeople = 6, @MinPermissionLevel = 2
EXECUTE SP_InsertRoom @Building = 'A', @FloorNr = 7, @Nr = 5, @MaxPeople = 2, @MinPermissionLevel = 0
EXECUTE SP_InsertRoom @Building = 'B', @FloorNr = 7, @Nr = 5, @MaxPeople = 10, @MinPermissionLevel = 0
EXECUTE SP_InsertRoom @Building = 'A', @FloorNr = 4, @Nr = 49, @MaxPeople = 4, @MinPermissionLevel = 0
EXECUTE SP_InsertRoom @Building = 'A', @FloorNr = 1, @Nr = 2, @MaxPeople = 4, @MinPermissionLevel = 0
EXECUTE SP_InsertRoom @Building = 'A', @FloorNr = 1, @Nr = 99, @MaxPeople = 8, @MinPermissionLevel = 0
EXECUTE SP_InsertRoom @Building = 'A', @FloorNr = 1, @Nr = 45, @MaxPeople = 2, @MinPermissionLevel = 0

EXECUTE SP_InsertReservation @PeopleNr = 8, @DateTo = '2017-05-15 18:00:00.00', @DateFrom = '2017-05-15 19:00:00.00', @Building = 'A', @FloorNr = 1, @Nr = 15, @Username = 'matt2694'

EXECUTE SP_DeleteReservation @ID = 12

EXECUTE SP_DeleteUser @Username = 'matt2694'

EXECUTE SP_DeleteRoom @Building = 'A', @FloorNr = 1, @Nr = 15