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
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrilla();
            }
        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {

            try
            {
                lblError.Text = "";

                Categoria nueva = new Categoria();
                nueva.Descripcion = txtNuevaCategoria.Text;

                CategoriaNegocio negocio = new CategoriaNegocio();
                negocio.Agregar(nueva);
                txtNuevaCategoria.Text = "";

                CargarGrilla();

            }
            catch (Exception ex)
            {

                lblError.Text = "Error: " + ex.Message;
            }

        }

        private void CargarGrilla()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            dgvCategorias.DataSource = negocio.Listar();
            dgvCategorias.DataBind();
        }
    }
}