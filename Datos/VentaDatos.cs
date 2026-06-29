using Dominio;
using System;
using System.Collections.Generic;
using TPComercio.Dominio;

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

        public List<Venta> ListarHistorial(string cliente = "", DateTime? desde = null, DateTime? hasta = null)
        {
            List<Venta> lista = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT V.Id, V.Fecha, V.NumeroFactura, V.Total, C.Nombre as Cliente, U.NombreUsuario as Vendedor FROM Ventas V JOIN Clientes C ON V.IdCliente = C.Id LEFT JOIN Usuarios U ON V.IdUsuario = U.Id WHERE 1=1 ";

                if (!string.IsNullOrEmpty(cliente))
                {
                    consulta += " AND C.Nombre LIKE @Cliente ";
                    datos.setearParametro("@Cliente", "%" + cliente + "%");
                }

                if (desde.HasValue)
                {
                    consulta += " AND V.Fecha >= @Desde ";
                    datos.setearParametro("@Desde", desde.Value);
                }

                if (hasta.HasValue)
                {
                    consulta += " AND V.Fecha < @Hasta ";
                    datos.setearParametro("@Hasta", hasta.Value.AddDays(1));
                }

                consulta += " ORDER BY V.Id DESC";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Venta aux = new Venta();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Total = (decimal)datos.Lector["Total"];

                    if (!(datos.Lector["NumeroFactura"] is DBNull))
                    {
                        aux.FacturaAsociada = new Factura();
                        aux.FacturaAsociada.NumeroFactura = (string)datos.Lector["NumeroFactura"];
                    }

                    aux.ClienteAsociado = new Cliente();
                    aux.ClienteAsociado.Nombre = (string)datos.Lector["Cliente"];

                    aux.RegistradoPor = new Usuario();
                    if (!(datos.Lector["Vendedor"] is DBNull))
                    {
                        aux.RegistradoPor.NombreUsuario = (string)datos.Lector["Vendedor"];
                    }
                    else
                    {
                        aux.RegistradoPor.NombreUsuario = "Sistema / Sin Asignar";
                    }

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

        public List<DetalleVenta> ListarDetalles(int idVenta)
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = @"SELECT DV.Id, P.Nombre as Producto, DV.Cantidad, DV.PrecioUnitario 
                                    FROM DetalleVentas DV 
                                    JOIN Productos P ON DV.IdProducto = P.Id 
                                    WHERE DV.IdVenta = @IdVenta";

                datos.setearConsulta(consulta);

                datos.setearParametro("@IdVenta", idVenta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    DetalleVenta aux = new DetalleVenta();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.PrecioUnitario = (decimal)datos.Lector["PrecioUnitario"];
                    aux.NombreProducto = (string)datos.Lector["Producto"];
                    
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
        public Venta ObtenerVentaPorId(int idVenta)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT V.Id, V.Fecha, V.NumeroFactura, V.Total, C.Nombre as Cliente, U.NombreUsuario as Vendedor FROM Ventas V JOIN Clientes C ON V.IdCliente = C.Id LEFT JOIN Usuarios U ON V.IdUsuario = U.Id WHERE V.Id = @IdVenta");
                datos.setearParametro("@IdVenta", idVenta);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Venta aux = new Venta();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Total = (decimal)datos.Lector["Total"];

                    if (!(datos.Lector["NumeroFactura"] is DBNull))
                    {
                        aux.FacturaAsociada = new Factura();
                        aux.FacturaAsociada.NumeroFactura = (string)datos.Lector["NumeroFactura"];
                    }

                    aux.ClienteAsociado = new Cliente();
                    aux.ClienteAsociado.Nombre = (string)datos.Lector["Cliente"];

                    aux.RegistradoPor = new Usuario();
                    if (!(datos.Lector["Vendedor"] is DBNull))
                    {
                        aux.RegistradoPor.NombreUsuario = (string)datos.Lector["Vendedor"];
                    }
                    else
                    {
                        aux.RegistradoPor.NombreUsuario = "Sistema / Sin Asignar";
                    }
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
    }
}