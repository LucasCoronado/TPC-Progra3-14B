using Dominio;
using System;
using System.Collections.Generic;
using TPComercio.Dominio;

namespace TPComercio.Datos
{
    public class CompraDatos
    {
        public int GuardarCompra(int idProveedor, decimal total, List<DetalleCompra> carrito)
        {
            int idCompraGenerado = 0;
            AccesoDatos datosCompra = new AccesoDatos();

            try
            {
                datosCompra.setearConsulta("INSERT INTO Compras (IdProveedor, Fecha, Total) OUTPUT inserted.Id VALUES (@IdProveedor, GETDATE(), @Total)");
                datosCompra.setearParametro("@IdProveedor", idProveedor);
                datosCompra.setearParametro("@Total", total);

                idCompraGenerado = datosCompra.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datosCompra.cerrarConexion();
            }

            foreach (DetalleCompra item in carrito)
            {
                AccesoDatos datosDetalle = new AccesoDatos();
                try
                {
                    string consulta = @"
                        INSERT INTO DetalleCompras (IdCompra, IdProducto, Cantidad, PrecioUnitario) 
                        VALUES (@IdCompra, @IdProducto, @Cantidad, @PrecioUnitario);
                        
                        UPDATE Productos 
                        SET StockActual = StockActual + @Cantidad 
                        WHERE Id = @IdProducto;";

                    datosDetalle.setearConsulta(consulta);
                    datosDetalle.setearParametro("@IdCompra", idCompraGenerado);
                    datosDetalle.setearParametro("@IdProducto", item.Producto.Id);
                    datosDetalle.setearParametro("@Cantidad", item.Cantidad);
                    datosDetalle.setearParametro("@PrecioUnitario", item.PrecioUnitario);

                    datosDetalle.ejecutarAccion();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    datosDetalle.cerrarConexion();
                }
            }

            return idCompraGenerado;
        }

        public List<Compra> ListarHistorial(string proveedor = "", DateTime? desde = null, DateTime? hasta = null)
        {
            List<Compra> lista = new List<Compra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT C.Id, C.Fecha, C.Total, P.Nombre as Proveedor FROM Compras C LEFT JOIN Proveedores P ON C.IdProveedor = P.Id WHERE 1=1 ";

                if (!string.IsNullOrEmpty(proveedor))
                {
                    consulta += " AND P.Nombre LIKE @Proveedor ";
                    datos.setearParametro("@Proveedor", "%" + proveedor + "%");
                }

                if (desde.HasValue)
                {
                    consulta += " AND C.Fecha >= @Desde ";
                    datos.setearParametro("@Desde", desde.Value);
                }

                if (hasta.HasValue)
                {
                    consulta += " AND C.Fecha < @Hasta ";
                    datos.setearParametro("@Hasta", hasta.Value.AddDays(1));
                }

                consulta += " ORDER BY C.Id DESC";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Compra aux = new Compra();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Total = (decimal)datos.Lector["Total"];
                    aux.ProveedorAsociado = new Proveedor();
                    aux.ProveedorAsociado.RazonSocial = (string)datos.Lector["Proveedor"];

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

        public Compra ObtenerCompraPorId(int idCompra)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta("SELECT C.Id, C.Fecha, C.Total, P.RazonSocial as Proveedor FROM Compras C JOIN Proveedores P ON C.IdProveedor = P.Id WHERE C.Id = @IdCompra");
                datos.setearParametro("@IdCompra", idCompra);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Compra aux = new Compra();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Total = (decimal)datos.Lector["Total"];

                    aux.ProveedorAsociado = new Proveedor();
                    aux.ProveedorAsociado.RazonSocial = (string)datos.Lector["Proveedor"];

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

        public List<DetalleCompra> ListarDetalles(int idCompra)
        {

            List<DetalleCompra> lista = new List<DetalleCompra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT DC.Id, P.Nombre as Producto, DC.Cantidad, DC.PrecioUnitario " +
                                     "FROM DetalleCompras DC " +
                                     "JOIN Productos P ON DC.IdProducto = P.Id " +
                                     "WHERE DC.IdCompra = @IdCompra");
                datos.setearParametro("@IdCompra", idCompra);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    DetalleCompra aux = new DetalleCompra();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.PrecioUnitario = (decimal)datos.Lector["PrecioUnitario"];
                    aux.Producto = new Producto();
                    aux.Producto.Nombre = (string)datos.Lector["Producto"];

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