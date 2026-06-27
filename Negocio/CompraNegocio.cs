using System.Collections.Generic;
using TPComercio.Dominio;
using TPComercio.Datos;

namespace Negocio
{
    public class CompraNegocio
    {
        public int RegistrarCompra(int idProveedor, decimal total, List<DetalleCompra> listaDetalles)
        {
            CompraDatos datosCompra = new CompraDatos();
            return datosCompra.GuardarCompra(idProveedor, total, listaDetalles);
        }
    }
}