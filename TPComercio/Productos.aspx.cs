using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
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
                ActualizarSesionYGrilla();
                CargarDdlMarcas();
                CargarDdlCategorias();
            }
        }

        private void ActualizarSesionYGrilla()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            List<Producto> lista = negocio.listar();
            Session.Add("ListaProductos", lista);
            CargarGrilla(lista);
        }

        private void CargarGrilla(List<Producto> lista)
        {
            dgvProductos.DataSource = lista;
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

                ActualizarSesionYGrilla();
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Producto> listaGuardada = (List<Producto>)Session["ListaProductos"];
            string filtro = txtFiltro.Text.ToUpper();

            if (!string.IsNullOrEmpty(filtro))
            {
                List<Producto> listaFiltrada = listaGuardada.FindAll(x =>
                    x.Nombre.ToUpper().Contains(filtro) ||
                    x.Codigo.ToUpper().Contains(filtro));
                CargarGrilla(listaFiltrada);
            }
            else
            {
                CargarGrilla(listaGuardada);
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
            CargarGrilla((List<Producto>)Session["ListaProductos"]);
        }

        protected void dgvProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvProductos.EditIndex = e.NewEditIndex;
            btnBuscar_Click(null, null);
        }

        protected void dgvProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvProductos.EditIndex = -1;
            btnBuscar_Click(null, null);
        }

        protected void dgvProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvProductos.DataKeys[e.RowIndex].Value);
                GridViewRow fila = dgvProductos.Rows[e.RowIndex];
                Producto prodModificado = new Producto();
                prodModificado.Id = id;
                prodModificado.Codigo = ((TextBox)fila.Cells[1].Controls[0]).Text;
                prodModificado.Nombre = ((TextBox)fila.Cells[2].Controls[0]).Text;
                prodModificado.StockActual = int.Parse(((TextBox)fila.Cells[3].Controls[0]).Text);

                ProductoNegocio negocio = new ProductoNegocio();
                negocio.Modificar(prodModificado);

                dgvProductos.EditIndex = -1;
                ActualizarSesionYGrilla();
                lblError.Text = "";
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al guardar: " + ex.Message;
            }
        }
    }
}