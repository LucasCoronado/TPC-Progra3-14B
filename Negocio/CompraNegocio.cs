using Dominio;
using System;
using System.Collections.Generic;
using TPComercio.Datos;
using TPComercio.Dominio;

namespace Negocio
{
    public class CompraNegocio
    {
        public int RegistrarCompra(int idProveedor, decimal total, List<DetalleCompra> listaDetalles)
        {
            CompraDatos datosCompra = new CompraDatos();
            return datosCompra.GuardarCompra(idProveedor, total, listaDetalles);
        }

        public List<Compra> ListarHistorial(string proveedor = "", DateTime? desde = null, DateTime? hasta = null)
        {
            List<Compra> lista = new List<Compra>();
            CompraDatos datos = new CompraDatos();

            return lista = datos.ListarHistorial(proveedor, desde, hasta);
        }

        public List<DetalleCompra> ListarDetalles(int idCompra)
        {
            CompraDatos datos = new CompraDatos();
            List<DetalleCompra> lista = new List<DetalleCompra>();

            return lista = datos.ListarDetalles(idCompra);
        }

        public Compra ObtenerCompraPorId(int idCompra)
        {
            CompraDatos datos = new CompraDatos();
            return datos.ObtenerCompraPorId(idCompra);
        }
    }
}