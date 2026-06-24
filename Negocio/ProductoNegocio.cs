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
            ProductoDatos datos = new ProductoDatos();

            if (datos.Existe(nuevo.Codigo))
            {
                throw new Exception("Ya existe otro producto con el código: " + nuevo.Codigo);
            }

            if (string.IsNullOrWhiteSpace(nuevo.Codigo))
            {
                throw new Exception("El Código del producto no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(nuevo.Nombre))
            {
                throw new Exception("El Nombre del producto no puede estar vacío.");
            }

            if (nuevo.StockMinimo < 0)
                throw new Exception("El stock mínimo no puede ser negativo.");

            if (nuevo.PrecioCompraActual <= 0)
            {
                throw new Exception("El precio de compra debe ser mayor a cero.");
            }

            datos.Agregar(nuevo);
        }

        public void Modificar(Producto modificado)
        {
            ProductoDatos datos = new ProductoDatos();

            if (datos.Existe(modificado.Codigo, modificado.Id))
            {
                throw new Exception("Ya existe otro producto con el código: " + modificado.Codigo);
            }

            if (string.IsNullOrWhiteSpace(modificado.Codigo))
                throw new Exception("El Código del producto no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(modificado.Nombre))
                throw new Exception("El Nombre del producto no puede estar vacío.");

            datos.Modificar(modificado);
        }
        public void ModificarAvanzado(Producto modificado)
        {
            ProductoDatos datos = new ProductoDatos();

            if (datos.Existe(modificado.Codigo, modificado.Id))
            {
                throw new Exception("Ya existe otro producto con el código: " + modificado.Codigo);
            }

            if (string.IsNullOrWhiteSpace(modificado.Codigo))
                throw new Exception("El Código del producto no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(modificado.Nombre))
                throw new Exception("El Nombre del producto no puede estar vacío.");

            if (modificado.PrecioCompraActual <= 0)
                throw new Exception("El precio no puede ser menor o igual a cero.");

            if (modificado.PorcentajeGanancia <= 0) 
                throw new Exception("La ganancia no puede ser menor o igual a cero.");


            datos.ModificarAvanzado(modificado);
        }

        public Producto BuscarPorId(int id)
        {
            ProductoDatos datos = new ProductoDatos();
            return datos.BuscarPorId(id);
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