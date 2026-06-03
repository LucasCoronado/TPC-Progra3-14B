CREATE DATABASE BDDComercio;
GO

USE BDDComercio;
GO

CREATE TABLE Productos
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(20) NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    StockActual INT NOT NULL
);

INSERT INTO Productos (Codigo, Nombre, StockActual)
VALUES
('P001', 'Yerba Mate', 50),
('P002', 'Azucar', 30),
('P003', 'Cafe', 20),
('P004', 'Sal', 24);
