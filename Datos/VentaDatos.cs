using Dominio;
using System;
using System.Collections.Generic;

namespace TPComercio.Datos
{
    public class VentaDatos
    {
        public int GuardarVenta(int idCliente, decimal total, List<DetalleVenta> carrito)
        {
            int idVentaGenerado = 0;

                AccesoDatos datosVenta = new AccesoDatos();
            try
            {
                datosVenta.setearConsulta("INSERT INTO Ventas (IdCliente, Fecha, Total) OUTPUT inserted.Id VALUES (@IdCliente, GETDATE(), @Total)");
                datosVenta.setearParametro("@IdCliente", idCliente);
                datosVenta.setearParametro("@Total", total);

                idVentaGenerado = datosVenta.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datosVenta.cerrarConexion();
            }

            foreach (DetalleVenta item in carrito)
            {
                AccesoDatos datosDetalle = new AccesoDatos();
                try
                {
                    string consulta = @"
                        INSERT INTO DetalleVentas (IdVenta, IdProducto, Cantidad, PrecioUnitario) 
                        VALUES (@IdVenta, @IdProducto, @Cantidad, @PrecioUnitario);
                        
                        UPDATE Productos 
                        SET StockActual = StockActual - @Cantidad 
                        WHERE Id = @IdProducto;";

                    datosDetalle.setearConsulta(consulta);
                    datosDetalle.setearParametro("@IdVenta", idVentaGenerado);
                    datosDetalle.setearParametro("@IdProducto", item.Id);
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

            return idVentaGenerado;
        }
    }
}