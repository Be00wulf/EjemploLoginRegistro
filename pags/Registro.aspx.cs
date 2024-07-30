using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pmLOGIN.pags
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //declarando tablas
        DataTable tablaPaises = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPais();
            }

            //recordar ~/ al inicio del "" luego del mapPath para ir a la raiz
            StreamReader leer = new StreamReader(Server.MapPath("~/txt/PaisesLatinoamericanos.txt"));


        }

        protected void DropDownListPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CargarPais();

            //mostrando el texto de la selección en el text box
            TextBoxPais.Text = DropDownListPais.SelectedItem.Text;
        }

        public void CargarPais()
        {
            tablaPaises.Columns.Add("Codigo");
            tablaPaises.Columns.Add("Pais");
            //recordar ~/ al inicio del "" luego del mapPath para ir a la raiz
            StreamReader leer = new StreamReader(Server.MapPath("~/txt/PaisesLatinoamericanos.txt"));

            while (!leer.EndOfStream)
            {
                string linea = leer.ReadLine();
                string[] aux = linea.Split(',');
                tablaPaises.Rows.Add(aux);
            }
            leer.Close();
            DropDownListPais.DataSource = tablaPaises;
            DropDownListPais.DataTextField = "Pais";
            DropDownListPais.DataValueField = "Codigo";
            DropDownListPais.DataBind();
        }

        protected void ButtonGenerarForm_Click(object sender, EventArgs e)
        {
            string nombre1 = TextBoxName1.Text;
            string nombre2 = TextBoxName2.Text;
            string nombreN = TextBoxNameN.Text;

            string apellido1 = TextBoxLn1.Text;
            string apellido2 = TextBoxLn2s.Text;
            string apellidoN = TextBoxLnN.Text;

            string cui = TextBoxCUI.Text;
            string nacimiento = TextBoxNacimiento.Text;
            string pais = TextBoxPais.Text;

            //agregando la linea con los nuevos datos
            string linea = $"{nombre1},{nombre2},{nombreN},{apellido1},{apellido2},{apellidoN},{cui},{nacimiento},{pais}";

            // Guardar en el archivo de texto
            string path = Server.MapPath("~/txt/Inscripciones2.txt");
            using (StreamWriter escribir = new StreamWriter(path, true))
            {
                escribir.WriteLine(linea);
            }

            //confirmacion
            Response.Write("<script language=javascript>alert('Se ha ingresado el cliente exitosamente')</script>");
            //limpiar();
        }
    }
}