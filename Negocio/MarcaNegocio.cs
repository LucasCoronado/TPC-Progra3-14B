using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPComercio.Datos;
using TPComercio.Dominio;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> Listar()
        {
            MarcaDatos datos = new MarcaDatos();
            return datos.ListarTodos();
        }

    }
}
