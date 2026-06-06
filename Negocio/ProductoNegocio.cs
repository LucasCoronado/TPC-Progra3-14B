using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPComercio.Datos;
using TPComercio.Dominio;

namespace TPComercio.Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listar()
        {
            ProductoDatos datos = new ProductoDatos();
            return datos.ListarTodos();
        }
    }
}