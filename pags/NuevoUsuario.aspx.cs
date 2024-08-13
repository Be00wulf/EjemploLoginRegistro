using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace pmLOGIN.pags
{
    public partial class NuevoUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                lblMessage.Text = "";
            }
        }

        protected void ButtonNuevoIngreso_Click(object sender, EventArgs e)
        {
            string username = TextBoxNuevoUsuario.Text.Trim();
            string password = TextBoxNuevaContrasenia.Text.Trim();

            //validando cmapos vacios
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Debe ingresar un nombre de usuario contraseña.";
                return;
            }

            string filePath = Server.MapPath("~/txt/usuarios.txt");

            if (UserExists(username, filePath))
            {
                lblMessage.Text = "El nombre de usuario ya está en uso.";
            }
            else
            {
                RegisterUser(username, password, filePath);
                lblMessage.Text = "Usuario registrado exitosamente.";
            }

        }

        private bool UserExists(string username, string filePath)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts[0].Equals(username, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private void RegisterUser(string username, string password, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{username},{password}");
            }
        }
    }
}