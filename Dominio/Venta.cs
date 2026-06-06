using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPComercio.Dominio
{
    public class Venta : Operacion
    {
        public Cliente ClienteAsociado { get; set; }
    }
}