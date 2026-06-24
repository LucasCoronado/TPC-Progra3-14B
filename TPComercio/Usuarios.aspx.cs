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
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrilla();
            }
        }

        private void CargarGrilla()
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            dgvUsuarios.DataSource = negocio.Listar();
            dgvUsuarios.DataBind();
        }
        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";

                if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) || string.IsNullOrWhiteSpace(ddlRol.SelectedValue) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    lblError.Text = "Error: Faltan completar campos obligatorios.";
                    return;
                }
                Usuario nuevo = new Usuario();
                nuevo.NombreUsuario = txtNombreUsuario.Text;
                nuevo.Password = txtPassword.Text; 
                nuevo.Rol = ddlRol.SelectedValue;
                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.Agregar(nuevo);
                
                txtNombreUsuario.Text = "";
                txtPassword.Text = "";
                ddlRol.SelectedIndex = 0;
                CargarGrilla();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error: " + ex.Message;
            }
        }
        protected void dgvUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvUsuarios.EditIndex = e.NewEditIndex;
            CargarGrilla();
        }
        protected void dgvUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvUsuarios.EditIndex = -1;
            CargarGrilla();
        }
        protected void dgvUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvUsuarios.DataKeys[e.RowIndex].Value);
                GridViewRow fila = dgvUsuarios.Rows[e.RowIndex];

                TextBox txtGridUsuario = (TextBox)fila.Cells[1].Controls[0];
                TextBox txtGridPassword = (TextBox)fila.Cells[2].Controls[0];
                TextBox txtGridRol = (TextBox)fila.Cells[3].Controls[0];

                Usuario usuarioModificado = new Usuario();
                usuarioModificado.Id = id;
                usuarioModificado.NombreUsuario = txtGridUsuario.Text;
                usuarioModificado.Password = txtGridPassword.Text;
                usuarioModificado.Rol = txtGridRol.Text;
                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.Modificar(usuarioModificado);

                dgvUsuarios.EditIndex = -1;
                CargarGrilla();
                lblError.Text = "";
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al guardar: " + ex.Message;
            }
        }
        protected void dgvUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvUsuarios.DataKeys[e.RowIndex].Value);
                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.Eliminar(id);
                CargarGrilla();
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al eliminar: " + ex.Message;
            }
        }

    }
}