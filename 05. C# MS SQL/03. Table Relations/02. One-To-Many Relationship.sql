CREATE TABLE Manufacturers(
	ManufacturerID INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(20) NOT NULL,
	EstablishedOn DATETIME2
)

CREATE TABLE Models(
	ModelID INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(20) NOT NULL,
	ManufacturerID INT NOT NULL,

	CONSTRAINT FK_Models_Manufacturers
	FOREIGN KEY (ManufacturerID)
	REFERENCES Manufacturers(ManufacturerID)
)