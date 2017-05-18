CREATE TRIGGER  trgInsertReservations ON Reservations
FOR INSERT AS
	declare @command	int;
	declare @table		NVarChar(max);
	declare	@PK			NVarChar(max);

	set @command =  0;
	set @table = 'Reservation';
	select @PK = i.ID from inserted i;

	INSERT INTO Change(Command, TableName, PrimaryKey) VALUES
	(@command, @table, @PK);
	
	PRINT 'Trigger: Insert Reservation'
GO

CREATE TRIGGER trgUpdateReservations ON Reservations
FOR UPDATE AS
	declare @command	int;
	declare @table		NVarChar(max);
	declare	@PK			NVarChar(max);

	set @command =  1;
	set @table = 'Reservations';
	select @PK = i.ID from inserted i;
	
	INSERT INTO Change(Command, TableName, PrimaryKey) VALUES
	(@command, @table, @PK);
	
	PRINT 'Trigger: Update Reservation'
GO

CREATE TRIGGER trgDeleteReservations on Reservations
FOR DELETE AS
	declare @command	int;
	declare @table		NVarChar(max);
	declare	@PK			NVarChar(max);

	set @command =  2;
	set @table = 'Reservations';
	select @PK = i.ID from deleted i;
	
	INSERT INTO Change(Command, TableName, PrimaryKey) VALUES
	(@command, @table, @PK);
	
	PRINT 'Trigger: Delete Reservation'
GO
