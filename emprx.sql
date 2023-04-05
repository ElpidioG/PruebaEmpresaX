CREATE DATABASE EmpresaX;
Use EmpresaX

CREATE TABLE Cliente (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(50),
    Apellido VARCHAR(50),
	Telefono Varchar (50)
);

CREATE TABLE Direccion (
    Id INT PRIMARY KEY,
    Calle VARCHAR(50),
    Numero VARCHAR(50),
    Ciudad VARCHAR(50),
    Estado VARCHAR(50),
    Pais VARCHAR(50),
    idCliente INT,
    FOREIGN KEY (idCliente) REFERENCES Cliente(Id)
);
