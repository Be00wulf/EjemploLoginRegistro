using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Collections.Generic;
using pmLOGIN.pag2;

namespace pmLOGIN.pags
{
    public partial class DatosRegistrados : System.Web.UI.Page
    {
        Registro registroPage = new Registro();
        DataTable tablaRegistros = new DataTable();

        DataTable tablaPaises = new DataTable();
        DataTable tablaGenero = new DataTable();
        DataTable tablaEstadoCivil = new DataTable();
        DataTable tablaDepartamento = new DataTable();
        DataTable tablaMunicipio = new DataTable();
        DataTable tablaSede = new DataTable();
        DataTable tablaCarrera = new DataTable();
        DataTable tablaPlan = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            //Registro registroPage = new Registro();

            // Llamar a la función pública
            //registroPage.CargarDepartamento();

            if (!IsPostBack)
            {
                //registroPage.CargarPais();
                CargarPais();
                CargarGenero();
                CargarDepartamento();
                CargarEstadoCivil();
                CargarMunicipio();
                CargarSede();
                CargarCarreraPlanSegunSede();

                CargarDatos();
            }
        }

        protected void FiltrarPorPais()
        {
            string paisSeleccionado = DropDownListPais.SelectedValue;
            string generoSeleccionado = DropDownListGenero.SelectedValue;
            string estadoCivilSeleccionado = DropDownListEstadoCivil.SelectedValue;
            string departamentoSeleccionado = DropDownListDepto.SelectedValue;
            string municipioSeleccionado = DropDownListMunicipio.SelectedValue;
            string sedeSeleccionada = DropDownListSede.SelectedValue;
            string carreraSeleccionada = DropDownListCarrera.SelectedValue;
            string planSeleccionado = DropDownListPlan.SelectedValue;

            string[] lineas = File.ReadAllLines(Server.MapPath("~/txt/Inscripciones3Opt.txt"));

            DataTable tablaFiltrada = new DataTable();
            tablaFiltrada.Columns.Add("CUI"); 
            tablaFiltrada.Columns.Add("País");
            tablaFiltrada.Columns.Add("Genero");
            tablaFiltrada.Columns.Add("Estado Civil");
            tablaFiltrada.Columns.Add("Departamento");
            tablaFiltrada.Columns.Add("Municipio");
            tablaFiltrada.Columns.Add("Sede");
            tablaFiltrada.Columns.Add("Carrera");
            tablaFiltrada.Columns.Add("Plan");

            foreach (string linea in lineas)
            {
                string[] valores = linea.Split(',');

                if (valores.Length >= 9)
                {
                    bool coincide = false;

                    if (string.IsNullOrEmpty(paisSeleccionado) || valores[1] == paisSeleccionado)
                        coincide = true;

                    if (!coincide && !string.IsNullOrEmpty(generoSeleccionado) && valores[2] == generoSeleccionado)
                        coincide = true;

                    if (!coincide && !string.IsNullOrEmpty(estadoCivilSeleccionado) && valores[3] == estadoCivilSeleccionado)
                        coincide = true;

                    if (!coincide && !string.IsNullOrEmpty(departamentoSeleccionado) && valores[4] == departamentoSeleccionado)
                        coincide = true;

                    if (!coincide && !string.IsNullOrEmpty(municipioSeleccionado) && valores[5] == municipioSeleccionado)
                        coincide = true;

                    if (!coincide && !string.IsNullOrEmpty(sedeSeleccionada) && valores[6] == sedeSeleccionada)
                        coincide = true;

                    if (!coincide && !string.IsNullOrEmpty(carreraSeleccionada) && valores[7] == carreraSeleccionada)
                        coincide = true;

                    if (!coincide && !string.IsNullOrEmpty(planSeleccionado) && valores[8] == planSeleccionado)
                        coincide = true;

                    // si coincide con al menos un filtro agregar a la tabla filtrada
                    if (coincide)
                    {
                        DataRow fila = tablaFiltrada.NewRow();
                        fila["CUI"] = valores[0];
                        fila["País"] = valores[1];
                        fila["Genero"] = valores[2];
                        fila["Estado Civil"] = valores[3];
                        fila["Departamento"] = valores[4];
                        fila["Municipio"] = valores[5];
                        fila["Sede"] = valores[6];
                        fila["Carrera"] = valores[7];
                        fila["Plan"] = valores[8];
                        tablaFiltrada.Rows.Add(fila);
                    }
                }
            }

            if (tablaFiltrada.Rows.Count > 0)
            {
                GridViewDatos.DataSource = tablaFiltrada;
                GridViewDatos.DataBind();
                lblMensaje.Visible = false;
            }
            else
            {
                lblMensaje.Text = "No se encontraron resultados para los filtros seleccionados.";
                lblMensaje.Visible = true;
                GridViewDatos.DataSource = null;
                GridViewDatos.DataBind();
            }
            //// Asignar la tabla filtrada al GridView
            //GridViewDatos.DataSource = tablaFiltrada;
            //GridViewDatos.DataBind();
        }


        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarPorPais();
        }

        public void CargarSede()
        {
            tablaSede.Columns.Clear();
            tablaSede.Rows.Clear();
            tablaSede.Columns.Add("Codigo");
            tablaSede.Columns.Add("Sede");
            StreamReader leer = new StreamReader(Server.MapPath("~/txt/Sede1.txt"));

            while (!leer.EndOfStream)
            {
                string linea = leer.ReadLine();
                string[] aux = linea.Split(',');
                tablaSede.Rows.Add(aux);
            }

            leer.Close();
            DropDownListSede.DataSource = tablaSede;
            DropDownListSede.DataTextField = "Sede";
            DropDownListSede.DataValueField = "Codigo";
            DropDownListSede.DataBind();
        }

        //MUNICIPIO Y DEPARTAMENTO ENLAZADOS
        public void CargarMunicipio()
        {
            tablaMunicipio.Columns.Clear();
            tablaMunicipio.Rows.Clear();
            tablaMunicipio.Columns.Add("CodMunic");
            tablaMunicipio.Columns.Add("Munic");
            tablaMunicipio.Columns.Add("CodDepto");

            StreamReader leer2 = new StreamReader(Server.MapPath("~/txt/Municipio.txt"));

            while (!leer2.EndOfStream)
            {
                string linea = leer2.ReadLine();
                string[] aux = linea.Split(',');
                if (DropDownListDepto.SelectedValue == aux[2])      //ojo  enlazado al condicional
                {
                    tablaMunicipio.Rows.Add(aux);
                }
            }

            leer2.Close();
            DropDownListMunicipio.DataSource = tablaMunicipio;
            DropDownListMunicipio.DataTextField = "Munic";
            DropDownListMunicipio.DataValueField = "CodMunic";
            DropDownListMunicipio.DataBind();
        }

        public void CargarDepartamento()
        {
            tablaDepartamento.Columns.Add("Codigo");
            tablaDepartamento.Columns.Add("Depto");
            StreamReader leer = new StreamReader(Server.MapPath("~/txt/Departamento.txt"));

            while (!leer.EndOfStream)
            {
                string linea = leer.ReadLine();
                string[] aux = linea.Split(',');
                tablaDepartamento.Rows.Add(aux);
            }

            leer.Close();
            DropDownListDepto.DataSource = tablaDepartamento;
            DropDownListDepto.DataTextField = "Depto";
            DropDownListDepto.DataValueField = "Codigo";
            DropDownListDepto.DataBind();
        }

        //GENERO Y ESTADO CIVIL ENLAZADOS
        public void CargarEstadoCivil()
        {
            tablaEstadoCivil.Columns.Clear();
            tablaEstadoCivil.Rows.Clear();
            tablaEstadoCivil.Columns.Add("CodEstadoC");
            tablaEstadoCivil.Columns.Add("EstadoCivil");
            tablaEstadoCivil.Columns.Add("CodGenero");
            StreamReader leer2 = new StreamReader(Server.MapPath("~/txt/EstadoCivilF.txt"));

            while (!leer2.EndOfStream)
            {
                string linea = leer2.ReadLine();
                string[] aux = linea.Split(',');
                if (DropDownListGenero.SelectedValue == aux[2])
                {
                    tablaEstadoCivil.Rows.Add(aux);
                }
            }

            leer2.Close();
            DropDownListEstadoCivil.DataSource = tablaEstadoCivil;
            DropDownListEstadoCivil.DataTextField = "EstadoCivil";
            DropDownListEstadoCivil.DataValueField = "CodEstadoC";
            DropDownListEstadoCivil.DataBind();
        }

        public void CargarGenero()
        {
            tablaGenero.Columns.Add("Codigo");
            tablaGenero.Columns.Add("Genero");
            StreamReader leer1 = new StreamReader(Server.MapPath("~/txt/GeneroM.txt"));

            while (!leer1.EndOfStream)
            {
                string linea = leer1.ReadLine();
                string[] aux = linea.Split(',');
                tablaGenero.Rows.Add(aux);
            }

            leer1.Close();
            DropDownListGenero.DataSource = tablaGenero;
            DropDownListGenero.DataTextField = "Genero";
            DropDownListGenero.DataValueField = "Codigo";
            DropDownListGenero.DataBind();
            tablaEstadoCivil.Clear();
        }

        public void CargarPais()
        {
            tablaPaises.Columns.Add("Codigo");
            tablaPaises.Columns.Add("Pais");
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

        public void CargarCarreraPlanSegunSede()
        {
            string codigoSedeSeleccionada = DropDownListSede.SelectedValue;

            StreamReader leerOptimo = new StreamReader(Server.MapPath("~/txtO/arch4optimo.txt"));
            List<string> codigosCarrera = new List<string>();

            while (!leerOptimo.EndOfStream)
            {
                string linea = leerOptimo.ReadLine();
                string[] aux = linea.Split(',');

                if (aux[1] == codigoSedeSeleccionada)
                {
                    codigosCarrera.Add(aux[2]);
                }
            }
            leerOptimo.Close();

            //carreras que correspondan a los códigos obtenidos
            tablaCarrera.Columns.Clear();
            tablaCarrera.Rows.Clear();
            tablaCarrera.Columns.Add("CodCarrera");
            tablaCarrera.Columns.Add("Carrera");
            tablaCarrera.Columns.Add("CodSede");

            StreamReader leerCarrera = new StreamReader(Server.MapPath("~/txtO/archCarrera.txt"));

            while (!leerCarrera.EndOfStream)
            {
                string linea = leerCarrera.ReadLine();
                string[] aux = linea.Split(',');

                if (codigosCarrera.Contains(aux[0]))
                {
                    tablaCarrera.Rows.Add(aux);
                }
            }
            leerCarrera.Close();

            DropDownListCarrera.DataSource = tablaCarrera;
            DropDownListCarrera.DataTextField = "Carrera";
            DropDownListCarrera.DataValueField = "CodCarrera";
            DropDownListCarrera.DataBind();


            //jornadas que corresponden a los codigos obtenidos
            tablaPlan.Columns.Clear();
            tablaPlan.Rows.Clear();
            tablaPlan.Columns.Add("CodPlan");
            tablaPlan.Columns.Add("Plan");
            tablaPlan.Columns.Add("CodCarrera");

            StreamReader leerPlan = new StreamReader(Server.MapPath("~/txtO/archPlan.txt"));

            while (!leerPlan.EndOfStream)
            {
                string linea = leerPlan.ReadLine();
                string[] aux = linea.Split(',');

                if (codigosCarrera.Contains(aux[0]))
                {
                    tablaPlan.Rows.Add(aux);
                }
            }
            leerCarrera.Close();

            DropDownListPlan.DataSource = tablaPlan;
            DropDownListPlan.DataTextField = "Plan";
            DropDownListPlan.DataValueField = "CodPlan";
            DropDownListPlan.DataBind();
        }

        public void CargarColumnasGrid()
        {
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

        }

        private void CargarDatos()
        {
            CargarColumnasGrid();

            StreamReader leer = new StreamReader(Server.MapPath("~/txt/Inscripciones3.txt"));
            while (!leer.EndOfStream)
            {
                string linea = leer.ReadLine();
                string[] aux = linea.Split(',');

                if (aux.Length == tablaRegistros.Columns.Count)
                {
                    tablaRegistros.Rows.Add(aux);
                }
            }
            leer.Close();

            GridViewDatos.DataSource = tablaRegistros;
            GridViewDatos.DataBind();
        }

        protected void DropDownListGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEstadoCivil();
        }

        protected void DropDownListDepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMunicipio();
        }

        protected void DropDownListSede_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCarreraPlanSegunSede();
        }
    }
}
