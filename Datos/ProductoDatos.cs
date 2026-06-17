using System;
using System.Collections.Generic;
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
                datos.setearConsulta("SELECT Id, Codigo, Nombre, StockActual, Activo FROM Productos WHERE Activo = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.StockActual = (int)datos.Lector["StockActual"];
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

        public void Agregar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "INSERT INTO Productos (Codigo, Nombre, StockActual, StockMinimo, PrecioCompraActual, PorcentajeGanancia, IdMarca, IdCategoria, Activo)" +
                    "VALUES (@Codigo, @Nombre, @StockActual, @StockMinimo, @PrecioCompra, @Porcentaje, @IdMarca, @IdCategoria, 1)";

                datos.setearConsulta(consulta);

                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@StockActual", nuevo.StockActual);
                datos.setearParametro("@StockMinimo", nuevo.StockMinimo);
                datos.setearParametro("@PrecioCompra", nuevo.PrecioCompraActual);
                datos.setearParametro("@Porcentaje", nuevo.PorcentajeGanancia);
                datos.setearParametro("@IdMarca", nuevo.Marca.Id);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.Id);

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

        public void Modificar(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Productos SET Codigo = @Codigo, Nombre = @Nombre, StockActual = @StockActual WHERE Id = @Id");
                datos.setearParametro("@Codigo", producto.Codigo);
                datos.setearParametro("@Nombre", producto.Nombre);
                datos.setearParametro("@StockActual", producto.StockActual);
                datos.setearParametro("@Id", producto.Id);
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
                datos.setearConsulta("UPDATE Productos SET Activo = 0 WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch(Exception ex)
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