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
    public partial class CompraDetalle : System.Web.UI.Page
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
                    int idCompra;
                    if (int.TryParse(Request.QueryString["id"], out idCompra))
                    {
                        lblNroCompra.Text = "#" + idCompra;
                        CompraNegocio negocio = new CompraNegocio();

                        Compra compraObj = negocio.ObtenerCompraPorId(idCompra);
                        if (compraObj != null)
                        {
                            lblFecha.Text = compraObj.Fecha.ToString("dd/MM/yyyy");
                            lblFactura.Text = compraObj.FacturaAsociada != null && !string.IsNullOrEmpty(compraObj.FacturaAsociada.NumeroFactura) ? compraObj.FacturaAsociada.NumeroFactura : "Sin Factura";
                            lblFechaFactura.Text = compraObj.FacturaAsociada != null && compraObj.FacturaAsociada.FechaEmision != DateTime.MinValue ? compraObj.FacturaAsociada.FechaEmision.ToString("dd/MM/yyyy") : "-";
                            lblProveedor.Text = compraObj.ProveedorAsociado.RazonSocial;
                            lblTotal.Text = compraObj.Total.ToString("C");
                        }

                        List<DetalleCompra> lista = negocio.ListarDetalles(idCompra);
                        dgvDetalles.DataSource = lista;
                        dgvDetalles.DataBind();
                    }
                    else
                    {
                        Response.Redirect("HistorialCompras.aspx", false);
                    }
                }
                else
                {
                    Response.Redirect("HistorialCompras.aspx", false);
                }
            }

        }
    }
}