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

DROP TABLE IF EXISTS Garantia;
DROP TABLE IF EXISTS VentaDetalle;
DROP TABLE IF EXISTS Venta;
DROP TABLE IF EXISTS Cliente;
DROP TABLE IF EXISTS InventarioStock;
DROP TABLE IF EXISTS SucursalAlmacen;
DROP TABLE IF EXISTS CompraDetalle;
DROP TABLE IF EXISTS Compra;
DROP TABLE IF EXISTS Importacion;
DROP TABLE IF EXISTS ProveedorFabrica;
DROP TABLE IF EXISTS ModeloCompatible;
DROP TABLE IF EXISTS Producto;
DROP TABLE IF EXISTS UnidadMedida;
DROP TABLE IF EXISTS CalidadPantalla;
DROP TABLE IF EXISTS ModeloCelular;
DROP TABLE IF EXISTS MarcaCelular;
DROP TABLE IF EXISTS RolPermiso;
DROP TABLE IF EXISTS Permiso;
DROP TABLE IF EXISTS Usuario;
DROP TABLE IF EXISTS Rol;
DROP TABLE IF EXISTS Empleado;

CREATE TABLE Empleado (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  nombres VARCHAR(50) NOT NULL,
  primerApellido VARCHAR(30) NOT NULL,
  segundoApellido VARCHAR(30) NULL,
  cedulaIdentidad VARCHAR(15) NOT NULL UNIQUE,
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

CREATE TABLE Permiso (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  nombre VARCHAR(50) NOT NULL UNIQUE,
  descripcion VARCHAR(150) NULL
);

CREATE TABLE RolPermiso (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idRol INT NOT NULL,
  idPermiso INT NOT NULL,
  CONSTRAINT fk_RolPermiso_Rol FOREIGN KEY (idRol) REFERENCES Rol(id),
  CONSTRAINT fk_RolPermiso_Permiso FOREIGN KEY (idPermiso) REFERENCES Permiso(id)
);

CREATE TABLE MarcaCelular (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  nombre VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE ModeloCelular (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idMarcaCelular INT NOT NULL,
  nombre VARCHAR(60) NOT NULL,
  CONSTRAINT fk_Modelo_Marca FOREIGN KEY (idMarcaCelular) REFERENCES MarcaCelular(id)
);

CREATE TABLE CalidadPantalla (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  nombre VARCHAR(50) NOT NULL UNIQUE,
  descripcion VARCHAR(150) NULL
);

CREATE TABLE UnidadMedida (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  descripcion VARCHAR(30) NOT NULL UNIQUE
);

CREATE TABLE Producto (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idCalidadPantalla INT NOT NULL,
  idUnidadMedida INT NOT NULL,
  codigo VARCHAR(25) NOT NULL UNIQUE,
  descripcion VARCHAR(200) NOT NULL,
  saldo DECIMAL(10,2) NOT NULL DEFAULT 0,
  precioVenta DECIMAL(10,2) NOT NULL CHECK (precioVenta > 0),
  CONSTRAINT fk_Producto_Calidad FOREIGN KEY (idCalidadPantalla) REFERENCES CalidadPantalla(id),
  CONSTRAINT fk_Producto_UnidadMedida FOREIGN KEY (idUnidadMedida) REFERENCES UnidadMedida(id)
);

CREATE TABLE ModeloCompatible (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idProducto INT NOT NULL,
  idModeloCelular INT NOT NULL,
  CONSTRAINT fk_ModeloCompatible_Producto FOREIGN KEY (idProducto) REFERENCES Producto(id),
  CONSTRAINT fk_ModeloCompatible_Modelo FOREIGN KEY (idModeloCelular) REFERENCES ModeloCelular(id)
);

CREATE TABLE ProveedorFabrica (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  nombre VARCHAR(100) NOT NULL,
  pais VARCHAR(50) NOT NULL,
  contacto VARCHAR(60) NOT NULL,
  telefono VARCHAR(25) NOT NULL
);

CREATE TABLE Importacion (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idProveedorFabrica INT NOT NULL,
  numeroContenedor VARCHAR(30) NOT NULL,
  paisOrigen VARCHAR(50) NOT NULL,
  fechaEmbarque DATE NOT NULL,
  estadoAduana VARCHAR(50) NOT NULL,
  gastosTransporte DECIMAL(10,2) NOT NULL DEFAULT 0,
  CONSTRAINT fk_Importacion_Proveedor FOREIGN KEY (idProveedorFabrica) REFERENCES ProveedorFabrica(id)
);

CREATE TABLE Compra (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idImportacion INT NOT NULL,
  idEmpleado INT NOT NULL,
  fecha DATE NOT NULL,
  total DECIMAL(10,2) NOT NULL CHECK(total >= 0),
  CONSTRAINT fk_Compra_Importacion FOREIGN KEY (idImportacion) REFERENCES Importacion(id),
  CONSTRAINT fk_Compra_Empleado FOREIGN KEY (idEmpleado) REFERENCES Empleado(id)
);

CREATE TABLE CompraDetalle (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idCompra INT NOT NULL,
  idProducto INT NOT NULL,
  cantidad DECIMAL(10,2) NOT NULL CHECK(cantidad > 0),
  costoUnitarioFabrica DECIMAL(10,2) NOT NULL CHECK(costoUnitarioFabrica > 0),
  aranceles DECIMAL(10,2) NOT NULL DEFAULT 0,
  subtotal DECIMAL(10,2) NOT NULL CHECK(subtotal > 0),
  CONSTRAINT fk_CompraDetalle_Compra FOREIGN KEY (idCompra) REFERENCES Compra(id),
  CONSTRAINT fk_CompraDetalle_Producto FOREIGN KEY (idProducto) REFERENCES Producto(id)
);

CREATE TABLE SucursalAlmacen (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  nombre VARCHAR(80) NOT NULL,
  direccion VARCHAR(150) NOT NULL,
  telefono VARCHAR(20) NOT NULL
);

CREATE TABLE InventarioStock (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idSucursalAlmacen INT NOT NULL,
  idProducto INT NOT NULL,
  stockActual DECIMAL(10,2) NOT NULL DEFAULT 0 CHECK(stockActual >= 0),
  stockMinimo DECIMAL(10,2) NOT NULL DEFAULT 0 CHECK(stockMinimo >= 0),
  CONSTRAINT fk_Inventario_Sucursal FOREIGN KEY (idSucursalAlmacen) REFERENCES SucursalAlmacen(id),
  CONSTRAINT fk_Inventario_Producto FOREIGN KEY (idProducto) REFERENCES Producto(id)
);

CREATE TABLE Cliente (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  nit VARCHAR(20) NOT NULL UNIQUE,
  razonSocial VARCHAR(150) NOT NULL,
  telefono VARCHAR(20) NOT NULL,
  direccion VARCHAR(150) NULL
);

CREATE TABLE Venta (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idCliente INT NOT NULL,
  idEmpleado INT NOT NULL,
  fecha DATE NOT NULL,
  tipoTransaccion VARCHAR(20) NOT NULL,
  total DECIMAL(10,2) NOT NULL CHECK(total > 0),
  CONSTRAINT fk_Venta_Cliente FOREIGN KEY (idCliente) REFERENCES Cliente(id),
  CONSTRAINT fk_Venta_Empleado FOREIGN KEY (idEmpleado) REFERENCES Empleado(id)
);

CREATE TABLE VentaDetalle (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idVenta INT NOT NULL,
  idProducto INT NOT NULL,
  cantidad DECIMAL(10,2) NOT NULL CHECK(cantidad > 0),
  precioUnitario DECIMAL(10,2) NOT NULL CHECK(precioUnitario > 0),
  subtotal DECIMAL(10,2) NOT NULL CHECK(subtotal > 0),
  CONSTRAINT fk_VentaDetalle_Venta FOREIGN KEY (idVenta) REFERENCES Venta(id),
  CONSTRAINT fk_VentaDetalle_Producto FOREIGN KEY (idProducto) REFERENCES Producto(id)
);

CREATE TABLE Garantia (
  id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  idVentaDetalle INT NOT NULL,
  motivo VARCHAR(250) NOT NULL,
  fechaRecepcion DATE NOT NULL,
  estadoGarantia VARCHAR(30) NOT NULL,
  observaciones VARCHAR(250) NULL,
  CONSTRAINT fk_Garantia_VentaDetalle FOREIGN KEY (idVentaDetalle) REFERENCES VentaDetalle(id)
);

ALTER TABLE Empleado ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Rol ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Usuario ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Permiso ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE RolPermiso ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE MarcaCelular ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE ModeloCelular ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE CalidadPantalla ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE UnidadMedida ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Producto ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE ModeloCompatible ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE ProveedorFabrica ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Importacion ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Compra ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE CompraDetalle ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE SucursalAlmacen ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE InventarioStock ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Cliente ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Venta ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE VentaDetalle ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Garantia ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(), fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), estado SMALLINT NOT NULL DEFAULT 1;

GO
DROP PROC IF EXISTS paProductoListar;
GO
CREATE PROC paProductoListar @parametro VARCHAR(50) AS
  SELECT p.id, p.idCalidadPantalla, p.idUnidadMedida, p.codigo, p.descripcion, 
         cp.nombre AS calidadPantalla, um.descripcion AS unidadMedida,
         p.saldo, p.precioVenta, p.usuarioRegistro, p.fechaRegistro, p.estado
  FROM Producto p
  INNER JOIN CalidadPantalla cp ON cp.id = p.idCalidadPantalla
  INNER JOIN UnidadMedida um ON um.id = p.idUnidadMedida
  WHERE p.estado = 1 AND (p.codigo + p.descripcion + cp.nombre + um.descripcion LIKE '%' + REPLACE(@parametro, ' ', '%') + '%')
  ORDER BY p.descripcion;
GO
EXEC paProductoListar 'Pantalla';

DROP PROC IF EXISTS paClienteListar;
GO
CREATE PROC paClienteListar @parametro VARCHAR(50) AS
  SELECT id, nit, razonSocial, telefono, direccion, usuarioRegistro, fechaRegistro, estado
  FROM Cliente
  WHERE estado = 1 AND (nit + razonSocial LIKE '%' + REPLACE(@parametro, ' ', '%') + '%')
  ORDER BY razonSocial;
GO
EXEC paClienteListar '';

-- DML
INSERT INTO Rol (nombre, descripcion)
VALUES ('Administrador', 'Control total del sistema'), ('Vendedor', 'Encargado de atenciones y ventas');

INSERT INTO Empleado (nombres, primerApellido, segundoApellido, cedulaIdentidad, celular, direccion, cargo)
VALUES ('Carlos', 'Mendoza', 'Rojas', '8976543', 70012345, 'Av. 6 de Agosto #450', 'Gerente General');

INSERT INTO Usuario (idEmpleado, idRol, usuario, clave)
VALUES (1, 1, 'admin', 'Q04sp73uUzMPFuEBS5xNLg==');

INSERT INTO CalidadPantalla (nombre, descripcion)
VALUES ('OLED Original', 'Pantalla original con máxima fidelidad de color'), ('Incell', 'Pantalla alternativa de alta calidad');

INSERT INTO UnidadMedida (descripcion)
VALUES ('Unidad'), ('Kit');

INSERT INTO Producto (idCalidadPantalla, idUnidadMedida, codigo, descripcion, saldo, precioVenta)
VALUES (1, 1, 'IP13PRO-OL', 'Pantalla OLED Original para iPhone 13 Pro', 10, 850.00),
       (2, 1, 'SGS22-INC', 'Pantalla Incell para Samsung Galaxy S22', 15, 350.00);

INSERT INTO Cliente (nit, razonSocial, telefono, direccion) 
VALUES ('5432109012', 'Servicios Técnicos Celular Express', 71234567, 'Calle España #210');

SELECT * FROM Empleado;
SELECT * FROM Usuario;
SELECT * FROM Producto;
SELECT * FROM Cliente;