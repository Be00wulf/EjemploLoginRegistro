using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace pmLOGIN.pags
{
    public partial class DatosRegistrados : System.Web.UI.Page
    {
        //definiendo tablas
        DataTable tablaRegistros = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            //definiendo columnas
            tablaRegistros.Columns.Add("Primer nombre");
            tablaRegistros.Columns.Add("Segundo nombre");
            tablaRegistros.Columns.Add("Otros nombres");

            tablaRegistros.Columns.Add("Primer apellido");
            tablaRegistros.Columns.Add("Segundo apellido");
            tablaRegistros.Columns.Add("Apellido de casada");

            tablaRegistros.Columns.Add("CUI");
            tablaRegistros.Columns.Add("Fecha de Nacimiento");
            tablaRegistros.Columns.Add("País de nacimiento");

            tablaRegistros.Columns.Add("Género");
            tablaRegistros.Columns.Add("Estado Civil");
            tablaRegistros.Columns.Add("Dirección");

            tablaRegistros.Columns.Add("Departamento");
            tablaRegistros.Columns.Add("Municipio");
            tablaRegistros.Columns.Add("Telefono");

            tablaRegistros.Columns.Add("Correo");
            tablaRegistros.Columns.Add("Contacto de Emergencia");
            tablaRegistros.Columns.Add("Telefono de Emergencia");

            tablaRegistros.Columns.Add("Sede");
            tablaRegistros.Columns.Add("Carrera");
            tablaRegistros.Columns.Add("Plan");

            tablaRegistros.Columns.Add("Titulo");
            tablaRegistros.Columns.Add("Fecha Del Titulo");
            tablaRegistros.Columns.Add("Institucion");

            if (!IsPostBack)
            {
                //
            }

            //leyendo datos
            StreamReader leer = new StreamReader(Server.MapPath("~/txt/Inscripciones2.txt"));

            //definiendo columnas de separacion de TIPOS DE datos ingresados
            while (!leer.EndOfStream)
            {
                string linea = leer.ReadLine();
                string[] aux = linea.Split(',');
                tablaRegistros.Rows.Add(aux);
            }
            leer.Close();
            GridViewDatos.DataSource = tablaRegistros;
            GridViewDatos.DataBind();

        }

        //
        


    }
}