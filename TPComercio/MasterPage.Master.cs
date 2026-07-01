using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TPComercio.Dominio;

namespace TPComercio
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Seguridad.sesionActiva(Session["usuario"]))
            {
                Response.Redirect("Login.aspx", false);
                return;
            }
            
            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                Usuario user = (Usuario)Session["usuario"];
                lblRol.Text = user.Rol;
                if (!Seguridad.esAdmin(Session["usuario"]))
                {
                    linkUsuarios.Visible = false;
                    linkMarcas.Visible = false;
                    linkCategorias.Visible = false;
                    linkProductos.Visible = false;
                    linkProveedores.Visible = false;
                    linkHistorial.Visible = false;
                    linkCompras.Visible = false;
                    linkAjusteStock.Visible = false;
                }
            }

        }

       protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}