using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pmLOGIN.pag2
{
    public partial class Registro : System.Web.UI.Page
    {
        //SITIO REGREADO
        //declarando tablas
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
            if (!IsPostBack)
            {
                CargarPais();
                CargarGenero();
                CargarDepartamento();
                CargarSede();

                CargarEstadoCivil();
                CargarMunicipio();
                CargarCarrera();
                CargarPlan();
            }
        }

        //SEDE - CARRERA Y PLAN, ENLAZADOS
        public void CargarPlan()
        {
            //..el primer valor de carrera esta ligado al terceer valor del plan
            tablaPlan.Columns.Clear();
            tablaPlan.Rows.Clear();
            tablaPlan.Columns.Add("CodPlan");
            tablaPlan.Columns.Add("Plan");
            tablaPlan.Columns.Add("CodCarrera");
            //tablaPlan.Columns.Add("CodCarreraPlan");

            StreamReader leer2 = new StreamReader(Server.MapPath("~/txt/Plan.txt"));
            //StreamReader leer2 = new StreamReader(Server.MapPath("~/txt/PlanOpt.txt"));
            //StreamReader leerCarrera = new StreamReader(Server.MapPath("~/txt/CarreraOpt.txt"));

            while (!leer2.EndOfStream)
            {
                string linea = leer2.ReadLine();
                string[] aux = linea.Split(',');
                if (DropDownListCarrera.SelectedValue == aux[2])      //ojo  enlazado al condicional
                //if (DropDownListCarrera.SelectedValue == aux[3])      //ojo  enlazado al condicional
                {
                    tablaPlan.Rows.Add(aux);
                }
            }

            leer2.Close();
            DropDownListPlan.DataSource = tablaPlan;
            DropDownListPlan.DataTextField = "Plan";
            DropDownListPlan.DataValueField = "CodPlan";
            DropDownListPlan.DataBind();
        }

        public void CargarCarrera()
        {
            tablaCarrera.Columns.Clear();
            tablaCarrera.Rows.Clear();
            tablaCarrera.Columns.Add("CodCarrera");
            tablaCarrera.Columns.Add("Carrera");
            tablaCarrera.Columns.Add("CodSede");

            StreamReader leer2 = new StreamReader(Server.MapPath("~/txt/Carrera.txt"));

            while (!leer2.EndOfStream)
            {
                string linea = leer2.ReadLine();
                string[] aux = linea.Split(',');
                if (DropDownListSede.SelectedValue == aux[2])      //ojo  enlazado al condicional
                {
                    tablaCarrera.Rows.Add(aux);
                }
            }

            leer2.Close();
            DropDownListCarrera.DataSource = tablaCarrera;
            DropDownListCarrera.DataTextField = "Carrera";
            DropDownListCarrera.DataValueField = "CodCarrera";
            DropDownListCarrera.DataBind();
        }

        public void CargarSede()
        {
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
            string pais = "[" + DropDownListPais.SelectedValue + "]" + DropDownListPais.SelectedItem.Text;

            string genero = "[" + DropDownListGenero.SelectedValue + "]" + DropDownListGenero.SelectedItem.Text;
            string estadoCivil = "[" + DropDownListEstadoCivil.SelectedValue + "]" + DropDownListEstadoCivil.SelectedItem.Text;
            string residencia = TextBoxDireccion.Text;

            string departamento = "[" + DropDownListDepto.SelectedValue + "]" + DropDownListDepto.SelectedItem.Text;
            string municipio = "[" + DropDownListMunicipio.SelectedValue + "]" + DropDownListMunicipio.SelectedItem.Text;
            string tel = TextBoxTel.Text;

            string mail = TextBoxEmail.Text;
            string emergName = TextBoxEmergName.Text;
            string emergTel = TextBoxEmergTel.Text;

            string sesde = "[" + DropDownListSede.SelectedValue + "]" + DropDownListSede.SelectedItem.Text;
            string carrera = "[" + DropDownListCarrera.SelectedValue + "]" + DropDownListCarrera.SelectedItem.Text;
            string plan = "[" + DropDownListPlan.SelectedValue + "]" + DropDownListPlan.SelectedItem.Text;

            string titulo = TextBoxTitulo.Text;
            string tituloFecha = TextBoxTituloFecha.Text;
            string institucion = TextBoxInstitucion.Text;

            if (
                (nombre1 != "" &&
                apellido1 != "" &&
                cui != "" &&
                nacimiento != "" &&
                pais != "" &&
                genero != "" &&
                estadoCivil != "" &&
                residencia != "" &&
                departamento != "" &&
                municipio != "" &&
                tel != "" &&
                mail != "" &&
                emergName != "" &&
                emergTel != "" &&
                sesde != "" &&
                carrera != "" &&
                plan != "" &&
                titulo != "" &&
                tituloFecha != "" &&
                institucion != "")
                )
            {
                //agregando la linea con los nuevos datos
                string linea = $"{nombre1}," +
                    $"{nombre2}," +
                    $"{nombreN}," +
                    $"{apellido1}," +
                    $"{apellido2}," +
                    $"{apellidoN}," +
                    $"{cui}," +
                    $"{nacimiento}," +
                    $"{pais}," +
                    $"{genero}," +
                    $"{estadoCivil}," +
                    $"{residencia}," +
                    $"{departamento}," +
                    $"{municipio}," +
                    $"{tel}," +
                    $"{mail}," +
                    $"{emergName}," +
                    $"{emergTel}," +
                    $"{sesde}," +
                    $"{carrera}," +
                    $"{plan}," +
                    $"{titulo}," +
                    $"{tituloFecha}," +
                    $"{institucion}";

                // Guardar en el archivo de texto
                string path = Server.MapPath("~/txt/Inscripciones2.txt");
                using (StreamWriter escribir = new StreamWriter(path, true))
                {
                    escribir.WriteLine(linea);
                }

                Response.Write("<script language=javascript>alert('Se ha ingresado el cliente exitosamente')</script>");
            }

            else
            {
                Response.Write("<script language=javascript>alert('Algunos campos están vacíos')</script>");
            }
        }

        protected void DropDownListPais_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            CargarCarrera();
        }

        protected void DropDownListCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPlan();

            //if (DropDownListPlan.Items.Count == 1)
            //{
            //    // Establece el texto del TextBox con el primer elemento del DropDownList
            //    DropDownListPlan.SelectedValue = DropDownListPlan.Items[0].Text;                //OJO REVISAR
            //}
        }
    }
}