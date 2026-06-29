using Dominio;
using System;
using System.Collections.Generic;

namespace TPComercio.Datos
{
    public class VentaDatos
    {
        public int GuardarVenta(int idCliente, int idUsuario, string numeroFactura, decimal total, List<DetalleVenta> carrito)
        {
            int idVentaGenerado = 0;

                AccesoDatos datosVenta = new AccesoDatos();
            try
            {
                datosVenta.setearConsulta("INSERT INTO Ventas (IdCliente, IdUsuario, Fecha, NumeroFactura, Total) OUTPUT inserted.Id VALUES (@IdCliente, @IdUsuario, GETDATE(), @NumeroFactura, @Total)");
                datosVenta.setearParametro("@IdCliente", idCliente);
                datosVenta.setearParametro("@IdUsuario", idUsuario);
                datosVenta.setearParametro("@NumeroFactura", numeroFactura);
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


        public string ObtenerProximoNumeroFactura()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT TOP 1 NumeroFactura FROM Ventas ORDER BY NumeroFactura DESC");

                object resultado = datos.ejecutarScalar();

                if (resultado == null || resultado == DBNull.Value)
                {
                    return "A-0001-00000001";
                }

                string ultimo = (string)resultado;
                string[] partes = ultimo.Split('-');
                int correlativo = int.Parse(partes[2]);

                return "A-0001-" + (correlativo + 1).ToString("D8");
            }
            catch (Exception ex) { throw ex; }
            finally { datos.cerrarConexion(); }
        }



    }


}