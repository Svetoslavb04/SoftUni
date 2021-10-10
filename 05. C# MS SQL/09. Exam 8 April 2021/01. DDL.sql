CREATE TABLE [Users]
(
	[Id] INT IDENTITY PRIMARY KEY
	, [Username] VARCHAR(30) UNIQUE NOT NULL
	, [Password] VARCHAR(50) NOT NULL
	, [Name] VARCHAR(50)
	, [Birthdate] DATETIME2
	, [Age] INT CHECK (Age BETWEEN 14 AND 110)
	, [Email] VARCHAR(50) NOT NULL
)

CREATE TABLE [Departments]
(
	[Id] INT IDENTITY PRIMARY KEY
	, [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Employees]
(
	[Id] INT IDENTITY PRIMARY KEY
	, [FirstName] VARCHAR(25)
	, [LastName] VARCHAR(25)
	, [Birthdate] DATETIME2
	, [Age] INT CHECK (Age BETWEEN 18 AND 110)
	, [DepartmentId] INT

	, CONSTRAINT FK_Employees_DepartmentId FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
)

CREATE TABLE [Categories]
(
	[Id] INT IDENTITY PRIMARY KEY
	, [Name] VARCHAR(50) NOT NULL
	, [DepartmentId] INT NOT NULL

	, CONSTRAINT FK_Categories_DepartmentId FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
)

CREATE TABLE [Status]
(
	[Id] INT IDENTITY PRIMARY KEY
	, [Label] VARCHAR(30) NOT NULL
)

CREATE TABLE [Reports]
(
	[Id] INT IDENTITY PRIMARY KEY
	, [CategoryId] INT NOT NULL
	, [StatusId] INT NOT NULL
	, [Opendate] DATETIME2 NOT NULL
	, [Closedate] DATETIME2
	, [Description] VARCHAR(200) NOT NULL
	, [UserId] INT NOT NULL
	, [EmployeeId] INT
	
	, CONSTRAINT FK_Reports_CategoryId FOREIGN KEY (CategoryId) REFERENCES [Categories](Id)
	, CONSTRAINT FK_Reports_StatusId FOREIGN KEY (StatusId) REFERENCES [Status](Id)
	, CONSTRAINT FK_Reports_UserId FOREIGN KEY (UserId) REFERENCES [Users](Id)
	, CONSTRAINT FK_Reports_EmployeeId FOREIGN KEY (EmployeeId) REFERENCES [Employees](Id)
)