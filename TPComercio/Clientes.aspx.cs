using System;
using System.Collections.Generic;
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
                ActualizarSesionYGrilla();
            }
        }

        private void ActualizarSesionYGrilla()
        {
            ClienteNegocio negocio = new ClienteNegocio();
            List<Cliente> lista = negocio.Listar();
            Session.Add("ListaClientes", lista);
            CargarGrilla(lista);
        }

        private void CargarGrilla(List<Cliente> lista)
        {
            dgvClientes.DataSource = lista;
            dgvClientes.DataBind();
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

                ActualizarSesionYGrilla();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error: " + ex.Message;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Cliente> listaGuardada = (List<Cliente>)Session["ListaClientes"];
            string filtro = txtFiltro.Text.ToUpper();

            if (!string.IsNullOrEmpty(filtro))
            {
                List<Cliente> listaFiltrada = listaGuardada.FindAll(x =>
                    x.Apellido.ToUpper().Contains(filtro) ||
                    x.Dni.Contains(filtro));
                CargarGrilla(listaFiltrada);
            }
            else
            {
                CargarGrilla(listaGuardada);
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
            CargarGrilla((List<Cliente>)Session["ListaClientes"]);
        }

        protected void dgvClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvClientes.EditIndex = e.NewEditIndex;
            btnBuscar_Click(null, null);
        }

        protected void dgvClientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvClientes.EditIndex = -1;
            btnBuscar_Click(null, null);
        }

        protected void dgvClientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvClientes.DataKeys[e.RowIndex].Value);
                GridViewRow fila = dgvClientes.Rows[e.RowIndex];

                Cliente clienteModificado = new Cliente();
                clienteModificado.Id = id;
                clienteModificado.Nombre = ((TextBox)fila.Cells[1].Controls[0]).Text;
                clienteModificado.Apellido = ((TextBox)fila.Cells[2].Controls[0]).Text;
                clienteModificado.Dni = ((TextBox)fila.Cells[3].Controls[0]).Text;
                clienteModificado.Telefono = ((TextBox)fila.Cells[4].Controls[0]).Text;
                clienteModificado.Email = ((TextBox)fila.Cells[5].Controls[0]).Text;

                ClienteNegocio negocio = new ClienteNegocio();
                negocio.Modificar(clienteModificado);

                dgvClientes.EditIndex = -1;
                ActualizarSesionYGrilla();
                lblError.Text = "";
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al guardar: " + ex.Message;
            }
        }

        protected void dgvClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvClientes.DataKeys[e.RowIndex].Value);

                ClienteNegocio negocio = new ClienteNegocio();
                negocio.Eliminar(id);

                ActualizarSesionYGrilla();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al eliminar: " + ex.Message;
            }
        }
    }
}