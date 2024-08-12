using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pmLOGIN.pag2
{
    public partial class Admins : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    lblUsername.Text = "Hola, " + Session["Username"].ToString();
                }
                else
                {
                    lblUsername.Text = ""; // 
                    // Redirigir al login si no hay sesión activa
                    Response.Redirect("~/pag2/Perfil.aspx");
                }
            }
        }
    }
}