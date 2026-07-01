using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPComercio.Dominio
{
    public class AuditoriaStock
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadCambio { get; set; }
        public string Motivo { get; set; }
        public int StockAnterior { get; set; }
        public int StockNuevo { get; set; }
        public string Producto { get; set; }
        public string Usuario { get; set; }
    }
}
