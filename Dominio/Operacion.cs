using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPComercio.Dominio;

namespace Dominio
{
    public abstract class Operacion
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public Usuario RegistradoPor { get; set; }
        public Factura FacturaAsociada { get; set; }
    }
}
