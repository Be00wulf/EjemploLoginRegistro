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


            if (!IsPostBack)
            {
                //CargarPais();
            }





        }

        //cargando paises
        


    }
}