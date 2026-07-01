using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPComercio.Datos;
using TPComercio.Dominio;

namespace Datos
{
    public class ClienteDatos
    {

        public List<Cliente> ListarTodos()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Nombre, Apellido, DNI, Telefono, Email, Activo from Clientes WHERE Activo = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Dni = (string)datos.Lector["Dni"];
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

        public void Agregar(Cliente nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("INSERT INTO CLIENTES (Nombre, Apellido, Dni, Telefono, Email, Activo)VALUES(@Nombre, @Apellido, @Dni, @Telefono, @Email, 1)");
                datos.setearParametro("@Nombre", nueva.Nombre);
                datos.setearParametro("@Apellido", nueva.Apellido);
                datos.setearParametro("@Dni", nueva.Dni);
                datos.setearParametro("@Telefono", nueva.Telefono);
                datos.setearParametro("@Email", nueva.Email);
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

        public void Modificar(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Clientes SET Nombre = @Nombre, Apellido = @Apellido, Dni = @Dni, Telefono = @Telefono, Email = @Email WHERE Id = @Id");
                datos.setearParametro("@Nombre", cliente.Nombre);
                datos.setearParametro("@Apellido", cliente.Apellido);
                datos.setearParametro("@Dni", cliente.Dni);
                datos.setearParametro("@Telefono", cliente.Telefono);
                datos.setearParametro("@Email", cliente.Email);
                datos.setearParametro("@Id", cliente.Id);
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
                datos.setearConsulta("UPDATE Clientes SET Activo = 0 WHERE Id = @Id");
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
                datos.setearConsulta("SELECT COUNT(*) FROM Clientes");
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
