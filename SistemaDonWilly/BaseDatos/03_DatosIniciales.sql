/* ============================================================
   SISTEMA DON WILLY
   Script 03: datos iniciales de demostracion
   Claves de acceso (SHA-256 con sal, RNF-02):
     admin   / admin123     ADMINISTRADOR
     mesera  / mesera123    MESERA
     cocina  / cocina123    COCINA
     cajera  / cajera123    CAJERA
     almacen / almacen123   ALMACEN
   ============================================================ */

USE BD_DonWilly;
GO

/* ---------- Perfiles ---------- */
INSERT INTO Perfil (nombre) VALUES
('ADMINISTRADOR'), ('MESERA'), ('COCINA'), ('CAJERA'), ('ALMACEN');
GO

/* ---------- Unidades de medida ---------- */
INSERT INTO UnidadMedida (nombre, abreviatura) VALUES
('Kilogramo', 'kg'), ('Gramo', 'g'), ('Litro', 'L'),
('Unidad', 'und'), ('Atado', 'ata'), ('Saco', 'sac');
GO

/* ---------- Insumos ---------- */
INSERT INTO Insumo (nombre, idUnidad) VALUES
('Arroz extra',        (SELECT idUnidad FROM UnidadMedida WHERE abreviatura = 'kg')),
('Pollo entero',       (SELECT idUnidad FROM UnidadMedida WHERE abreviatura = 'kg')),
('Papa amarilla',      (SELECT idUnidad FROM UnidadMedida WHERE abreviatura = 'kg')),
('Aceite vegetal',     (SELECT idUnidad FROM UnidadMedida WHERE abreviatura = 'L')),
('Cebolla roja',       (SELECT idUnidad FROM UnidadMedida WHERE abreviatura = 'kg')),
('Limon',              (SELECT idUnidad FROM UnidadMedida WHERE abreviatura = 'kg')),
('Culantro',           (SELECT idUnidad FROM UnidadMedida WHERE abreviatura = 'ata')),
('Gaseosa personal',   (SELECT idUnidad FROM UnidadMedida WHERE abreviatura = 'und'));
GO

/* ---------- Productos de la carta ---------- */
INSERT INTO Producto (nombre, tipoProducto, precio, disponible) VALUES
('Menu del dia',            'MENU',   12.00, 1),
('Arroz con pollo',         'PLATO',  18.00, 1),
('Ceviche mixto',           'PLATO',  28.00, 1),
('Lomo saltado',            'PLATO',  26.00, 1),
('Sopa criolla',            'PLATO',  14.00, 1),
('Chicha morada (jarra)',   'BEBIDA', 10.00, 1),
('Gaseosa personal',        'BEBIDA',  4.50, 1),
('Agua mineral',            'BEBIDA',  3.00, 1);
GO

/* ---------- Mesas ---------- */
INSERT INTO Mesa (codigo, ubicacion, capacidad) VALUES
('M-01', 'Salon principal', 4), ('M-02', 'Salon principal', 4),
('M-03', 'Salon principal', 6), ('M-04', 'Terraza', 2),
('M-05', 'Terraza', 4), ('M-06', 'Segundo piso', 8);
GO

/* ---------- Proveedores ---------- */
INSERT INTO Proveedor (razonSocial, documento, direccion, telefono) VALUES
('Distribuidora Mayorista La Hermelinda', '20481234567', 'Av. Los Incas 1200, Trujillo', '044-123456'),
('Avicola El Granjero EIRL',              '20567891234', 'Mercado Zonal Palermo, Trujillo', '949112233'),
('Abarrotes Don Pepe',                    '10456789123', 'Jr. Union 455, Trujillo', '958774411');
GO

/* ---------- Trabajadores ---------- */
INSERT INTO Trabajador (documento, nombres, apellidos, cargo, telefono) VALUES
('70112233', 'Willy',   'Rodriguez Paz',   'Administrador',        '949001122'),
('70223344', 'Rosa',    'Chavez Milla',    'Mesera',               '949002233'),
('70334455', 'Julio',   'Vargas Leon',     'Personal de cocina',   '949003344'),
('70445566', 'Carmen',  'Diaz Soto',       'Cajera',               '949004455'),
('70556677', 'Marco',   'Paredes Ruiz',    'Encargado de almacen', '949005566');
GO

/* ---------- Usuarios y perfiles ---------- */
INSERT INTO Usuario (idTrabajador, nomUsuario, claveHash, claveSal) VALUES
((SELECT idTrabajador FROM Trabajador WHERE documento = '70112233'), 'admin',
 '6QnBVoXwWfwWAl4xczmw8Tau4lVbstD6NgsParZrz5A=', 'S4lDonWilly01'),
((SELECT idTrabajador FROM Trabajador WHERE documento = '70223344'), 'mesera',
 'QQ7zx+SA48PRd1D8GRRmYhLCfgMdRgPtBttq9+Gtf70=', 'S4lDonWilly02'),
((SELECT idTrabajador FROM Trabajador WHERE documento = '70334455'), 'cocina',
 '8GrZGdyCt1o4BzUAFjTHP06EPul6MiaEKgM2LVes0/A=', 'S4lDonWilly03'),
((SELECT idTrabajador FROM Trabajador WHERE documento = '70445566'), 'cajera',
 '9oqy3U9sNvQDhFQC0BI/kAPQk3G9G8n3wN0i/b1vFfg=', 'S4lDonWilly04'),
((SELECT idTrabajador FROM Trabajador WHERE documento = '70556677'), 'almacen',
 'IlQPddytcaGSu7XHkx1wSeaxCVD57rJsh9sKGfEQWPM=', 'S4lDonWilly05');
GO

INSERT INTO UsuarioPerfil (idUsuario, idPerfil)
SELECT u.idUsuario, p.idPerfil
FROM Usuario u INNER JOIN Perfil p ON
     (u.nomUsuario = 'admin'   AND p.nombre = 'ADMINISTRADOR') OR
     (u.nomUsuario = 'mesera'  AND p.nombre = 'MESERA')        OR
     (u.nomUsuario = 'cocina'  AND p.nombre = 'COCINA')        OR
     (u.nomUsuario = 'cajera'  AND p.nombre = 'CAJERA')        OR
     (u.nomUsuario = 'almacen' AND p.nombre = 'ALMACEN');
GO

PRINT 'BD_DonWilly: datos iniciales cargados correctamente.';
GO
