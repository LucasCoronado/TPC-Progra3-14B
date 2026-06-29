using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using TPComercio.Dominio;

namespace TPComercio
{
    public partial class VentaDetalle : System.Web.UI.Page
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
                if (Request.QueryString["id"] != null)
                {
                    int idVenta;
                    if (int.TryParse(Request.QueryString["id"], out idVenta))
                    {
                        lblNroVenta.Text = "#" + idVenta;
                        VentaNegocio negocio = new VentaNegocio();
                        
                        Venta ventaObj = negocio.ObtenerVentaPorId(idVenta);
                        if (ventaObj != null)
                        {
                            lblFecha.Text = ventaObj.Fecha.ToString("dd/MM/yyyy");
                            lblFactura.Text = ventaObj.FacturaAsociada != null && !string.IsNullOrEmpty(ventaObj.FacturaAsociada.NumeroFactura) ? ventaObj.FacturaAsociada.NumeroFactura : "Sin Factura";
                            lblCliente.Text = ventaObj.ClienteAsociado.Nombre;
                            lblVendedor.Text = ventaObj.RegistradoPor.NombreUsuario;
                            lblTotal.Text = ventaObj.Total.ToString("C");
                        }

                        List<global::Dominio.DetalleVenta> lista = negocio.ListarDetalles(idVenta);
                        dgvDetalles.DataSource = lista;
                        dgvDetalles.DataBind();
                    }
                    else
                    {
                        Response.Redirect("HistorialVentas.aspx", false);
                    }
                }
                else
                {
                    Response.Redirect("HistorialVentas.aspx", false);
                }
            }
        }
    }
}
