using Datos;
using System;
using System.Collections.Generic;
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

        public void Agregar(Producto nuevo)
        {
            if (string.IsNullOrWhiteSpace(nuevo.Codigo))
            {
                throw new Exception("El Código del producto no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(nuevo.Nombre))
            {
                throw new Exception("El Nombre del producto no puede estar vacío.");
            }


            if (nuevo.PrecioCompraActual <= 0)
            {
                throw new Exception("El precio de compra debe ser mayor a cero.");
            }

            ProductoDatos datos = new ProductoDatos();
            datos.Agregar(nuevo);
        }

        public void Modificar(Producto modificado)
        {
            if (string.IsNullOrWhiteSpace(modificado.Codigo))
                throw new Exception("El Código del producto no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(modificado.Nombre))
                throw new Exception("El Nombre del producto no puede estar vacío.");

            if (modificado.StockActual < 0)
                throw new Exception("El stock no puede ser negativo.");

            ProductoDatos datos = new ProductoDatos();
            datos.Modificar(modificado);
        }

        public void Eliminar(int id)
        {
            try
            {
                ProductoDatos datos = new ProductoDatos();
                datos.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}