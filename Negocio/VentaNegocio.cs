using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPComercio.Datos;
using TPComercio.Dominio;

namespace Negocio
{
    public class VentaNegocio
    {
        public int GenerarVenta(int idCliente, int idUsuario, string numeroFactura, decimal total, List<DetalleVenta> carrito)
        {
            VentaDatos datosVenta = new VentaDatos();

            return datosVenta.GuardarVenta(idCliente, idUsuario, numeroFactura, total, carrito);
        }

        public string GenerarProximoNumero()
        {
            VentaDatos datos = new VentaDatos();
            return datos.ObtenerProximoNumeroFactura();
        }

        public List<Venta> ListarHistorial(string cliente = "", DateTime? desde = null, DateTime? hasta = null)
        {
            List<Venta> lista = new List<Venta>();
            VentaDatos datos = new VentaDatos();

            return lista = datos.ListarHistorial(cliente, desde, hasta);
        }

        public List<DetalleVenta> ListarDetalles(int idVenta)
        {
            VentaDatos datos = new VentaDatos();
            List<DetalleVenta> lista = new List<DetalleVenta>();

            return lista = datos.ListarDetalles(idVenta);

        }
        public Venta ObtenerVentaPorId(int idVenta)
        {
            VentaDatos datos = new VentaDatos();
            return datos.ObtenerVentaPorId(idVenta);
        }

        public int ContarVentas()
        {
            VentaDatos datos = new VentaDatos();
            return datos.Contar();
        }
    }
}
