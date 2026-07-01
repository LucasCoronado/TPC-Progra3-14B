using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TPComercio.Negocio;

namespace TPComercio
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductoNegocio pNeg = new ProductoNegocio();
                ClienteNegocio cNeg = new ClienteNegocio();
                VentaNegocio vNeg = new VentaNegocio();
                ProveedorNegocio prNeg = new ProveedorNegocio();

                lblTotalProductos.Text = pNeg.ContarProductos().ToString();
                lblTotalClientes.Text = cNeg.ContarClientes().ToString();
                lblTotalVentas.Text = vNeg.ContarVentas().ToString();
                lblTotalProveedores.Text = prNeg.ContarProveedores().ToString();
            }
        }
    }
}