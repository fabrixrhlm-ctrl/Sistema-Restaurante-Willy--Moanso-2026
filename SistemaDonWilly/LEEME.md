# Sistema Don Willy - Software de gestión para el Restaurante Don Willy

Proyecto en C# (.NET Framework 4.8.1, Windows Forms) con arquitectura en 4 capas, basado en el informe del Grupo 06 y en el patrón del ejemplo MANTENEDOR CLIENTE.

## Estructura

| Capa | Proyecto | Contenido |
|---|---|---|
| Entidad | `CapaEntidad` | Clases `ent*` y `entSesion` (sesión y perfiles) |
| Acceso a datos | `CapaAccesoDatos` | `Conexion` (Singleton) y clases `dat*` que llaman procedimientos almacenados |
| Lógica de negocio | `CapaLogicaNegocio` | Clases `log*` (Singleton), validaciones, permisos por perfil y auditoría |
| Presentación | `CapaPresentacion` | Formularios Windows Forms (ejecutable `DonWilly.exe`) |
| Base de datos | `BaseDatos` | 3 scripts SQL Server |

## Instalación (paso a paso)

1. Abrir **SQL Server Management Studio** y ejecutar, en este orden:
   1. `BaseDatos/01_CrearBaseDatos.sql`
   2. `BaseDatos/02_Procedimientos.sql`
   3. `BaseDatos/03_DatosIniciales.sql`
2. Abrir `SistemaDonWilly.sln` con Visual Studio 2019 o 2022.
3. En `CapaPresentacion/App.config`, ajustar la cadena de conexión `BD_DonWilly` si tu servidor no es `.` (por ejemplo `.\SQLEXPRESS`).
4. Clic derecho en `CapaPresentacion` > **Establecer como proyecto de inicio**, y ejecutar con **F5**.

## Usuarios de prueba

| Usuario | Clave | Perfil | Pantallas disponibles |
|---|---|---|---|
| admin | admin123 | ADMINISTRADOR | Todas |
| mesera | mesera123 | MESERA | Solicitud de pedido, disponibilidad, despacho, consultas |
| cocina | cocina123 | COCINA | Disponibilidad, preparación, consultas |
| cajera | cajera123 | CAJERA | Cobro, consulta de cobros |
| almacen | almacen123 | ALMACEN | Requerimiento, compra, recepción, diferencias, consulta de abastecimiento |

## Correspondencia con el informe

- **Pedidos:** solicitud, atención y pago son estados independientes (`estSolicitud`, `estAtencion`, `estPago`).
- **Abastecimiento:** requerimiento semanal, revisión, compra, recepción y regularización de diferencias.
- **RNF-01:** los permisos se validan en la capa lógica en cada operación.
- **RNF-02:** claves con SHA-256 + sal; la conexión está en `App.config`.
- **RNF-03:** transacciones; cabecera y detalle se guardan de forma atómica con tipos de tabla (TVP).
- **RNF-07:** tabla `Auditoria` con registro de operaciones.
- **Mantenedores:** Producto, Insumo, Proveedor, Mesa, Trabajador, Unidad de medida y Usuario, todos con eliminación lógica (deshabilitar/habilitar).
