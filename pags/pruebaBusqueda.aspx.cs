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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGridView();
            }
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

            // Leer los archivos y verificar las condiciones
            bool codigoExiste = VerificarExistenciaEnArchivo(codigo, Server.MapPath("~/txtO/arch4optimo.txt"));
            bool sedeExiste = VerificarExistenciaEnArchivo(sede, Server.MapPath("~/txtO/archSede.txt"));
            bool carreraExiste = VerificarExistenciaEnArchivo(carrera, Server.MapPath("~/txtO/archCarrera.txt"));
            bool jornadaExiste = VerificarExistenciaEnArchivo(jornada, Server.MapPath("~/txtO/archPlan.txt"));

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
                // Código para guardar el nuevo registro
                lblMensaje.Text = "Registro guardado con éxito.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;

                // Lógica para guardar el nuevo registro en el archivo
                // Puedes agregar el código aquí para escribir en el archivo.
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
                    string[] partes = linea.Split(','); // Divide la línea por la coma
                    if (partes.Length > 0 && partes[0].Trim() == valor) // Compara con la primera palabra
                    {
                        return true; // Retorna true si encuentra una coincidencia
                    }
                }
            }
            return false; // Retorna false si no hay coincidencia
        }








    }
}