/* ============================================================
   SISTEMA DON WILLY
   Script 02: tipos de tabla y procedimientos almacenados
   Toda la capa de acceso a datos trabaja unicamente con estos
   procedimientos (la presentacion nunca ejecuta SQL directo).
   ============================================================ */

USE BD_DonWilly;
GO

/* ============================================================
   TIPOS DE TABLA (permiten guardar cabecera y detalle como una
   sola unidad de trabajo - RNF-03 Integridad)
   ============================================================ */

CREATE TYPE TipoDetallePedido AS TABLE
(
    idProducto     INT           NOT NULL,
    cantidad       INT           NOT NULL,
    precioAplicado DECIMAL(10,2) NOT NULL
);
GO

CREATE TYPE TipoDetalleRequerimiento AS TABLE
(
    idInsumo       INT           NOT NULL,
    idUnidad       INT           NOT NULL,
    cantUtilizable DECIMAL(10,2) NOT NULL,
    cantNecesidad  DECIMAL(10,2) NOT NULL,
    cantSolicitada DECIMAL(10,2) NOT NULL
);
GO

CREATE TYPE TipoDetalleCompra AS TABLE
(
    idInsumo       INT           NOT NULL,
    idUnidad       INT           NOT NULL,
    cantidad       DECIMAL(10,2) NOT NULL,
    precioUnitario DECIMAL(10,2) NOT NULL
);
GO

CREATE TYPE TipoDetalleRecepcion AS TABLE
(
    idDetalleCompra INT           NOT NULL,
    cantRecibida    DECIMAL(10,2) NOT NULL,
    cantAceptada    DECIMAL(10,2) NOT NULL,
    cantObservada   DECIMAL(10,2) NOT NULL,
    motivo          NVARCHAR(250) NULL
);
GO

CREATE TYPE TipoListaId AS TABLE (id INT NOT NULL);
GO

/* ============================================================
   CUS-17  MANTENER UNIDADES DE MEDIDA        (RF-14)
   ============================================================ */

CREATE PROCEDURE spListarUnidad
AS
    SELECT idUnidad, nombre, abreviatura, estUnidad
    FROM UnidadMedida
    ORDER BY nombre;
GO

CREATE PROCEDURE spListarUnidadActiva
AS
    SELECT idUnidad, nombre, abreviatura, estUnidad
    FROM UnidadMedida
    WHERE estUnidad = 1
    ORDER BY nombre;
GO

CREATE PROCEDURE spBuscarUnidad (@texto NVARCHAR(50))
AS
    SELECT idUnidad, nombre, abreviatura, estUnidad
    FROM UnidadMedida
    WHERE nombre LIKE '%' + @texto + '%' OR abreviatura LIKE '%' + @texto + '%'
    ORDER BY nombre;
GO

CREATE PROCEDURE spInsertarUnidad (@nombre NVARCHAR(50), @abreviatura NVARCHAR(10))
AS
BEGIN
    IF EXISTS (SELECT 1 FROM UnidadMedida WHERE abreviatura = @abreviatura)
        THROW 51000, 'La abreviatura ya esta registrada.', 1;
    INSERT INTO UnidadMedida (nombre, abreviatura, estUnidad) VALUES (@nombre, @abreviatura, 1);
    SELECT SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE spEditarUnidad (@idUnidad INT, @nombre NVARCHAR(50), @abreviatura NVARCHAR(10))
AS
BEGIN
    IF EXISTS (SELECT 1 FROM UnidadMedida WHERE abreviatura = @abreviatura AND idUnidad <> @idUnidad)
        THROW 51000, 'La abreviatura ya esta registrada.', 1;
    -- RFD-30: no se cambia el significado de una unidad ya utilizada
    IF EXISTS (SELECT 1 FROM DetalleRequerimiento WHERE idUnidad = @idUnidad)
       AND EXISTS (SELECT 1 FROM UnidadMedida WHERE idUnidad = @idUnidad AND abreviatura <> @abreviatura)
        THROW 51000, 'La unidad tiene operaciones registradas: no se puede cambiar su abreviatura.', 1;
    UPDATE UnidadMedida SET nombre = @nombre, abreviatura = @abreviatura WHERE idUnidad = @idUnidad;
END
GO

CREATE PROCEDURE spDeshabilitarUnidad (@idUnidad INT)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Insumo WHERE idUnidad = @idUnidad AND estInsumo = 1)
        THROW 51000, 'Existen insumos activos que usan esta unidad.', 1;
    UPDATE UnidadMedida SET estUnidad = 0 WHERE idUnidad = @idUnidad;
END
GO

CREATE PROCEDURE spHabilitarUnidad (@idUnidad INT)
AS
    UPDATE UnidadMedida SET estUnidad = 1 WHERE idUnidad = @idUnidad;
GO

/* ============================================================
   CUS-13  MANTENER INSUMOS                   (RF-08)
   ============================================================ */

CREATE PROCEDURE spListarInsumo
AS
    SELECT i.idInsumo, i.nombre, i.idUnidad, u.abreviatura AS unidad, i.estInsumo
    FROM Insumo i INNER JOIN UnidadMedida u ON u.idUnidad = i.idUnidad
    ORDER BY i.nombre;
GO

CREATE PROCEDURE spListarInsumoActivo
AS
    SELECT i.idInsumo, i.nombre, i.idUnidad, u.abreviatura AS unidad, i.estInsumo
    FROM Insumo i INNER JOIN UnidadMedida u ON u.idUnidad = i.idUnidad
    WHERE i.estInsumo = 1
    ORDER BY i.nombre;
GO

CREATE PROCEDURE spBuscarInsumo (@texto NVARCHAR(80))
AS
    SELECT i.idInsumo, i.nombre, i.idUnidad, u.abreviatura AS unidad, i.estInsumo
    FROM Insumo i INNER JOIN UnidadMedida u ON u.idUnidad = i.idUnidad
    WHERE i.nombre LIKE '%' + @texto + '%'
    ORDER BY i.nombre;
GO

CREATE PROCEDURE spInsertarInsumo (@nombre NVARCHAR(80), @idUnidad INT)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Insumo WHERE nombre = @nombre)
        THROW 51000, 'El insumo ya esta registrado.', 1;
    IF NOT EXISTS (SELECT 1 FROM UnidadMedida WHERE idUnidad = @idUnidad AND estUnidad = 1)
        THROW 51000, 'La unidad de medida debe estar activa.', 1;
    INSERT INTO Insumo (nombre, idUnidad, estInsumo) VALUES (@nombre, @idUnidad, 1);
    SELECT SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE spEditarInsumo (@idInsumo INT, @nombre NVARCHAR(80), @idUnidad INT)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Insumo WHERE nombre = @nombre AND idInsumo <> @idInsumo)
        THROW 51000, 'El insumo ya esta registrado.', 1;
    -- RFD-22: la unidad de insumos con operaciones historicas no cambia
    IF EXISTS (SELECT 1 FROM DetalleRequerimiento WHERE idInsumo = @idInsumo)
       OR EXISTS (SELECT 1 FROM DetalleCompra WHERE idInsumo = @idInsumo)
    BEGIN
        IF EXISTS (SELECT 1 FROM Insumo WHERE idInsumo = @idInsumo AND idUnidad <> @idUnidad)
            THROW 51000, 'El insumo tiene operaciones registradas: no se puede cambiar su unidad.', 1;
    END
    UPDATE Insumo SET nombre = @nombre, idUnidad = @idUnidad WHERE idInsumo = @idInsumo;
END
GO

CREATE PROCEDURE spDeshabilitarInsumo (@idInsumo INT)
AS
    UPDATE Insumo SET estInsumo = 0 WHERE idInsumo = @idInsumo;
GO

CREATE PROCEDURE spHabilitarInsumo (@idInsumo INT)
AS
    UPDATE Insumo SET estInsumo = 1 WHERE idInsumo = @idInsumo;
GO

/* ============================================================
   CUS-12  MANTENER PRODUCTOS                 (RF-07)
   ============================================================ */

CREATE PROCEDURE spListarProducto
AS
    SELECT idProducto, nombre, tipoProducto, precio, disponible, estProducto
    FROM Producto ORDER BY tipoProducto, nombre;
GO

CREATE PROCEDURE spListarProductoActivo
AS
    SELECT idProducto, nombre, tipoProducto, precio, disponible, estProducto
    FROM Producto WHERE estProducto = 1 AND disponible = 1
    ORDER BY tipoProducto, nombre;
GO

CREATE PROCEDURE spBuscarProducto (@texto NVARCHAR(80))
AS
    SELECT idProducto, nombre, tipoProducto, precio, disponible, estProducto
    FROM Producto WHERE nombre LIKE '%' + @texto + '%' OR tipoProducto LIKE '%' + @texto + '%'
    ORDER BY tipoProducto, nombre;
GO

CREATE PROCEDURE spInsertarProducto
(
    @nombre NVARCHAR(80), @tipoProducto NVARCHAR(20),
    @precio DECIMAL(10,2), @disponible BIT
)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Producto WHERE nombre = @nombre)
        THROW 51000, 'El producto ya esta registrado.', 1;
    INSERT INTO Producto (nombre, tipoProducto, precio, disponible, estProducto)
    VALUES (@nombre, @tipoProducto, @precio, @disponible, 1);
    SELECT SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE spEditarProducto
(
    @idProducto INT, @nombre NVARCHAR(80), @tipoProducto NVARCHAR(20),
    @precio DECIMAL(10,2), @disponible BIT
)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Producto WHERE nombre = @nombre AND idProducto <> @idProducto)
        THROW 51000, 'El producto ya esta registrado.', 1;
    -- RFD-21: los precios de pedidos confirmados no cambian (se guardan en DetallePedido)
    UPDATE Producto
    SET nombre = @nombre, tipoProducto = @tipoProducto, precio = @precio, disponible = @disponible
    WHERE idProducto = @idProducto;
END
GO

CREATE PROCEDURE spDeshabilitarProducto (@idProducto INT)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM DetallePedido d INNER JOIN Pedido p ON p.idPedido = d.idPedido
               WHERE d.idProducto = @idProducto AND p.estAtencion <> 'ENTREGADO' AND p.estSolicitud <> 'DESISTIDA')
        THROW 51000, 'El producto participa en pedidos en curso.', 1;
    UPDATE Producto SET estProducto = 0, disponible = 0 WHERE idProducto = @idProducto;
END
GO

CREATE PROCEDURE spHabilitarProducto (@idProducto INT)
AS
    UPDATE Producto SET estProducto = 1 WHERE idProducto = @idProducto;
GO

/* ============================================================
   CUS-14  MANTENER PROVEEDORES                (RF-09)
   ============================================================ */

CREATE PROCEDURE spListarProveedor
AS
    SELECT idProveedor, razonSocial, documento, direccion, telefono, estProveedor
    FROM Proveedor ORDER BY razonSocial;
GO

CREATE PROCEDURE spListarProveedorActivo
AS
    SELECT idProveedor, razonSocial, documento, direccion, telefono, estProveedor
    FROM Proveedor WHERE estProveedor = 1 ORDER BY razonSocial;
GO

CREATE PROCEDURE spBuscarProveedor (@texto NVARCHAR(100))
AS
    SELECT idProveedor, razonSocial, documento, direccion, telefono, estProveedor
    FROM Proveedor
    WHERE razonSocial LIKE '%' + @texto + '%' OR ISNULL(documento,'') LIKE '%' + @texto + '%'
    ORDER BY razonSocial;
GO

CREATE PROCEDURE spInsertarProveedor
(
    @razonSocial NVARCHAR(100), @documento NVARCHAR(15),
    @direccion NVARCHAR(120), @telefono NVARCHAR(15)
)
AS
BEGIN
    IF @documento <> '' AND EXISTS (SELECT 1 FROM Proveedor WHERE documento = @documento)
        THROW 51000, 'El documento ya esta registrado.', 1;
    INSERT INTO Proveedor (razonSocial, documento, direccion, telefono, estProveedor)
    VALUES (@razonSocial, NULLIF(@documento,''), NULLIF(@direccion,''), NULLIF(@telefono,''), 1);
    SELECT SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE spEditarProveedor
(
    @idProveedor INT, @razonSocial NVARCHAR(100), @documento NVARCHAR(15),
    @direccion NVARCHAR(120), @telefono NVARCHAR(15)
)
AS
BEGIN
    IF @documento <> '' AND EXISTS (SELECT 1 FROM Proveedor WHERE documento = @documento AND idProveedor <> @idProveedor)
        THROW 51000, 'El documento ya esta registrado.', 1;
    UPDATE Proveedor
    SET razonSocial = @razonSocial, documento = NULLIF(@documento,''),
        direccion = NULLIF(@direccion,''), telefono = NULLIF(@telefono,'')
    WHERE idProveedor = @idProveedor;
END
GO

CREATE PROCEDURE spDeshabilitarProveedor (@idProveedor INT)
AS
    UPDATE Proveedor SET estProveedor = 0 WHERE idProveedor = @idProveedor;
GO

CREATE PROCEDURE spHabilitarProveedor (@idProveedor INT)
AS
    UPDATE Proveedor SET estProveedor = 1 WHERE idProveedor = @idProveedor;
GO

/* ============================================================
   CUS-15  MANTENER MESAS                      (RF-12)
   ============================================================ */

CREATE PROCEDURE spListarMesa
AS
    SELECT idMesa, codigo, ubicacion, capacidad, estMesa FROM Mesa ORDER BY codigo;
GO

CREATE PROCEDURE spListarMesaActiva
AS
    SELECT idMesa, codigo, ubicacion, capacidad, estMesa FROM Mesa WHERE estMesa = 1 ORDER BY codigo;
GO

CREATE PROCEDURE spBuscarMesa (@texto NVARCHAR(60))
AS
    SELECT idMesa, codigo, ubicacion, capacidad, estMesa FROM Mesa
    WHERE codigo LIKE '%' + @texto + '%' OR ISNULL(ubicacion,'') LIKE '%' + @texto + '%'
    ORDER BY codigo;
GO

CREATE PROCEDURE spInsertarMesa (@codigo NVARCHAR(10), @ubicacion NVARCHAR(60), @capacidad INT)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Mesa WHERE codigo = @codigo)
        THROW 51000, 'El codigo de mesa ya esta registrado.', 1;
    INSERT INTO Mesa (codigo, ubicacion, capacidad, estMesa) VALUES (@codigo, @ubicacion, @capacidad, 1);
    SELECT SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE spEditarMesa (@idMesa INT, @codigo NVARCHAR(10), @ubicacion NVARCHAR(60), @capacidad INT)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Mesa WHERE codigo = @codigo AND idMesa <> @idMesa)
        THROW 51000, 'El codigo de mesa ya esta registrado.', 1;
    UPDATE Mesa SET codigo = @codigo, ubicacion = @ubicacion, capacidad = @capacidad WHERE idMesa = @idMesa;
END
GO

CREATE PROCEDURE spDeshabilitarMesa (@idMesa INT)
AS
BEGIN
    -- RFD-28: no se da de baja una mesa con pedidos abiertos
    IF EXISTS (SELECT 1 FROM Pedido WHERE idMesa = @idMesa
               AND estSolicitud <> 'DESISTIDA' AND estPago <> 'PAGADO')
        THROW 51000, 'La mesa tiene pedidos abiertos.', 1;
    UPDATE Mesa SET estMesa = 0 WHERE idMesa = @idMesa;
END
GO

CREATE PROCEDURE spHabilitarMesa (@idMesa INT)
AS
    UPDATE Mesa SET estMesa = 1 WHERE idMesa = @idMesa;
GO

/* ============================================================
   CUS-16  MANTENER TRABAJADORES               (RF-13)
   ============================================================ */

CREATE PROCEDURE spListarTrabajador
AS
    SELECT idTrabajador, documento, nombres, apellidos, cargo, telefono, estTrabajador
    FROM Trabajador ORDER BY apellidos, nombres;
GO

CREATE PROCEDURE spListarTrabajadorActivo
AS
    SELECT idTrabajador, documento, nombres, apellidos, cargo, telefono, estTrabajador
    FROM Trabajador WHERE estTrabajador = 1 ORDER BY apellidos, nombres;
GO

CREATE PROCEDURE spBuscarTrabajador (@texto NVARCHAR(60))
AS
    SELECT idTrabajador, documento, nombres, apellidos, cargo, telefono, estTrabajador
    FROM Trabajador
    WHERE documento LIKE '%' + @texto + '%' OR nombres LIKE '%' + @texto + '%'
       OR apellidos LIKE '%' + @texto + '%' OR cargo LIKE '%' + @texto + '%'
    ORDER BY apellidos, nombres;
GO

CREATE PROCEDURE spInsertarTrabajador
(
    @documento NVARCHAR(15), @nombres NVARCHAR(60), @apellidos NVARCHAR(60),
    @cargo NVARCHAR(40), @telefono NVARCHAR(15)
)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Trabajador WHERE documento = @documento)
        THROW 51000, 'El documento ya esta registrado.', 1;
    INSERT INTO Trabajador (documento, nombres, apellidos, cargo, telefono, estTrabajador)
    VALUES (@documento, @nombres, @apellidos, @cargo, NULLIF(@telefono,''), 1);
    SELECT SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE spEditarTrabajador
(
    @idTrabajador INT, @documento NVARCHAR(15), @nombres NVARCHAR(60),
    @apellidos NVARCHAR(60), @cargo NVARCHAR(40), @telefono NVARCHAR(15)
)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Trabajador WHERE documento = @documento AND idTrabajador <> @idTrabajador)
        THROW 51000, 'El documento ya esta registrado.', 1;
    UPDATE Trabajador
    SET documento = @documento, nombres = @nombres, apellidos = @apellidos,
        cargo = @cargo, telefono = NULLIF(@telefono,'')
    WHERE idTrabajador = @idTrabajador;
END
GO

CREATE PROCEDURE spDeshabilitarTrabajador (@idTrabajador INT)
AS
BEGIN
    -- RFD-29: la baja bloquea sus accesos sin borrar su historial
    BEGIN TRY
        BEGIN TRANSACTION;
        IF EXISTS (SELECT 1 FROM Usuario u
                   INNER JOIN UsuarioPerfil up ON up.idUsuario = u.idUsuario
                   INNER JOIN Perfil pf ON pf.idPerfil = up.idPerfil
                   WHERE u.idTrabajador = @idTrabajador AND u.estUsuario = 1 AND pf.nombre = 'ADMINISTRADOR')
           AND (SELECT COUNT(*) FROM Usuario u
                INNER JOIN UsuarioPerfil up ON up.idUsuario = u.idUsuario
                INNER JOIN Perfil pf ON pf.idPerfil = up.idPerfil
                WHERE u.estUsuario = 1 AND pf.nombre = 'ADMINISTRADOR') = 1
            THROW 51000, 'Debe permanecer al menos un administrador activo.', 1;

        UPDATE Usuario SET estUsuario = 0 WHERE idTrabajador = @idTrabajador;
        UPDATE Trabajador SET estTrabajador = 0 WHERE idTrabajador = @idTrabajador;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE spHabilitarTrabajador (@idTrabajador INT)
AS
    UPDATE Trabajador SET estTrabajador = 1 WHERE idTrabajador = @idTrabajador;
GO

/* ============================================================
   CUS-18  ADMINISTRAR USUARIOS Y PERFILES     (RF-11)
   ============================================================ */

CREATE PROCEDURE spListarPerfil
AS
    SELECT idPerfil, nombre FROM Perfil ORDER BY nombre;
GO

CREATE PROCEDURE spListarUsuario
AS
    SELECT u.idUsuario, u.idTrabajador, u.nomUsuario, u.estUsuario,
           t.nombres + ' ' + t.apellidos AS trabajador,
           STUFF((SELECT ', ' + p.nombre FROM UsuarioPerfil up
                  INNER JOIN Perfil p ON p.idPerfil = up.idPerfil
                  WHERE up.idUsuario = u.idUsuario
                  ORDER BY p.nombre FOR XML PATH('')), 1, 2, '') AS perfiles
    FROM Usuario u INNER JOIN Trabajador t ON t.idTrabajador = u.idTrabajador
    ORDER BY u.nomUsuario;
GO

CREATE PROCEDURE spListarPerfilesDeUsuario (@idUsuario INT)
AS
    SELECT p.idPerfil, p.nombre
    FROM UsuarioPerfil up INNER JOIN Perfil p ON p.idPerfil = up.idPerfil
    WHERE up.idUsuario = @idUsuario ORDER BY p.nombre;
GO

CREATE PROCEDURE spObtenerCredencial (@nomUsuario NVARCHAR(30))
AS
    SELECT u.idUsuario, u.idTrabajador, u.nomUsuario, u.claveHash, u.claveSal, u.estUsuario,
           t.nombres + ' ' + t.apellidos AS trabajador, t.estTrabajador
    FROM Usuario u INNER JOIN Trabajador t ON t.idTrabajador = u.idTrabajador
    WHERE u.nomUsuario = @nomUsuario;
GO

CREATE PROCEDURE spInsertarUsuario
(
    @idTrabajador INT, @nomUsuario NVARCHAR(30),
    @claveHash NVARCHAR(100), @claveSal NVARCHAR(50), @perfiles TipoListaId READONLY
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        IF EXISTS (SELECT 1 FROM Usuario WHERE nomUsuario = @nomUsuario)
            THROW 51000, 'El nombre de usuario ya esta registrado.', 1;
        IF NOT EXISTS (SELECT 1 FROM Trabajador WHERE idTrabajador = @idTrabajador AND estTrabajador = 1)
            THROW 51000, 'El trabajador debe estar activo.', 1;
        IF NOT EXISTS (SELECT 1 FROM @perfiles)
            THROW 51000, 'Debe asignar al menos un perfil.', 1;

        INSERT INTO Usuario (idTrabajador, nomUsuario, claveHash, claveSal, estUsuario)
        VALUES (@idTrabajador, @nomUsuario, @claveHash, @claveSal, 1);

        DECLARE @idUsuario INT = SCOPE_IDENTITY();
        INSERT INTO UsuarioPerfil (idUsuario, idPerfil) SELECT @idUsuario, id FROM @perfiles;
        COMMIT TRANSACTION;
        SELECT @idUsuario;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE spEditarUsuario
(
    @idUsuario INT, @nomUsuario NVARCHAR(30),
    @claveHash NVARCHAR(100), @claveSal NVARCHAR(50), @perfiles TipoListaId READONLY
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        IF EXISTS (SELECT 1 FROM Usuario WHERE nomUsuario = @nomUsuario AND idUsuario <> @idUsuario)
            THROW 51000, 'El nombre de usuario ya esta registrado.', 1;
        IF NOT EXISTS (SELECT 1 FROM @perfiles)
            THROW 51000, 'Debe asignar al menos un perfil.', 1;

        UPDATE Usuario SET nomUsuario = @nomUsuario WHERE idUsuario = @idUsuario;
        IF @claveHash <> ''
            UPDATE Usuario SET claveHash = @claveHash, claveSal = @claveSal WHERE idUsuario = @idUsuario;

        DELETE FROM UsuarioPerfil WHERE idUsuario = @idUsuario;
        INSERT INTO UsuarioPerfil (idUsuario, idPerfil) SELECT @idUsuario, id FROM @perfiles;

        -- A3: debe conservarse al menos un administrador activo
        IF NOT EXISTS (SELECT 1 FROM Usuario u
                       INNER JOIN UsuarioPerfil up ON up.idUsuario = u.idUsuario
                       INNER JOIN Perfil p ON p.idPerfil = up.idPerfil
                       WHERE u.estUsuario = 1 AND p.nombre = 'ADMINISTRADOR')
            THROW 51000, 'Debe permanecer al menos un administrador activo.', 1;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE spDeshabilitarUsuario (@idUsuario INT)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM UsuarioPerfil up INNER JOIN Perfil p ON p.idPerfil = up.idPerfil
               WHERE up.idUsuario = @idUsuario AND p.nombre = 'ADMINISTRADOR')
       AND (SELECT COUNT(*) FROM Usuario u
            INNER JOIN UsuarioPerfil up ON up.idUsuario = u.idUsuario
            INNER JOIN Perfil p ON p.idPerfil = up.idPerfil
            WHERE u.estUsuario = 1 AND p.nombre = 'ADMINISTRADOR') = 1
        THROW 51000, 'Debe permanecer al menos un administrador activo.', 1;
    UPDATE Usuario SET estUsuario = 0 WHERE idUsuario = @idUsuario;
END
GO

CREATE PROCEDURE spHabilitarUsuario (@idUsuario INT)
AS
    UPDATE Usuario SET estUsuario = 1 WHERE idUsuario = @idUsuario;
GO

/* ============================================================
   CUS-01 / CUS-02 / CUS-03  SOLICITUDES       (RF-01)
   ============================================================ */

CREATE PROCEDURE spRegistrarSolicitud
(
    @modalidad NVARCHAR(10), @idMesa INT, @idTrabajador INT,
    @detalle TipoDetallePedido READONLY
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM @detalle)
            THROW 51000, 'Revise los productos, las cantidades y la mesa.', 1;   -- A1 de CUS-01
        IF EXISTS (SELECT 1 FROM @detalle WHERE cantidad <= 0)
            THROW 51000, 'Revise los productos, las cantidades y la mesa.', 1;
        IF @modalidad = 'MESA' AND @idMesa IS NULL
            THROW 51000, 'Revise los productos, las cantidades y la mesa.', 1;

        INSERT INTO Pedido (modalidad, idMesa, idTrabajadorReg, estSolicitud, estAtencion, estPago, total)
        VALUES (@modalidad, CASE WHEN @modalidad = 'MESA' THEN @idMesa ELSE NULL END,
                @idTrabajador, 'PENDIENTE', 'SIN_INICIAR', 'PENDIENTE', 0);

        DECLARE @idPedido INT = SCOPE_IDENTITY();

        INSERT INTO DetallePedido (idPedido, idProducto, cantidad, precioAplicado)
        SELECT @idPedido, idProducto, cantidad, precioAplicado FROM @detalle;

        UPDATE Pedido SET total = (SELECT SUM(cantidad * precioAplicado) FROM DetallePedido WHERE idPedido = @idPedido)
        WHERE idPedido = @idPedido;

        COMMIT TRANSACTION;
        SELECT @idPedido;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE spModificarSolicitud (@idPedido INT, @detalle TipoDetallePedido READONLY)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM Pedido WHERE idPedido = @idPedido AND estSolicitud IN ('PENDIENTE','RESPONDIDA'))
            THROW 51000, 'La solicitud ya fue confirmada o cerrada.', 1;

        DELETE FROM DetallePedido WHERE idPedido = @idPedido;
        INSERT INTO DetallePedido (idPedido, idProducto, cantidad, precioAplicado)
        SELECT @idPedido, idProducto, cantidad, precioAplicado FROM @detalle;

        -- A1 de CUS-03: al modificar se invalida la respuesta anterior
        UPDATE RespuestaDisponibilidad SET vigente = 0 WHERE idPedido = @idPedido;
        UPDATE Pedido
        SET estSolicitud = 'PENDIENTE',
            total = (SELECT SUM(cantidad * precioAplicado) FROM DetallePedido WHERE idPedido = @idPedido)
        WHERE idPedido = @idPedido;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE spListarSolicitudPendiente
AS
    SELECT p.idPedido, p.modalidad, ISNULL(m.codigo,'-') AS mesa, p.fecRegistro, p.total,
           t.nombres + ' ' + t.apellidos AS registradoPor
    FROM Pedido p
    LEFT  JOIN Mesa m ON m.idMesa = p.idMesa
    INNER JOIN Trabajador t ON t.idTrabajador = p.idTrabajadorReg
    WHERE p.estSolicitud = 'PENDIENTE'
    ORDER BY p.fecRegistro;
GO

CREATE PROCEDURE spListarSolicitudRespondida
AS
    SELECT p.idPedido, p.modalidad, ISNULL(m.codigo,'-') AS mesa, p.fecRegistro, p.total,
           r.resultado, ISNULL(r.observacion,'') AS observacion
    FROM Pedido p
    LEFT  JOIN Mesa m ON m.idMesa = p.idMesa
    INNER JOIN RespuestaDisponibilidad r ON r.idPedido = p.idPedido AND r.vigente = 1
    WHERE p.estSolicitud = 'RESPONDIDA'
    ORDER BY p.fecRegistro;
GO

CREATE PROCEDURE spListarDetallePedido (@idPedido INT)
AS
    SELECT d.idDetallePedido, d.idProducto, pr.nombre AS producto, pr.tipoProducto,
           d.cantidad, d.precioAplicado, (d.cantidad * d.precioAplicado) AS subtotal
    FROM DetallePedido d INNER JOIN Producto pr ON pr.idProducto = d.idProducto
    WHERE d.idPedido = @idPedido
    ORDER BY pr.tipoProducto, pr.nombre;
GO

CREATE PROCEDURE spObtenerPedido (@idPedido INT)
AS
    SELECT p.idPedido, p.modalidad, p.idMesa, ISNULL(m.codigo,'-') AS mesa, p.idTrabajadorReg,
           p.fecRegistro, p.estSolicitud, p.estAtencion, p.estPago, p.total,
           ISNULL(p.motivoDesiste,'') AS motivoDesiste
    FROM Pedido p LEFT JOIN Mesa m ON m.idMesa = p.idMesa
    WHERE p.idPedido = @idPedido;
GO

CREATE PROCEDURE spResponderDisponibilidad
(
    @idPedido INT, @idTrabajador INT, @resultado NVARCHAR(12), @observacion NVARCHAR(250)
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM Pedido WHERE idPedido = @idPedido AND estSolicitud = 'PENDIENTE')
            THROW 51000, 'La solicitud no esta pendiente de disponibilidad.', 1;
        IF @resultado = 'FALTANTES' AND ISNULL(@observacion,'') = ''
            THROW 51000, 'Indique los faltantes y las alternativas.', 1;

        UPDATE RespuestaDisponibilidad SET vigente = 0 WHERE idPedido = @idPedido;
        INSERT INTO RespuestaDisponibilidad (idPedido, idTrabajador, resultado, observacion, vigente)
        VALUES (@idPedido, @idTrabajador, @resultado, NULLIF(@observacion,''), 1);
        UPDATE Pedido SET estSolicitud = 'RESPONDIDA' WHERE idPedido = @idPedido;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE spConfirmarSolicitud (@idPedido INT)
AS
BEGIN
    -- B4 de CUS-03: solo con respuesta favorable vigente
    IF NOT EXISTS (SELECT 1 FROM RespuestaDisponibilidad
                   WHERE idPedido = @idPedido AND vigente = 1 AND resultado = 'FAVORABLE')
        THROW 51000, 'Se requiere una respuesta favorable de cocina.', 1;
    IF NOT EXISTS (SELECT 1 FROM Pedido WHERE idPedido = @idPedido AND estSolicitud = 'RESPONDIDA')
        THROW 51000, 'La solicitud no esta en condicion de confirmarse.', 1;

    UPDATE Pedido SET estSolicitud = 'CONFIRMADA' WHERE idPedido = @idPedido;
END
GO

CREATE PROCEDURE spDesistirSolicitud (@idPedido INT, @motivo NVARCHAR(150))
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Pedido WHERE idPedido = @idPedido AND estSolicitud = 'CONFIRMADA')
        THROW 51000, 'Un pedido confirmado no se desiste desde este caso de uso.', 1;
    UPDATE Pedido SET estSolicitud = 'DESISTIDA', motivoDesiste = @motivo WHERE idPedido = @idPedido;
END
GO

/* ============================================================
   CUS-04 / CUS-05  ATENCION DE PEDIDOS        (RF-02)
   ============================================================ */

CREATE PROCEDURE spListarPedidoParaPreparar
AS
    -- RFD-04: en mesa basta la confirmacion; para llevar se exige pago completo
    SELECT p.idPedido, p.modalidad, ISNULL(m.codigo,'-') AS mesa, p.fecRegistro,
           p.estAtencion, p.estPago, p.total
    FROM Pedido p LEFT JOIN Mesa m ON m.idMesa = p.idMesa
    WHERE p.estSolicitud = 'CONFIRMADA'
      AND p.estAtencion IN ('SIN_INICIAR','PREPARACION','POR_CORREGIR')
      AND (p.modalidad = 'MESA' OR p.estPago = 'PAGADO')
    ORDER BY p.fecRegistro;
GO

CREATE PROCEDURE spIniciarPreparacion (@idPedido INT)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Pedido WHERE idPedido = @idPedido
                   AND estSolicitud = 'CONFIRMADA' AND estAtencion IN ('SIN_INICIAR','POR_CORREGIR')
                   AND (modalidad = 'MESA' OR estPago = 'PAGADO'))
        THROW 51000, 'El pedido no esta habilitado para preparacion.', 1;
    UPDATE Pedido SET estAtencion = 'PREPARACION' WHERE idPedido = @idPedido;
END
GO

CREATE PROCEDURE spMarcarPedidoListo (@idPedido INT)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Pedido WHERE idPedido = @idPedido AND estAtencion = 'PREPARACION')
        THROW 51000, 'El pedido debe estar en preparacion.', 1;
    UPDATE Pedido SET estAtencion = 'LISTO' WHERE idPedido = @idPedido;
END
GO

CREATE PROCEDURE spListarPedidoParaDespacho
AS
    SELECT p.idPedido, p.modalidad, ISNULL(m.codigo,'-') AS mesa, p.fecRegistro, p.estPago, p.total
    FROM Pedido p LEFT JOIN Mesa m ON m.idMesa = p.idMesa
    WHERE p.estAtencion = 'LISTO'
    ORDER BY p.fecRegistro;
GO

CREATE PROCEDURE spRegistrarDespacho (@idPedido INT, @idTrabajador INT)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Pedido WHERE idPedido = @idPedido AND estAtencion = 'LISTO')
        THROW 51000, 'El pedido debe estar listo para revision.', 1;
    IF EXISTS (SELECT 1 FROM Pedido WHERE idPedido = @idPedido AND modalidad = 'LLEVAR' AND estPago <> 'PAGADO')
        THROW 51000, 'Un pedido para llevar se entrega con el pago completo.', 1;
    UPDATE Pedido SET estAtencion = 'ENTREGADO' WHERE idPedido = @idPedido;
    INSERT INTO Auditoria (nomUsuario, entidad, idRegistro, operacion, detalle)
    SELECT t.nombres + ' ' + t.apellidos, 'Pedido', @idPedido, 'DESPACHO', 'Entrega conforme'
    FROM Trabajador t WHERE t.idTrabajador = @idTrabajador;
END
GO

CREATE PROCEDURE spSolicitarCorreccion (@idPedido INT, @observacion NVARCHAR(250), @idTrabajador INT)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Pedido WHERE idPedido = @idPedido AND estAtencion = 'LISTO')
        THROW 51000, 'El pedido debe estar listo para revision.', 1;
    UPDATE Pedido SET estAtencion = 'POR_CORREGIR' WHERE idPedido = @idPedido;
    INSERT INTO Auditoria (nomUsuario, entidad, idRegistro, operacion, detalle)
    SELECT t.nombres + ' ' + t.apellidos, 'Pedido', @idPedido, 'CORRECCION', @observacion
    FROM Trabajador t WHERE t.idTrabajador = @idTrabajador;
END
GO

/* ============================================================
   CUS-06 / CUS-22  COBRANZA                   (RF-03)
   ============================================================ */

CREATE PROCEDURE spListarPedidoPorCobrar
AS
    SELECT p.idPedido, p.modalidad, ISNULL(m.codigo,'-') AS mesa, p.estAtencion, p.estPago, p.total,
           p.total - ISNULL((SELECT SUM(importe) FROM Pago WHERE idPedido = p.idPedido),0) AS saldo
    FROM Pedido p LEFT JOIN Mesa m ON m.idMesa = p.idMesa
    WHERE p.estSolicitud = 'CONFIRMADA' AND p.estPago <> 'PAGADO'
      AND (p.modalidad = 'LLEVAR' OR p.estAtencion = 'ENTREGADO')
    ORDER BY p.fecRegistro;
GO

CREATE PROCEDURE spCalcularSaldoPedido (@idPedido INT)
AS
    -- CUS-22: saldo = total del pedido menos pagos aplicados
    SELECT p.idPedido, p.total,
           ISNULL((SELECT SUM(importe) FROM Pago WHERE idPedido = p.idPedido),0) AS pagado,
           p.total - ISNULL((SELECT SUM(importe) FROM Pago WHERE idPedido = p.idPedido),0) AS saldo
    FROM Pedido p WHERE p.idPedido = @idPedido;
GO

CREATE PROCEDURE spRegistrarCobro
(
    @idPedido INT, @importe DECIMAL(10,2), @medioPago NVARCHAR(10),
    @montoRecibido DECIMAL(10,2), @referencia NVARCHAR(40), @idTrabajador INT
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        DECLARE @total DECIMAL(10,2), @pagado DECIMAL(10,2), @saldo DECIMAL(10,2);

        SELECT @total = total FROM Pedido WITH (UPDLOCK, HOLDLOCK) WHERE idPedido = @idPedido;
        IF @total IS NULL THROW 51000, 'El pedido no existe.', 1;

        SELECT @pagado = ISNULL(SUM(importe),0) FROM Pago WHERE idPedido = @idPedido;
        SET @saldo = @total - @pagado;

        IF @saldo <= 0 THROW 51000, 'El pedido ya esta pagado.', 1;                 -- A1 de CUS-22
        IF @importe <= 0 OR @importe > @saldo
            THROW 51000, 'Revise el importe y el saldo pendiente.', 1;              -- A2 de CUS-06
        IF @medioPago = 'EFECTIVO' AND @montoRecibido < @importe
            THROW 51000, 'Revise el importe y el saldo pendiente.', 1;

        DECLARE @vuelto DECIMAL(10,2) =
            CASE WHEN @medioPago = 'EFECTIVO' THEN @montoRecibido - @importe ELSE 0 END;

        INSERT INTO Pago (idPedido, importe, medioPago, montoRecibido, vuelto, referencia, idTrabajador)
        VALUES (@idPedido, @importe, @medioPago,
                CASE WHEN @medioPago = 'EFECTIVO' THEN @montoRecibido ELSE @importe END,
                @vuelto, NULLIF(@referencia,''), @idTrabajador);

        SET @pagado = @pagado + @importe;
        UPDATE Pedido
        SET estPago = CASE WHEN @pagado >= @total THEN 'PAGADO' ELSE 'PARCIAL' END
        WHERE idPedido = @idPedido;

        COMMIT TRANSACTION;
        SELECT @total AS total, @pagado AS pagado, @total - @pagado AS saldo, @vuelto AS vuelto;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE spListarPagoPedido (@idPedido INT)
AS
    SELECT g.idPago, g.fecPago, g.importe, g.medioPago, g.vuelto, ISNULL(g.referencia,'') AS referencia,
           t.nombres + ' ' + t.apellidos AS cajera
    FROM Pago g INNER JOIN Trabajador t ON t.idTrabajador = g.idTrabajador
    WHERE g.idPedido = @idPedido ORDER BY g.fecPago;
GO

/* ============================================================
   CUS-07 / CUS-08  REQUERIMIENTO SEMANAL      (RF-04)
   ============================================================ */

CREATE PROCEDURE spRegistrarRequerimiento
(
    @semana NVARCHAR(20), @fecConteo DATE, @idTrabajador INT,
    @estado NVARCHAR(12), @detalle TipoDetalleRequerimiento READONLY
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM @detalle)
            THROW 51000, 'Registre al menos un insumo con su cantidad solicitada.', 1;
        IF EXISTS (SELECT 1 FROM @detalle WHERE cantSolicitada <= 0)
            THROW 51000, 'Las cantidades solicitadas deben ser mayores que cero.', 1;

        INSERT INTO RequerimientoSemanal (semana, fecConteo, idTrabajadorAlm, estRequerimiento)
        VALUES (@semana, @fecConteo, @idTrabajador, @estado);

        DECLARE @id INT = SCOPE_IDENTITY();
        INSERT INTO DetalleRequerimiento
            (idRequerimiento, idInsumo, idUnidad, cantUtilizable, cantNecesidad, cantSolicitada)
        SELECT @id, idInsumo, idUnidad, cantUtilizable, cantNecesidad, cantSolicitada FROM @detalle;

        COMMIT TRANSACTION;
        SELECT @id;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE spActualizarRequerimiento
(
    @idRequerimiento INT, @semana NVARCHAR(20), @fecConteo DATE,
    @estado NVARCHAR(12), @detalle TipoDetalleRequerimiento READONLY
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM RequerimientoSemanal
                       WHERE idRequerimiento = @idRequerimiento AND estRequerimiento IN ('BORRADOR','DEVUELTO'))
            THROW 51000, 'Solo se corrigen requerimientos en borrador o devueltos.', 1;

        DELETE FROM DetalleRequerimiento WHERE idRequerimiento = @idRequerimiento;
        INSERT INTO DetalleRequerimiento
            (idRequerimiento, idInsumo, idUnidad, cantUtilizable, cantNecesidad, cantSolicitada)
        SELECT @idRequerimiento, idInsumo, idUnidad, cantUtilizable, cantNecesidad, cantSolicitada FROM @detalle;

        UPDATE RequerimientoSemanal
        SET semana = @semana, fecConteo = @fecConteo, estRequerimiento = @estado
        WHERE idRequerimiento = @idRequerimiento;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE spListarRequerimiento (@estado NVARCHAR(12) = NULL)
AS
    SELECT r.idRequerimiento, r.semana, r.fecConteo, r.fecRegistro, r.estRequerimiento,
           ISNULL(r.observacion,'') AS observacion,
           t.nombres + ' ' + t.apellidos AS almacenero,
           (SELECT COUNT(*) FROM DetalleRequerimiento d WHERE d.idRequerimiento = r.idRequerimiento) AS insumos
    FROM RequerimientoSemanal r INNER JOIN Trabajador t ON t.idTrabajador = r.idTrabajadorAlm
    WHERE (@estado IS NULL OR r.estRequerimiento = @estado)
    ORDER BY r.fecRegistro DESC;
GO

CREATE PROCEDURE spListarDetalleRequerimiento (@idRequerimiento INT)
AS
    SELECT d.idDetalleReq, d.idInsumo, i.nombre AS insumo, d.idUnidad, u.abreviatura AS unidad,
           d.cantUtilizable, d.cantNecesidad, d.cantSolicitada
    FROM DetalleRequerimiento d
    INNER JOIN Insumo i       ON i.idInsumo = d.idInsumo
    INNER JOIN UnidadMedida u ON u.idUnidad = d.idUnidad
    WHERE d.idRequerimiento = @idRequerimiento
    ORDER BY i.nombre;
GO

CREATE PROCEDURE spRevisarRequerimiento
(
    @idRequerimiento INT, @idTrabajador INT, @conforme BIT, @observacion NVARCHAR(250)
)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM RequerimientoSemanal
                   WHERE idRequerimiento = @idRequerimiento AND estRequerimiento = 'PENDIENTE')
        THROW 51000, 'El requerimiento no esta pendiente de revision.', 1;
    IF @conforme = 0 AND ISNULL(@observacion,'') = ''
        THROW 51000, 'Indique las observaciones de la devolucion.', 1;

    UPDATE RequerimientoSemanal
    SET estRequerimiento = CASE WHEN @conforme = 1 THEN 'REVISADO' ELSE 'DEVUELTO' END,
        observacion      = NULLIF(@observacion,''),
        idTrabajadorRev  = @idTrabajador,
        fecRevision      = GETDATE()
    WHERE idRequerimiento = @idRequerimiento;
END
GO

/* ============================================================
   CUS-09  COMPRA DE INSUMOS                   (RF-05)
   ============================================================ */

CREATE PROCEDURE spListarRequerimientoRevisado
AS
    SELECT r.idRequerimiento, r.semana, r.fecConteo, r.fecRevision,
           t.nombres + ' ' + t.apellidos AS almacenero
    FROM RequerimientoSemanal r INNER JOIN Trabajador t ON t.idTrabajador = r.idTrabajadorAlm
    WHERE r.estRequerimiento = 'REVISADO'
    ORDER BY r.fecRevision DESC;
GO

CREATE PROCEDURE spListarAvanceRequerimiento (@idRequerimiento INT)
AS
    -- B2 de CUS-09: cantidades solicitadas y compras acumuladas por insumo
    SELECT d.idInsumo, i.nombre AS insumo, u.abreviatura AS unidad, d.idUnidad,
           d.cantSolicitada,
           ISNULL(c.comprado,0) AS comprado,
           d.cantSolicitada - ISNULL(c.comprado,0) AS pendiente
    FROM DetalleRequerimiento d
    INNER JOIN Insumo i       ON i.idInsumo = d.idInsumo
    INNER JOIN UnidadMedida u ON u.idUnidad = d.idUnidad
    OUTER APPLY (SELECT SUM(dc.cantidad) AS comprado
                 FROM DetalleCompra dc INNER JOIN Compra co ON co.idCompra = dc.idCompra
                 WHERE co.idRequerimiento = @idRequerimiento AND dc.idInsumo = d.idInsumo) c
    WHERE d.idRequerimiento = @idRequerimiento
    ORDER BY i.nombre;
GO

CREATE PROCEDURE spRegistrarCompra
(
    @idRequerimiento INT, @idProveedor INT, @fecCompra DATE, @documento NVARCHAR(30),
    @observacion NVARCHAR(250), @idTrabajador INT, @detalle TipoDetalleCompra READONLY
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM RequerimientoSemanal
                       WHERE idRequerimiento = @idRequerimiento AND estRequerimiento = 'REVISADO')
            THROW 51000, 'El requerimiento debe estar revisado.', 1;
        IF NOT EXISTS (SELECT 1 FROM Proveedor WHERE idProveedor = @idProveedor AND estProveedor = 1)
            THROW 51000, 'El proveedor debe estar activo.', 1;
        IF NOT EXISTS (SELECT 1 FROM @detalle)
            THROW 51000, 'Registre al menos un insumo comprado.', 1;

        INSERT INTO Compra (idRequerimiento, idProveedor, fecCompra, documento, total, observacion, idTrabajador)
        VALUES (@idRequerimiento, @idProveedor, @fecCompra, NULLIF(@documento,''), 0,
                NULLIF(@observacion,''), @idTrabajador);

        DECLARE @idCompra INT = SCOPE_IDENTITY();

        INSERT INTO DetalleCompra (idCompra, idInsumo, idUnidad, cantidad, precioUnitario, subtotal)
        SELECT @idCompra, idInsumo, idUnidad, cantidad, precioUnitario, cantidad * precioUnitario FROM @detalle;

        UPDATE Compra SET total = (SELECT SUM(subtotal) FROM DetalleCompra WHERE idCompra = @idCompra)
        WHERE idCompra = @idCompra;

        COMMIT TRANSACTION;
        SELECT @idCompra;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE spListarCompra (@idRequerimiento INT = NULL)
AS
    SELECT c.idCompra, c.idRequerimiento, r.semana, c.fecCompra, p.razonSocial AS proveedor,
           ISNULL(c.documento,'') AS documento, c.total, ISNULL(c.observacion,'') AS observacion
    FROM Compra c
    INNER JOIN Proveedor p            ON p.idProveedor = c.idProveedor
    INNER JOIN RequerimientoSemanal r ON r.idRequerimiento = c.idRequerimiento
    WHERE (@idRequerimiento IS NULL OR c.idRequerimiento = @idRequerimiento)
    ORDER BY c.fecCompra DESC, c.idCompra DESC;
GO

CREATE PROCEDURE spListarDetalleCompra (@idCompra INT)
AS
    SELECT dc.idDetalleCompra, dc.idInsumo, i.nombre AS insumo, u.abreviatura AS unidad,
           dc.cantidad, dc.precioUnitario, dc.subtotal
    FROM DetalleCompra dc
    INNER JOIN Insumo i       ON i.idInsumo = dc.idInsumo
    INNER JOIN UnidadMedida u ON u.idUnidad = dc.idUnidad
    WHERE dc.idCompra = @idCompra ORDER BY i.nombre;
GO

/* ============================================================
   CUS-10 / CUS-23 / CUS-11  RECEPCION         (RF-06)
   ============================================================ */

CREATE PROCEDURE spListarCompraPendienteRecepcion
AS
    SELECT c.idCompra, c.fecCompra, p.razonSocial AS proveedor, r.semana, c.total
    FROM Compra c
    INNER JOIN Proveedor p            ON p.idProveedor = c.idProveedor
    INNER JOIN RequerimientoSemanal r ON r.idRequerimiento = c.idRequerimiento
    WHERE EXISTS
    (
        SELECT 1 FROM DetalleCompra dc
        OUTER APPLY (SELECT SUM(dr.cantAceptada) AS aceptado
                     FROM DetalleRecepcion dr WHERE dr.idDetalleCompra = dc.idDetalleCompra) a
        WHERE dc.idCompra = c.idCompra AND dc.cantidad - ISNULL(a.aceptado,0) > 0
    )
    ORDER BY c.fecCompra DESC;
GO

CREATE PROCEDURE spListarDetalleCompraPendiente (@idCompra INT)
AS
    -- B2 de CUS-10: detalles con cantidades pendientes de aceptacion
    SELECT dc.idDetalleCompra, i.nombre AS insumo, u.abreviatura AS unidad,
           dc.cantidad AS cantComprada,
           ISNULL(a.aceptado,0) AS cantAceptadaAcum,
           dc.cantidad - ISNULL(a.aceptado,0) AS pendiente
    FROM DetalleCompra dc
    INNER JOIN Insumo i       ON i.idInsumo = dc.idInsumo
    INNER JOIN UnidadMedida u ON u.idUnidad = dc.idUnidad
    OUTER APPLY (SELECT SUM(dr.cantAceptada) AS aceptado
                 FROM DetalleRecepcion dr WHERE dr.idDetalleCompra = dc.idDetalleCompra) a
    WHERE dc.idCompra = @idCompra
    ORDER BY i.nombre;
GO

CREATE PROCEDURE spRegistrarRecepcion
(
    @idCompra INT, @fecRecepcion DATE, @idTrabajador INT,
    @observacion NVARCHAR(250), @detalle TipoDetalleRecepcion READONLY
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM @detalle WHERE cantRecibida > 0)
            THROW 51000, 'Registre al menos una cantidad recibida.', 1;
        IF EXISTS (SELECT 1 FROM @detalle WHERE cantAceptada + cantObservada <> cantRecibida)
            THROW 51000, 'Revise las cantidades recibidas, aceptadas y observadas.', 1;   -- A2 de CUS-10

        -- RFD-18: no se acepta mas de lo comprado pendiente
        IF EXISTS
        (
            SELECT 1 FROM @detalle d
            INNER JOIN DetalleCompra dc ON dc.idDetalleCompra = d.idDetalleCompra
            OUTER APPLY (SELECT SUM(dr.cantAceptada) AS aceptado
                         FROM DetalleRecepcion dr WHERE dr.idDetalleCompra = dc.idDetalleCompra) a
            WHERE d.cantAceptada > dc.cantidad - ISNULL(a.aceptado,0)
        )
            THROW 51000, 'No se puede aceptar mas de la cantidad comprada pendiente.', 1;

        -- CUS-23: toda diferencia exige motivo
        IF EXISTS (SELECT 1 FROM @detalle WHERE cantObservada > 0 AND ISNULL(motivo,'') = '')
            THROW 51000, 'Indique el motivo de la diferencia.', 1;

        INSERT INTO Recepcion (idCompra, fecRecepcion, idTrabajador, observacion)
        VALUES (@idCompra, @fecRecepcion, @idTrabajador, NULLIF(@observacion,''));

        DECLARE @idRecepcion INT = SCOPE_IDENTITY();

        DECLARE @insertados TABLE (idDetalleRecepcion INT, idDetalleCompra INT, cantObservada DECIMAL(10,2));

        INSERT INTO DetalleRecepcion (idRecepcion, idDetalleCompra, cantRecibida, cantAceptada, cantObservada)
        OUTPUT inserted.idDetalleRecepcion, inserted.idDetalleCompra, inserted.cantObservada INTO @insertados
        SELECT @idRecepcion, idDetalleCompra, cantRecibida, cantAceptada, cantObservada
        FROM @detalle WHERE cantRecibida > 0;

        -- CUS-23: la recepcion y sus diferencias se confirman juntas
        INSERT INTO DiferenciaRecepcion (idDetalleRecepcion, motivo, estDiferencia)
        SELECT i.idDetalleRecepcion, d.motivo, 'PENDIENTE'
        FROM @insertados i INNER JOIN @detalle d ON d.idDetalleCompra = i.idDetalleCompra
        WHERE i.cantObservada > 0;

        COMMIT TRANSACTION;
        SELECT @idRecepcion;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE spListarDiferenciaPendiente
AS
    SELECT df.idDiferencia, c.idCompra, rc.idRecepcion, rc.fecRecepcion,
           i.nombre AS insumo, u.abreviatura AS unidad, dr.cantObservada,
           p.razonSocial AS proveedor, df.motivo, df.estDiferencia
    FROM DiferenciaRecepcion df
    INNER JOIN DetalleRecepcion dr ON dr.idDetalleRecepcion = df.idDetalleRecepcion
    INNER JOIN Recepcion rc        ON rc.idRecepcion = dr.idRecepcion
    INNER JOIN DetalleCompra dc    ON dc.idDetalleCompra = dr.idDetalleCompra
    INNER JOIN Compra c            ON c.idCompra = dc.idCompra
    INNER JOIN Proveedor p         ON p.idProveedor = c.idProveedor
    INNER JOIN Insumo i            ON i.idInsumo = dc.idInsumo
    INNER JOIN UnidadMedida u      ON u.idUnidad = dc.idUnidad
    WHERE df.estDiferencia = 'PENDIENTE'
    ORDER BY rc.fecRecepcion;
GO

CREATE PROCEDURE spRegularizarDiferencia
(
    @idDiferencia INT, @solucion NVARCHAR(250), @sustento NVARCHAR(60),
    @fecRegularizacion DATE, @idTrabajador INT
)
AS
BEGIN
    IF ISNULL(@solucion,'') = '' OR ISNULL(@sustento,'') = ''
        THROW 51000, 'Indique como se resolvio la diferencia.', 1;                 -- A2 de CUS-11
    IF NOT EXISTS (SELECT 1 FROM DiferenciaRecepcion WHERE idDiferencia = @idDiferencia AND estDiferencia = 'PENDIENTE')
        THROW 51000, 'La diferencia ya fue regularizada.', 1;

    UPDATE DiferenciaRecepcion
    SET estDiferencia = 'REGULARIZADO', solucion = @solucion, sustento = @sustento,
        fecRegularizacion = @fecRegularizacion, idTrabajadorReg = @idTrabajador
    WHERE idDiferencia = @idDiferencia;
END
GO

/* ============================================================
   CUS-19 / CUS-20 / CUS-21  CONSULTAS   (RF-10, RF-15, RF-16)
   ============================================================ */

CREATE PROCEDURE spConsultarPedidos
(
    @desde DATE, @hasta DATE, @modalidad NVARCHAR(10) = NULL,
    @estAtencion NVARCHAR(15) = NULL, @estPago NVARCHAR(10) = NULL
)
AS
    SELECT p.idPedido, p.fecRegistro, p.modalidad, ISNULL(m.codigo,'-') AS mesa,
           STUFF((SELECT ', ' + pr.nombre + ' x' + CAST(d.cantidad AS NVARCHAR(5))
                  FROM DetallePedido d INNER JOIN Producto pr ON pr.idProducto = d.idProducto
                  WHERE d.idPedido = p.idPedido FOR XML PATH('')), 1, 2, '') AS productos,
           p.total,
           p.total - ISNULL((SELECT SUM(importe) FROM Pago WHERE idPedido = p.idPedido),0) AS saldo,
           p.estSolicitud, p.estAtencion, p.estPago,
           t.nombres + ' ' + t.apellidos AS responsable
    FROM Pedido p
    LEFT  JOIN Mesa m       ON m.idMesa = p.idMesa
    INNER JOIN Trabajador t ON t.idTrabajador = p.idTrabajadorReg
    WHERE CAST(p.fecRegistro AS DATE) BETWEEN @desde AND @hasta
      AND (@modalidad   IS NULL OR p.modalidad   = @modalidad)
      AND (@estAtencion IS NULL OR p.estAtencion = @estAtencion)
      AND (@estPago     IS NULL OR p.estPago     = @estPago)
    ORDER BY p.fecRegistro DESC;
GO

CREATE PROCEDURE spConsultarCobros
(
    @desde DATE, @hasta DATE, @medioPago NVARCHAR(10) = NULL, @idTrabajador INT = NULL
)
AS
    -- RFD-31: el total suma importes aplicados y excluye el vuelto
    SELECT g.idPago, g.idPedido, g.fecPago, g.importe, g.medioPago, g.vuelto,
           ISNULL(g.referencia,'') AS referencia,
           t.nombres + ' ' + t.apellidos AS cajera,
           p.modalidad
    FROM Pago g
    INNER JOIN Pedido p     ON p.idPedido = g.idPedido
    INNER JOIN Trabajador t ON t.idTrabajador = g.idTrabajador
    WHERE CAST(g.fecPago AS DATE) BETWEEN @desde AND @hasta
      AND (@medioPago    IS NULL OR g.medioPago    = @medioPago)
      AND (@idTrabajador IS NULL OR g.idTrabajador = @idTrabajador)
    ORDER BY g.fecPago DESC;
GO

CREATE PROCEDURE spConsultarAbastecimiento
(
    @idRequerimiento INT = NULL, @idProveedor INT = NULL, @estDiferencia NVARCHAR(12) = NULL
)
AS
    -- RFD-32: requerido, comprado y aceptado por insumo, sin duplicar acumulados
    SELECT r.idRequerimiento, r.semana, i.nombre AS insumo, u.abreviatura AS unidad,
           d.cantSolicitada AS requerido,
           ISNULL(cmp.comprado,0) AS comprado,
           ISNULL(acp.aceptado,0) AS aceptado,
           d.cantSolicitada - ISNULL(cmp.comprado,0) AS pendienteCompra,
           ISNULL(cmp.comprado,0) - ISNULL(acp.aceptado,0) AS pendienteRecepcion,
           ISNULL(dif.pendientes,0) AS difPendientes,
           ISNULL(dif.regularizadas,0) AS difRegularizadas
    FROM DetalleRequerimiento d
    INNER JOIN RequerimientoSemanal r ON r.idRequerimiento = d.idRequerimiento
    INNER JOIN Insumo i               ON i.idInsumo = d.idInsumo
    INNER JOIN UnidadMedida u         ON u.idUnidad = d.idUnidad
    OUTER APPLY (SELECT SUM(dc.cantidad) AS comprado
                 FROM DetalleCompra dc INNER JOIN Compra c ON c.idCompra = dc.idCompra
                 WHERE c.idRequerimiento = d.idRequerimiento AND dc.idInsumo = d.idInsumo
                   AND (@idProveedor IS NULL OR c.idProveedor = @idProveedor)) cmp
    OUTER APPLY (SELECT SUM(dr.cantAceptada) AS aceptado
                 FROM DetalleRecepcion dr
                 INNER JOIN DetalleCompra dc ON dc.idDetalleCompra = dr.idDetalleCompra
                 INNER JOIN Compra c         ON c.idCompra = dc.idCompra
                 WHERE c.idRequerimiento = d.idRequerimiento AND dc.idInsumo = d.idInsumo
                   AND (@idProveedor IS NULL OR c.idProveedor = @idProveedor)) acp
    OUTER APPLY (SELECT SUM(CASE WHEN df.estDiferencia = 'PENDIENTE'    THEN 1 ELSE 0 END) AS pendientes,
                        SUM(CASE WHEN df.estDiferencia = 'REGULARIZADO' THEN 1 ELSE 0 END) AS regularizadas
                 FROM DiferenciaRecepcion df
                 INNER JOIN DetalleRecepcion dr ON dr.idDetalleRecepcion = df.idDetalleRecepcion
                 INNER JOIN DetalleCompra dc    ON dc.idDetalleCompra = dr.idDetalleCompra
                 INNER JOIN Compra c            ON c.idCompra = dc.idCompra
                 WHERE c.idRequerimiento = d.idRequerimiento AND dc.idInsumo = d.idInsumo) dif
    WHERE (@idRequerimiento IS NULL OR d.idRequerimiento = @idRequerimiento)
      AND (@estDiferencia IS NULL
           OR (@estDiferencia = 'PENDIENTE'    AND ISNULL(dif.pendientes,0)    > 0)
           OR (@estDiferencia = 'REGULARIZADO' AND ISNULL(dif.regularizadas,0) > 0))
    ORDER BY r.semana DESC, i.nombre;
GO

/* ============================================================
   TRAZABILIDAD (RNF-07)
   ============================================================ */

CREATE PROCEDURE spRegistrarAuditoria
(
    @nomUsuario NVARCHAR(30), @entidad NVARCHAR(40), @idRegistro INT,
    @operacion NVARCHAR(30), @detalle NVARCHAR(250)
)
AS
    INSERT INTO Auditoria (nomUsuario, entidad, idRegistro, operacion, detalle)
    VALUES (@nomUsuario, @entidad, @idRegistro, @operacion, @detalle);
GO

PRINT 'BD_DonWilly: procedimientos almacenados creados correctamente.';
GO
