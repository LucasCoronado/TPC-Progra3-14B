using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPComercio.Dominio
{
    public class Compra : Operacion
    {
        public Proveedor ProveedorAsociado { get; set; }

        public string NumeroFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public int IdProveedor
        {
            get { return ProveedorAsociado != null ? ProveedorAsociado.Id : 0; }
        }
    }
}