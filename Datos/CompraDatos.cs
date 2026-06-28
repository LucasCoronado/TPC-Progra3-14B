using Dominio;
using System;
using System.Collections.Generic;
using TPComercio.Dominio;

namespace TPComercio.Datos
{
    public class CompraDatos
    {
        public int GuardarCompra(Compra nuevaCompra, List<DetalleCompra> carrito)
        {
            int idCompraGenerado = 0;
            AccesoDatos datosCompra = new AccesoDatos();

            try
            {
                datosCompra.setearConsulta("INSERT INTO Compras (IdProveedor, Fecha, Total, NumeroFactura, FechaFactura) OUTPUT inserted.Id VALUES (@IdProveedor, @FechaIngreso, @Total, @NumeroFactura, @FechaFactura)");
                datosCompra.setearParametro("@IdProveedor", nuevaCompra.IdProveedor);
                datosCompra.setearParametro("@FechaIngreso", nuevaCompra.Fecha);
                datosCompra.setearParametro("@Total", nuevaCompra.Total);
                datosCompra.setearParametro("@NumeroFactura", nuevaCompra.NumeroFactura);
                datosCompra.setearParametro("@FechaFactura", nuevaCompra.FechaFactura);

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