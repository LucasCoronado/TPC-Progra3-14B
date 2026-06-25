using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPComercio.Dominio
{
    public class Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public decimal PrecioCompraActual { get; set; }
        public decimal PorcentajeGanancia { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public decimal PrecioVenta
        {
            get
            {
                return PrecioCompraActual + (PrecioCompraActual * (PorcentajeGanancia / 100));
            }
        }
    }
}