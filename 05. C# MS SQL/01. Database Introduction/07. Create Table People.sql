CREATE TABLE [People] (
	[Id] INT IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(max),
	[Height] DECIMAL(3,2),
	[Weight] DECIMAL(3,2),
	[Gender] CHAR(1) NOT NULL,
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(max)
	CONSTRAINT PK_Person PRIMARY KEY (Id)
)

INSERT INTO [People] (Name,Gender,Birthdate,Biography)
VALUES ('Pesho', 'm', '1998-10-10', 'asdkasdk'),
		('Gosho', 'm', '2000-08-08', 'asdkasdafdfsdk'),
		('Stanka', 'f', '2007-10-12', 'asdksdfsdfasdk'),
		('Ivanjsa', 'f', '1998-10-10', 'asdasddkasdk'),
		('ponka', 'f', '1998-10-10', 'asdkasdk');
