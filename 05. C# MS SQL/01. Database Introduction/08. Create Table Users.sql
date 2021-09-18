CREATE TABLE [Users](
	[Id] BIGINT IDENTITY,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) UNIQUE NOT NULL,
	[ProfilePicture] VARBINARY(max),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT NOT NULL,
	CONSTRAINT PK_ID_USERS PRIMARY KEY (Id),
)

INSERT INTO Users (Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
VALUES			  ('Kiro Kirkov', '112234', NULL, '1989-05-20', 0),
				  ('Ivan Ivanov', '1125', NULL, '1969-02-21', 1),
				  ('Pesho Peshov', '1234345567', NULL, '1999-05-16', 1),
				  ('Stamat Stamatov', '1231264567', NULL, '1976-02-09', 0),
				  ('Vanko Vankov', '15534', NULL, '1999-05-05', 0)