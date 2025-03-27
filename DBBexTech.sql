-- Crear la base de datos
CREATE DATABASE LocationDB;
GO

USE LocationDB;
GO

-- Tabla de Países
CREATE TABLE Country (
    CountryID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Code NVARCHAR(10) UNIQUE NOT NULL
);
GO

-- Tabla de Departamentos
CREATE TABLE State (
    StateID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    CountryID INT NOT NULL,
    CONSTRAINT FK_State_Country FOREIGN KEY (CountryID) REFERENCES Country(CountryID) ON DELETE CASCADE
);
GO

-- Tabla de Ciudades
CREATE TABLE City (
    CityID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    StateID INT NOT NULL,
    CONSTRAINT FK_City_State FOREIGN KEY (StateID) REFERENCES State(StateID) ON DELETE CASCADE
);
GO

--Procedimientos Almacenados para País
-- Insertar un nuevo país
CREATE PROCEDURE InsertCountry
    @Name NVARCHAR(100),
    @Code NVARCHAR(10)
AS
BEGIN
    INSERT INTO Country (Name, Code) VALUES (@Name, @Code);

	SELECT * FROM Country WHERE Name = @Name AND Code= @Code;
END;
GO

-- Obtener todos los países
CREATE PROCEDURE GetCountries
AS
BEGIN
    SELECT * FROM Country;
END;
GO

-- Actualizar un país
CREATE PROCEDURE UpdateCountry
    @CountryID INT,
    @Name NVARCHAR(100),
    @Code NVARCHAR(10)
AS
BEGIN
    UPDATE Country SET Name = @Name, Code = @Code WHERE CountryID = @CountryID;

	SELECT * FROM Country WHERE Name = @Name AND Code= @Code;
END;
GO

-- Eliminar un país
CREATE PROCEDURE DeleteCountry
    @CountryID INT
AS
BEGIN
    DELETE FROM Country WHERE CountryID = @CountryID;
END;
GO

--Procedimientos Almacenados para Departamento
-- Insertar un nuevo departamento
CREATE PROCEDURE InsertState
    @Name NVARCHAR(100),
    @CountryID INT
AS
BEGIN
    INSERT INTO State (Name, CountryID) VALUES (@Name, @CountryID);

	SELECT s.*, c.Name AS CountryName FROM State s
    INNER JOIN Country c ON s.CountryID = c.CountryID
	WHERE S.Name = @Name AND C.CountryID = @CountryID;
END;
GO

-- Obtener todos los departamentos
CREATE PROCEDURE GetStates
AS
BEGIN
    SELECT s.*, c.Name AS CountryName FROM State s
    INNER JOIN Country c ON s.CountryID = c.CountryID;
END;
GO

-- Actualizar un departamento
CREATE PROCEDURE UpdateState
    @StateID INT,
    @Name NVARCHAR(100),
    @CountryID INT
AS
BEGIN
    UPDATE State SET Name = @Name, CountryID = @CountryID WHERE StateID = @StateID;

	SELECT s.*, c.Name AS CountryName FROM State s
    INNER JOIN Country c ON s.CountryID = c.CountryID
	WHERE S.StateID = @StateID AND S.Name = @Name AND C.CountryID = @CountryID;
END;
GO

-- Eliminar un departamento
CREATE PROCEDURE DeleteState
    @StateID INT
AS
BEGIN
    DELETE FROM State WHERE StateID = @StateID;
END;
GO

--Procedimientos Almacenados para Ciudad
-- Insertar una nueva ciudad
CREATE PROCEDURE InsertCity
    @Name NVARCHAR(100),
    @StateID INT
AS
BEGIN
    INSERT INTO City (Name, StateID) VALUES (@Name, @StateID);

	SELECT c.*, s.Name AS StateName FROM City c
    INNER JOIN State s ON c.StateID = s.StateID
	WHERE c.Name = @Name  AND C.StateID = @StateID;
END;
GO

-- Obtener todas las ciudades
CREATE PROCEDURE GetCities
AS
BEGIN
    SELECT c.*, s.Name AS StateName FROM City c
    INNER JOIN State s ON c.StateID = s.StateID;
END;
GO

-- Actualizar una ciudad
CREATE PROCEDURE UpdateCity
    @CityID INT,
    @Name NVARCHAR(100),
    @StateID INT
AS
BEGIN
    UPDATE City SET Name = @Name, StateID = @StateID WHERE CityID = @CityID;

	SELECT c.*, s.Name AS StateName FROM City c
    INNER JOIN State s ON c.StateID = s.StateID
	WHERE c.CityID = @CityID AND c.Name = @Name  AND C.StateID = @StateID;
END;
GO

-- Eliminar una ciudad
CREATE PROCEDURE DeleteCity
    @CityID INT
AS
BEGIN
    DELETE FROM City WHERE CityID = @CityID;
END;
GO

--Vista para mostrar todas las ciudades con su respectivo departamento y país.
CREATE VIEW View_Cities AS
SELECT 
    c.CityID, c.Name AS CityName, 
    s.Name AS StateName, 
    co.Name AS CountryName
FROM City c
INNER JOIN State s ON c.StateID = s.StateID
INNER JOIN Country co ON s.CountryID = co.CountryID;
GO

--Inserciones...
--Country
INSERT INTO [dbo].[Country] VALUES('Colombia', 'CO')
INSERT INTO [dbo].[Country] VALUES('Argentina', 'AR')

--State
INSERT INTO [dbo].[State] VALUES ('Cundinamarca', 1)
INSERT INTO [dbo].[State] VALUES ('Tolima', 1)

--City
INSERT INTO [dbo].[City] VALUES ('Bogotá D.C.', 1)
INSERT INTO [dbo].[City] VALUES ('Melgar', 1)

