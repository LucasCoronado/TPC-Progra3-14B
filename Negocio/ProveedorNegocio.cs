using Datos;
using System;
using System.Collections.Generic;
using TPComercio.Dominio;

namespace TPComercio.Negocio
{
    public class ProveedorNegocio
    {
        public List<Proveedor> Listar()
        {
            ProveedorDatos datos = new ProveedorDatos();
            return datos.ListarTodos();
        }

        public void Agregar(Proveedor nuevo)
        {
            if (string.IsNullOrWhiteSpace(nuevo.RazonSocial))
                throw new Exception("La Razón Social del proveedor no puede estar vacía.");
            if (string.IsNullOrWhiteSpace(nuevo.Cuit))
                throw new Exception("El CUIT del proveedor no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(nuevo.Telefono))
                throw new Exception("El Teléfono del proveedor no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(nuevo.Email))
                throw new Exception("El Email del proveedor no puede estar vacío.");

            ProveedorDatos datos = new ProveedorDatos();
            datos.Agregar(nuevo);
        }

        public void Modificar(Proveedor modificado)
        {
            if (string.IsNullOrWhiteSpace(modificado.RazonSocial))
                throw new Exception("La Razón Social del proveedor no puede estar vacía.");

            if (string.IsNullOrWhiteSpace(modificado.Cuit))
                throw new Exception("El CUIT del proveedor no puede estar vacío.");

            ProveedorDatos datos = new ProveedorDatos();
            datos.Modificar(modificado);
        }

        public void Eliminar(int id)
        {
            try
            {
                ProveedorDatos datos = new ProveedorDatos();
                datos.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}