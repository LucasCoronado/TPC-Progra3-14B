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
    public partial class Categorias : System.Web.UI.Page
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

        protected void dgvCategorias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvCategorias.EditIndex = e.NewEditIndex;
            CargarGrilla();
        }

        protected void dgvCategorias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvCategorias.EditIndex = -1;
            CargarGrilla();
        }

        protected void dgvCategorias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvCategorias.DataKeys[e.RowIndex].Value);

                GridViewRow fila = dgvCategorias.Rows[e.RowIndex];
                TextBox txtDescripcion = (TextBox)fila.Cells[1].Controls[0];


                Categoria categoriaModificada = new Categoria();
                categoriaModificada.Id = id;
                categoriaModificada.Descripcion = txtDescripcion.Text;

                CategoriaNegocio negocio = new CategoriaNegocio();
                negocio.Modificar(categoriaModificada);

                dgvCategorias.EditIndex = -1;
                CargarGrilla();
                lblError.Text = "";
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al guardar: " + ex.Message;
            }
        }

        protected void dgvCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvCategorias.DataKeys[e.RowIndex].Value);

                CategoriaNegocio negocio = new CategoriaNegocio();
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