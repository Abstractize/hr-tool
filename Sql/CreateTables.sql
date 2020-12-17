CREATE TABLE [Image] (
    [IdImage] INT NOT NULL IDENTITY(1,1),
    [Data] VARBINARY(MAX),
    PRIMARY KEY ([IdImage])
)

CREATE TABLE [Employee] (
  [IdEmployee] INT NOT NULL IDENTITY(1,1),
  [EmployeeId] VARCHAR(255) NOT NULL,
  [IsActive] BIT NOT NULL DEFAULT 1,
  PRIMARY KEY ([IdEmployee]),
  FOREIGN KEY ([IdUser]) REFERENCES [dbo].[User](IdUser)
);

CREATE TABLE [EmployeeData] (
    [IdEmployeeData] INT NOT NULL IDENTITY(1,1),
    [IdEmployee] INT NOT NULL,
    [RegisterDate] DATETIME NOT NULL DEFAULT GETDATE(),
    [Name] VARCHAR(255) NOT NULL,
    [IdImage] INT NOT NULL,
    [PhoneNumber] VARCHAR(255) NOT NULL,
    [Email] VARCHAR(255) NOT NULL,
    [HireDate] DATETIME NOT NULL,
    [IdManager] INT,
    PRIMARY KEY ([IdEmployeeData]),
    FOREIGN KEY ([IdImage]) REFERENCES [dbo].[Image](IdImage),
    FOREIGN KEY ([IdEmployee]) REFERENCES [dbo].[Employee](IdEmployee),
    FOREIGN KEY ([IdManager]) REFERENCES [dbo].[Employee](IdEmployee),
)