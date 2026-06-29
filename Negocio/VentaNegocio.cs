using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPComercio.Datos;

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
    }
}
