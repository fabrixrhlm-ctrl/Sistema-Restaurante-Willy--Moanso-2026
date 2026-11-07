using System;
using System.Collections.Generic;
using CapaAccesoDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
    /// <summary>Reglas del mantenedor de unidades de medida (CUS-17 / RF-14).</summary>
    public class logUnidadMedida
    {
        private static readonly logUnidadMedida _instancia = new logUnidadMedida();

        private logUnidadMedida()
        {
        }

        public static logUnidadMedida Instancia
        {
            get { return logUnidadMedida._instancia; }
        }

        public List<entUnidadMedida> Listar()
        {
            return datUnidadMedida.Instancia.Listar();
        }

        public List<entUnidadMedida> ListarActivas()
        {
            return datUnidadMedida.Instancia.ListarActivos();
        }

        public List<entUnidadMedida> Buscar(string texto)
        {
            return datUnidadMedida.Instancia.Buscar(Validacion.Limpiar(texto));
        }

        public int Insertar(entUnidadMedida u)
        {
            Validar(u);
            return datUnidadMedida.Instancia.Insertar(u);
        }

        public void Editar(entUnidadMedida u)
        {
            Validacion.Seleccionado(u.idUnidad, "una unidad de medida");
            Validar(u);
            datUnidadMedida.Instancia.Editar(u);
        }

        public void Deshabilitar(int idUnidad)
        {
            Validacion.Seleccionado(idUnidad, "una unidad de medida");
            datUnidadMedida.Instancia.Deshabilitar(idUnidad);
        }

        public void Habilitar(int idUnidad)
        {
            Validacion.Seleccionado(idUnidad, "una unidad de medida");
            datUnidadMedida.Instancia.Habilitar(idUnidad);
        }

        private void Validar(entUnidadMedida u)
        {
            u.nombre = Validacion.Limpiar(u.nombre);
            u.abreviatura = Validacion.Limpiar(u.abreviatura);
            Validacion.Requerido(u.nombre, "nombre");
            Validacion.Requerido(u.abreviatura, "abreviatura");
            Validacion.LongitudMaxima(u.nombre, 50, "nombre");
            Validacion.LongitudMaxima(u.abreviatura, 10, "abreviatura");
        }
    }

    /// <summary>Reglas del mantenedor de insumos (CUS-13 / RF-08).</summary>
    public class logInsumo
    {
        private static readonly logInsumo _instancia = new logInsumo();

        private logInsumo()
        {
        }

        public static logInsumo Instancia
        {
            get { return logInsumo._instancia; }
        }

        public List<entInsumo> Listar()
        {
            return datInsumo.Instancia.Listar();
        }

        public List<entInsumo> ListarActivos()
        {
            return datInsumo.Instancia.ListarActivos();
        }

        public List<entInsumo> Buscar(string texto)
        {
            return datInsumo.Instancia.Buscar(Validacion.Limpiar(texto));
        }

        public int Insertar(entInsumo i)
        {
            Validar(i);
            return datInsumo.Instancia.Insertar(i);
        }

        public void Editar(entInsumo i)
        {
            Validacion.Seleccionado(i.idInsumo, "un insumo");
            Validar(i);
            datInsumo.Instancia.Editar(i);
        }

        public void Deshabilitar(int idInsumo)
        {
            Validacion.Seleccionado(idInsumo, "un insumo");
            datInsumo.Instancia.Deshabilitar(idInsumo);
        }

        public void Habilitar(int idInsumo)
        {
            Validacion.Seleccionado(idInsumo, "un insumo");
            datInsumo.Instancia.Habilitar(idInsumo);
        }

        private void Validar(entInsumo i)
        {
            i.nombre = Validacion.Limpiar(i.nombre);
            Validacion.Requerido(i.nombre, "nombre");
            Validacion.LongitudMaxima(i.nombre, 80, "nombre");
            Validacion.Seleccionado(i.idUnidad, "una unidad de medida activa");
        }
    }

    /// <summary>Reglas del mantenedor de productos de la carta (CUS-12 / RF-07).</summary>
    public class logProducto
    {
        private static readonly logProducto _instancia = new logProducto();

        private logProducto()
        {
        }

        public static logProducto Instancia
        {
            get { return logProducto._instancia; }
        }

        public List<entProducto> Listar()
        {
            return datProducto.Instancia.Listar();
        }

        /// <summary>Oferta vigente que se muestra al tomar una solicitud (ACT-01).</summary>
        public List<entProducto> ListarDisponibles()
        {
            return datProducto.Instancia.ListarActivos();
        }

        public List<entProducto> Buscar(string texto)
        {
            return datProducto.Instancia.Buscar(Validacion.Limpiar(texto));
        }

        public int Insertar(entProducto p)
        {
            Validar(p);
            return datProducto.Instancia.Insertar(p);
        }

        public void Editar(entProducto p)
        {
            Validacion.Seleccionado(p.idProducto, "un producto");
            Validar(p);
            datProducto.Instancia.Editar(p);
        }

        public void Deshabilitar(int idProducto)
        {
            Validacion.Seleccionado(idProducto, "un producto");
            datProducto.Instancia.Deshabilitar(idProducto);
        }

        public void Habilitar(int idProducto)
        {
            Validacion.Seleccionado(idProducto, "un producto");
            datProducto.Instancia.Habilitar(idProducto);
        }

        private void Validar(entProducto p)
        {
            p.nombre = Validacion.Limpiar(p.nombre);
            Validacion.Requerido(p.nombre, "nombre");
            Validacion.LongitudMaxima(p.nombre, 80, "nombre");
            Validacion.Requerido(p.tipoProducto, "tipo de producto");
            Validacion.NoNegativo(p.precio, "precio");
        }
    }

    /// <summary>Reglas del mantenedor de proveedores (CUS-14 / RF-09).</summary>
    public class logProveedor
    {
        private static readonly logProveedor _instancia = new logProveedor();

        private logProveedor()
        {
        }

        public static logProveedor Instancia
        {
            get { return logProveedor._instancia; }
        }

        public List<entProveedor> Listar()
        {
            return datProveedor.Instancia.Listar();
        }

        public List<entProveedor> ListarActivos()
        {
            return datProveedor.Instancia.ListarActivos();
        }

        public List<entProveedor> Buscar(string texto)
        {
            return datProveedor.Instancia.Buscar(Validacion.Limpiar(texto));
        }

        public int Insertar(entProveedor p)
        {
            Validar(p);
            return datProveedor.Instancia.Insertar(p);
        }

        public void Editar(entProveedor p)
        {
            Validacion.Seleccionado(p.idProveedor, "un proveedor");
            Validar(p);
            datProveedor.Instancia.Editar(p);
        }

        public void Deshabilitar(int idProveedor)
        {
            Validacion.Seleccionado(idProveedor, "un proveedor");
            datProveedor.Instancia.Deshabilitar(idProveedor);
        }

        public void Habilitar(int idProveedor)
        {
            Validacion.Seleccionado(idProveedor, "un proveedor");
            datProveedor.Instancia.Habilitar(idProveedor);
        }

        private void Validar(entProveedor p)
        {
            p.razonSocial = Validacion.Limpiar(p.razonSocial);
            p.documento = Validacion.Limpiar(p.documento);
            p.direccion = Validacion.Limpiar(p.direccion);
            p.telefono = Validacion.Limpiar(p.telefono);
            Validacion.Requerido(p.razonSocial, "razon social");
            Validacion.LongitudMaxima(p.razonSocial, 100, "razon social");
            Validacion.SoloDigitos(p.documento, "documento");
            Validacion.LongitudMaxima(p.documento, 15, "documento");
            Validacion.SoloDigitos(p.telefono.Replace("-", string.Empty), "telefono");
        }
    }

    /// <summary>Reglas del mantenedor de mesas (CUS-15 / RF-12).</summary>
    public class logMesa
    {
        private static readonly logMesa _instancia = new logMesa();

        private logMesa()
        {
        }

        public static logMesa Instancia
        {
            get { return logMesa._instancia; }
        }

        public List<entMesa> Listar()
        {
            return datMesa.Instancia.Listar();
        }

        public List<entMesa> ListarActivas()
        {
            return datMesa.Instancia.ListarActivos();
        }

        public List<entMesa> Buscar(string texto)
        {
            return datMesa.Instancia.Buscar(Validacion.Limpiar(texto));
        }

        public int Insertar(entMesa m)
        {
            Validar(m);
            return datMesa.Instancia.Insertar(m);
        }

        public void Editar(entMesa m)
        {
            Validacion.Seleccionado(m.idMesa, "una mesa");
            Validar(m);
            datMesa.Instancia.Editar(m);
        }

        public void Deshabilitar(int idMesa)
        {
            Validacion.Seleccionado(idMesa, "una mesa");
            datMesa.Instancia.Deshabilitar(idMesa);
        }

        public void Habilitar(int idMesa)
        {
            Validacion.Seleccionado(idMesa, "una mesa");
            datMesa.Instancia.Habilitar(idMesa);
        }

        private void Validar(entMesa m)
        {
            m.codigo = Validacion.Limpiar(m.codigo);
            m.ubicacion = Validacion.Limpiar(m.ubicacion);
            Validacion.Requerido(m.codigo, "codigo");
            Validacion.LongitudMaxima(m.codigo, 10, "codigo");
            Validacion.Positivo(m.capacidad, "capacidad");
        }
    }

    /// <summary>Reglas del mantenedor de trabajadores (CUS-16 / RF-13).</summary>
    public class logTrabajador
    {
        private static readonly logTrabajador _instancia = new logTrabajador();

        private logTrabajador()
        {
        }

        public static logTrabajador Instancia
        {
            get { return logTrabajador._instancia; }
        }

        public List<entTrabajador> Listar()
        {
            return datTrabajador.Instancia.Listar();
        }

        public List<entTrabajador> ListarActivos()
        {
            return datTrabajador.Instancia.ListarActivos();
        }

        public List<entTrabajador> Buscar(string texto)
        {
            return datTrabajador.Instancia.Buscar(Validacion.Limpiar(texto));
        }

        public int Insertar(entTrabajador t)
        {
            Validar(t);
            return datTrabajador.Instancia.Insertar(t);
        }

        public void Editar(entTrabajador t)
        {
            Validacion.Seleccionado(t.idTrabajador, "un trabajador");
            Validar(t);
            datTrabajador.Instancia.Editar(t);
        }

        public void Deshabilitar(int idTrabajador)
        {
            Validacion.Seleccionado(idTrabajador, "un trabajador");
            datTrabajador.Instancia.Deshabilitar(idTrabajador);
        }

        public void Habilitar(int idTrabajador)
        {
            Validacion.Seleccionado(idTrabajador, "un trabajador");
            datTrabajador.Instancia.Habilitar(idTrabajador);
        }

        private void Validar(entTrabajador t)
        {
            t.documento = Validacion.Limpiar(t.documento);
            t.nombres = Validacion.Limpiar(t.nombres);
            t.apellidos = Validacion.Limpiar(t.apellidos);
            t.cargo = Validacion.Limpiar(t.cargo);
            t.telefono = Validacion.Limpiar(t.telefono);
            Validacion.Requerido(t.documento, "documento");
            Validacion.SoloDigitos(t.documento, "documento");
            Validacion.Requerido(t.nombres, "nombres");
            Validacion.Requerido(t.apellidos, "apellidos");
            Validacion.Requerido(t.cargo, "cargo");
            Validacion.LongitudMaxima(t.documento, 15, "documento");
        }
    }
}
