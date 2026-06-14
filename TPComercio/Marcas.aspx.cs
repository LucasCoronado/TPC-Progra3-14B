using Negocio;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TPComercio.Dominio;

namespace TPComercio
{
    public partial class Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrilla();
            }
        }

        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {

            try
            {
                lblError.Text = "";

                Marca nueva = new Marca();
                nueva.Descripcion = txtNuevaMarca.Text;

                MarcaNegocio negocio = new MarcaNegocio();
                negocio.Agregar(nueva);
                txtNuevaMarca.Text = "";

                CargarGrilla();

            }
            catch (Exception ex)
            {

                lblError.Text = "Error: " + ex.Message;
            }

        }

        private void CargarGrilla()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            dgvMarcas.DataSource = negocio.Listar();
            dgvMarcas.DataBind();
        }

    }
}