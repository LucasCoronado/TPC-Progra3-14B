using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPComercio
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"] != null)
            {
                lblMensajeError.Text = Session["error"].ToString();
            }
            else
            {
                lblMensajeError.Text = "Error desconocido o intento de acceso denegado.";
            }
        }
    }
}