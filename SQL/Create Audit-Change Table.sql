DROP TABLE Change

CREATE TABLE Change (
	ID			int				NOT NULL	IDENTITY(1,1), -- 0: Insert, 1: Update, 2: Delete
	Command		int				NOT NULL,
	TableName	NVarChar(MAX)	NOT NULL,
	PrimaryKey	NVarChar(MAX)	NOT NULL,
	Identifier	int,
	CONSTRAINT	Change_PK		Primary Key(ID)
);