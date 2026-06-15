using Negocio;
using System;
using TPComercio.Dominio;
using TPComercio.Negocio;

namespace TPComercio
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrilla();

                CargarDdlMarcas();
                CargarDdlCategorias();

            }
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";

                Producto nuevo = new Producto();
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.StockActual = int.Parse(txtStockActual.Text);
                nuevo.StockMinimo = int.Parse(txtStockMinimo.Text);
                nuevo.PrecioCompraActual = decimal.Parse(txtPrecioCompra.Text);
                nuevo.PorcentajeGanancia = decimal.Parse(txtPorcentaje.Text);
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarcas.SelectedValue);

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategorias.SelectedValue);

                ProductoNegocio negocio = new ProductoNegocio();
                negocio.Agregar(nuevo);


                txtCodigo.Text = "";
                txtNombre.Text = "";
                txtStockActual.Text = "";
                txtStockMinimo.Text = "";
                txtPrecioCompra.Text = "";
                txtPorcentaje.Text = "";
                
                CargarGrilla();
            }
            catch (FormatException)
            {
                lblError.Text = "Error: Por favor, ingrese valores numéricos válidos en Stock y Precios.";
            }
            catch (Exception ex)
            {
                lblError.Text = "Error: " + ex.Message;
            }
        }

        private void CargarGrilla()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            dgvProductos.DataSource = negocio.listar();
            dgvProductos.DataBind();
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

    }
}