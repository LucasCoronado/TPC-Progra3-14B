using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TPComercio.Dominio;

namespace TPComercio
{
    public partial class HistorialCompras : System.Web.UI.Page
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
                dgvCompras.DataSource = new List<Compra>();
                dgvCompras.DataBind();
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltroProveedor.Text = "";
            txtFechaDesde.Text = "";
            txtFechaHasta.Text = "";

            dgvCompras.DataSource = new List<Compra>();
            dgvCompras.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            CompraNegocio negocio = new CompraNegocio();

            string Proveedor = txtFiltroProveedor.Text.Trim();
            DateTime? desde = null;
            DateTime? hasta = null;

            if (DateTime.TryParse(txtFechaDesde.Text, out DateTime parsedDesde))
            {
                desde = parsedDesde;
            }
            if (DateTime.TryParse(txtFechaHasta.Text, out DateTime parsedHasta))
            {
                hasta = parsedHasta;
            }

            List<Compra> lista = negocio.ListarHistorial(Proveedor, desde, hasta);
            dgvCompras.DataSource = lista;
            dgvCompras.DataBind();
        }
    }
}