using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPComercio.Dominio;

namespace TPComercio.Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> Listar()
        {
            ClienteDatos datos = new ClienteDatos();
            return datos.ListarTodos();
        }

        public void Agregar(Cliente nuevo)
        {
            if (string.IsNullOrWhiteSpace(nuevo.Nombre))
            {
                throw new Exception("El Nombre del cliente no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(nuevo.Apellido))
            {
                throw new Exception("El Apellido del cliente no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(nuevo.Dni))
            {
                throw new Exception("El DNI del cliente no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(nuevo.Telefono))
            {
                throw new Exception("El Teléfono del cliente no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(nuevo.Email))
            {
                throw new Exception("El Email del cliente no puede estar vacío.");
            }

            ClienteDatos datos = new ClienteDatos();
            datos.Agregar(nuevo);
        }

        public void Modificar(Cliente modificado)
        {
            if (string.IsNullOrWhiteSpace(modificado.Nombre))
                throw new Exception("El Nombre del cliente no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(modificado.Apellido))
                throw new Exception("El Apellido del cliente no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(modificado.Dni))
                throw new Exception("El DNI del cliente no puede estar vacío.");

            ClienteDatos datos = new ClienteDatos();
            datos.Modificar(modificado);
        }

        public void Eliminar(int id)
        {
            try
            {
                ClienteDatos datos = new ClienteDatos();
                datos.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}