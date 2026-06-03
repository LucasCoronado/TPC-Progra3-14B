using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPComercio.Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
    }
}