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

    }
}