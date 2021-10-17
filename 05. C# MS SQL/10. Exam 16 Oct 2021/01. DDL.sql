CREATE TABLE Sizes
(
	Id INT IDENTITY PRIMARY KEY,
	[Length] INT CHECK ([Length] BETWEEN 10 AND 25) NOT NULL,
	RingRange DECIMAL NOT NULL,

	CONSTRAINT CK_RingRange CHECK(RingRange >= 1.5)
)

CREATE TABLE Tastes
(
	Id INT IDENTITY PRIMARY KEY,
	TasteType VARCHAR(20) NOT NULL,
	TasteStrength VARCHAR(15) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands
(
	Id INT IDENTITY PRIMARY KEY,
	BrandName VARCHAR(30) UNIQUE NOT NULL,
	BrandDescription VARCHAR(max),
)

CREATE TABLE Cigars
(
	Id INT IDENTITY PRIMARY KEY,
	CigarName VARCHAR(80) UNIQUE NOT NULL,
	BrandId INT NOT NULL,
	TastId INT NOT NULL,
	SizeId INT NOT NULL,
	PriceForSingleCigar DECIMAL NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL


	CONSTRAINT FK_Cigars_BrandId FOREIGN KEY (BrandId) REFERENCES Brands(Id),
	CONSTRAINT FK_Cigars_TastId FOREIGN KEY (TastId) REFERENCES Tastes(Id),
	CONSTRAINT FK_Cigars_SizeId FOREIGN KEY (SizeId) REFERENCES Sizes(Id)
)

CREATE TABLE Addresses
(
	Id INT IDENTITY PRIMARY KEY,
	Town VARCHAR(30) NOT NULL,
	Country NVARCHAR(30) NOT NULL,
	Streat NVARCHAR(100) NOT NULL,
	ZIP VARCHAR(20) NOT NULL
)

CREATE TABLE Clients
(
	Id INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL,	
	AddressId INT NOT NULL,

	CONSTRAINT FK_Clients_AddressId FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
)

CREATE TABLE ClientsCigars
(
	ClientId INT NOT NULL,
	CigarId INT NOT NULL,

	CONSTRAINT PK_ClientsCigars_ClientIdCigarID PRIMARY KEY (ClientId, CigarId),
	CONSTRAINT FK_ClientsCigars_ClientId FOREIGN KEY (ClientId) REFERENCES Clients(Id),
	CONSTRAINT FK_ClientsCigars_CigarId FOREIGN KEY (CigarId) REFERENCES Cigars(Id)
)
