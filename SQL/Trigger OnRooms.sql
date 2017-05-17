CREATE TRIGGER  trgInsertRooms ON Rooms
FOR INSERT AS
	declare @command	int;
	declare @table		NVarChar(max);
	declare	@PK			NVarChar(max);

	declare @Building	NVarChar(max);
	declare @FloorNr	NVarChar(max);
	declare @Nr			NVarChar(max);

	set @command =  0;
	set @table = 'Rooms';
	select @Building = i.Building from inserted i;
	select @FloorNr = i.FloorNr from inserted i;
	select @Nr = i.Nr from inserted i;
	select @PK = @Building +';' +@FloorNr + ';' + @Nr;

	INSERT INTO Change(Command, TableName, PrimaryKey) VALUES
	(@command, @table, @PK);
	
	PRINT 'Trigger: Insert Room'
GO

CREATE TRIGGER trgUpdateRooms ON Rooms
FOR UPDATE AS
	declare @command	int;
	declare @table		NVarChar(max);
	declare	@PK			NVarChar(max);

	declare @Building	Char;
	declare @FloorNr	int;
	declare @Nr			int;

	set @command =  1;
	set @table = 'Rooms';
	select @Building = i.Building from inserted i;
	select @FloorNr = i.FloorNr from inserted i;
	select @Nr = i.Nr from inserted i;
	select @PK = @Building +';' +@FloorNr + ';' + @Nr;
	
	INSERT INTO Change(Command, TableName, PrimaryKey) VALUES
	(@command, @table, @PK);
	
	PRINT 'Trigger: Update Rooms'
GO

CREATE TRIGGER trgDeleteRooms on Rooms
FOR DELETE AS

	declare @command	int;
	declare @table		NVarChar(max);
	declare	@PK			NVarChar(max);

	declare @Building	Char;
	declare @FloorNr	NVarChar(max);
	declare @Nr			NVarChar(max);

	set @command =  2;
	set @table = 'Rooms';
	select @Building = i.Building from deleted i;
	select @FloorNr = i.FloorNr from deleted i;
	select @Nr = i.Nr from deleted i;
	set @PK = @Building + ';' + @FloorNr + ';' + @Nr;
	
	INSERT INTO Change(Command, TableName, PrimaryKey) VALUES
	(@command, @table, @PK);
	
	PRINT 'Trigger: Delete ' + @table
GO
