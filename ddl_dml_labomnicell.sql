-- 1. Desconectarse de la base de datos y poner en modo de usuario único para borrarla
ALTER DATABASE LabOmnicell SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
-- 2. Eliminar la base de datos
DROP DATABASE LabOmnicell;
GO
-- 3. Eliminar el inicio de sesión del servidor
DROP LOGIN usromnicell;
GO

-- DDL
CREATE DATABASE LabOmnicell
GO
USE master
GO
CREATE LOGIN usromnicell WITH PASSWORD=N'123456',
    DEFAULT_DATABASE=LabOmnicell,
    CHECK_EXPIRATION=OFF,
    CHECK_POLICY=ON
GO
USE LabOmnicell
GO
CREATE USER usromnicell FOR LOGIN usromnicell
GO
ALTER ROLE [db_owner] ADD MEMBER usromnicell
GO

DROP TABLE IF EXISTS VentaDetalle;
DROP TABLE IF EXISTS Venta;
DROP TABLE IF EXISTS Cliente;
DROP TABLE IF EXISTS Inventario;
DROP TABLE IF EXISTS Sucursal;
DROP TABLE IF EXISTS CompraDetalle;
DROP TABLE IF EXISTS Compra;
DROP TABLE IF EXISTS Proveedor;
DROP TABLE IF EXISTS Compatibilidad;
DROP TABLE IF EXISTS Pantalla;
DROP TABLE IF EXISTS Modelo;
DROP TABLE IF EXISTS Marca;
DROP TABLE IF EXISTS Usuario;
DROP TABLE IF EXISTS Rol;
DROP TABLE IF EXISTS Empleado;

CREATE TABLE Empleado (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombres VARCHAR(50) NOT NULL,
    primerApellido VARCHAR(30) NOT NULL,
    segundoApellido VARCHAR(30) NULL,
    ci VARCHAR(15) NOT NULL UNIQUE,
    celular BIGINT NOT NULL,
    direccion VARCHAR(150) NOT NULL,
    cargo VARCHAR(50) NOT NULL
);

CREATE TABLE Rol (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(50) NOT NULL UNIQUE,
    descripcion VARCHAR(150) NULL
);

CREATE TABLE Usuario (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    idEmpleado INT NOT NULL UNIQUE,
    idRol INT NOT NULL,
    usuario VARCHAR(20) NOT NULL UNIQUE,
    clave VARCHAR(100) NOT NULL,
    CONSTRAINT fk_Usuario_Empleado FOREIGN KEY (idEmpleado) REFERENCES Empleado(id),
    CONSTRAINT fk_Usuario_Rol FOREIGN KEY (idRol) REFERENCES Rol(id)
);

CREATE TABLE Marca (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Modelo (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    idMarca INT NOT NULL,
    nombre VARCHAR(60) NOT NULL,
    CONSTRAINT fk_Modelo_Marca FOREIGN KEY (idMarca) REFERENCES Marca(id)
);

CREATE TABLE Pantalla (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    sku VARCHAR(30) NOT NULL UNIQUE,
    descripcion VARCHAR(150) NOT NULL,
    calidad VARCHAR(30) NOT NULL, 
    tecnologia VARCHAR(30) NOT NULL, 
    precioVenta DECIMAL(10,2) NOT NULL CHECK(precioVenta > 0),
    stockTotal DECIMAL(10,2) NOT NULL DEFAULT 0
);

CREATE TABLE Compatibilidad (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    idPantalla INT NOT NULL,
    idModelo INT NOT NULL,
    CONSTRAINT fk_Compatibilidad_Pantalla FOREIGN KEY (idPantalla) REFERENCES Pantalla(id),
    CONSTRAINT fk_Compatibilidad_Modelo FOREIGN KEY (idModelo) REFERENCES Modelo(id)
);

CREATE TABLE Proveedor (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    razonSocial VARCHAR(100) NOT NULL,
    pais VARCHAR(50) NOT NULL,
    contactoPersona VARCHAR(60) NOT NULL,
    telefono VARCHAR(25) NOT NULL
);

CREATE TABLE Compra (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    idProveedor INT NOT NULL,
    idEmpleado INT NOT NULL,
    fechaCompra DATE NOT NULL,
    factura VARCHAR(30) NOT NULL,
    costoTotal DECIMAL(10,2) NOT NULL CHECK(costoTotal >= 0),
    CONSTRAINT fk_Compra_Proveedor FOREIGN KEY (idProveedor) REFERENCES Proveedor(id),
    CONSTRAINT fk_Compra_Empleado FOREIGN KEY (idEmpleado) REFERENCES Empleado(id)
);

CREATE TABLE CompraDetalle (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    idCompra INT NOT NULL,
    idPantalla INT NOT NULL,
    cantidad DECIMAL(10,2) NOT NULL CHECK(cantidad > 0),
    costoUnitario DECIMAL(10,2) NOT NULL CHECK(costoUnitario > 0),
    subtotal DECIMAL(10,2) NOT NULL CHECK(subtotal > 0),
    CONSTRAINT fk_CompraDetalle_Compra FOREIGN KEY (idCompra) REFERENCES Compra(id),
    CONSTRAINT fk_CompraDetalle_Pantalla FOREIGN KEY (idPantalla) REFERENCES Pantalla(id)
);

CREATE TABLE Sucursal (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(80) NOT NULL,
    ciudad VARCHAR(50) NOT NULL,
    direccion VARCHAR(150) NOT NULL,
    telefono VARCHAR(20) NOT NULL
);

CREATE TABLE Inventario (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    idSucursal INT NOT NULL,
    idPantalla INT NOT NULL,
    stockActual DECIMAL(10,2) NOT NULL DEFAULT 0 CHECK(stockActual >= 0),
    stockMinimo DECIMAL(10,2) NOT NULL DEFAULT 0 CHECK(stockMinimo >= 0),
    CONSTRAINT fk_Inventario_Sucursal FOREIGN KEY (idSucursal) REFERENCES Sucursal(id),
    CONSTRAINT fk_Inventario_Pantalla FOREIGN KEY (idPantalla) REFERENCES Pantalla(id)
);

CREATE TABLE Cliente (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nitCi VARCHAR(20) NOT NULL UNIQUE,
    razonSocial VARCHAR(150) NOT NULL,
    telefono VARCHAR(20) NOT NULL,
    direccion VARCHAR(150) NULL,
    tipoCliente VARCHAR(30) NOT NULL 
);

CREATE TABLE Venta (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    idCliente INT NOT NULL,
    idEmpleado INT NOT NULL,
    idSucursal INT NOT NULL,
    fechaVenta DATE NOT NULL,
    tipoPago VARCHAR(30) NOT NULL, 
    montoTotal DECIMAL(10,2) NOT NULL CHECK(montoTotal > 0),
    CONSTRAINT fk_Venta_Cliente FOREIGN KEY (idCliente) REFERENCES Cliente(id),
    CONSTRAINT fk_Venta_Empleado FOREIGN KEY (idEmpleado) REFERENCES Empleado(id),
    CONSTRAINT fk_Venta_Sucursal FOREIGN KEY (idSucursal) REFERENCES Sucursal(id)
);

CREATE TABLE VentaDetalle (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    idVenta INT NOT NULL,
    idPantalla INT NOT NULL,
    cantidad DECIMAL(10,2) NOT NULL CHECK(cantidad > 0),
    precioUnitario DECIMAL(10,2) NOT NULL CHECK(precioUnitario > 0),
    subtotal DECIMAL(10,2) NOT NULL CHECK(subtotal > 0),
    CONSTRAINT fk_VentaDetalle_Venta FOREIGN KEY (idVenta) REFERENCES Venta(id),
    CONSTRAINT fk_VentaDetalle_Pantalla FOREIGN KEY (idPantalla) REFERENCES Pantalla(id)
);

-- Auditoría estándar
ALTER TABLE Empleado ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Rol ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Usuario ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Marca ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Modelo ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Pantalla ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Compatibilidad ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Proveedor ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Compra ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE CompraDetalle ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Sucursal ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Inventario ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Cliente ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Venta ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE VentaDetalle ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;

GO
DROP PROC IF EXISTS paPantallaListar;
GO
CREATE PROC paPantallaListar @parametro VARCHAR(50) AS
  SELECT id, sku, descripcion, calidad, tecnologia, precioVenta, stockTotal, usuarioRegistro, fechaRegistro, estado
  FROM Pantalla
  WHERE estado = 1 AND (sku + descripcion + calidad LIKE '%' + REPLACE(@parametro, ' ', '%') + '%')
  ORDER BY descripcion;
GO
EXEC paPantallaListar 'Iphone 13 pro';

DROP PROC IF EXISTS paClienteListar;
GO
CREATE PROC paClienteListar @parametro VARCHAR(50) AS
  SELECT id, nitCi, razonSocial, telefono, direccion, tipoCliente, usuarioRegistro, fechaRegistro, estado
  FROM Cliente
  WHERE estado = 1 AND (nitCi + razonSocial LIKE '%' + REPLACE(@parametro, ' ', '%') + '%')
  ORDER BY razonSocial;
GO
EXEC paClienteListar 'CelRep';

-- DML
INSERT INTO Rol (nombre, descripcion)
VALUES ('Administrador', 'Control total del sistema'), ('Vendedor', 'Encargado de atenciones y ventas');

INSERT INTO Empleado (nombres, primerApellido, segundoApellido, ci, celular, direccion, cargo)
VALUES ('Carlos', 'Mendoza', 'Rojas', '8976543', 70012345, 'Av. 6 de Agosto #450', 'Gerente General'),
('Tifany', 'Perez', 'Motalvo', '6543281', 71234567, 'Av. Emilio Hoschamn #123', 'Vendedor');

INSERT INTO Usuario (idEmpleado, idRol, usuario, clave)
VALUES (1, 1, 'admin', 'Q04sp73uUzMPFuEBS5xNLg==');

INSERT INTO Marca (nombre)
VALUES ('Apple'), ('Samsung'), ('Xiaomi'), ('Tecno'), ('Infinix');

INSERT INTO Modelo (idMarca, nombre)
VALUES (1, 'iPhone 13 Pro'), (2, 'Galaxy S22'), (3, 'Note 10 Pro'), (4, 'Spark Go 1'), (5, 'Note 30 Pro');

INSERT INTO Pantalla (sku, descripcion, calidad, tecnologia, precioVenta, stockTotal)
VALUES ('IP13PRO-OL', 'Pantalla OLED Original para iPhone 13 Pro', 'OLED Original', 'Capacitiva', 850.00, 10),
       ('SGS22-INC', 'Pantalla Incell para Samsung Galaxy S22', 'Incell', 'OGS', 300.00, 15),
       ('XMN10PR-OLED', 'Pantalla LCD para Xiaomi Note 10 Pro', 'OLED', 'Capacitiva', 350.00, 15);

INSERT INTO Cliente (nitCi, razonSocial, telefono, direccion, tipoCliente) 
VALUES ('5432109012', 'Servicios Técnicos Celular Express', 71234567, 'Calle España #210', 'Técnico Mayorista'),
('3214567', 'Servicios Técnicos CelRep', 7654321, 'Calle Aniceto Arce #60', 'Técnico Minorista');

SELECT * FROM Empleado;
SELECT * FROM Usuario;
SELECT * FROM Pantalla;
SELECT * FROM Cliente;
SELECT * FROM Marca;