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
                nuevo.Marca.Id = int.Parse(txtIdMarca.Text);

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(txtIdCategoria.Text);

                ProductoNegocio negocio = new ProductoNegocio();
                negocio.Agregar(nuevo);


                txtCodigo.Text = "";
                txtNombre.Text = "";
                txtStockActual.Text = "";
                txtStockMinimo.Text = "";
                txtPrecioCompra.Text = "";
                txtPorcentaje.Text = "";
                txtIdMarca.Text = "";
                txtIdCategoria.Text = "";

                CargarGrilla();
            }
            catch (FormatException)
            {
                lblError.Text = "Error: Por favor, ingrese valores numéricos válidos en Stock, Precios y IDs.";
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
    }
}