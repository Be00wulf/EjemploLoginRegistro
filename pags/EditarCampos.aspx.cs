using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pmLOGIN.pags
{
    public partial class EditarCampos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnSede_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificarSede.aspx");
        }

        protected void btnCarrera_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificarCarrera.aspx");
        }

        protected void btnPlan_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificarPlan.aspx");
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            Response.Redirect("pruebaBusqueda.aspx");
        }
    }
}