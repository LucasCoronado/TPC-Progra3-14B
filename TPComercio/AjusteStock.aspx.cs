using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TPComercio.Dominio;
using TPComercio.Negocio;

namespace TPComercio
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["usuario"]))
            {
                Response.Redirect("Default.aspx", false);
                return;
            }

            if (!IsPostBack)
            {
                CargarProductos();
            }
        }

        private void CargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            ddlProductos.DataSource = negocio.listar();
            ddlProductos.DataTextField = "Nombre";
            ddlProductos.DataValueField = "Id";
            ddlProductos.DataBind();
            ddlProductos.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }

        protected void ddlProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProductos.SelectedValue != "0")
            {
                ProductoNegocio negocio = new ProductoNegocio();
                var producto = negocio.BuscarPorId(int.Parse(ddlProductos.SelectedValue));
                lblStockActual.Text = producto.StockActual.ToString();
            }
            else
            {
                lblStockActual.Text = "";
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                int idProducto = int.Parse(ddlProductos.SelectedValue);
                int cantidad = int.Parse(txtCantidad.Text);
                string motivo = ddlMotivos.SelectedValue;
                int idUsuario = ((Usuario)Session["usuario"]).Id;

                ProductoNegocio negocio = new ProductoNegocio();
                negocio.AjustarStockManual(idProducto, cantidad, motivo, idUsuario);

                lblMensaje.Text = "Ajuste realizado correctamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                CargarProductos();
                lblStockActual.Text = "";
                txtCantidad.Text = "";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}