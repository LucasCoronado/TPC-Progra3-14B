using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TPComercio.Dominio;
using TPComercio.Negocio;

namespace TPComercio
{
    public partial class NuevoProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            txtStock.Enabled = false;

            try
            {
                if (!IsPostBack)
                {
                    CargarDdlMarcas();
                    CargarDdlCategorias();
                }

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ProductoNegocio negocio = new ProductoNegocio();
                    Producto aux = new Producto();
                    aux = negocio.BuscarPorId(int.Parse(id));

                    txtId.Text = aux.Id.ToString();
                    txtCodigo.Text = aux.Codigo;
                    txtNombre.Text = aux.Nombre;
                    txtPrecio.Text = aux.PrecioCompraActual.ToString();
                    txtGanancia.Text = aux.PorcentajeGanancia.ToString();
                    txtStock.Text = aux.StockActual.ToString();
                    txtStockMinimo.Text = aux.StockMinimo.ToString();

                    ddlMarcas.SelectedValue = aux.Marca.Id.ToString();
                    ddlCategorias.SelectedValue = aux.Categoria.Id.ToString();

                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        private void CargarDdlMarcas()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            ddlMarcas.DataSource = negocio.Listar();
            ddlMarcas.DataTextField = "Descripcion";
            ddlMarcas.DataValueField = "Id";
            ddlMarcas.DataBind();
        }

        private void CargarDdlCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            ddlCategorias.DataSource = negocio.Listar();
            ddlCategorias.DataTextField = "Descripcion";
            ddlCategorias.DataValueField = "Id";
            ddlCategorias.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                try
                {
                    Producto producto = new Producto();
                    ProductoNegocio negocio = new ProductoNegocio();


                    producto.Codigo = txtCodigo.Text;
                    producto.Nombre = txtNombre.Text;
                    producto.PrecioCompraActual = decimal.Parse(txtPrecio.Text);
                    producto.PorcentajeGanancia = decimal.Parse(txtGanancia.Text);
                    producto.Marca = new Marca();
                    producto.Marca.Id = int.Parse(ddlMarcas.SelectedValue);
                    producto.Categoria = new Categoria();
                    producto.Categoria.Id = int.Parse(ddlCategorias.SelectedValue);
                    producto.StockMinimo = int.Parse(txtStockMinimo.Text);
                    if (Request.QueryString["id"] != null)
                    {
                        producto.Id = int.Parse(txtId.Text);
                        negocio.ModificarAvanzado(producto);
                    }
                    else
                    {
                        producto.StockActual = 0;
                        negocio.Agregar(producto);
                    }

                    Response.Redirect("Productos.aspx", false);

                }
                catch (Exception ex)
                {

                    lblError.Text = "Error: " + ex.Message;
                }
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                negocio.Eliminar(int.Parse(txtId.Text));
                Response.Redirect("Productos.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al eliminar: " + ex.Message;
            }
        }
    }
}