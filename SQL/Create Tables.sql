DROP TABLE Reservations;
DROP TABLE Rooms;
DROP TABLE Users;

CREATE TABLE Users(
	Username		NVarChar(100)	NOT NULL,
	Email			NVarChar(MAX)	NOT NULL,
	PermissionLevel	Int				NOT NULL,
	CONSTRAINT	User_PK		PRIMARY KEY (Username)
);

CREATE TABLE Rooms(
	Building			Char	NOT NULL,
	FloorNr				Int		NOT NULL,
	Nr					Int		NOT NULL,
	MaxPeople			Int		NOT NULL,
	MinPermissionLevel	Int		NOT NULL,
	CONSTRAINT	Rooms_PK	PRIMARY KEY (Building, FloorNr, Nr)
);

CREATE TABLE Reservations(
	ID			Int				NOT NULL IDENTITY(1,1),
	PeopleNr	Int				NOT NULL,
	DateTo		DateTime2		NOT NUll,
	DateFrom	DateTime2		NOT NULL,
	Building	Char			NOT NULL,
	FloorNr		Int				NOT NULL,
	Nr			Int				NOT NULL,
	Username	NVarChar(100)	NOT NULL,
	CONSTRAINT	Reservations_Users_FK	FOREIGN KEY (Username)
		REFERENCES	Users(Username)
		ON DELETE CASCADE,
	CONSTRAINT	Reservations_Rooms_FK	FOREIGN KEY (Building, FloorNr, Nr)
		REFERENCES	Rooms(Building, FloorNr, Nr)
		ON DELETE CASCADE
);