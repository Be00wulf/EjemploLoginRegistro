using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace pmLOGIN.pags
{
    public partial class pruebaBusqueda : System.Web.UI.Page
    {
        DataTable tablaProducto = new DataTable();
        DataTable tablaCarrera = new DataTable();
        DataTable tablaPlan = new DataTable();

        string rutaArchivo_Sede = "~/txtO/archSede.txt";
        string rutaArchivo_Carrera = "~/txtO/archCarrera.txt";
        string rutaArchivo_Plan= "~/txtO/archPlan.txt";

        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["Username"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}

            if (!IsPostBack)
            {
                LoadGridView();
                CargarSede();
                CargarCarrera();
                CargarPlan();

            }
        }

        public void CargarPlan()
        {
            tablaPlan.Columns.Add("Codigo");
            tablaPlan.Columns.Add("Plan");
            StreamReader leer = new StreamReader(Server.MapPath(rutaArchivo_Plan));

            while (!leer.EndOfStream)
            {
                string linea = leer.ReadLine();
                string[] aux = linea.Split(',');

                // Concatenar Código y Sede en una sola cadena para mostrarla en el DropDownList
                string codigoYplan = "[" + aux[0] + "] " + aux[1];

                tablaPlan.Rows.Add(aux[0], codigoYplan);
            }

            leer.Close();
            DropDownListAddPlan.DataSource = tablaPlan;
            DropDownListAddPlan.DataTextField = "Plan";
            DropDownListAddPlan.DataValueField = "Codigo";
            DropDownListAddPlan.DataBind();
        }

        public void CargarCarrera()
        {
            tablaCarrera.Columns.Add("Codigo");
            tablaCarrera.Columns.Add("Carrera");
            StreamReader leer = new StreamReader(Server.MapPath(rutaArchivo_Carrera));

            while (!leer.EndOfStream)
            {
                string linea = leer.ReadLine();
                string[] aux = linea.Split(',');

                // Concatenar Código y Sede en una sola cadena para mostrarla en el DropDownList
                string codigoYcarrera = "[" + aux[0] + "] " + aux[1];

                tablaCarrera.Rows.Add(aux[0], codigoYcarrera);
            }

            leer.Close();
            DropDownListAddCarrera.DataSource = tablaCarrera;
            DropDownListAddCarrera.DataTextField = "Carrera";
            DropDownListAddCarrera.DataValueField = "Codigo";
            DropDownListAddCarrera.DataBind();
        }

        public void CargarSede()
        {
            tablaProducto.Columns.Add("Codigo");
            tablaProducto.Columns.Add("Sede");
            StreamReader leer = new StreamReader(Server.MapPath(rutaArchivo_Sede));

            while (!leer.EndOfStream)
            {
                string linea = leer.ReadLine();
                string[] aux = linea.Split(',');

                // Concatenar Código y Sede en una sola cadena para mostrarla en el DropDownList
                string codigoYSede = "[" + aux[0] + "] " + aux[1];

                tablaProducto.Rows.Add(aux[0], codigoYSede);
            }

            leer.Close();
            DropDownListAddSede.DataSource = tablaProducto;
            DropDownListAddSede.DataTextField = "Sede";
            DropDownListAddSede.DataValueField = "Codigo";
            DropDownListAddSede.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt = GetData();
            DataView dv = dt.DefaultView;

            string filter = "";

            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                filter += "CODIGO = " + txtCodigo.Text;
            }
            if (!string.IsNullOrEmpty(txtSede.Text))
            {
                if (filter.Length > 0) filter += " AND ";
                filter += "SEDE = " + txtSede.Text;
            }
            if (!string.IsNullOrEmpty(txtCarrera.Text))
            {
                if (filter.Length > 0) filter += " AND ";
                filter += "CARRERA = " + txtCarrera.Text;
            }
            if (!string.IsNullOrEmpty(txtJornada.Text))
            {
                if (filter.Length > 0) filter += " AND ";
                filter += "JORNADA = " + txtJornada.Text;
            }

            dv.RowFilter = filter;

            if (dv.Count > 0)
            {
                GridView1.DataSource = dv;
                GridView1.DataBind();
                lblNoResults.Visible = false; // Oculta el mensaje si hay resultados
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                lblNoResults.Visible = true; // Muestra el mensaje si no hay resultados
            }
        }


        private DataTable GetData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CODIGO");
            dt.Columns.Add("SEDE");
            dt.Columns.Add("CARRERA");
            dt.Columns.Add("JORNADA");

            string filePath = Server.MapPath("~/txtO/arch4optimo.txt");

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] values = line.Split(',');

                    if (values.Length == 4) 
                    {
                        DataRow row = dt.NewRow();
                        row["CODIGO"] = values[0];
                        row["SEDE"] = values[1];
                        row["CARRERA"] = values[2];
                        row["JORNADA"] = values[3];
                        dt.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error al leer el archivo: " + ex.Message);
            }

            return dt;
        }

        private void LoadGridView()
        {
            GridView1.DataSource = GetData();
            GridView1.DataBind();
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();
            string sede = txtSede.Text.Trim();
            string carrera = txtCarrera.Text.Trim();
            string jornada = txtJornada.Text.Trim();

            string rutaArchivoCodigo = Server.MapPath("~/txtO/arch4optimo.txt");
            string rutaArchivoSede = Server.MapPath("~/txtO/archSede.txt");
            string rutaArchivoCarrera = Server.MapPath("~/txtO/archCarrera.txt");
            string rutaArchivoJornada = Server.MapPath("~/txtO/archPlan.txt");

            // Verificar existencia en los archivos respectivos
            bool codigoExiste = VerificarExistenciaEnArchivo(codigo, rutaArchivoCodigo);
            bool sedeExiste = VerificarExistenciaEnArchivo(sede, rutaArchivoSede);
            bool carreraExiste = VerificarExistenciaEnArchivo(carrera, rutaArchivoCarrera);
            bool jornadaExiste = VerificarExistenciaEnArchivo(jornada, rutaArchivoJornada);

            // Validaciones y mensajes
            if (codigoExiste)
            {
                lblMensaje.Text = "El código ya existe.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
            else if (!sedeExiste)
            {
                lblMensaje.Text = "La sede no ha sido registrada.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
            else if (!carreraExiste)
            {
                lblMensaje.Text = "La carrera no ha sido registrada.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
            else if (!jornadaExiste)
            {
                lblMensaje.Text = "La jornada no ha sido registrada.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                // Construir la línea en el formato requerido para arch4optimo.txt
                string nuevaLinea = $"{codigo},{sede},{carrera},{jornada}";

                // Guardar el nuevo registro en el archivo arch4optimo.txt
                GuardarEnArchivo(nuevaLinea, rutaArchivoCodigo);

                lblMensaje.Text = "Registro guardado con éxito.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
        }

        // Método para verificar la existencia de un valor en la primera posición de cada línea del archivo
        private bool VerificarExistenciaEnArchivo(string valor, string rutaArchivo)
        {
            if (File.Exists(rutaArchivo))
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                foreach (string linea in lineas)
                {
                    string[] partes = linea.Split(',');
                    if (partes.Length > 0 && partes[0].Trim() == valor)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Método para guardar una nueva línea en el archivo arch4optimo.txt
        private void GuardarEnArchivo(string nuevaLinea, string rutaArchivo)
        {
            // Abrir el archivo para añadir el nuevo valor
            using (StreamWriter sw = new StreamWriter(rutaArchivo, true))
            {
                sw.WriteLine(nuevaLinea);
            }
        }

        protected void ButtonRefrescar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = string.Empty;
            txtSede.Text = string.Empty;
            txtCarrera.Text = string.Empty;
            txtJornada.Text = string.Empty;

            // Limpiar el mensaje
            lblMensaje.Text = string.Empty;
            lblNoResults.Text = string.Empty;
            LoadGridView();
        }





        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            string codigoEliminar = txtCodigo.Text.Trim();
            string rutaArchivo = Server.MapPath("~/txtO/arch4optimo.txt");

            if (EliminarRegistro(codigoEliminar, rutaArchivo))
            {
                lblMensaje.Text = "Registro eliminado con éxito.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensaje.Text = "El código no existe.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool EliminarRegistro(string codigo, string rutaArchivo)
        {
            // Leer todas las líneas del archivo
            string[] lineas = File.ReadAllLines(rutaArchivo);
            bool encontrado = false;

            // Crear una lista para almacenar las líneas que no deben ser eliminadas
            List<string> nuevasLineas = new List<string>();

            foreach (string linea in lineas)
            {
                string[] partes = linea.Split(',');

                // Comprobar si el primer valor de la línea coincide con el código
                if (partes[0] == codigo)
                {
                    encontrado = true;
                    // No añadir la línea a la lista, la estamos eliminando
                }
                else
                {
                    nuevasLineas.Add(linea);
                }
            }

            // Si se encontró y eliminó el registro, reescribir el archivo sin el registro eliminado
            if (encontrado)
            {
                File.WriteAllLines(rutaArchivo, nuevasLineas);
            }

            return encontrado;
        }




    }
}