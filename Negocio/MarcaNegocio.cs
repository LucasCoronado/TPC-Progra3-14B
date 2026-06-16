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

        public void Modificar(Marca marcaModificada)
        {
            if (string.IsNullOrWhiteSpace(marcaModificada.Descripcion))
            {
                throw new Exception("El nombre de la marca no puede estar vacío.");
            }

            MarcaDatos datos = new MarcaDatos();

            List<Marca> listaMarcas = Listar();

            bool existe = listaMarcas.Any(c => c.Descripcion.ToUpper() == marcaModificada.Descripcion.ToUpper() &&
            c.Id != marcaModificada.Id);

            if (existe)
            {
                throw new Exception("Ya existe una marca con ese nombre");
            }

            datos.Modificar(marcaModificada);
        }

    }
}
