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

        public void Agregar(Marca nueva)
        {
            if (string.IsNullOrWhiteSpace(nueva.Descripcion))
            {
                throw new Exception("El nombre de la marca no puede estar vacio.");
            }

            MarcaDatos datos = new MarcaDatos();
            datos.Agregar(nueva);
        }

    }
}
