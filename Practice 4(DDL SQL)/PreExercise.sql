Create Table Owners(
	OwnerId int Identity,
	Fname nvarchar(100),
	Lname nvarchar(100),
	Address nvarchar(100),
	Phone nvarchar(100),
	Constraint Pk_Owners Primary Key(OwnerId)
)

Create Table Dogs (
	DogId int Identity,
	DogName nvarchar(100),
	Breed nvarchar(100),
	OwnerId int Not Null,
	Constraint PK_Dogs Primary Key(DogId),
	Constraint Fk_Dogs_OwnerId Foreign Key(OwnerId) References Owners(OwnerId)
)
