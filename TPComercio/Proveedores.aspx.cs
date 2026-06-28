using Dominio;
using System;
using System.Web.UI.WebControls;
using TPComercio.Dominio;
using TPComercio.Negocio;

namespace TPComercio
{
    public partial class Proveedores : System.Web.UI.Page
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

        protected void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";

                Proveedor nuevo = new Proveedor();
                nuevo.RazonSocial = txtRazonSocial.Text;
                nuevo.Cuit = txtCuit.Text;
                nuevo.Telefono = txtTelefonoProveedor.Text;
                nuevo.Email = txtEmailProveedor.Text;

                ProveedorNegocio negocio = new ProveedorNegocio();
                negocio.Agregar(nuevo);

                txtRazonSocial.Text = "";
                txtCuit.Text = "";
                txtTelefonoProveedor.Text = "";
                txtEmailProveedor.Text = "";

                CargarGrilla();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error: " + ex.Message;
            }
        }

        private void CargarGrilla()
        {
            ProveedorNegocio negocio = new ProveedorNegocio();
            dgvProveedores.DataSource = negocio.Listar();
            dgvProveedores.DataBind();
        }

        protected void dgvProveedores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvProveedores.EditIndex = e.NewEditIndex;
            CargarGrilla();
        }

        protected void dgvProveedores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvProveedores.EditIndex = -1;
            CargarGrilla();
        }

        protected void dgvProveedores_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvProveedores.DataKeys[e.RowIndex].Value);

                GridViewRow fila = dgvProveedores.Rows[e.RowIndex];
                TextBox txtGridRazonSocial = (TextBox)fila.Cells[1].Controls[0];
                TextBox txtGridCuit = (TextBox)fila.Cells[2].Controls[0];
                TextBox txtGridTelefono = (TextBox)fila.Cells[3].Controls[0];
                TextBox txtGridEmail = (TextBox)fila.Cells[4].Controls[0];

                Proveedor proveedorModificado = new Proveedor();
                proveedorModificado.Id = id;
                proveedorModificado.RazonSocial = txtGridRazonSocial.Text;
                proveedorModificado.Cuit = txtGridCuit.Text;
                proveedorModificado.Telefono = txtGridTelefono.Text;
                proveedorModificado.Email = txtGridEmail.Text;

                ProveedorNegocio negocio = new ProveedorNegocio();
                negocio.Modificar(proveedorModificado);

                dgvProveedores.EditIndex = -1;
                CargarGrilla();
                lblError.Text = "";
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al guardar: " + ex.Message;
            }
        }

        protected void dgvProveedores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvProveedores.DataKeys[e.RowIndex].Value);

                ProveedorNegocio negocio = new ProveedorNegocio();
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