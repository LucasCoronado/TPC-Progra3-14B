using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPComercio.Dominio;

namespace TPComercio.Dominio
{
    public class DetalleCompra : DetalleOperacion
    {
        public Producto Producto { get; set; }

        public string NombreProducto
        {
            get { return Producto != null ? Producto.Nombre : "Sin nombre"; }
        }
        public string NumeroFactura { get; set; }
    }
}