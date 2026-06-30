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
    public partial class HistorialVentas : System.Web.UI.Page
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
                dgvVentas.DataSource = new List<Venta>();
                dgvVentas.DataBind();
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            VentaNegocio negocio = new VentaNegocio();
            
            string cliente = txtFiltroCliente.Text.Trim();
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

            List<Venta> lista = negocio.ListarHistorial(cliente, desde, hasta);
            dgvVentas.DataSource = lista;
            dgvVentas.DataBind();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltroCliente.Text = "";
            txtFechaDesde.Text = "";
            txtFechaHasta.Text = "";
            
            dgvVentas.DataSource = new List<Venta>();
            dgvVentas.DataBind();
        }
    }
}