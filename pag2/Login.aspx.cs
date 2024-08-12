using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace pmLOGIN.Login_aa
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //RECREANDO
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //limpiar la sesión / inicializar algún dato.
                Session.Clear();
            }
        }

        protected void ButtonIngresar_Click(object sender, EventArgs e)
        {
            string username = TextBoxUsuario.Text.Trim();
            string password = TextBoxContrasenia.Text.Trim();

            bool isAuthenticated = AuthenticateUser(username, password);

            if (isAuthenticated)
            {
                // Guardar el nombre de usuario en la sesión y redirigir
                Session["Username"] = username;
                Response.Redirect("Perfil.aspx");
            }
            else
            {
                //lblMessage.Text = "Nombre de usuario o contraseña incorrectos.";
                Response.Write("<script language=javascript>alert('Nombre de usuario o contraseña incorrectos')</script>");
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            // Ruta al archivo de usuarios
            string filePath = Server.MapPath("~/txt/usuarios.txt");

            // Leer el archivo de usuarios
            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    string storedUsername = parts[0].Trim();
                    string storedPassword = parts[1].Trim();

                    if (username == storedUsername && password == storedPassword)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}