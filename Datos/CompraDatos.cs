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
    }
}