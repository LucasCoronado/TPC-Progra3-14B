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
        public int GenerarVenta(int idCliente, decimal total, List<DetalleVenta> carrito)
        {
            VentaDatos datosVenta = new VentaDatos();

            return datosVenta.GuardarVenta(idCliente, total, carrito);
        }
    }
}
