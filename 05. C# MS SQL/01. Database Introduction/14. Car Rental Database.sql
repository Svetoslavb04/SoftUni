CREATE DATABASE CarRental

CREATE TABLE Categories(
	Id INT IDENTITY,
	CategoryName NVARCHAR(20) NOT NULL,
	DailyRate DECIMAL(18,2) NOT NULL,
	WeeklyRate DECIMAL(18,2) NOT NULL,
	MonthlyRate DECIMAL(18,2) NOT NULL,
	WeekendRate DECIMAL(18,2) NOT NULL,

	CONSTRAINT PK_IdCategories PRIMARY KEY (Id)
)

CREATE TABLE Cars(
	Id INT IDENTITY,
	PlateNumber NVARCHAR(10) NOT NULL,
	Manufacturer NVARCHAR(30) NOT NULL,
	Model NVARCHAR(30) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT NOT NULL,
	Doors INT,
	Picture VARBINARY(max),
	Condition NVARCHAR(200),
	Available NVARCHAR(12),

	CONSTRAINT PK_IdCars PRIMARY KEY (Id),
	CONSTRAINT FK_Category FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
)

CREATE TABLE Employees(
	Id INT IDENTITY,
	FirstName NVARCHAR(10) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Title NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(max),

	CONSTRAINT PK_IdEmployees PRIMARY KEY (Id)
)

CREATE TABLE Customers(
	Id INT IDENTITY,
	DriverLicenceNumber NVARCHAR(20) NOT NULL,
	FullName NVARCHAR(40) NOT NULL,
	Address NVARCHAR(80) NOT NULL,
	City NVARCHAR(20) NOT NULL,
	ZIPCode INT NOT NULL,
	Notes NVARCHAR(max),


	CONSTRAINT PK_IdCustomers PRIMARY KEY (Id),
)

CREATE TABLE RentalOrders(
	Id INT IDENTITY,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel INT,
	KilometrageStart DECIMAL(18,2),
	KilometrageEnd DECIMAL(18,2),
	TotalKilometrage AS (KilometrageEnd - KilometrageStart),
	StartDate DATETIME2 NOT NULL,
	EndDate DATETIME2 NOT NULL,
	TotalDays AS DATEDIFF(DAY, StartDate, EndDate),
	RateApplied INT NOT NULL,
	TaxRate INT NOT NULL,
	OrderStatus NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(max),

	CONSTRAINT PK_IdRentalOrders PRIMARY KEY (Id),
	CONSTRAINT FK_EmployeeIdRentalOrders FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
	CONSTRAINT FK_CustomerIdRentalOrders FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
	CONSTRAINT FK_CarIdRentalOrders FOREIGN KEY (CarId) REFERENCES Cars(Id),
)

INSERT INTO Categories
VALUES ('Sport', '100', '600', '1500', '150'),
		('Family', '30', '170', '350', '50'),
		('Daily', '20', '120', '300', '300')

INSERT INTO Cars
VALUES ('CT2010RR', 'Opel', 'Astra', '1999', 3,4,NULL,'Perfect', 'Unavailable'),
		('CT1948BR', 'Mercedes', 'E63 AMG', '2018', 1,4,NULL,'PERFECT ICE WHITE ', 'Available'),
		('CA7777AC', 'Audi', 'RS6', '2020', 2,4,NULL,'Scratched', 'Unavailable')

INSERT INTO Employees
VALUES ('Stamat', 'Bonev', 'Seller', 'Smart boy'),
		('Ivan', 'Ivanov', 'Boss', 'Bad guy'),
		('Peter', 'The Fish', 'A Fish', 'Cute black molly fish')

INSERT INTO Customers
VALUES ('9123993', 'Lewis Linkoln', '24 Petkanob', 'Sofia', 1242, 'Rich gut'),
		('3235214', 'Peter McKinon', '25 Petkanob', 'Sofia', 1242, 'Common gut'),
		('9123993', 'Michael Musk', '27 Petkanob', 'Sofia', 1242, 'Poor gut')

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, StartDate, EndDate, RateApplied, TaxRate, OrderStatus)
VALUES (1, 1, 1, 20, 150, 350, '2021-09-09', '2021-09-27', 10, 20, 'Completed'),
		(2, 2, 2, 50, 261, 401, '2021-08-08', '2021-09-26', 10, 20, 'Completed'),
		(3, 3, 3, 100, 410, 500, '2021-07-07', '2021-09-25', 10, 20, 'Completed')