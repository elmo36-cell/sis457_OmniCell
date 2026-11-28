-- Desconectarse de la base de datos
ALTER DATABASE LabOmnicell SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
-- Eliminar la base de datos
DROP DATABASE LabOmnicell;
GO
ALTER DATABASE LabOmnicell SET ONLINE;
-- Eliminar el inicio de sesión del servidor
DROP LOGIN usromnicell;
GO

USE LabOmnicell;
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
DROP TABLE IF EXISTS Sucursal;

CREATE TABLE Sucursal (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(80) NOT NULL,
    ciudad VARCHAR(50) NOT NULL,
    direccion VARCHAR(150) NOT NULL,
    telefono VARCHAR(20) NOT NULL
);

CREATE TABLE Empleado (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    idSucursal INT NOT NULL,
    nombres VARCHAR(50) NOT NULL,
    primerApellido VARCHAR(30) NOT NULL,
    segundoApellido VARCHAR(30) NULL,
    ci VARCHAR(15) NOT NULL UNIQUE,
    celular BIGINT NOT NULL,
    direccion VARCHAR(150) NOT NULL,
    cargo VARCHAR(50) NOT NULL,
    CONSTRAINT fk_Empleado_Sucursal FOREIGN KEY (idSucursal) REFERENCES Sucursal(id)
);

CREATE TABLE Rol (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(50) NOT NULL UNIQUE,
    descripcion VARCHAR(150) NULL
);

CREATE TABLE Usuario (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    idEmpleado INT NOT NULL,
    idRol INT NOT NULL,
    nombreUsuario VARCHAR(20) NOT NULL UNIQUE,
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
    nombres VARCHAR(50) NULL,
    primerApellido VARCHAR(30) NULL,
    segundoApellido VARCHAR(30) NULL,
    razonSocial VARCHAR(150) NULL,
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
    observacionGarantia VARCHAR(150) NULL, 
    CONSTRAINT fk_VentaDetalle_Venta FOREIGN KEY (idVenta) REFERENCES Venta(id),
    CONSTRAINT fk_VentaDetalle_Pantalla FOREIGN KEY (idPantalla) REFERENCES Pantalla(id)
);
GO

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
  SELECT id, sku, descripcion, calidad, tecnologia, precioVenta, stockTotal
  FROM Pantalla
  WHERE estado = 1 AND (sku + descripcion + calidad LIKE '%' + REPLACE(@parametro, ' ', '%') + '%')
  ORDER BY descripcion;
GO

DROP PROC IF EXISTS paClienteListar;
GO
CREATE PROC paClienteListar @parametro VARCHAR(50) AS
  SELECT id, nitCi, nombres, primerApellido, segundoApellido, razonSocial, telefono, direccion, tipoCliente, usuarioRegistro
  FROM Cliente
  WHERE estado = 1 AND (
        nitCi LIKE '%' + @parametro + '%' OR 
        nombres + ' ' + ISNULL(primerApellido,'') LIKE '%' + REPLACE(@parametro, ' ', '%') + '%' OR
        ISNULL(razonSocial,'') LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
  )
  ORDER BY nitCi;
GO

DROP PROC IF EXISTS paEmpleadoListar;
GO
CREATE PROC paEmpleadoListar @parametro VARCHAR(50) AS
  SELECT id, nombres, primerApellido, segundoApellido, ci, celular, direccion, cargo
  FROM Empleado
  WHERE estado = 1 AND (ci + nombres + primerApellido LIKE '%' + REPLACE(@parametro, ' ', '%') + '%')
  ORDER BY primerApellido, nombres;
GO

DROP PROC IF EXISTS paUsuarioListar;
GO
CREATE PROC paUsuarioListar @parametro VARCHAR(50) AS
  SELECT u.id, e.nombres, e.cargo, r.nombre, u.nombreUsuario
  FROM Usuario u
  INNER JOIN Empleado e ON u.idEmpleado = e.id
  INNER JOIN Rol r ON u.idRol = r.id
  WHERE u.estado = 1 AND (u.nombreUsuario + e.nombres + e.primerApellido LIKE '%' + REPLACE(@parametro, ' ', '%') + '%')
  ORDER BY u.nombreUsuario;
GO

DROP PROC IF EXISTS paProveedorListar;
GO
CREATE PROC paProveedorListar @parametro VARCHAR(50) AS
  SELECT id, razonSocial, pais, contactoPersona, telefono
  FROM Proveedor
  WHERE estado = 1 AND (razonSocial + contactoPersona + pais LIKE '%' + REPLACE(@parametro, ' ', '%') + '%')
  ORDER BY razonSocial;
GO



DROP PROC IF EXISTS dbo.paVentaListar;
GO
CREATE PROC dbo.paVentaListar @parametro VARCHAR(50) AS BEGIN
    SELECT v.id, v.fechaVenta, CONCAT(c.nombres, ' ', c.primerApellido) AS cliente, c.nitCi, CONCAT(e.nombres, ' ', e.primerApellido) AS vendedor, s.nombre AS sucursal, v.tipoPago, v.montoTotal
    FROM Venta v
    INNER JOIN Cliente c ON v.idCliente = c.id
    INNER JOIN Empleado e ON v.idEmpleado = e.id
    INNER JOIN Sucursal s ON v.idSucursal = s.id
    WHERE
        v.estado = 1
        AND CONCAT(
            c.nitCi, ' ',
            c.nombres, ' ',
            c.primerApellido, ' ',
            e.nombres, ' ',
            e.primerApellido, ' ',
            s.nombre, ' ',
            v.tipoPago
        ) LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
    ORDER BY v.id DESC;
END;
GO

DROP PROC IF EXISTS paCompraListar;
GO
CREATE PROC paCompraListar @parametro VARCHAR(50) AS BEGIN
  SELECT c.id, c.fechaCompra, p.razonSocial AS proveedor, p.pais, e.nombres + ' ' + e.primerApellido AS empleado, c.factura, c.costoTotal
    FROM Compra c
    INNER JOIN Proveedor p ON c.idProveedor = p.id
    INNER JOIN Empleado e ON c.idEmpleado = e.id
    WHERE c.estado = 1 
    AND CONCAT( c.id, ' ', p.razonSocial, ' ', p.pais, ' ', e.nombres, ' ', e.primerApellido, ' ', c.factura ) LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
    ORDER BY c.id DESC;
END;
GO




DROP PROC IF EXISTS paPantallaListarPorSucursal;
GO
CREATE PROC paPantallaListarPorSucursal
    @idSucursal INT,
    @parametro VARCHAR(50)
AS
BEGIN
    SELECT
        p.id,
        p.sku,
        p.descripcion,
        p.calidad,
        p.tecnologia,
        p.precioVenta,
        i.stockActual
    FROM Pantalla p
    INNER JOIN Inventario i
        ON p.id = i.idPantalla
    WHERE
        p.estado = 1
        AND i.estado = 1
        AND i.idSucursal = @idSucursal
        AND i.stockActual > 0
        AND (
            p.sku + ' ' +
            p.descripcion + ' ' +
            p.calidad + ' ' +
            p.tecnologia
        ) LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
    ORDER BY p.descripcion;
END;
GO


-- DML (Datos Iniciales)
INSERT INTO Rol (nombre, descripcion)
VALUES ('Administrador', 'Control total del sistema'), 
       ('Vendedor', 'Encargado de atenciones y ventas'),
       ('Cliente', 'Cliente registrado en el sistema');

INSERT INTO Sucursal (nombre, ciudad, direccion, telefono)
VALUES ('Sucursal Central', 'Sucre', 'Calle Junin N. 120', '76123456'), 
       ('Sucursal Norte', 'Potosi', 'Av. Litoral N. 250', '76234567'), 
       ('Sucursal Sur', 'Oruro', 'Calle Bolivar N. 80', '76345678'),
       ('Sucursal Centro', 'La Paz', 'Av. Mariscal Santa Cruz N. 1050', '76456789'),
       ('Sucursal El Alto', 'El Alto', 'Av. 6 de Marzo N. 420', '76567890'),
       ('Sucursal Valle', 'Cochabamba', 'Av. Heroinas N. 310', '76678901'),
       ('Sucursal Oriente', 'Santa Cruz', 'Av. Monseñor Rivero N. 515', '76789012'),
       ('Sucursal Chapaco', 'Tarija', 'Calle La Madrid N. 190', '76890123'),
       ('Sucursal Beni', 'Trinidad', 'Av. 6 de Agosto N. 280', '76901234'),
       ('Sucursal Pando', 'Cobija', 'Av. Fernandez Molina N. 140', '76012345');

INSERT INTO Empleado (idSucursal, nombres, primerApellido, segundoApellido, ci, celular, direccion, cargo)
VALUES 
       -- Administrador Principal (Sucursal 1)
       (1, 'Carlos', 'Mendoza', 'Rojas', '8976543', 70012345, 'Av. 6 de Agosto #450', 'Gerente General'),
       (1, 'Tifany', 'Perez', 'Montalvo', '6543281', 71234567, 'Calle España #123', 'Vendedor'),
       (1, 'Andres', 'Gomez', 'Vargas', '6543282', 71234568, 'Av. Hernando Siles #410', 'Vendedor'),
       (2, 'Fredy', 'Rios', 'Perez', '1534556', 78524174, 'Av. Litoral #150', 'Vendedor'),
       (2, 'Elena', 'Mamani', 'Quispe', '1534557', 78524175, 'Calle Padilla #88', 'Vendedor'),
       (3, 'Jorge Luis', 'Vargas', 'Fernandez', '9876541', 72045678, 'Calle Bolivar #210', 'Vendedor'),
       (3, 'Sofia', 'Chavez', 'Flores', '9876542', 72045679, 'Av. 6 de Octubre #55', 'Vendedor'),
       (4, 'Rodrigo', 'Flores', 'Calani', '7123458', 71239876, 'Zona Sopocachi, Calle 20 #320', 'Vendedor'),
       (4, 'Carla', 'Salazar', 'Mendoza', '4512390', 73456789, 'Av. Arce #2100', 'Vendedor'),
       (5, 'Miguel', 'Ticona', 'Choque', '6234512', 71829340, 'Zona Villa Fatima, Calle 2 #45', 'Vendedor'),
       (5, 'Lucia', 'Mamani', 'Poma', '3987652', 76543890, 'El Alto, Ceja, Av. 6 de Marzo #100', 'Vendedor'),
       (6, 'Fernando', 'Arce', 'Torrico', '5123491', 74123451, 'Av. Heroinas #512', 'Vendedor'),
       (6, 'Daniela', 'Vega', 'Rojas', '5123492', 74123452, 'Calle Ayacucho #304', 'Vendedor'),
       (7, 'Mateo', 'Justiniano', 'Suarez', '3891201', 75123451, 'Av. Monseñor Rivero #610', 'Vendedor'),
       (7, 'Camila', 'Paniagua', 'Ortiz', '3891202', 75123452, 'Equipetrol, Calle 5 #120', 'Vendedor'),
       (8, 'Sebastian', 'Aparicio', 'Lema', '4912301', 76123451, 'Calle La Madrid #230', 'Vendedor'),
       (8, 'Valentina', 'Castillo', 'Mendez', '4912302', 76123452, 'Av. Las Americas #415', 'Vendedor'),
       (9, 'Mauricio', 'Ribera', 'Saucedo', '5912301', 77123451, 'Av. 6 de Agosto #310', 'Vendedor'),
       (9, 'Natalia', 'Melgar', 'Vaca', '5912302', 77123452, 'Calle Cipriano Barace #90', 'Vendedor'),
       (10, 'Diego', 'Bazan', 'Añez', '6912301', 78123451, 'Av. Fernandez Molina #180', 'Vendedor'),
       (10, 'Paola', 'Cortez', 'Navarro', '6912302', 78123452, 'Barrio Mapajo, Calle 4 #72', 'Vendedor');

INSERT INTO Usuario (idEmpleado, idRol, nombreUsuario, clave)
VALUES 
       (1, 1, 'admin', 'Q04sp73uUzMPFuEBS5xNLg=='),       -- Administrador
       (2, 2, 'tperez', 'Q04sp73uUzMPFuEBS5xNLg=='),      -- Sucursal 1 (Sucre)
       (3, 2, 'agomez', 'Q04sp73uUzMPFuEBS5xNLg=='),      -- Sucursal 1 (Sucre)
       (4, 2, 'frios', 'Q04sp73uUzMPFuEBS5xNLg=='),       -- Sucursal 2 (Potosí)
       (5, 2, 'emamani', 'Q04sp73uUzMPFuEBS5xNLg=='),     -- Sucursal 2 (Potosí)
       (6, 2, 'jvargas', 'Q04sp73uUzMPFuEBS5xNLg=='),     -- Sucursal 3 (Oruro)
       (7, 2, 'schavez', 'Q04sp73uUzMPFuEBS5xNLg=='),     -- Sucursal 3 (Oruro)
       (8, 2, 'rflores', 'Q04sp73uUzMPFuEBS5xNLg=='),     -- Sucursal 4 (La Paz)
       (9, 2, 'csalazar', 'Q04sp73uUzMPFuEBS5xNLg=='),    -- Sucursal 4 (La Paz)
       (10, 2, 'mticona', 'Q04sp73uUzMPFuEBS5xNLg=='),    -- Sucursal 5 (El Alto)
       (11, 2, 'lmamani', 'Q04sp73uUzMPFuEBS5xNLg=='),    -- Sucursal 5 (El Alto)
       (12, 2, 'farce', 'Q04sp73uUzMPFuEBS5xNLg=='),      -- Sucursal 6 (Cochabamba)
       (13, 2, 'dvega', 'Q04sp73uUzMPFuEBS5xNLg=='),      -- Sucursal 6 (Cochabamba)
       (14, 2, 'mjustiniano', 'Q04sp73uUzMPFuEBS5xNLg=='),-- Sucursal 7 (Santa Cruz)
       (15, 2, 'cpaniagua', 'Q04sp73uUzMPFuEBS5xNLg=='),  -- Sucursal 7 (Santa Cruz)
       (16, 2, 'saparicio', 'Q04sp73uUzMPFuEBS5xNLg=='),  -- Sucursal 8 (Tarija)
       (17, 2, 'vcastillo', 'Q04sp73uUzMPFuEBS5xNLg=='),  -- Sucursal 8 (Tarija)
       (18, 2, 'mribera', 'Q04sp73uUzMPFuEBS5xNLg=='),    -- Sucursal 9 (Trinidad)
       (19, 2, 'nmelgar', 'Q04sp73uUzMPFuEBS5xNLg=='),    -- Sucursal 9 (Trinidad)
       (20, 2, 'dbazan', 'Q04sp73uUzMPFuEBS5xNLg=='),     -- Sucursal 10 (Cobija)
       (21, 2, 'pcortez', 'Q04sp73uUzMPFuEBS5xNLg==');    -- Sucursal 10 (Cobija)

INSERT INTO Marca (nombre)
VALUES ('Apple'), ('Samsung'), ('Xiaomi'), ('Tecno'), ('Infinix'), 
       ('Sony'), ('Nokia'), ('ZTE'), ('Asus'), ('Lenovo'),
       ('Huawei'), ('Oppo'), ('Realme'), ('Honor'), ('Motorola'),
       ('Google'), ('OnePlus'), ('Vivo'), ('Nothing'), ('LG'),
       ('Alcatel'), ('Itel');

INSERT INTO Modelo (idMarca, nombre)
SELECT v.idMarca, v.nombre
FROM (VALUES
    (1, 'iPhone X'), (1, 'iPhone XR'), (1, 'iPhone XS Max'),
    (1, 'iPhone 11'), (1, 'iPhone 11 Pro'), (1, 'iPhone 11 Pro Max'),
    (1, 'iPhone 12'), (1, 'iPhone 12 Mini'), (1, 'iPhone 12 Pro'), (1, 'iPhone 12 Pro Max'),
    (1, 'iPhone 13'), (1, 'iPhone 13 Mini'), (1, 'iPhone 13 Pro'), (1, 'iPhone 13 Pro Max'),
    (1, 'iPhone 14'), (1, 'iPhone 14 Plus'), (1, 'iPhone 14 Pro'), (1, 'iPhone 14 Pro Max'),
    (1, 'iPhone 15'), (1, 'iPhone 15 Plus'), (1, 'iPhone 15 Pro'), (1, 'iPhone 15 Pro Max'),
    (1, 'iPhone 16'), (1, 'iPhone 16 Pro'), (1, 'iPhone 16 Pro Max'),
    -- Samsung (2)
    (2, 'Galaxy A04s'), (2, 'Galaxy A05s'), (2, 'Galaxy A13'), (2, 'Galaxy A14'), (2, 'Galaxy A15'),
    (2, 'Galaxy A23'), (2, 'Galaxy A24'), (2, 'Galaxy A25'), (2, 'Galaxy A33'), (2, 'Galaxy A34'), (2, 'Galaxy A35'),
    (2, 'Galaxy A52s'), (2, 'Galaxy A53'), (2, 'Galaxy A54'), (2, 'Galaxy A55'),
    (2, 'Galaxy S21 FE'), (2, 'Galaxy S22'), (2, 'Galaxy S22 Ultra'), (2, 'Galaxy S23'), (2, 'Galaxy S23 FE'), (2, 'Galaxy S23 Ultra'),
    (2, 'Galaxy S24'), (2, 'Galaxy S24 Ultra'), (2, 'Galaxy Z Flip5'), (2, 'Galaxy Z Fold5'),
    -- Xiaomi / Redmi / Poco (3)
    (3, 'Redmi Note 10 Pro'), (3, 'Redmi Note 11'), (3, 'Redmi Note 11S'), (3, 'Redmi Note 11 Pro'),
    (3, 'Redmi Note 12'), (3, 'Redmi Note 12S'), (3, 'Redmi Note 12 Pro'), (3, 'Redmi Note 13'), (3, 'Redmi Note 13 Pro'),
    (3, 'Redmi 12'), (3, 'Redmi 12C'), (3, 'Redmi 13C'), (3, 'Poco M5s'), (3, 'Poco X5 Pro'), (3, 'Poco X6 Pro'), (3, 'Poco F5'), (3, 'Poco F6'),
    -- Tecno (4)
    (4, 'Spark Go 1'), (4, 'Spark 10'), (4, 'Spark 10 Pro'), (4, 'Spark 20'), (4, 'Spark 20C'), (4, 'Spark 20 Pro+'),
    (4, 'Camon 20'), (4, 'Camon 20 Pro'), (4, 'Pova 5'), (4, 'Pova 6 Pro'), (4, 'Camon 30 Pro'),
    -- Infinix (5)
    (5, 'Hot 30'), (5, 'Hot 30i'), (5, 'Note 30'), (5, 'Note 30 Pro'),
    (5, 'Hot 40i'), (5, 'Hot 40 Pro'), (5, 'Note 40'), (5, 'Note 40 Pro'), (5, 'Zero 30'), (5, 'Smart 8'),
    -- Sony (6)
    (6, 'Xperia 10 V'), (6, 'Xperia 5 IV'), (6, 'Xperia 1 V'),
    -- Nokia (7)
    (7, 'G22'), (7, 'G42'), (7, 'C32'), (7, 'X30 5G'),
    -- ZTE (8)
    (8, 'Blade A73'), (8, 'Blade V50'), (8, 'Nubia Neo 5G'), (8, 'Blade V41 Vita'),
    -- Asus (9)
    (9, 'ROG Phone 6'), (9, 'ROG Phone 7'), (9, 'Zenfone 10'), (9, 'ROG Phone 8'),
    -- Lenovo (10)
    (10, 'Legion Y70'), (10, 'K14'), (10, 'Legion Duel 2'),
    -- Huawei (11)
    (11, 'Nova 11i'), (11, 'P60 Pro'), (11, 'Mate 50 Pro'), (11, 'Nova 10 Se'), (11, 'Pura 70'), (11, 'Pura 70 Ultra'), (11, 'Y9a'),
    -- Oppo (12)
    (12, 'Reno 10'), (12, 'Reno 11'), (12, 'Reno 11 Pro'), (12, 'A78'), (12, 'Find N3 Flip'), (12, 'A58'), (12, 'A38'),
    -- Realme (13)
    (13, 'Realme 11 Pro'), (13, 'Realme C55'), (13, 'Realme GT 3'), (13, 'Realme 12 Pro+'), (13, 'Realme C67'), (13, 'Realme C53'),
    -- Honor (14)
    (14, 'Honor 90'), (14, 'Honor X8a'), (14, 'Honor X8b'), (14, 'Magic5 Pro'), (14, 'Honor X9b'), (14, 'Magic6 Lite'), (14, 'Honor 200'), (14, 'Honor X7b'),
    -- Motorola (15)
    (15, 'Moto G84'), (15, 'Moto G54'), (15, 'Edge 40 Pro'), (15, 'Moto G14'), (15, 'Moto G24'), (15, 'Edge 50 Fusion'), (15, 'Edge 50 Pro'), (15, 'Moto G34'),
    -- Google (16)
    (16, 'Pixel 7 Pro'), (16, 'Pixel 8'), (16, 'Pixel 8 Pro'),
    -- OnePlus (17)
    (17, 'OnePlus 11'), (17, 'OnePlus 12'), (17, 'Nord 3'),
    -- Vivo (18)
    (18, 'Vivo V29'), (18, 'Vivo Y36'), (18, 'Vivo V30'),
    -- Nothing (19)
    (19, 'Phone (1)'), (19, 'Phone (2)'), (19, 'Phone (2a)'),
    -- LG (20)
    (20, 'Velvet 5G'), (20, 'Wing 5G'),
    -- Alcatel (21)
    (21, '1B (2022)'), (21, '3L'),
    -- Itel (22)
    (22, 'S23+'), (22, 'P55 5G'), (22, 'A70')
) AS v(idMarca, nombre)
WHERE NOT EXISTS (
    SELECT 1 
    FROM Modelo m 
    WHERE m.idMarca = v.idMarca AND m.nombre = v.nombre
);

INSERT INTO Pantalla (sku, descripcion, calidad, tecnologia, precioVenta, stockTotal)
VALUES ('IP13PRO-OL', 'Pantalla OLED Original iPhone 13 / 13 Pro / 12 Pro', 'OLED Original', 'Capacitiva', 850.00, 150),
       ('SGS22-INC', 'Pantalla Incell Universal Samsung S22 / A54 / S21 FE', 'Incell', 'OGS', 300.00, 150),
       ('XMN10PR-OLED', 'Pantalla OLED Xiaomi Redmi Note 10 Pro / 11S / 11', 'OLED', 'Capacitiva', 350.00, 150),
       ('TCSG1-IPS', 'Pantalla IPS LCD Tecno Spark Go 1 / Spark 10 / 20', 'Original', 'IPS', 180.00, 150),
       ('IFN30PR-AM', 'Pantalla AMOLED Infinix Note 30 Pro / Note 40 Pro', 'Original', 'AMOLED', 320.00, 150),
       ('MTG84-OL', 'Pantalla pOLED Motorola Moto G84 / Edge 40 Pro', 'OLED', 'Capacitiva', 340.00, 150),
       ('HWP60PR-OL', 'Pantalla OLED Curva Huawei P60 Pro / Mate 50 Pro', 'OLED Original', 'LTPO', 780.00, 150),
       ('OPR10-AM', 'Pantalla AMOLED Oppo Reno 10 / Realme 11 Pro', 'OLED', 'Capacitiva', 360.00, 150),
       ('RL11PR-INC', 'Pantalla Incell Realme 11 Pro / C55 / C53', 'Incell', 'OGS', 220.00, 150),
       ('HN90-OL', 'Pantalla OLED Curva Honor 90 / X9b', 'OLED Original', 'AMOLED', 450.00, 150),
       ('IP15PRO-OL', 'Pantalla OLED Original iPhone 15 / 15 Pro / 15 Pro Max', 'OLED Original', 'LTPO', 1250.00, 150),
       ('SGS24-AMO', 'Pantalla Dynamic AMOLED Samsung Galaxy S24 / S24 Ultra', 'AMOLED', 'Capacitiva', 1100.00, 150),
       ('XN13PR-INC', 'Pantalla Incell Redmi Note 13 / Note 13 Pro', 'Incell', 'OGS', 310.00, 150),
       ('SAM54-INC', 'Pantalla Incell Samsung Galaxy A34 / A35 / A54 / A55', 'Incell', 'IPS', 250.00, 150),
       ('IP11-LCD', 'Pantalla LCD In-Cell iPhone 11 / 12 / 12 Mini', 'Incell', 'IPS', 280.00, 150),
       ('OPR11-AMO', 'Pantalla AMOLED Curva Oppo Reno 11 / 11 Pro', 'OLED Original', 'AMOLED', 520.00, 150),
       ('MOTG54-IPS', 'Pantalla IPS Motorola Moto G54 / G14 / G24 / G34', 'Original', 'IPS', 210.00, 150),
       ('HOMX9B-CUR', 'Pantalla Curva AMOLED Honor X9b / Magic6 Lite', 'OLED', 'AMOLED', 610.00, 150),
       ('RL12PR-INC', 'Pantalla Incell Realme 12 Pro+ / C67 / A78', 'Incell', 'OGS', 340.00, 150),
       ('XPOCOX5-AMO', 'Pantalla AMOLED Poco X5 Pro / X6 Pro / F5 / F6', 'Original', 'AMOLED', 410.00, 150),
       ('IP14PM-OL', 'Pantalla OLED Original iPhone 14 / 14 Pro / 14 Pro Max', 'OLED Original', 'LTPO', 1150.00, 150),
       ('IP16PM-OL', 'Pantalla Super Retina OLED iPhone 16 / 16 Pro / 16 Pro Max', 'OLED Original', 'LTPO', 1480.00, 150),
       ('SGA14-IPS', 'Pantalla PLS LCD Samsung Galaxy A13 / A14 / A15 / A24', 'Original', 'IPS', 195.00, 150),
       ('SGS23U-AMO', 'Pantalla Dynamic AMOLED 2X Galaxy S23 / S23 Ultra', 'AMOLED', 'LTPO', 980.00, 150),
       ('SGZFL5-OL', 'Pantalla Plegable OLED Galaxy Z Flip5 / Z Fold5', 'OLED Original', 'AMOLED', 1350.00, 150),
       ('XMN12-AMO', 'Pantalla AMOLED Redmi Note 12 / Note 12S / Note 12 Pro', 'AMOLED', 'Capacitiva', 330.00, 150),
       ('XM13C-IPS', 'Pantalla IPS LCD Redmi 12 / Redmi 13C / Redmi 12C', 'Original', 'IPS', 175.00, 150),
       ('TCCAM20-AM', 'Pantalla AMOLED Tecno Camon 20 / Camon 20 Pro / Camon 30 Pro', 'Original', 'AMOLED', 310.00, 150),
       ('IFH40I-IPS', 'Pantalla IPS 90Hz Infinix Hot 40i / Hot 30i / Smart 8', 'Original', 'IPS', 165.00, 150),
       ('HWN11I-IPS', 'Pantalla FullView IPS Huawei Nova 11i / Nova 10 SE', 'Original', 'IPS', 240.00, 150),
       ('GPX8P-OL', 'Pantalla Super Actua OLED Google Pixel 7 Pro / 8 / 8 Pro', 'OLED Original', 'LTPO', 890.00, 150),
       ('OP12-AMO', 'Pantalla ProXDR AMOLED OnePlus 11 / 12 / Nord 3', 'AMOLED', 'LTPO', 760.00, 150),
       ('VV29-CUR', 'Pantalla AMOLED Curva Vivo V29 / V30 / Y36', 'OLED', 'AMOLED', 490.00, 150),
       ('SNXP1V-OL', 'Pantalla 4K HDR OLED Sony Xperia 1 V / 5 IV / 10 V', 'OLED Original', 'OLED', 820.00, 150),
       ('ASROG7-AM', 'Pantalla 165Hz AMOLED Asus ROG Phone 6 / 7 / 8', 'AMOLED', 'AMOLED', 740.00, 150),
       ('NTHP2-OL', 'Pantalla Flexible LTPO OLED Nothing Phone (1) / (2) / (2a)', 'OLED Original', 'LTPO', 690.00, 150),
       ('LGVLV-OL', 'Pantalla P-OLED Curva LG Velvet 5G / Wing 5G', 'OLED', 'OLED', 540.00, 150),
       ('HWPUR70-OL', 'Pantalla LTPO OLED Huawei Pura 70 / Pura 70 Ultra', 'OLED Original', 'LTPO', 1050.00, 150),
       ('MTEDG50-OL', 'Pantalla pOLED Curva Motorola Edge 50 Fusion / Edge 50 Pro', 'OLED Original', 'LTPO', 580.00, 150),
       ('HN200-AM', 'Pantalla AMOLED Curva Honor 200 / Honor X8b', 'AMOLED', 'AMOLED', 510.00, 150),
       ('IP13PM-INC', 'Pantalla Incell Económica iPhone 13 Pro Max / 14 Plus', 'Incell', 'IPS', 390.00, 150),
       ('IP11PM-OL', 'Pantalla OLED Soft iPhone 11 Pro / 11 Pro Max', 'OLED', 'OLED', 620.00, 150),
       ('SGS22U-OL', 'Pantalla Dynamic AMOLED Curva Galaxy S22 Ultra', 'OLED Original', 'LTPO', 940.00, 150),
       ('TCPV6-IPS', 'Pantalla FHD+ 120Hz Tecno Pova 5 / Pova 6 Pro', 'Original', 'IPS', 260.00, 150),
       ('IFNT40-AM', 'Pantalla AMOLED 120Hz Infinix Note 40 / Zero 30', 'AMOLED', 'AMOLED', 370.00, 150),
       ('IPX-OL', 'Pantalla OLED Soft iPhone X / XR / XS Max', 'OLED', 'OLED', 330.00, 150),
       ('SGA05-IPS', 'Pantalla PLS LCD Samsung Galaxy A04s / A05s', 'Original', 'IPS', 160.00, 150),
       ('SGA52S-AM', 'Pantalla Super AMOLED Galaxy A52s / A33 / S23 FE', 'AMOLED', 'AMOLED', 420.00, 150),
       ('XMPM5-IPS', 'Pantalla FHD+ IPS Poco M5s / Redmi Note 11 Pro', 'Original', 'IPS', 235.00, 150),
       ('TCSPK20C-IPS', 'Pantalla HD+ 90Hz Tecno Spark 20C / Itel A70', 'Original', 'IPS', 155.00, 150),
       ('ITLS23P-AM', 'Pantalla AMOLED Curva Itel S23+ / P55 5G', 'AMOLED', 'AMOLED', 290.00, 150),
       ('OPA38-IPS', 'Pantalla IPS 90Hz Oppo A38 / A58 / Realme C53', 'Original', 'IPS', 190.00, 150),
       ('HNX7B-IPS', 'Pantalla FHD+ 90Hz Honor X7b / Huawei Y9a', 'Original', 'IPS', 225.00, 150),
       ('ALC3L-IPS', 'Pantalla HD+ Alcatel 1B (2022) / 3L', 'Original', 'IPS', 135.00, 150),
       ('ZTENUB-IPS', 'Pantalla 120Hz ZTE Nubia Neo 5G / Blade V50', 'Original', 'IPS', 245.00, 150);

INSERT INTO Compatibilidad(idPantalla, idModelo)
SELECT v.idPantalla, m.id
FROM (VALUES
    (1, 'iPhone 13 Pro'), (1, 'iPhone 13'), (1, 'iPhone 12 Pro'),
    (2, 'Galaxy S22'), (2, 'Galaxy A54'), (2, 'Galaxy S21 FE'),
    (3, 'Redmi Note 10 Pro'), (3, 'Redmi Note 11'), (3, 'Redmi Note 11S'),
    (4, 'Spark Go 1'), (4, 'Spark 10'), (4, 'Spark 20'), (4, 'Hot 40i'),
    (5, 'Note 30 Pro'), (5, 'Hot 30'), (5, 'Note 40 Pro'), (5, 'Camon 20'),
    (6, 'Moto G84'), (6, 'Edge 40 Pro'), (6, 'Xperia 5 IV'),
    (7, 'P60 Pro'), (7, 'Mate 50 Pro'), (7, 'Pura 70'),
    (8, 'Reno 10'), (8, 'Realme 11 Pro'), (8, 'Blade A73'),
    (9, 'Realme 11 Pro'), (9, 'Realme C55'), (9, 'ROG Phone 7'),
    (10, 'Honor 90'), (10, 'Honor X9b'), (10, 'Legion Y70'),
    (11, 'iPhone 15 Pro Max'), (11, 'iPhone 15 Pro'), (11, 'iPhone 15'), (11, 'iPhone 15 Plus'),
    (12, 'Galaxy S24 Ultra'), (12, 'Galaxy S24'), (12, 'Galaxy S23 Ultra'),
    (13, 'Redmi Note 13 Pro'), (13, 'Redmi Note 13'), (13, 'Redmi Note 12 Pro'),
    (14, 'Galaxy A54'), (14, 'Galaxy A34'), (14, 'Galaxy A55'), (14, 'Galaxy A35'), (14, 'Galaxy A53'),
    (15, 'iPhone 11'), (15, 'iPhone 12'), (15, 'iPhone 12 Mini'),
    (16, 'Reno 11 Pro'), (16, 'Reno 11'), (16, 'Find N3 Flip'),
    (17, 'Moto G54'), (17, 'Moto G14'), (17, 'Moto G24'), (17, 'Moto G34'),
    (18, 'Honor X9b'), (18, 'Magic6 Lite'), (18, 'Honor X8b'),
    (19, 'Realme 12 Pro+'), (19, 'Realme C67'), (19, 'A78'), (19, 'A58'),
    (20, 'Poco X5 Pro'), (20, 'Poco X6 Pro'), (20, 'Poco F5'), (20, 'Poco F6'),
    (21, 'iPhone 14 Pro Max'), (21, 'iPhone 14 Pro'), (21, 'iPhone 14'),
    (22, 'iPhone 16 Pro Max'), (22, 'iPhone 16 Pro'), (22, 'iPhone 16'),
    (23, 'Galaxy A14'), (23, 'Galaxy A15'), (23, 'Galaxy A24'), (23, 'Galaxy A13'), (23, 'Galaxy A23'), (23, 'Galaxy A25'),
    (24, 'Galaxy S23 Ultra'), (24, 'Galaxy S23'),
    (25, 'Galaxy Z Flip5'), (25, 'Galaxy Z Fold5'),
    (26, 'Redmi Note 12'), (26, 'Redmi Note 12S'), (26, 'Redmi Note 12 Pro'),
    (27, 'Redmi 13C'), (27, 'Redmi 12'), (27, 'Redmi 12C'), (27, 'Smart 8'),
    (28, 'Camon 20'), (28, 'Camon 20 Pro'), (28, 'Camon 30 Pro'),
    (29, 'Hot 40i'), (29, 'Smart 8'), (29, 'Hot 30i'), (29, 'Spark Go 1'),
    (30, 'Nova 11i'), (30, 'Nova 10 Se'),
    (31, 'Pixel 8 Pro'), (31, 'Pixel 8'), (31, 'Pixel 7 Pro'),
    (32, 'OnePlus 12'), (32, 'OnePlus 11'), (32, 'Nord 3'),
    (33, 'Vivo V29'), (33, 'Vivo V30'), (33, 'Vivo Y36'),
    (34, 'Xperia 1 V'), (34, 'Xperia 5 IV'), (34, 'Xperia 10 V'),
    (35, 'ROG Phone 7'), (35, 'ROG Phone 8'), (35, 'ROG Phone 6'),
    (36, 'Phone (1)'), (36, 'Phone (2)'), (36, 'Phone (2a)'),
    (37, 'Velvet 5G'), (37, 'Wing 5G'),
    (38, 'Pura 70'), (38, 'Pura 70 Ultra'),
    (39, 'Edge 50 Fusion'), (39, 'Edge 50 Pro'),
    (40, 'Honor 200'), (40, 'Honor X8b'), (40, 'Honor X8a'),
    (41, 'iPhone 13 Pro Max'), (41, 'iPhone 14 Plus'),
    (42, 'iPhone 11 Pro'), (42, 'iPhone 11 Pro Max'),
    (43, 'Galaxy S22 Ultra'),
    (44, 'Pova 5'), (44, 'Pova 6 Pro'),
    (45, 'Note 40'), (45, 'Zero 30'), (45, 'Hot 40 Pro'),
    (46, 'iPhone X'), (46, 'iPhone XR'), (46, 'iPhone XS Max'),
    (47, 'Galaxy A04s'), (47, 'Galaxy A05s'),
    (48, 'Galaxy A52s'), (48, 'Galaxy A33'), (48, 'Galaxy S23 FE'),
    (49, 'Poco M5s'), (49, 'Redmi Note 11 Pro'),
    (50, 'Spark 20C'), (50, 'A70'),
    (51, 'S23+'), (51, 'P55 5G'),
    (52, 'A38'), (52, 'A58'), (52, 'Realme C53'),
    (53, 'Honor X7b'), (53, 'Y9a'),
    (54, '1B (2022)'), (54, '3L'),
    (55, 'Nubia Neo 5G'), (55, 'Blade V50')
) AS v(idPantalla, nombreModelo)
INNER JOIN Modelo m
    ON m.nombre = v.nombreModelo
   AND m.estado = 1
WHERE NOT EXISTS (
    SELECT 1
    FROM Compatibilidad c
    WHERE c.idPantalla = v.idPantalla
      AND c.idModelo = m.id
);

INSERT INTO Cliente (nitCi, nombres, primerApellido, segundoApellido, razonSocial, telefono, direccion, tipoCliente) 
VALUES ('0', 'Consumidor', 'Final', NULL, NULL, '0000000', 'Sin Dirección', 'Consumidor Final'),
       ('6543210', 'Pedro', 'Guzman', 'Vargas', NULL, '72345678', 'Av. Las Américas #12, Sucre', 'Minorista'),
       ('5432109012', NULL, NULL, NULL, 'Servicios Técnicos Celular Express', '71234567', 'Calle España #210, Sucre', 'Técnico Mayorista'),
       ('7894561', 'Laura', 'Paredes', 'Salazar', 'Laura Paredes', '76541230', 'Calle Ayacucho #45, Potosí', 'Minorista'),
       ('1029384015', 'Empresa', 'Representante', 'Legal', 'Importadora Móvil Bolivia S.R.L.', '70112233', 'Av. Camacho #1150, La Paz', 'Técnico Mayorista'),
       ('4561239', 'Roberto', 'Condori', 'Choque', 'Roberto Condori', '73098765', 'Zona 16 de Julio, Calle 3 #88, El Alto', 'Minorista'),
       ('8877665019', 'Empresa', 'Representante', 'Legal', 'Centro de Reparaciones TechFix', '75432198', 'Av. Blanco Galindo Km 4, Cochabamba', 'Técnico Mayorista'),
       ('3216548', 'Valeria', 'Montaño', 'Ríos', 'Valeria Montaño', '79876543', 'Calle Sucre #310, Tarija', 'Minorista'),
       ('9988776', 'Diego', 'Fernández', 'Alarcón', 'Diego Fernández', '71987654', 'Av. Ballivián #720, La Paz', 'Minorista'),
       ('2030405011', 'Empresa', 'Representante', 'Legal', 'Mundo Digital y Repuestos', '74125896', 'Calle Huyustus #540, La Paz', 'Técnico Mayorista'),
       ('4125896', 'Oscar', 'Miranda', 'Tapia', 'Oscar Miranda', '72985412', 'Calle Bolívar #145, Oruro', 'Minorista'),
       ('7418529014', NULL, NULL, NULL, 'Doctor Celular Santa Cruz S.R.L.', '76321458', 'Av. Cañoto #410, Santa Cruz', 'Técnico Mayorista'),
       ('8529634', 'Gabriela', 'Soliz', 'Antelo', 'Gabriela Soliz', '77854123', 'Calle 24 de Septiembre #190, Santa Cruz', 'Minorista'),
       ('9638527', 'Hugo', 'Villarroel', 'Céspedes', 'Hugo Villarroel', '71458963', 'Av. América #820, Cochabamba', 'Minorista'),
       ('3040506018', NULL, NULL, NULL, 'Laboratorio Móvil del Sur', '72963852', 'Calle General Trigo #312, Tarija', 'Técnico Mayorista'),
       ('1472583', 'Patricia', 'Lozada', 'Gutiérrez', 'Patricia Lozada', '76147258', 'Av. 6 de Agosto #510, Trinidad', 'Minorista'),
       ('2583691', 'Esteban', 'Cuéllar', 'Morales', 'Esteban Cuéllar', '78258369', 'Av. Pando #220, Cobija', 'Minorista'),
       ('4050607013', NULL, NULL, NULL, 'Repuestos y Pantallas El Alto', '71593574', 'Av. Juan Pablo II #1020, El Alto', 'Técnico Mayorista'),
       ('3692581', 'Mónica', 'Choquehuanca', 'Quispe', 'Mónica Choquehuanca', '73692581', 'Calle Junín #412, Sucre', 'Minorista'),
       ('5060708019', NULL, NULL, NULL, 'GSM Pro Reparaciones', '75824691', 'Calle Potosí #615, Oruro', 'Técnico Mayorista'),
       ('6070809012', 'Marcelo', 'Ricaldi', 'Flores', 'Marcelo Ricaldi', '72314569', 'Calle Sucre #500, Potosí', 'Minorista'),
       ('7080901015', NULL, NULL, NULL, 'TecnoCell Soluciones Integrales', '79865412', 'Av. San Martín #320, Cochabamba', 'Técnico Mayorista'),
       ('8090102014', 'Claudia', 'Vargas', 'Paz', 'Claudia Vargas', '71239854', 'Calle Beni #110, Santa Cruz', 'Minorista'),
       ('9010203017', NULL, NULL, NULL, 'ServiPhone Bolivia', '74521398', 'Av. 16 de Julio #1400, La Paz', 'Técnico Mayorista'),
       ('1234098011', 'Renán', 'Flores', 'Calani', 'Renán Flores', '76321987', 'Calle Pando #80, Sucre', 'Minorista'),
       ('6712345', 'Alejandro', 'Salvatierra', 'Cruz', NULL, '71894562', 'Calle Arenales #230, Sucre', 'Minorista'),
       ('8945612016', NULL, NULL, NULL, 'SmartFix Microsoldadura', '76981234', 'Av. Hernando Siles #890, Sucre', 'Técnico Mayorista'),
       ('5412398', 'Mariana', 'Villca', 'Orellana', NULL, '72456891', 'Calle Dalence #112, Sucre', 'Minorista'),
       ('7744112018', NULL, NULL, NULL, 'iStore Repuestos Bolivia', '75129874', 'Av. Cristóbal de Mendoza #340, Santa Cruz', 'Técnico Mayorista'),
       ('6123984', 'Javier', 'Torrico', 'Mendoza', NULL, '78451236', 'Av. Pando #415, Cochabamba', 'Minorista'),
       ('7312456', 'Fabiana', 'Quispe', 'Mamani', NULL, '71542369', 'Calle Colón #310, La Paz', 'Minorista'),
       ('9123456014', NULL, NULL, NULL, 'MegaScreen Importaciones S.R.L.', '76451289', 'Av. El Trompillo #620, Santa Cruz', 'Técnico Mayorista'),
       ('8412365', 'Rodrigo', 'Aramayo', 'Zeballos', NULL, '72984512', 'Calle Olañeta #145, Sucre', 'Minorista'),
       ('6512389', 'Paola', 'Céspedes', 'Rivero', NULL, '77451296', 'Calle Sucre #610, Santa Cruz', 'Minorista'),
       ('5123987012', NULL, NULL, NULL, 'Centro Técnico Apple & Android', '71984563', 'Av. Ballivián #980, Cochabamba', 'Técnico Mayorista'),
       ('7912348', 'Mauricio', 'Pinto', 'Aguilar', NULL, '76129845', 'Calle Bolívar #420, Tarija', 'Minorista'),
       ('8234561', 'Daniela', 'Ortuño', 'Soria', NULL, '72541298', 'Calle Ayacucho #215, Sucre', 'Minorista'),
       ('6345128019', NULL, NULL, NULL, 'FixIt Bolivia S.A.', '74129856', 'Av. Arce #1890, La Paz', 'Técnico Mayorista'),
       ('9456123', 'Cristian', 'Choque', 'Yujra', NULL, '71854236', 'Av. 6 de Marzo #750, El Alto', 'Minorista'),
       ('7561234', 'Verónica', 'Méndez', 'Castro', NULL, '76984512', 'Calle La Paz #330, Oruro', 'Minorista'),
       ('8671234011', NULL, NULL, NULL, 'Digital Parts Potosí', '78451296', 'Calle Hoyos #190, Potosí', 'Técnico Mayorista'),
       ('6781234', 'Sergio', 'Balderrama', 'Paz', NULL, '77124589', 'Av. América #1120, Cochabamba', 'Minorista'),
       ('5891234', 'Andrea', 'Navarro', 'Lema', NULL, '76541289', 'Calle General Trigo #450, Tarija', 'Minorista'),
       ('7901234015', NULL, NULL, NULL, 'Pantallas Express Beni', '73124589', 'Av. 6 de Agosto #710, Trinidad', 'Técnico Mayorista'),
       ('8012345', 'Luis Fernando', 'Gutiérrez', 'Roca', NULL, '78945123', 'Av. Tte. Cornejo #310, Cobija', 'Minorista'),
       ('6112233', 'Natalia', 'Serrano', 'Daza', NULL, '71245896', 'Calle Loa #340, Sucre', 'Minorista'),
       ('7223344012', NULL, NULL, NULL, 'MovilTech Sucre S.R.L.', '76451298', 'Av. Venezuela #510, Sucre', 'Técnico Mayorista'),
       ('8334455', 'Fernando', 'Caballero', 'Ruiz', NULL, '72984561', 'Zona El Tejar, Calle 4 #22, Sucre', 'Minorista'),
       ('9445566018', NULL, NULL, NULL, 'CellMaster Bolivia', '75412369', 'Av. Banzer Km 3, Santa Cruz', 'Técnico Mayorista'),
       ('5556677', 'Camila', 'Velásquez', 'Ortiz', NULL, '71985412', 'Calle Potosí #890, La Paz', 'Minorista'),
       ('6667788015', NULL, NULL, NULL, 'Pantallas y Táctiles Cochabamba', '77412589', 'Calle Esteban Arze #420, Cochabamba', 'Técnico Mayorista'),
       ('7778899', 'Eduardo', 'Salinas', 'Chávez', NULL, '76123987', 'Calle 15 de Abril #210, Tarija', 'Minorista'),
       ('8889900', 'Patricia', 'Rocabado', 'Vega', NULL, '72345123', 'Calle Bolívar #610, Oruro', 'Minorista'),
       ('9990011014', NULL, NULL, NULL, 'Refacciones Móviles El Alto', '71569842', 'Ceja El Alto, Calle 1 #55, El Alto', 'Técnico Mayorista'),
       ('4112233', 'Gonzalo', 'Molina', 'Paredes', NULL, '78412563', 'Calle Bustillos #410, Potosí', 'Minorista'),
       ('5223344', 'Silvia', 'Terrazas', 'Lozano', NULL, '73412589', 'Av. Germán Busch #320, Trinidad', 'Minorista'),
       ('6334455011', NULL, NULL, NULL, 'Pando Celular Service', '78912345', 'Av. 9 de Febrero #180, Cobija', 'Técnico Mayorista'),
       ('7445566', 'Marco Antonio', 'Zeballos', 'Prado', NULL, '72654987', 'Calle Calvo #190, Sucre', 'Minorista'),
       ('8556677019', NULL, NULL, NULL, 'Doctor Pantalla S.R.L.', '75698412', 'Av. Irala #480, Santa Cruz', 'Técnico Mayorista'),
       ('9667788', 'Karina', 'Peñaranda', 'Soliz', NULL, '71894512', 'Av. Villazón Km 2, Cochabamba', 'Minorista');

INSERT INTO Proveedor (razonSocial, pais, contactoPersona, telefono)
VALUES ('Shenzhen Mobile Parts Co., Ltd.', 'China', 'Wei Chen', '+86 755 8321 4567'),
       ('Global Tech Screens S.A.', 'Estados Unidos', 'Michael Carter', '+1 305 555 0192'),
       ('Importadora Repuestos Andinos S.R.L.', 'Bolivia', 'Carlos Torrico', '+591 71543210'),
       ('Guangzhou OLED Display Ltd.', 'China', 'Li Na', '+86 20 8765 1234'),
       ('Distribuidora Móvil del Sur', 'Chile', 'Javier Soto', '+56 9 8765 4321'),
       ('Panamá Electronics Wholesale Corp.', 'Panamá', 'Sofía Morales', '+507 6234 5678'),
       ('TechSupply Hong Kong Limited', 'Hong Kong', 'Kevin Wong', '+852 2345 6789'),
       ('Insumos Celulares Pacífico S.A.C.', 'Perú', 'Andrés Quispe', '+51 987 654 321'),
       ('Korea Display Solutions Inc.', 'Corea del Sur', 'Min-ho Park', '+82 2 3456 7890'),
       ('Comercializadora Digital Mercosur', 'Brasil', 'Lucas Silva', '+55 11 98765 4321'),
       ('Shenzhen Huaqiangbei LCD Group', 'China', 'Zhang Wei', '+86 755 8899 1122'),
       ('Miami Wireless Parts LLC', 'Estados Unidos', 'David Gómez', '+1 786 555 0144'),
       ('Taipei Amoled Tech Corp.', 'Taiwán', 'Chen Lin', '+886 2 2345 6789'),
       ('Iquique Zona Franca Móvil Ltda.', 'Chile', 'Patricio Muñoz', '+56 57 241 8899'),
       ('Bolivian Tech Distribution S.A.', 'Bolivia', 'Fernanda Ríos', '+591 77412589'),
       ('Dragon Display Components Ltd.', 'China', 'Liu Yang', '+86 755 6677 8899'),
       ('Arica Import & Export Mobile', 'Chile', 'RodrigoTapia', '+56 58 222 4455'),
       ('Lima Telecom Repuestos S.A.', 'Perú', 'Valeria Huamán', '+51 945 123 789'),
       ('Colon Free Zone Tech Trading', 'Panamá', 'Ricardo Méndez', '+507 6890 1234'),
       ('Altiplano Digital Importaciones', 'Bolivia', 'Jorge Mamani', '+591 71258963');
INSERT INTO Compra (idProveedor, idEmpleado, fechaCompra, factura, costoTotal)
VALUES (1, 1, '2026-09-01', 'FAC-1001', 5400.00),
       (2, 1, '2026-09-05', 'FAC-1002', 3200.50),
       (3, 1, '2026-09-10', 'FAC-1003', 1500.00),
       (4, 1, '2026-09-15', 'FAC-1004', 5300.25),
       (5, 1, '2026-09-20', 'FAC-1005', 2800.00),
       (6, 1, '2026-09-25', 'FAC-1006', 3900.75),
       (7, 1, '2026-10-01', 'FAC-1007', 4600.00),
       (8, 1, '2026-10-05', 'FAC-1008', 2100.50),
       (9, 1, '2026-10-10', 'FAC-1009', 6200.00),
       (10, 1, '2026-10-12', 'FAC-1010', 3100.25),
       (1, 1, '2026-10-15', 'FAC-1011', 4100.00),
       (2, 1, '2026-10-20', 'FAC-1012', 2500.00),
       (3, 1, '2026-10-25', 'FAC-1013', 4850.00),
       (4, 1, '2026-11-01', 'FAC-1014', 7100.00),
       (5, 1, '2026-11-05', 'FAC-1015', 3300.00),
       (6, 1, '2026-11-08', 'FAC-1016', 4200.00),
       (7, 1, '2026-11-10', 'FAC-1017', 5900.50),
       (8, 1, '2026-11-12', 'FAC-1018', 2750.00),
       (9, 1, '2026-11-14', 'FAC-1019', 8300.00),
       (10, 1, '2026-11-15', 'FAC-1020', 3450.00),
       (11, 1, '2026-11-15', 'FAC-1021', 6400.00),
       (12, 1, '2026-11-15', 'FAC-1022', 4950.00),
       (13, 1, '2026-11-15', 'FAC-1023', 5120.00),
       (14, 1, '2026-11-16', 'FAC-1024', 3890.00),
       (15, 1, '2026-11-16', 'FAC-1025', 2980.00),
       (1, 1, '2026-11-16', 'FAC-1026', 7250.00),
       (4, 1, '2026-11-16', 'FAC-1027', 6180.00),
       (9, 1, '2026-11-16', 'FAC-1028', 8900.00),
       (11, 1, '2026-11-16', 'FAC-1029', 4320.00),
       (14, 1, '2026-11-16', 'FAC-1030', 5600.00),
       (16, 1, '2026-11-16', 'FAC-1031', 4150.00),
       (17, 1, '2026-11-16', 'FAC-1032', 2890.00),
       (18, 1, '2026-11-16', 'FAC-1033', 3670.00),
       (19, 1, '2026-11-16', 'FAC-1034', 5240.00),
       (20, 1, '2026-11-16', 'FAC-1035', 1980.00),
       (2, 1, '2026-11-16', 'FAC-1036', 6700.00),
       (6, 1, '2026-11-16', 'FAC-1037', 4410.00),
       (12, 1, '2026-11-16', 'FAC-1038', 7820.00),
       (15, 1, '2026-11-16', 'FAC-1039', 3120.00),
       (16, 1, '2026-11-16', 'FAC-1040', 5950.00);

INSERT INTO CompraDetalle (idCompra, idPantalla, cantidad, costoUnitario, subtotal)
VALUES (1, 1, 10, 540.00, 5400.00),
       (2, 2, 16, 200.00, 3200.50),
       (3, 4, 15, 100.00, 1500.00),
       (4, 10, 18, 294.45, 5300.25),
       (5, 15, 16, 175.00, 2800.00),
       (6, 20, 15, 260.05, 3900.75),
       (7, 11, 5, 920.00, 4600.00),
       (8, 17, 15, 140.00, 2100.50),
       (9, 12, 8, 775.00, 6200.00),
       (10, 13, 16, 193.75, 3100.25),
       (11, 21, 5, 820.00, 4100.00),
       (12, 23, 20, 125.00, 2500.00),
       (13, 24, 7, 692.85, 4850.00),
       (14, 25, 8, 887.50, 7100.00),
       (15, 26, 15, 220.00, 3300.00),
       (16, 28, 20, 210.00, 4200.00),
       (17, 31, 10, 590.05, 5900.50),
       (18, 30, 18, 152.77, 2750.00),
       (19, 22, 8, 1037.50, 8300.00),
       (20, 33, 10, 345.00, 3450.00),
       (21, 34, 11, 581.81, 6400.00),
       (22, 35, 9, 550.00, 4950.00),
       (23, 36, 11, 465.45, 5120.00),
       (24, 37, 10, 389.00, 3890.00),
       (25, 38, 4, 745.00, 2980.00),
       (26, 39, 19, 381.57, 7250.00),
       (27, 40, 18, 343.33, 6180.00),
       (28, 43, 13, 684.61, 8900.00),
       (29, 44, 24, 180.00, 4320.00),
       (30, 45, 22, 254.54, 5600.00),
       (31, 46, 18, 230.55, 4150.00),
       (32, 47, 26, 111.15, 2890.00),
       (33, 48, 13, 282.30, 3670.00),
       (34, 49, 32, 163.75, 5240.00),
       (35, 50, 18, 110.00, 1980.00),
       (36, 51, 33, 203.03, 6700.00),
       (37, 52, 33, 133.63, 4410.00),
       (38, 53, 50, 156.40, 7820.00),
       (39, 54, 32, 97.50, 3120.00),
       (40, 55, 35, 170.00, 5950.00);

INSERT INTO Inventario(idSucursal, idPantalla, stockActual, stockMinimo)
SELECT s.idSucursal, p.idPantalla, 15, 3
FROM (VALUES (1),(2),(3),(4),(5),(6),(7),(8),(9),(10)) s(idSucursal)
CROSS JOIN (VALUES (1),(2),(3),(4),(5),(6),(7),(8),(9),(10),(11),(12),(13),(14),(15),(16),(17),(18),(19),(20)) p(idPantalla)
WHERE NOT EXISTS (
    SELECT 1 FROM Inventario i
    WHERE i.idSucursal = s.idSucursal AND i.idPantalla = p.idPantalla
);


INSERT INTO Venta (idCliente, idEmpleado, idSucursal, fechaVenta, tipoPago, montoTotal)
VALUES (2, 2, 1, '2026-10-02', 'Efectivo', 850.00),
       (3, 3, 1, '2026-10-03', 'QR', 650.00),
       (4, 4, 2, '2026-10-04', 'Transferencia', 300.00),
       (5, 5, 2, '2026-10-05', 'Efectivo', 700.00),
       (11, 6, 3, '2026-10-06', 'QR', 350.00),
       (6, 8, 4, '2026-10-07', 'Efectivo', 180.00),
       (7, 10, 5, '2026-10-08', 'Transferencia', 640.00),
       (12, 12, 6, '2026-10-09', 'QR', 340.00),
       (8, 14, 7, '2026-10-10', 'Efectivo', 780.00),
       (9, 16, 8, '2026-10-11', 'Transferencia', 360.00),
       (16, 18, 9, '2026-10-12', 'Efectivo', 440.00),
       (17, 20, 10, '2026-10-13', 'QR', 900.00),
       (10, 7, 3, '2026-10-14', 'Efectivo', 500.00),
       (13, 9, 4, '2026-10-15', 'Transferencia', 1200.00),
       (14, 11, 5, '2026-10-18', 'QR', 450.00),
       (15, 13, 6, '2026-10-20', 'Efectivo', 850.00),
       (18, 15, 7, '2026-10-22', 'Transferencia', 1100.00),
       (19, 17, 8, '2026-10-25', 'QR', 310.00),
       (20, 19, 9, '2026-10-28', 'Efectivo', 620.00),
       (21, 21, 10, '2026-10-30', 'Transferencia', 750.00),
       (22, 2, 1, '2026-11-01', 'QR', 1250.00),
       (23, 4, 2, '2026-11-03', 'Efectivo', 1100.00),
       (24, 6, 3, '2026-11-05', 'Transferencia', 310.00),
       (25, 8, 4, '2026-11-07', 'Efectivo', 280.00),
       (2, 10, 5, '2026-11-10', 'QR', 520.00),
       (26, 1, 1, '2026-11-11', 'Efectivo', 1150.00),
       (27, 2, 1, '2026-11-11', 'Transferencia', 2100.00),
       (1, 3, 1, '2026-11-12', 'Efectivo', 340.00),
       (28, 1, 1, '2026-11-12', 'QR', 610.00),
       (29, 14, 7, '2026-11-13', 'Transferencia', 2960.00),
       (30, 12, 6, '2026-11-13', 'Efectivo', 890.00),
       (3, 2, 1, '2026-11-14', 'QR', 1560.00),
       (1, 1, 1, '2026-11-14', 'Efectivo', 250.00),
       (5, 8, 4, '2026-11-15', 'Transferencia', 1960.00),
       (7, 13, 6, '2026-11-15', 'QR', 1350.00),
       (26, 3, 1, '2026-11-15', 'Efectivo', 490.00),
       (27, 1, 1, '2026-11-16', 'Transferencia', 1730.00),
       (1, 2, 1, '2026-11-16', 'Efectivo', 195.00),
       (28, 3, 1, '2026-11-16', 'QR', 760.00),
       (2, 1, 1, '2026-11-16', 'Efectivo', 1190.00),
       (31, 9, 4, '2026-11-16', 'Efectivo', 690.00),
       (32, 15, 7, '2026-11-16', 'Transferencia', 2100.00),
       (33, 2, 1, '2026-11-16', 'QR', 580.00),
       (34, 14, 7, '2026-11-16', 'Efectivo', 510.00),
       (35, 12, 6, '2026-11-16', 'Transferencia', 1480.00),
       (36, 16, 8, '2026-11-16', 'Efectivo', 390.00),
       (37, 3, 1, '2026-11-16', 'Efectivo', 620.00),
       (38, 8, 4, '2026-11-16', 'QR', 940.00),
       (39, 10, 5, '2026-11-16', 'Efectivo', 260.00),
       (40, 6, 3, '2026-11-16', 'Transferencia', 370.00),
       (41, 4, 2, '2026-11-16', 'QR', 1150.00),
       (42, 13, 6, '2026-11-16', 'Efectivo', 820.00),
       (43, 17, 8, '2026-11-16', 'QR', 740.00),
       (44, 18, 9, '2026-11-16', 'Efectivo', 540.00),
       (45, 20, 10, '2026-11-16', 'Transferencia', 1050.00),
       (1, 3, 1, '2026-11-16', 'Efectivo', 280.00),
       (26, 2, 1, '2026-11-16', 'QR', 980.00),
       (27, 3, 1, '2026-11-16', 'Transferencia', 1350.00),
       (28, 2, 1, '2026-11-16', 'Efectivo', 410.00),
       (33, 1, 1, '2026-11-16', 'QR', 1480.00),
       (37, 1, 1, '2026-11-16', 'Efectivo', 520.00),
       (19, 2, 1, '2026-11-16', 'Transferencia', 890.00),
       (25, 3, 1, '2026-11-16', 'Efectivo', 760.00),
       (1, 2, 1, '2026-11-16', 'Efectivo', 175.00),
       (3, 1, 1, '2026-11-16', 'Transferencia', 2460.00),
       (46, 2, 1, '2026-11-16', 'Efectivo', 330.00),
       (47, 3, 1, '2026-11-16', 'Transferencia', 1680.00),
       (48, 2, 1, '2026-11-16', 'QR', 235.00),
       (49, 14, 7, '2026-11-16', 'Transferencia', 1950.00),
       (50, 8, 4, '2026-11-16', 'Efectivo', 420.00),
       (51, 12, 6, '2026-11-16', 'QR', 870.00),
       (52, 16, 8, '2026-11-16', 'Efectivo', 190.00),
       (53, 6, 3, '2026-11-16', 'Transferencia', 450.00),
       (54, 10, 5, '2026-11-16', 'QR', 1140.00),
       (55, 4, 2, '2026-11-16', 'Efectivo', 245.00),
       (56, 18, 9, '2026-11-16', 'QR', 320.00),
       (57, 20, 10, '2026-11-16', 'Transferencia', 680.00),
       (58, 2, 1, '2026-11-16', 'Efectivo', 540.00),
       (59, 15, 7, '2026-11-16', 'Transferencia', 2250.00),
       (60, 13, 6, '2026-11-16', 'QR', 310.00),
       (1, 3, 1, '2026-11-16', 'Efectivo', 160.00),
       (46, 1, 1, '2026-11-16', 'QR', 940.00),
       (47, 2, 1, '2026-11-16', 'Transferencia', 1520.00),
       (48, 3, 1, '2026-11-16', 'Efectivo', 290.00),
       (58, 1, 1, '2026-11-16', 'QR', 740.00),
       (49, 15, 7, '2026-11-16', 'Transferencia', 1860.00),
       (50, 9, 4, '2026-11-16', 'Efectivo', 580.00),
       (51, 13, 6, '2026-11-16', 'Transferencia', 1320.00),
       (54, 11, 5, '2026-11-16', 'Efectivo', 490.00),
       (55, 5, 2, '2026-11-16', 'QR', 610.00),
       (1, 2, 1, '2026-11-16', 'Efectivo', 155.00),
       (2, 3, 1, '2026-11-16', 'QR', 820.00),
       (3, 2, 1, '2026-11-16', 'Transferencia', 1980.00),
       (19, 3, 1, '2026-11-16', 'Efectivo', 370.00),
       (25, 2, 1, '2026-11-16', 'QR', 690.00),
       (46, 3, 1, '2026-11-16', 'Efectivo', 225.00),
       (47, 1, 1, '2026-11-16', 'Transferencia', 2740.00),
       (58, 2, 1, '2026-11-16', 'QR', 480.00),
       (1, 1, 1, '2026-11-16', 'Efectivo', 350.00),
       (27, 2, 1, '2026-11-16', 'Transferencia', 1640.00);

       INSERT INTO VentaDetalle (idVenta, idPantalla, cantidad, precioUnitario, subtotal, observacionGarantia)
VALUES (1, 1, 1, 850.00, 850.00, 'Garantía 30 días por defectos de fábrica'),
       (2, 3, 1, 350.00, 350.00, NULL),
       (2, 2, 1, 300.00, 300.00, NULL),
       (3, 2, 1, 300.00, 300.00, NULL),
       (4, 3, 2, 350.00, 700.00, 'Instalación verificada en tienda'),
       (5, 3, 1, 350.00, 350.00, NULL),
       (6, 4, 1, 180.00, 180.00, NULL),
       (7, 5, 2, 320.00, 640.00, NULL),
       (8, 6, 1, 340.00, 340.00, NULL),
       (9, 7, 1, 780.00, 780.00, 'Garantía 30 días'),
       (10, 8, 1, 360.00, 360.00, NULL),
       (11, 9, 2, 220.00, 440.00, NULL),
       (12, 10, 2, 450.00, 900.00, NULL),
       (13, 14, 2, 250.00, 500.00, NULL),
       (14, 8, 2, 360.00, 720.00, NULL),
       (14, 30, 2, 240.00, 480.00, NULL),
       (15, 10, 1, 450.00, 450.00, NULL),
       (16, 1, 1, 850.00, 850.00, NULL),
       (17, 12, 1, 1100.00, 1100.00, 'Garantía 30 días'),
       (18, 13, 1, 310.00, 310.00, NULL),
       (19, 13, 2, 310.00, 620.00, NULL),
       (20, 14, 3, 250.00, 750.00, NULL),
       (21, 11, 1, 1250.00, 1250.00, 'Garantía 30 días'),
       (22, 12, 1, 1100.00, 1100.00, NULL),
       (23, 13, 1, 310.00, 310.00, NULL),
       (24, 15, 1, 280.00, 280.00, NULL),
       (25, 16, 1, 520.00, 520.00, NULL),
       (26, 21, 1, 1150.00, 1150.00, 'Garantía 30 días'),
       (27, 1, 2, 850.00, 1700.00, 'Pedido técnico mayorista'),
       (27, 17, 2, 200.00, 400.00, NULL),
       (28, 6, 1, 340.00, 340.00, NULL),
       (29, 18, 1, 610.00, 610.00, NULL),
       (30, 22, 2, 1480.00, 2960.00, 'Garantía 30 días'),
       (31, 31, 1, 890.00, 890.00, NULL),
       (32, 7, 2, 780.00, 1560.00, NULL),
       (33, 14, 1, 250.00, 250.00, NULL),
       (34, 24, 2, 980.00, 1960.00, 'Garantía 30 días'),
       (35, 25, 1, 1350.00, 1350.00, 'Pantalla plegable verificada'),
       (36, 33, 1, 490.00, 490.00, NULL),
       (37, 21, 1, 1150.00, 1150.00, NULL),
       (37, 10, 1, 450.00, 450.00, NULL),
       (37, 27, 1, 130.00, 130.00, NULL),
       (38, 23, 1, 195.00, 195.00, NULL),
       (39, 32, 1, 760.00, 760.00, NULL),
       (40, 1, 1, 850.00, 850.00, NULL),
       (40, 6, 1, 340.00, 340.00, NULL),
       (41, 36, 1, 690.00, 690.00, 'Garantía 30 días'),
       (42, 38, 2, 1050.00, 2100.00, 'Pedido técnico mayorista'),
       (43, 39, 1, 580.00, 580.00, NULL),
       (44, 40, 1, 510.00, 510.00, NULL),
       (45, 22, 1, 1480.00, 1480.00, 'Garantía 30 días'),
       (46, 41, 1, 390.00, 390.00, NULL),
       (47, 42, 1, 620.00, 620.00, NULL),
       (48, 43, 1, 940.00, 940.00, 'Garantía 30 días'),
       (49, 44, 1, 260.00, 260.00, NULL),
       (50, 45, 1, 370.00, 370.00, NULL),
       (51, 21, 1, 1150.00, 1150.00, NULL),
       (52, 34, 1, 820.00, 820.00, NULL),
       (53, 35, 1, 740.00, 740.00, NULL),
       (54, 37, 1, 540.00, 540.00, NULL),
       (55, 38, 1, 1050.00, 1050.00, 'Garantía 30 días'),
       (56, 15, 1, 280.00, 280.00, NULL),
       (57, 24, 1, 980.00, 980.00, NULL),
       (58, 25, 1, 1350.00, 1350.00, 'Garantía 30 días'),
       (59, 20, 1, 410.00, 410.00, NULL),
       (60, 22, 1, 1480.00, 1480.00, 'Garantía 30 días'),
       (61, 16, 1, 520.00, 520.00, NULL),
       (62, 31, 1, 890.00, 890.00, NULL),
       (63, 32, 1, 760.00, 760.00, NULL),
       (64, 27, 1, 175.00, 175.00, NULL),
       (65, 11, 1, 1250.00, 1250.00, 'Garantía 30 días'),
       (65, 18, 1, 610.00, 610.00, NULL),
       (65, 2, 2, 300.00, 600.00, 'Pedido técnico mayorista'),
       (66, 46, 1, 330.00, 330.00, NULL),
       (67, 48, 4, 420.00, 1680.00, 'Pedido técnico mayorista'),
       (68, 49, 1, 235.00, 235.00, NULL),
       (69, 51, 5, 290.00, 1450.00, NULL),
       (69, 14, 2, 250.00, 500.00, NULL),
       (70, 48, 1, 420.00, 420.00, NULL),
       (71, 51, 3, 290.00, 870.00, NULL),
       (72, 52, 1, 190.00, 190.00, NULL),
       (73, 53, 2, 225.00, 450.00, NULL),
       (74, 52, 6, 190.00, 1140.00, 'Pedido técnico mayorista'),
       (75, 55, 1, 245.00, 245.00, NULL),
       (76, 5, 1, 320.00, 320.00, NULL),
       (77, 6, 2, 340.00, 680.00, NULL),
       (78, 37, 1, 540.00, 540.00, NULL),
       (79, 1, 2, 850.00, 1700.00, 'Pedido técnico mayorista'),
       (79, 27, 2, 275.00, 550.00, NULL),
       (80, 13, 1, 310.00, 310.00, NULL),
       (81, 47, 1, 160.00, 160.00, NULL),
       (82, 43, 1, 940.00, 940.00, 'Garantía 30 días'),
       (83, 32, 2, 760.00, 1520.00, 'Pedido técnico mayorista'),
       (84, 51, 1, 290.00, 290.00, NULL),
       (85, 35, 1, 740.00, 740.00, NULL),
       (86, 42, 3, 620.00, 1860.00, 'Pedido técnico mayorista'),
       (87, 39, 1, 580.00, 580.00, NULL),
       (88, 26, 4, 330.00, 1320.00, 'Pedido técnico mayorista'),
       (89, 33, 1, 490.00, 490.00, NULL),
       (90, 18, 1, 610.00, 610.00, NULL),
       (91, 50, 1, 155.00, 155.00, NULL),
       (92, 34, 1, 820.00, 820.00, NULL),
       (93, 24, 2, 980.00, 1960.00, 'Pedido técnico mayorista'),
       (94, 45, 1, 370.00, 370.00, NULL),
       (95, 36, 1, 690.00, 690.00, NULL),
       (96, 53, 1, 225.00, 225.00, NULL),
       (97, 22, 1, 1480.00, 1480.00, 'Garantía 30 días'),
       (97, 42, 2, 620.00, 1240.00, NULL),
       (98, 30, 2, 240.00, 480.00, NULL),
       (99, 3, 1, 350.00, 350.00, NULL),
       (100, 1, 1, 850.00, 850.00, 'Pedido técnico mayorista'),
       (100, 41, 2, 395.00, 790.00, NULL);
GO


SELECT * FROM Rol;
SELECT * FROM Empleado;
SELECT * FROM Usuario;
SELECT * FROM Marca;
SELECT * FROM Modelo;
SELECT * FROM Pantalla;
SELECT * FROM Inventario;
SELECT * FROM Sucursal;
SELECT * FROM Cliente;
SELECT * FROM Venta;