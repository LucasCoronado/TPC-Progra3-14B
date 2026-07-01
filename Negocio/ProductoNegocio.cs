using Datos;
using System;
using System.Collections.Generic;
using TPComercio.Datos;
using TPComercio.Dominio;

namespace TPComercio.Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listar()
        {
            ProductoDatos datos = new ProductoDatos();
            return datos.ListarTodos();
        }

        public List<Producto> Buscar(string filtro)
        {
            List<Producto> listaCompleta = listar();

            List<Producto> listaFiltrada = listaCompleta.FindAll(x =>
                x.Nombre.ToUpper().Contains(filtro.ToUpper()) ||
                x.Codigo.ToUpper().Contains(filtro.ToUpper())
            );

            return listaFiltrada;
        }

        public void Agregar(Producto nuevo)
        {
            ProductoDatos datos = new ProductoDatos();

            if (datos.Existe(nuevo.Codigo))
            {
                throw new Exception("Ya existe otro producto con el código: " + nuevo.Codigo);
            }

            if (string.IsNullOrWhiteSpace(nuevo.Codigo))
            {
                throw new Exception("El Código del producto no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(nuevo.Nombre))
            {
                throw new Exception("El Nombre del producto no puede estar vacío.");
            }

            if (nuevo.StockMinimo < 0)
                throw new Exception("El stock mínimo no puede ser negativo.");

            if (nuevo.PrecioCompraActual <= 0)
            {
                throw new Exception("El precio de compra debe ser mayor a cero.");
            }

            datos.Agregar(nuevo);
        }

        public void Modificar(Producto modificado)
        {
            ProductoDatos datos = new ProductoDatos();

            if (datos.Existe(modificado.Codigo, modificado.Id))
            {
                throw new Exception("Ya existe otro producto con el código: " + modificado.Codigo);
            }

            if (string.IsNullOrWhiteSpace(modificado.Codigo))
                throw new Exception("El Código del producto no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(modificado.Nombre))
                throw new Exception("El Nombre del producto no puede estar vacío.");

            datos.Modificar(modificado);
        }
        public void ModificarAvanzado(Producto modificado)
        {
            ProductoDatos datos = new ProductoDatos();

            if (datos.Existe(modificado.Codigo, modificado.Id))
            {
                throw new Exception("Ya existe otro producto con el código: " + modificado.Codigo);
            }

            if (string.IsNullOrWhiteSpace(modificado.Codigo))
                throw new Exception("El Código del producto no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(modificado.Nombre))
                throw new Exception("El Nombre del producto no puede estar vacío.");

            if (modificado.PrecioCompraActual <= 0)
                throw new Exception("El precio no puede ser menor o igual a cero.");

            if (modificado.PorcentajeGanancia <= 0) 
                throw new Exception("La ganancia no puede ser menor o igual a cero.");


            datos.ModificarAvanzado(modificado);
        }

        public Producto BuscarPorId(int id)
        {
            ProductoDatos datos = new ProductoDatos();
            return datos.BuscarPorId(id);
        }

        public void Eliminar(int id)
        {
            try
            {
                ProductoDatos datos = new ProductoDatos();
                datos.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AjustarStockManual(int idProducto, int cantidadAjuste, string motivo, int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT StockActual FROM Productos WHERE Id = @Id");
                datos.setearParametro("@Id", idProducto);
                int stockAnterior = (int)datos.ejecutarScalar();
                int stockNuevo = stockAnterior + cantidadAjuste;

                if (stockNuevo < 0)
                    throw new Exception("El stock no puede quedar negativo.");

                string consultaUnificada = @"INSERT INTO AuditoriaStock (IdProducto, IdUsuario, Fecha, CantidadCambio, Motivo, StockAnterior, StockNuevo) 
                VALUES (@IdP, @IdU, GETDATE(), @Cant, @Mot, @StkAnt, @StkNuevo);

                UPDATE Productos SET StockActual = @StkNuevo WHERE Id = @IdP;";

                datos.setearConsulta(consultaUnificada);
                datos.setearParametro("@IdP", idProducto);
                datos.setearParametro("@IdU", idUsuario);
                datos.setearParametro("@Cant", cantidadAjuste);
                datos.setearParametro("@Mot", motivo);
                datos.setearParametro("@StkAnt", stockAnterior);
                datos.setearParametro("@StkNuevo", stockNuevo);

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

        public List<AuditoriaStock> ListarAuditoria()
        {
            List<AuditoriaStock> lista = new List<AuditoriaStock>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(@"SELECT A.Fecha, A.Motivo, A.CantidadCambio, A.StockAnterior, A.StockNuevo, 
                               P.Nombre AS Producto, U.NombreUsuario AS Usuario
                               FROM AuditoriaStock A
                               JOIN Productos P ON A.IdProducto = P.Id
                               JOIN Usuarios U ON A.IdUsuario = U.Id
                               ORDER BY A.Fecha DESC");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    AuditoriaStock aux = new AuditoriaStock();
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Motivo = (string)datos.Lector["Motivo"];
                    aux.CantidadCambio = (int)datos.Lector["CantidadCambio"];
                    aux.StockAnterior = (int)datos.Lector["StockAnterior"];
                    aux.StockNuevo = (int)datos.Lector["StockNuevo"];
                    aux.Producto = (string)datos.Lector["Producto"];
                    aux.Usuario = (string)datos.Lector["Usuario"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex) { throw ex; }
            finally { datos.cerrarConexion(); }
        }

        public int ContarProductos()
        {
            ProductoDatos datos = new ProductoDatos();
            return datos.Contar();
        }

    }
}