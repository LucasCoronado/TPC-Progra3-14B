using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPComercio.Dominio
{
    public class Proveedor : Persona
    {
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }

    }
}