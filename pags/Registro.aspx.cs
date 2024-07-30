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
    }
}