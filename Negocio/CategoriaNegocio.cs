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

        public void Modificar(Categoria categoriaModificada)
        {
            if (string.IsNullOrWhiteSpace(categoriaModificada.Descripcion))
            {
                throw new Exception("El nombre de la categoría no puede estar vacío.");
            }

            CategoriaDatos datos = new CategoriaDatos();

            List<Categoria> listaCategorias = Listar();

            bool existe = listaCategorias.Any(c => c.Descripcion.ToUpper() == categoriaModificada.Descripcion.ToUpper() && 
            c.Id != categoriaModificada.Id);

            if (existe)
            {
                throw new Exception("Ya existe una categoria con ese nombre");
            }

            datos.Modificar(categoriaModificada);
        }
    }
}
