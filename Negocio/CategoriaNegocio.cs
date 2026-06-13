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
    public class CategoriaNegocio
    {

        public List<Categoria> Listar()
        {
            CategoriaDatos datos = new CategoriaDatos();
            return datos.ListarTodos();
        }

        public void Agregar(Categoria nueva)
        {
            if (string.IsNullOrWhiteSpace(nueva.Descripcion))
            {
                throw new Exception("El nombre de la categoria no puede estar vacio.");
            }

            CategoriaDatos datos = new CategoriaDatos();
            datos.Agregar(nueva);
        }

    }
}
