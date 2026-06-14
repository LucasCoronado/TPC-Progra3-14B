using Negocio;
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
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrilla();
            }

        }

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {

            try
            {
                lblError.Text = "";

                Cliente nueva = new Cliente();
                nueva.Nombre = txtNombreCliente.Text;
                nueva.Apellido = txtApellidoCliente.Text;
                nueva.Dni = txtDniCliente.Text;
                nueva.Telefono = txtTelefonoCliente.Text;
                nueva.Email = txtEmailCliente.Text;

                ClienteNegocio negocio = new ClienteNegocio();
                negocio.Agregar(nueva);

                txtNombreCliente.Text = "";
                txtApellidoCliente.Text = "";
                txtDniCliente.Text = "";
                txtTelefonoCliente.Text = "";
                txtEmailCliente.Text = "";

                CargarGrilla();

            }
            catch (Exception ex)
            {

                lblError.Text = "Error: " + ex.Message;
            }

        }


        private void CargarGrilla()
        {
            ClienteNegocio negocio = new ClienteNegocio();
            dgvClientes.DataSource = negocio.Listar();
            dgvClientes.DataBind();
        }
    }
}