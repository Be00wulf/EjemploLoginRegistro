using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pmLOGIN.pags
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                LabelWC.Text = $"¿Qué te gustaría hacer hoy, {Session["Username"]}?";
                //Response.Write("<script language=javascript>alert('Nombre de usuario o contraseña incorrectos')</script>");
            }
            else
            {
                Response.Redirect("LogIn.aspx");
            }
        }
    }
}