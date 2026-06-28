using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using TPComercio.Dominio;
using TPComercio.Negocio;

namespace TPComercio
{
    public partial class NuevaCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFechaIngreso.Text = DateTime.Now.ToString("dd/MM/yyyy");
                CargarProveedores();
                Session["CarritoCompra"] = new List<DetalleCompra>();
            }
        }

        private void CargarProveedores()
        {
            ProveedorNegocio negocio = new ProveedorNegocio();
            ddlProveedores.DataSource = negocio.Listar();
            ddlProveedores.DataValueField = "Id";
            ddlProveedores.DataTextField = "RazonSocial";
            ddlProveedores.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            dgvProductos.DataSource = negocio.Buscar(txtBusqueda.Text);
            dgvProductos.DataBind();
        }

        protected void dgvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Agregar")
            {
                int idProducto = int.Parse(e.CommandArgument.ToString());
                GridViewRow row = (GridViewRow)((Button)e.CommandSource).NamingContainer;

                TextBox txtCant = (TextBox)row.FindControl("txtCantidad");
                int cantidad = int.Parse(txtCant.Text);

                string nombre = row.Cells[2].Text;

                string precioTexto = row.Cells[4].Text.Replace("$", "").Trim();
                decimal precioUnitario = decimal.Parse(precioTexto);

                Producto productoSeleccionado = new Producto();
                productoSeleccionado.Id = idProducto;
                productoSeleccionado.Nombre = nombre;

                DetalleCompra nuevoDetalle = new DetalleCompra();
                nuevoDetalle.Producto = productoSeleccionado;
                nuevoDetalle.Cantidad = cantidad;
                nuevoDetalle.PrecioUnitario = precioUnitario;
                nuevoDetalle.Subtotal = cantidad * precioUnitario;
                nuevoDetalle.NumeroFactura = txtNumeroFactura.Text;

                List<DetalleCompra> carrito = (List<DetalleCompra>)Session["CarritoCompra"];
                carrito.Add(nuevoDetalle);
                Session["CarritoCompra"] = carrito;

                ActualizarGrillaCarrito();
                lblTotal.Text = "Total: $" + CalcularTotal(carrito).ToString("0.00");
            }
        }

        protected void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            List<DetalleCompra> carrito = (List<DetalleCompra>)Session["CarritoCompra"];

            Compra nuevaCompra = new Compra();
            nuevaCompra.ProveedorAsociado = new Proveedor { Id = int.Parse(ddlProveedores.SelectedValue) };
            nuevaCompra.Total = CalcularTotal(carrito);
            nuevaCompra.NumeroFactura = txtNumeroFactura.Text;
            nuevaCompra.FechaFactura = DateTime.Parse(txtFechaFactura.Text);
            nuevaCompra.Fecha = DateTime.Now;

            CompraNegocio negocio = new CompraNegocio();
            int idCompraGenerado = negocio.RegistrarCompra(nuevaCompra, carrito);

            if (idCompraGenerado > 0)
            {
                Session["CarritoCompra"] = new List<DetalleCompra>();
                ActualizarGrillaCarrito();
                lblTotal.Text = "Total: $0.00";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Compra registrada correctamente con ID: " + idCompraGenerado + "');", true);
            }
        }

        protected void btnCancelarCompra_Click(object sender, EventArgs e)
        {
            Session["CarritoCompra"] = new List<DetalleCompra>();
            ActualizarGrillaCarrito();
            lblTotal.Text = "Total: $0.00";
        }

        private void ActualizarGrillaCarrito()
        {
            dgvDetalle.DataSource = Session["CarritoCompra"];
            dgvDetalle.DataBind();
        }

        protected void dgvDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Quitar")
            {
                int idProducto = int.Parse(e.CommandArgument.ToString());

                List<DetalleCompra> carrito = (List<DetalleCompra>)Session["CarritoCompra"];
                carrito.RemoveAll(x => x.Producto.Id == idProducto);
                Session["CarritoCompra"] = carrito;
                ActualizarGrillaCarrito();

            }
        }
                private decimal CalcularTotal(List<DetalleCompra> carrito)
        {
            decimal total = 0;
            foreach (DetalleCompra item in carrito)
            {
                total += item.Subtotal;
            }
            return total;
        }
    }
}