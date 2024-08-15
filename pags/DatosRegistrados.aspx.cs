using System;
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
        DataTable tablaRegistros = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            // Definir columnas de la tabla
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

            // Leer datos desde el archivo
            StreamReader leer = new StreamReader(Server.MapPath("~/txt/Inscripciones3.txt"));
            while (!leer.EndOfStream)
            {
                string linea = leer.ReadLine();
                string[] aux = linea.Split(',');

                // Asegúrate de que `aux` tiene la cantidad de elementos esperada antes de agregar la fila
                if (aux.Length == tablaRegistros.Columns.Count)
                {
                    tablaRegistros.Rows.Add(aux);
                }
            }
            leer.Close();

            GridViewDatos.DataSource = tablaRegistros;
            GridViewDatos.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Obtener el término de búsqueda
            string terminoBusqueda = txtBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(terminoBusqueda))
            {
                // Crear una vista de la tabla para filtrar los resultados
                DataView dv = new DataView(tablaRegistros);

                // Aplicar el filtro solo en la columna CUI
                dv.RowFilter = string.Format("[CUI] LIKE '%{0}%'", terminoBusqueda);

                GridViewDatos.DataSource = dv;
            }
            else
            {
                // Si el término de búsqueda está vacío, mostrar todos los datos
                GridViewDatos.DataSource = tablaRegistros;
            }

            GridViewDatos.DataBind();
        }
    }
}
