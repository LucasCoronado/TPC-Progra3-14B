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
                datos.setearConsulta("SELECT Id, Codigo, Nombre, StockActual, PrecioCompraActual, PorcentajeGanancia, Activo FROM Productos WHERE Activo = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.StockActual = (int)datos.Lector["StockActual"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    aux.PrecioCompraActual = (decimal)datos.Lector["PrecioCompraActual"];
                    aux.PorcentajeGanancia = (decimal)datos.Lector["PorcentajeGanancia"];

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
                datos.setearConsulta("UPDATE Productos SET Codigo = @Codigo, Nombre = @Nombre WHERE Id = @Id");
                datos.setearParametro("@Codigo", producto.Codigo);
                datos.setearParametro("@Nombre", producto.Nombre);
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
        public void ModificarAvanzado(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Productos SET " +
                    "Codigo = @Codigo, Nombre = @Nombre, PrecioCompraActual = @PrecioCompraActual, IdMarca = @IdMarca, IdCategoria = @IdCategoria " +
                    "WHERE Id = @Id");
                datos.setearParametro("@Id", producto.Id);
                datos.setearParametro("@Codigo", producto.Codigo);
                datos.setearParametro("@Nombre", producto.Nombre);
                datos.setearParametro("@PrecioCompraActual", producto.PrecioCompraActual);
                datos.setearParametro("@IdMarca", producto.Marca.Id);
                datos.setearParametro("@IdCategoria", producto.Categoria.Id);
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

        public Producto BuscarPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, Codigo, Nombre, StockActual, StockMinimo, PrecioCompraActual, PorcentajeGanancia, IdMarca, IdCategoria, Activo " +
                    "FROM Productos WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Producto aux = new Producto();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.StockActual = (int)datos.Lector["StockActual"];
                    aux.Activo = (bool)datos.Lector["Activo"];

                    aux.StockMinimo = datos.Lector["StockMinimo"] != DBNull.Value ? (int)datos.Lector["StockMinimo"] : 0;
                    aux.PrecioCompraActual = datos.Lector["PrecioCompraActual"] != DBNull.Value ? (decimal)datos.Lector["PrecioCompraActual"] : 0;
                    aux.PorcentajeGanancia = datos.Lector["PorcentajeGanancia"] != DBNull.Value ? (decimal)datos.Lector["PorcentajeGanancia"] : 0;

                    aux.Marca = new Marca();
                    aux.Marca.Id = datos.Lector["IdMarca"] != DBNull.Value ? (int)datos.Lector["IdMarca"] : 0;

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = datos.Lector["IdCategoria"] != DBNull.Value ? (int)datos.Lector["IdCategoria"] : 0;

                    return aux; 
                }

                return null;
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

        public bool Existe(string codigo, int idExcluido = 0)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("SELECT Id FROM Productos WHERE Codigo = @Codigo AND Id != @IdExcluido");
                datos.setearParametro("@Codigo", codigo);
                datos.setearParametro("@IdExcluido", idExcluido);
                datos.ejecutarLectura();

                return datos.Lector.Read();

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