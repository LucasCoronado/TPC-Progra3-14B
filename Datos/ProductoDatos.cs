using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPComercio.Datos;
using TPComercio.Dominio;

namespace Datos
{
    public class ProductoDatos
    {
        public List<Producto> ListarTodos()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Codigo, Nombre, StockActual FROM Productos");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.StockActual = (int)datos.Lector["StockActual"];

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
    }
}
