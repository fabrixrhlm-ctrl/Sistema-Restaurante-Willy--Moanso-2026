/* ============================================================
   SISTEMA DON WILLY - Restaurante "Don Willy" (Trujillo)
   Curso: Modelamiento y Analisis de Software (MOANSO 2026-2)
   Script 01: creacion de la base de datos y de las tablas
   Motor: SQL Server 2019 o superior
   ============================================================ */

IF DB_ID('BD_DonWilly') IS NOT NULL
BEGIN
    ALTER DATABASE BD_DonWilly SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE BD_DonWilly;
END
GO

CREATE DATABASE BD_DonWilly;
GO

USE BD_DonWilly;
GO

/* ------------------------------------------------------------
   GRUPO 1: CATALOGOS (mantenedores regulares)
   RF-07, RF-08, RF-09, RF-12, RF-13, RF-14
   ------------------------------------------------------------ */

CREATE TABLE UnidadMedida
(
    idUnidad        INT IDENTITY(1,1) NOT NULL,
    nombre          NVARCHAR(50)      NOT NULL,
    abreviatura     NVARCHAR(10)      NOT NULL,
    estUnidad       BIT               NOT NULL CONSTRAINT DF_Unidad_est DEFAULT(1),
    CONSTRAINT PK_UnidadMedida PRIMARY KEY CLUSTERED (idUnidad ASC),
    CONSTRAINT UQ_UnidadMedida_abrev UNIQUE (abreviatura)
);
GO

CREATE TABLE Insumo
(
    idInsumo        INT IDENTITY(1,1) NOT NULL,
    nombre          NVARCHAR(80)      NOT NULL,
    idUnidad        INT               NOT NULL,
    estInsumo       BIT               NOT NULL CONSTRAINT DF_Insumo_est DEFAULT(1),
    CONSTRAINT PK_Insumo PRIMARY KEY CLUSTERED (idInsumo ASC),
    CONSTRAINT UQ_Insumo_nombre UNIQUE (nombre),
    CONSTRAINT FK_Insumo_Unidad FOREIGN KEY (idUnidad) REFERENCES UnidadMedida(idUnidad)
);
GO

CREATE TABLE Producto
(
    idProducto      INT IDENTITY(1,1) NOT NULL,
    nombre          NVARCHAR(80)      NOT NULL,
    tipoProducto    NVARCHAR(20)      NOT NULL,   -- PLATO | MENU | BEBIDA
    precio          DECIMAL(10,2)     NOT NULL,
    disponible      BIT               NOT NULL CONSTRAINT DF_Producto_disp DEFAULT(1),
    estProducto     BIT               NOT NULL CONSTRAINT DF_Producto_est  DEFAULT(1),
    CONSTRAINT PK_Producto PRIMARY KEY CLUSTERED (idProducto ASC),
    CONSTRAINT UQ_Producto_nombre UNIQUE (nombre),
    CONSTRAINT CK_Producto_precio CHECK (precio >= 0),
    CONSTRAINT CK_Producto_tipo   CHECK (tipoProducto IN ('PLATO','MENU','BEBIDA'))
);
GO

CREATE TABLE Proveedor
(
    idProveedor     INT IDENTITY(1,1) NOT NULL,
    razonSocial     NVARCHAR(100)     NOT NULL,
    documento       NVARCHAR(15)      NULL,
    direccion       NVARCHAR(120)     NULL,
    telefono        NVARCHAR(15)      NULL,
    estProveedor    BIT               NOT NULL CONSTRAINT DF_Proveedor_est DEFAULT(1),
    CONSTRAINT PK_Proveedor PRIMARY KEY CLUSTERED (idProveedor ASC)
);
GO

CREATE UNIQUE INDEX UQ_Proveedor_doc ON Proveedor(documento) WHERE documento IS NOT NULL;
GO

CREATE TABLE Mesa
(
    idMesa          INT IDENTITY(1,1) NOT NULL,
    codigo          NVARCHAR(10)      NOT NULL,
    ubicacion       NVARCHAR(60)      NULL,
    capacidad       INT               NOT NULL,
    estMesa         BIT               NOT NULL CONSTRAINT DF_Mesa_est DEFAULT(1),
    CONSTRAINT PK_Mesa PRIMARY KEY CLUSTERED (idMesa ASC),
    CONSTRAINT UQ_Mesa_codigo UNIQUE (codigo),
    CONSTRAINT CK_Mesa_capacidad CHECK (capacidad > 0)
);
GO

CREATE TABLE Trabajador
(
    idTrabajador    INT IDENTITY(1,1) NOT NULL,
    documento       NVARCHAR(15)      NOT NULL,
    nombres         NVARCHAR(60)      NOT NULL,
    apellidos       NVARCHAR(60)      NOT NULL,
    cargo           NVARCHAR(40)      NOT NULL,
    telefono        NVARCHAR(15)      NULL,
    estTrabajador   BIT               NOT NULL CONSTRAINT DF_Trabajador_est DEFAULT(1),
    CONSTRAINT PK_Trabajador PRIMARY KEY CLUSTERED (idTrabajador ASC),
    CONSTRAINT UQ_Trabajador_doc UNIQUE (documento)
);
GO

/* ------------------------------------------------------------
   GRUPO 2: ACCESOS (RF-11)
   ------------------------------------------------------------ */

CREATE TABLE Perfil
(
    idPerfil        INT IDENTITY(1,1) NOT NULL,
    nombre          NVARCHAR(30)      NOT NULL,
    CONSTRAINT PK_Perfil PRIMARY KEY CLUSTERED (idPerfil ASC),
    CONSTRAINT UQ_Perfil_nombre UNIQUE (nombre)
);
GO

CREATE TABLE Usuario
(
    idUsuario       INT IDENTITY(1,1) NOT NULL,
    idTrabajador    INT               NOT NULL,
    nomUsuario      NVARCHAR(30)      NOT NULL,
    claveHash       NVARCHAR(100)     NOT NULL,   -- SHA-256 en Base64 (RNF-02)
    claveSal        NVARCHAR(50)      NOT NULL,
    estUsuario      BIT               NOT NULL CONSTRAINT DF_Usuario_est DEFAULT(1),
    CONSTRAINT PK_Usuario PRIMARY KEY CLUSTERED (idUsuario ASC),
    CONSTRAINT UQ_Usuario_nom UNIQUE (nomUsuario),
    CONSTRAINT FK_Usuario_Trabajador FOREIGN KEY (idTrabajador) REFERENCES Trabajador(idTrabajador)
);
GO

CREATE TABLE UsuarioPerfil
(
    idUsuario       INT NOT NULL,
    idPerfil        INT NOT NULL,
    CONSTRAINT PK_UsuarioPerfil PRIMARY KEY CLUSTERED (idUsuario ASC, idPerfil ASC),
    CONSTRAINT FK_UsuarioPerfil_Usuario FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario),
    CONSTRAINT FK_UsuarioPerfil_Perfil  FOREIGN KEY (idPerfil)  REFERENCES Perfil(idPerfil)
);
GO

/* ------------------------------------------------------------
   GRUPO 3: ATENCION Y COBRO (RF-01, RF-02, RF-03)
   ------------------------------------------------------------ */

CREATE TABLE Pedido
(
    idPedido          INT IDENTITY(1,1) NOT NULL,
    modalidad         NVARCHAR(10)      NOT NULL,  -- MESA | LLEVAR
    idMesa            INT               NULL,
    idTrabajadorReg   INT               NOT NULL,
    fecRegistro       DATETIME          NOT NULL CONSTRAINT DF_Pedido_fec DEFAULT(GETDATE()),
    estSolicitud      NVARCHAR(15)      NOT NULL,  -- PENDIENTE|RESPONDIDA|CONFIRMADA|DESISTIDA
    estAtencion       NVARCHAR(15)      NOT NULL,  -- SIN_INICIAR|PREPARACION|LISTO|POR_CORREGIR|ENTREGADO
    estPago           NVARCHAR(10)      NOT NULL,  -- PENDIENTE|PARCIAL|PAGADO
    total             DECIMAL(10,2)     NOT NULL CONSTRAINT DF_Pedido_total DEFAULT(0),
    motivoDesiste     NVARCHAR(150)     NULL,
    CONSTRAINT PK_Pedido PRIMARY KEY CLUSTERED (idPedido ASC),
    CONSTRAINT FK_Pedido_Mesa       FOREIGN KEY (idMesa)          REFERENCES Mesa(idMesa),
    CONSTRAINT FK_Pedido_Trabajador FOREIGN KEY (idTrabajadorReg) REFERENCES Trabajador(idTrabajador),
    CONSTRAINT CK_Pedido_modalidad  CHECK (modalidad IN ('MESA','LLEVAR')),
    CONSTRAINT CK_Pedido_mesa       CHECK ((modalidad = 'MESA' AND idMesa IS NOT NULL) OR modalidad = 'LLEVAR')
);
GO

CREATE TABLE DetallePedido
(
    idDetallePedido INT IDENTITY(1,1) NOT NULL,
    idPedido        INT               NOT NULL,
    idProducto      INT               NOT NULL,
    cantidad        INT               NOT NULL,
    precioAplicado  DECIMAL(10,2)     NOT NULL,   -- precio historico (RFD-21)
    CONSTRAINT PK_DetallePedido PRIMARY KEY CLUSTERED (idDetallePedido ASC),
    CONSTRAINT FK_DetPedido_Pedido   FOREIGN KEY (idPedido)   REFERENCES Pedido(idPedido),
    CONSTRAINT FK_DetPedido_Producto FOREIGN KEY (idProducto) REFERENCES Producto(idProducto),
    CONSTRAINT CK_DetPedido_cantidad CHECK (cantidad > 0),
    CONSTRAINT CK_DetPedido_precio   CHECK (precioAplicado >= 0)
);
GO

CREATE TABLE RespuestaDisponibilidad
(
    idRespuesta     INT IDENTITY(1,1) NOT NULL,
    idPedido        INT               NOT NULL,
    idTrabajador    INT               NOT NULL,
    fecRespuesta    DATETIME          NOT NULL CONSTRAINT DF_Resp_fec DEFAULT(GETDATE()),
    resultado       NVARCHAR(12)      NOT NULL,  -- FAVORABLE | FALTANTES
    observacion     NVARCHAR(250)     NULL,
    vigente         BIT               NOT NULL CONSTRAINT DF_Resp_vig DEFAULT(1),
    CONSTRAINT PK_RespuestaDisponibilidad PRIMARY KEY CLUSTERED (idRespuesta ASC),
    CONSTRAINT FK_Resp_Pedido     FOREIGN KEY (idPedido)     REFERENCES Pedido(idPedido),
    CONSTRAINT FK_Resp_Trabajador FOREIGN KEY (idTrabajador) REFERENCES Trabajador(idTrabajador),
    CONSTRAINT CK_Resp_resultado  CHECK (resultado IN ('FAVORABLE','FALTANTES'))
);
GO

CREATE TABLE Pago
(
    idPago          INT IDENTITY(1,1) NOT NULL,
    idPedido        INT               NOT NULL,
    fecPago         DATETIME          NOT NULL CONSTRAINT DF_Pago_fec DEFAULT(GETDATE()),
    importe         DECIMAL(10,2)     NOT NULL,   -- importe aplicado al saldo (sin vuelto)
    medioPago       NVARCHAR(10)      NOT NULL,   -- EFECTIVO | YAPE
    montoRecibido   DECIMAL(10,2)     NOT NULL CONSTRAINT DF_Pago_recibido DEFAULT(0),
    vuelto          DECIMAL(10,2)     NOT NULL CONSTRAINT DF_Pago_vuelto DEFAULT(0),
    referencia      NVARCHAR(40)      NULL,
    idTrabajador    INT               NOT NULL,
    CONSTRAINT PK_Pago PRIMARY KEY CLUSTERED (idPago ASC),
    CONSTRAINT FK_Pago_Pedido     FOREIGN KEY (idPedido)     REFERENCES Pedido(idPedido),
    CONSTRAINT FK_Pago_Trabajador FOREIGN KEY (idTrabajador) REFERENCES Trabajador(idTrabajador),
    CONSTRAINT CK_Pago_importe    CHECK (importe > 0),
    CONSTRAINT CK_Pago_medio      CHECK (medioPago IN ('EFECTIVO','YAPE'))
);
GO

/* ------------------------------------------------------------
   GRUPO 4: ABASTECIMIENTO (RF-04, RF-05, RF-06)
   ------------------------------------------------------------ */

CREATE TABLE RequerimientoSemanal
(
    idRequerimiento   INT IDENTITY(1,1) NOT NULL,
    semana            NVARCHAR(20)      NOT NULL,
    fecConteo         DATE              NOT NULL,
    fecRegistro       DATETIME          NOT NULL CONSTRAINT DF_Req_fec DEFAULT(GETDATE()),
    idTrabajadorAlm   INT               NOT NULL,
    estRequerimiento  NVARCHAR(12)      NOT NULL,  -- BORRADOR|PENDIENTE|REVISADO|DEVUELTO
    observacion       NVARCHAR(250)     NULL,
    idTrabajadorRev   INT               NULL,
    fecRevision       DATETIME          NULL,
    CONSTRAINT PK_RequerimientoSemanal PRIMARY KEY CLUSTERED (idRequerimiento ASC),
    CONSTRAINT FK_Req_Almacen FOREIGN KEY (idTrabajadorAlm) REFERENCES Trabajador(idTrabajador),
    CONSTRAINT FK_Req_Revisor FOREIGN KEY (idTrabajadorRev) REFERENCES Trabajador(idTrabajador),
    CONSTRAINT CK_Req_estado  CHECK (estRequerimiento IN ('BORRADOR','PENDIENTE','REVISADO','DEVUELTO'))
);
GO

CREATE TABLE DetalleRequerimiento
(
    idDetalleReq      INT IDENTITY(1,1) NOT NULL,
    idRequerimiento   INT               NOT NULL,
    idInsumo          INT               NOT NULL,
    idUnidad          INT               NOT NULL,
    cantUtilizable    DECIMAL(10,2)     NOT NULL,   -- conteo fisico con fecha (RFD-11)
    cantNecesidad     DECIMAL(10,2)     NOT NULL,
    cantSolicitada    DECIMAL(10,2)     NOT NULL,
    CONSTRAINT PK_DetalleRequerimiento PRIMARY KEY CLUSTERED (idDetalleReq ASC),
    CONSTRAINT FK_DetReq_Req    FOREIGN KEY (idRequerimiento) REFERENCES RequerimientoSemanal(idRequerimiento),
    CONSTRAINT FK_DetReq_Insumo FOREIGN KEY (idInsumo)        REFERENCES Insumo(idInsumo),
    CONSTRAINT FK_DetReq_Unidad FOREIGN KEY (idUnidad)        REFERENCES UnidadMedida(idUnidad),
    CONSTRAINT CK_DetReq_cant   CHECK (cantUtilizable >= 0 AND cantNecesidad >= 0 AND cantSolicitada > 0)
);
GO

CREATE TABLE Compra
(
    idCompra          INT IDENTITY(1,1) NOT NULL,
    idRequerimiento   INT               NOT NULL,
    idProveedor       INT               NOT NULL,
    fecCompra         DATE              NOT NULL,
    documento         NVARCHAR(30)      NULL,
    total             DECIMAL(10,2)     NOT NULL CONSTRAINT DF_Compra_total DEFAULT(0),
    observacion       NVARCHAR(250)     NULL,
    idTrabajador      INT               NOT NULL,
    CONSTRAINT PK_Compra PRIMARY KEY CLUSTERED (idCompra ASC),
    CONSTRAINT FK_Compra_Req        FOREIGN KEY (idRequerimiento) REFERENCES RequerimientoSemanal(idRequerimiento),
    CONSTRAINT FK_Compra_Proveedor  FOREIGN KEY (idProveedor)     REFERENCES Proveedor(idProveedor),
    CONSTRAINT FK_Compra_Trabajador FOREIGN KEY (idTrabajador)    REFERENCES Trabajador(idTrabajador)
);
GO

CREATE TABLE DetalleCompra
(
    idDetalleCompra INT IDENTITY(1,1) NOT NULL,
    idCompra        INT               NOT NULL,
    idInsumo        INT               NOT NULL,
    idUnidad        INT               NOT NULL,
    cantidad        DECIMAL(10,2)     NOT NULL,
    precioUnitario  DECIMAL(10,2)     NOT NULL,
    subtotal        DECIMAL(10,2)     NOT NULL,
    CONSTRAINT PK_DetalleCompra PRIMARY KEY CLUSTERED (idDetalleCompra ASC),
    CONSTRAINT FK_DetCompra_Compra FOREIGN KEY (idCompra) REFERENCES Compra(idCompra),
    CONSTRAINT FK_DetCompra_Insumo FOREIGN KEY (idInsumo) REFERENCES Insumo(idInsumo),
    CONSTRAINT FK_DetCompra_Unidad FOREIGN KEY (idUnidad) REFERENCES UnidadMedida(idUnidad),
    CONSTRAINT CK_DetCompra_cant   CHECK (cantidad > 0 AND precioUnitario >= 0)
);
GO

CREATE TABLE Recepcion
(
    idRecepcion     INT IDENTITY(1,1) NOT NULL,
    idCompra        INT               NOT NULL,
    fecRecepcion    DATE              NOT NULL,
    idTrabajador    INT               NOT NULL,
    observacion     NVARCHAR(250)     NULL,
    CONSTRAINT PK_Recepcion PRIMARY KEY CLUSTERED (idRecepcion ASC),
    CONSTRAINT FK_Recepcion_Compra     FOREIGN KEY (idCompra)     REFERENCES Compra(idCompra),
    CONSTRAINT FK_Recepcion_Trabajador FOREIGN KEY (idTrabajador) REFERENCES Trabajador(idTrabajador)
);
GO

CREATE TABLE DetalleRecepcion
(
    idDetalleRecepcion INT IDENTITY(1,1) NOT NULL,
    idRecepcion        INT              NOT NULL,
    idDetalleCompra    INT              NOT NULL,
    cantRecibida       DECIMAL(10,2)    NOT NULL,
    cantAceptada       DECIMAL(10,2)    NOT NULL,
    cantObservada      DECIMAL(10,2)    NOT NULL,
    CONSTRAINT PK_DetalleRecepcion PRIMARY KEY CLUSTERED (idDetalleRecepcion ASC),
    CONSTRAINT FK_DetRecep_Recepcion FOREIGN KEY (idRecepcion)     REFERENCES Recepcion(idRecepcion),
    CONSTRAINT FK_DetRecep_DetCompra FOREIGN KEY (idDetalleCompra) REFERENCES DetalleCompra(idDetalleCompra),
    CONSTRAINT CK_DetRecep_cant      CHECK (cantRecibida >= 0 AND cantAceptada >= 0 AND cantObservada >= 0),
    CONSTRAINT CK_DetRecep_suma      CHECK (cantAceptada + cantObservada = cantRecibida)   -- RFD-18
);
GO

CREATE TABLE DiferenciaRecepcion
(
    idDiferencia       INT IDENTITY(1,1) NOT NULL,
    idDetalleRecepcion INT               NOT NULL,
    motivo             NVARCHAR(250)     NOT NULL,
    estDiferencia      NVARCHAR(12)      NOT NULL CONSTRAINT DF_Dif_est DEFAULT('PENDIENTE'),
    solucion           NVARCHAR(250)     NULL,
    sustento           NVARCHAR(60)      NULL,
    fecRegularizacion  DATE              NULL,
    idTrabajadorReg    INT               NULL,
    CONSTRAINT PK_DiferenciaRecepcion PRIMARY KEY CLUSTERED (idDiferencia ASC),
    CONSTRAINT FK_Dif_DetRecep    FOREIGN KEY (idDetalleRecepcion) REFERENCES DetalleRecepcion(idDetalleRecepcion),
    CONSTRAINT FK_Dif_Trabajador  FOREIGN KEY (idTrabajadorReg)    REFERENCES Trabajador(idTrabajador),
    CONSTRAINT CK_Dif_estado      CHECK (estDiferencia IN ('PENDIENTE','REGULARIZADO'))
);
GO

/* ------------------------------------------------------------
   GRUPO 5: TRAZABILIDAD (RNF-07)
   ------------------------------------------------------------ */

CREATE TABLE Auditoria
(
    idAuditoria   INT IDENTITY(1,1) NOT NULL,
    fecEvento     DATETIME          NOT NULL CONSTRAINT DF_Aud_fec DEFAULT(GETDATE()),
    nomUsuario    NVARCHAR(30)      NOT NULL,
    entidad       NVARCHAR(40)      NOT NULL,
    idRegistro    INT               NULL,
    operacion     NVARCHAR(30)      NOT NULL,
    detalle       NVARCHAR(250)     NULL,
    CONSTRAINT PK_Auditoria PRIMARY KEY CLUSTERED (idAuditoria ASC)
);
GO

PRINT 'BD_DonWilly: tablas creadas correctamente.';
GO
