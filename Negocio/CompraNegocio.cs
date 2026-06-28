using System.Collections.Generic;
using TPComercio.Dominio;
using TPComercio.Datos;

namespace Negocio
{
    public class CompraNegocio
    {
        public int RegistrarCompra(Compra nuevaCompra, List<DetalleCompra> listaDetalles)
        {
            CompraDatos datosCompra = new CompraDatos();
            return datosCompra.GuardarCompra(nuevaCompra, listaDetalles);
        }
    }
}