using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TPComercio.Datos;
using TPComercio.Dominio;
using TPComercio.Negocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace TPComercio
{
    public partial class NuevaVenta : System.Web.UI.Page
    {
        public List<DetalleVenta> CarritoSession
        {
            get
            {
                if (Session["Carrito"] == null)
                {
                    Session["Carrito"] = new List<DetalleVenta>();
                }
                return (List<DetalleVenta>)Session["Carrito"];
            }
            set
            {
                Session["Carrito"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["descargar"] == "1")
            {
                if (Session["Ticket_Numero"] != null)
                {
                    string num = Session["Ticket_Numero"].ToString();
                    string cli = Session["Ticket_Cliente"].ToString();
                    decimal tot = (decimal)Session["Ticket_Total"];
                    List<DetalleVenta> det = (List<DetalleVenta>)Session["Ticket_Detalle"];
                    
                    Session.Remove("Ticket_Numero");
                    Session.Remove("Ticket_Cliente");
                    Session.Remove("Ticket_Total");
                    Session.Remove("Ticket_Detalle");
                    
                    TicketHelper.GenerarTicketPDF(num, cli, tot, det, DateTime.Now);
                }
            }

            if (!IsPostBack)
            {
                txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                ClienteNegocio negocioCliente = new ClienteNegocio();
                ddlClientes.DataSource = negocioCliente.Listar();
                ddlClientes.DataValueField = "Id";    
                ddlClientes.DataTextField = "Nombre"; 
                ddlClientes.DataBind();

                ProductoNegocio negocioProducto = new ProductoNegocio();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBusqueda.Text.Trim().ToUpper();

            ProductoNegocio negocioProducto = new ProductoNegocio();

            if (string.IsNullOrEmpty(filtro))
            {
                dgvProductos.DataSource = negocioProducto.listar();
            }
            else
            {
                dgvProductos.DataSource = negocioProducto.Buscar(filtro);
            }

             dgvProductos.DataBind();
        }

        protected void dgvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Agregar")
            {
                GridViewRow row = (GridViewRow)((Button)e.CommandSource).NamingContainer;

                int idProducto = Convert.ToInt32(e.CommandArgument);

                TextBox txtCantidad = (TextBox)row.FindControl("txtCantidad");
                int cantidad;

                if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
                {
                    return;
                }

                int stockActual = Convert.ToInt32(row.Cells[3].Text);
                string nombreProducto = HttpUtility.HtmlDecode(row.Cells[2].Text);
                decimal precioVenta = decimal.Parse(row.Cells[4].Text, System.Globalization.NumberStyles.Currency);

                List<DetalleVenta> carritoTemporal = CarritoSession;
                DetalleVenta itemExistente = carritoTemporal.Find(x => x.Id == idProducto);

                int cantidadTotalRequerida = cantidad;
                if (itemExistente != null)
                {
                    cantidadTotalRequerida += itemExistente.Cantidad;
                }

                if (cantidadTotalRequerida > stockActual)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "setTimeout(function(){ alert('No hay suficiente stock disponible. Stock disponible: " + stockActual + "'); }, 100);", true);
                    return;
                }

                if (itemExistente != null)
                {
                    itemExistente.Cantidad += cantidad;
                  
                }
                else
                {
                    DetalleVenta nuevoDetalle = new DetalleVenta();
                    nuevoDetalle.Id = idProducto;
                    nuevoDetalle.NombreProducto = nombreProducto;
                    nuevoDetalle.Cantidad = cantidad;
                    nuevoDetalle.PrecioUnitario = precioVenta;
                   

                    carritoTemporal.Add(nuevoDetalle);
                }

                CarritoSession = carritoTemporal;

                ActualizarPantallaCarrito();
                txtCantidad.Text = "1";
            }
        }
        protected void dgvDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Quitar")
            {
                int idProducto = Convert.ToInt32(e.CommandArgument);
                List<DetalleVenta> carritoTemporal = CarritoSession;

                carritoTemporal.RemoveAll(x => x.Id == idProducto);
                CarritoSession = carritoTemporal;
                ActualizarPantallaCarrito();
            }
        }

        protected void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            if (CarritoSession == null || CarritoSession.Count == 0)
            {
                return;
            }

            if (string.IsNullOrEmpty(ddlClientes.SelectedValue))
            {
                return;
            }

            if (Session["usuario"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Sesión expirada. Por favor, vuelva a loguearse.');", true);
                return;
            }

            Usuario usuarioLogueado = (Usuario)Session["usuario"];
            int idUsuario = usuarioLogueado.Id;

            try
            {
                int idCliente = int.Parse(ddlClientes.SelectedValue);
                decimal totalFinal = CarritoSession.Sum(item => item.Cantidad * item.PrecioUnitario);

                VentaNegocio negocioVenta = new VentaNegocio();

                string nuevoNumero = negocioVenta.GenerarProximoNumero();
                
                int idNuevaVenta = negocioVenta.GenerarVenta(idCliente, idUsuario, nuevoNumero, totalFinal, CarritoSession);

                Session["Ticket_Numero"] = nuevoNumero;
                Session["Ticket_Cliente"] = ddlClientes.SelectedItem.Text;
                Session["Ticket_Total"] = totalFinal;
                Session["Ticket_Detalle"] = new List<DetalleVenta>(CarritoSession);

                Session["Carrito"] = null;
                dgvDetalle.DataSource = null;
                dgvDetalle.DataBind();
                lblTotal.Text = "Total: $0";
                btnBuscar_Click(null, null);
                
                string script = "alert('Venta registrada correctamente con ID: " + idNuevaVenta + "'); window.location.href = 'NuevaVenta.aspx?descargar=1';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaPDF", script, true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "error", "alert('Error al procesar la venta: " + ex.Message + "');", true);
            }
        }

        protected void btnCancelarVenta_Click(object sender, EventArgs e)
        {
            Session["Carrito"] = null;
            ddlClientes.SelectedIndex = 0;
            ActualizarPantallaCarrito();
        }

        private void ActualizarPantallaCarrito()
        {
            dgvDetalle.DataSource = CarritoSession;
            dgvDetalle.DataBind();

            decimal total = CarritoSession.Sum(item => item.Cantidad * item.PrecioUnitario);

            lblTotal.Text = $"Total: {total:C}";
        }


    }
}