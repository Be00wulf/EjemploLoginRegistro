using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pmLOGIN.pags
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Obtener los valores ingresados
            string correo = TextBoxUsuario.Text;
            string clave = TextBoxContrasenia.Text;


        }
    }
}