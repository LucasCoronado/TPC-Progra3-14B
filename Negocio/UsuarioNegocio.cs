using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPComercio.Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> Listar()
        {
            UsuarioDatos datos = new UsuarioDatos();
            return datos.Listar();
        }

        public void Agregar(Usuario nuevo)
        {
            if (string.IsNullOrWhiteSpace(nuevo.NombreUsuario))
            {
                throw new Exception("El nombre del usuario no puede estar vacio.");
            }

            UsuarioDatos datos = new UsuarioDatos();
            datos.Agregar(nuevo);
        }

        public void Modificar(Usuario usuarioModificado)
        {
            if (string.IsNullOrWhiteSpace(usuarioModificado.NombreUsuario))
            {
                throw new Exception("El nombre del usuario no puede estar vacío.");
            }

            UsuarioDatos datos = new UsuarioDatos();

            List<Usuario> listaUsuarios = Listar();

            bool existe = listaUsuarios.Any(c => c.NombreUsuario.ToUpper() == usuarioModificado.NombreUsuario.ToUpper() &&
            c.Id != usuarioModificado.Id);

            if (existe)
            {
                throw new Exception("Ya existe un usuario con ese nombre");
            }

            datos.Modificar(usuarioModificado);
        }

        public void Eliminar(int id)
        {
            UsuarioDatos datos = new UsuarioDatos();
            datos.Eliminar(id);
        }

        public bool Login(Usuario usuario)
        {
            UsuarioDatos uDatos = new UsuarioDatos();
            return uDatos.Login(usuario);
        }
    }
}
