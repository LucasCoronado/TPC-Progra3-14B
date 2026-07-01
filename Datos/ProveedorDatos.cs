using System;
using System.Collections.Generic;
using TPComercio.Datos;
using TPComercio.Dominio;

namespace Datos
{
    public class ProveedorDatos
    {
        public List<Proveedor> ListarTodos()
        {
            List<Proveedor> lista = new List<Proveedor>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, RazonSocial, Cuit, Telefono, Email, Activo FROM Proveedores WHERE Activo = 1;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Proveedor aux = new Proveedor();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.RazonSocial = (string)datos.Lector["RazonSocial"];
                    aux.Cuit = (string)datos.Lector["Cuit"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Activo = (bool)datos.Lector["Activo"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Agregar(Proveedor nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO PROVEEDORES (RazonSocial, Cuit, Telefono, Email, Activo) VALUES (@RazonSocial, @Cuit, @Telefono, @Email, 1)");
                datos.setearParametro("@RazonSocial", nuevo.RazonSocial);
                datos.setearParametro("@Cuit", nuevo.Cuit);
                datos.setearParametro("@Telefono", nuevo.Telefono);
                datos.setearParametro("@Email", nuevo.Email);

                datos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Modificar(Proveedor proveedor)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE PROVEEDORES SET RazonSocial = @RazonSocial, Cuit = @Cuit, Telefono = @Telefono, Email = @Email WHERE Id = @Id");

                datos.setearParametro("@RazonSocial", proveedor.RazonSocial);
                datos.setearParametro("@Cuit", proveedor.Cuit);
                datos.setearParametro("@Telefono", proveedor.Telefono);
                datos.setearParametro("@Email", proveedor.Email);
                datos.setearParametro("@Id", proveedor.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Proveedores SET Activo = 0 WHERE @Id = id");
                datos.setearParametro("@Id", id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public int Contar()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Proveedores");
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                    return (int)datos.Lector[0];

                return 0;
            }
            catch (Exception ex) { throw ex; }
            finally { datos.cerrarConexion(); }
        }
    }
}