CREATE DATABASE [Movies]
CREATE TABLE [Directors] (
	[Id] INT IDENTITY,
	[DirectorName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(max)
	CONSTRAINT PK_Id_Directors PRIMARY KEY (Id)
)
CREATE TABLE [Genres] (
	[Id] INT IDENTITY,
	[GenreName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(max)
	CONSTRAINT PK_Id_Genres PRIMARY KEY (Id)
)
CREATE TABLE Categories (
	[Id] INT IDENTITY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(max)
	CONSTRAINT PK_Id_Categories PRIMARY KEY (Id)
)
CREATE TABLE [Movies] (
	[Id] INT IDENTITY,
	[Title] NVARCHAR(50) NOT NULL,
	[DirectorId] INT NOT NULL,
	[CopyrightYear] DATETIME2,
	[Length] REAL,
	[GenreId] INT NOT NULL,
	[CategoryId] INT NOT NULL,
	[Rating] REAL,
	[Notes] NVARCHAR(max)

	CONSTRAINT PK_Id_Movies PRIMARY KEY (Id),
	CONSTRAINT FK_DirectorId FOREIGN KEY (DirectorId) REFERENCES Directors(Id),
	CONSTRAINT FK_GenreId FOREIGN KEY (GenreId) REFERENCES Genres(Id),
	CONSTRAINT FK_CategoryId FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
)

INSERT INTO Directors (DirectorName, Notes)
VALUES		('Ivo', 'Good one'),
			('Stamat', NULL),
			('Jorko', NULL),
			('Gogi', 'Best Director'),
			('Chompi', NULL)

INSERT INTO Genres (GenreName, Notes)
VALUES		('Action', NULL),
			('Horror', 'Creepy'),
			('Romance', NUll),
			('Comedy', NULL),
			('Fantasy', NULL)


INSERT INTO Categories (CategoryName, Notes)
VALUES		('Animated', NULL),
			('Mystery', 'Creepy'),
			('Gangster', NUll),
			('Sports', NULL),
			('Science Fiction', NULL)

INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
VALUES			   ('Batman', 1, '1999-11-11', 211, 1, 3, 8, 'Full of action'),
                   ('Titanic', 4, '1997-10-10', 268, 3, 3, 9, NULL),
				   ('Fast and Furious 7', 2, '2016-08-08', 212, 1, 4, 10, 'It is a must see!'),
				   ('Ford vs Ferrari', 5, '1995-12-12', 198, 1, 4, 7, NULL),
				   ('Toy Story 4', 3, '2019-01-01', 168, 4, 1, 9, NULL)