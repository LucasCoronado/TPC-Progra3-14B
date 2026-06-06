using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPComercio.Dominio;

namespace Dominio
{
    public abstract class DetalleOperacion
    {
        public int Id { get; set; }
        public Producto ProductoAsociado { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; } // Cantidad * PrecioUnitario
    }
}
