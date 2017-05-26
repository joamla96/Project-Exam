CREATE TRIGGER  trgInsertReservations ON Reservations
FOR INSERT AS
	declare @command	int;
	declare @table		NVarChar(max);
	declare	@PK			NVarChar(max);

	declare @ID			NVarChar(max);
	declare @DateTo		NVarChar(max);
	declare @DateFrom	NVarChar(max);
	declare @Username	NVarChar(max);

	set @command =  0;
	set @table = 'Reservations';
	select @ID = i.ID from inserted i;
	select @DateTo = i.DateTo from inserted i;
	select @DateFrom = i.DateFrom from inserted i;
	select @Username = i.Username from inserted i;
	select @PK = @ID + ';' + @DateTo + ';' + @DateFrom + ';' + @Username;

	INSERT INTO Change(Command, TableName, PrimaryKey) VALUES
	(@command, @table, @PK);
	
	PRINT 'Trigger: Insert Reservation'
GO

CREATE TRIGGER trgUpdateReservations ON Reservations
FOR UPDATE AS
	declare @command	int;
	declare @table		NVarChar(max);
	declare	@PK			NVarChar(max);

	declare @ID			NVarChar(max);
	declare @DateTo		NVarChar(max);
	declare @DateFrom	NVarChar(max);
	declare @Username	NVarChar(max);

	set @command =  1;
	set @table = 'Reservations';
	select @ID = i.ID from inserted i;
	select @DateTo = i.DateTo from inserted i;
	select @DateFrom = i.DateFrom from inserted i;
	select @Username = i.Username from inserted i;
	select @PK = @ID + ';' + @DateTo + ';' + @DateFrom + ';' + @Username;
	
	INSERT INTO Change(Command, TableName, PrimaryKey) VALUES
	(@command, @table, @PK);
	
	PRINT 'Trigger: Update Reservation'
GO

CREATE TRIGGER trgDeleteReservations on Reservations
FOR DELETE AS
	declare @command	int;
	declare @table		NVarChar(max);
	declare	@PK			NVarChar(max);

	declare @ID			NVarChar(max);
	declare @DateTo		NVarChar(max);
	declare @DateFrom	NVarChar(max);
	declare @Username	NVarChar(max);

	set @command =  2;
	set @table = 'Reservations';
	select @ID = i.ID from deleted i;
	select @DateTo = i.DateTo from deleted i;
	select @DateFrom = i.DateFrom from deleted i;
	select @Username = i.Username from deleted i;
	select @PK = @ID + ';' + @DateTo + ';' + @DateFrom + ';' + @Username;
	
	INSERT INTO Change(Command, TableName, PrimaryKey) VALUES
	(@command, @table, @PK);
	
	PRINT 'Trigger: Delete Reservation'
GO
