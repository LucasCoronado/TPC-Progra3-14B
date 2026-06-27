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
            if (!Seguridad.esAdmin(Session["usuario"]))
            {
                Response.Redirect("Default.aspx", false);
                return;
            }

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

        protected void dgvMarcas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvMarcas.EditIndex = e.NewEditIndex;
            CargarGrilla();
        }

        protected void dgvMarcas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvMarcas.EditIndex = -1;
            CargarGrilla();
        }

        protected void dgvMarcas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvMarcas.DataKeys[e.RowIndex].Value);

                GridViewRow fila = dgvMarcas.Rows[e.RowIndex];
                TextBox txtDescripcion = (TextBox)fila.Cells[1].Controls[0];


                Marca marcaModificada = new Marca();
                marcaModificada.Id = id;
                marcaModificada.Descripcion = txtDescripcion.Text;

                MarcaNegocio negocio = new MarcaNegocio();
                negocio.Modificar(marcaModificada);

                dgvMarcas.EditIndex = -1;
                CargarGrilla();
                lblError.Text = "";
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al guardar: " + ex.Message;
            }
        }

        protected void dgvMarcas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvMarcas.DataKeys[e.RowIndex].Value);

                MarcaNegocio negocio = new MarcaNegocio();
                negocio.Eliminar(id);

                CargarGrilla();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al eliminar: " + ex.Message;
            }
        }

    }
}