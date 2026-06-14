using Negocio;
using System;
using System.Web.UI;
using TPComercio.Dominio;
using TPComercio.Negocio;

namespace TPComercio
{
    public partial class Proveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
    }
}