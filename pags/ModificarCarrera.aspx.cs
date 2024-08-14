﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pmLOGIN.pags
{
    public partial class ModificarCarrera : System.Web.UI.Page
    {
        DataTable tablaProducto = new DataTable();
        DataTable tablaCarrera = new DataTable();
        private string txtCodigo;
        private string txtProducto;
        private bool btnEditF, btnEditT;
        private bool btnElimF, btnElimT;
        string rutaArchivo = "~/txt/Carrera.txt";      //cambiar a txt carrera
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Username"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}

            //txtAstr();
            tablaCarrera.Columns.Add("CODIGO");
            tablaCarrera.Columns.Add("DATO");

            //?
            tablaCarrera.Columns.Add("CODIGO_SEDE");

            if (!IsPostBack)
            {
                btnOff();
                CargarSede();
            }
            else
            {
                txtAstr();
            }

            StreamReader leer = new StreamReader(Server.MapPath(rutaArchivo));

            //definiendo columnas de separacion de TIPOS DE datos ingresados
            while (!leer.EndOfStream)
            {
                string linea = leer.ReadLine();
                string[] aux = linea.Split(',');
                tablaCarrera.Rows.Add(aux);
            }
            leer.Close();
            GridView1.DataSource = tablaCarrera;
            GridView1.DataBind();
        }

        public void CargarSede()
        {
            tablaProducto.Columns.Add("Codigo");
            tablaProducto.Columns.Add("Sede");
            StreamReader leer = new StreamReader(Server.MapPath("~/txt/Sede1.txt"));

            while (!leer.EndOfStream)
            {
                string linea = leer.ReadLine();
                string[] aux = linea.Split(',');

                // Concatenar Código y Sede en una sola cadena para mostrarla en el DropDownList
                string codigoYSede = "[" + aux[0] + "] " + aux[1];

                tablaProducto.Rows.Add(aux[0], codigoYSede);
            }

            leer.Close();
            DropDownListAddSedeCarrera.DataSource = tablaProducto;
            DropDownListAddSedeCarrera.DataTextField = "Sede";
            DropDownListAddSedeCarrera.DataValueField = "Codigo";
            DropDownListAddSedeCarrera.DataBind();
        }
        public void limpiar()
        {
            //txtAstr();
            TextBoxCodigo.Text = "";
            TextBoxProducto.Text = "";
            btnOff();
        }
        public void btnOff()
        {
            //btnElimT = btnELIMINAR.Enabled = true;
            btnElimF = btnELIMINAR.Enabled = false;
            //btnEditT = btnEDITAR.Enabled = true;
            btnEditF = btnEDITAR.Enabled = false;
        }

        protected void btnGUARDAR_Click(object sender, EventArgs e)
        {
            txtAstr();
            string dropSedeCarrera = DropDownListAddSedeCarrera.SelectedValue;

            if ((txtCodigo != "") &&
                (txtProducto != "") &&
                (dropSedeCarrera != "") )
            {

                //rectificando si no hay codigos repetidos
                bool codDuplicado = false;
                foreach (DataRow fila in tablaCarrera.Rows)
                {
                    if (fila[0].ToString() == txtCodigo)
                    {
                        codDuplicado = true;
                        break;
                    }
                }

                if (codDuplicado)
                {
                    Response.Write("<script language=javascript>alert('Una sede con este CODIGO ya ha sido registrado. Intente con otro CODIGO.')</script>");
                    limpiar();
                }

                else
                {
                    tablaCarrera.Rows.Add(txtCodigo, txtProducto, dropSedeCarrera);
                    //agrega los datos al grid
                    GridView1.DataBind();

                    //agregar datos al archivo txt
                    string linea = txtCodigo + "," + txtProducto + "," + dropSedeCarrera;
                    StreamWriter escribir = new StreamWriter(Server.MapPath(rutaArchivo), true);
                    escribir.WriteLine(linea);
                    escribir.Close();
                    Response.Write("<script language=javascript>alert('Se ha ingresado el dato exitosamente')</script>");
                    limpiar();
                }
            }

            else
            {
                Response.Write("<script language=javascript>alert('Algunos campos están vacíos')</script>");
            }
        }

        protected void btnEDITAR_Click(object sender, EventArgs e)
        {
            if (
                (txtCodigo == "") ||
                (txtProducto == ""))
            {
                Response.Write("<script language=javascript>alert('Todos los campos deben estar llenos')</script>");
                return; // Salir del método si algún campo está vacío
            }

            string filePath = Server.MapPath(rutaArchivo);

            if (File.Exists(filePath))
            {
                // Leer todas las líneas del archivo
                string[] lineas = File.ReadAllLines(filePath);
                bool prodEncontrado = false;

                for (int i = 0; i < lineas.Length; i++)
                {
                    string[] campos = lineas[i].Split(',');

                    if (campos[0] == txtCodigo)
                    {
                        // Actualizar los campos en la línea
                        lineas[i] = txtCodigo + "," +
                            txtProducto;
                        prodEncontrado = true;
                        GridView1.DataBind();
                        break;
                    }
                }

                if (prodEncontrado)
                {
                    // Escribir las líneas actualizadas de nuevo en el archivo
                    File.WriteAllLines(filePath, lineas);
                    Response.Write("<script language=javascript>alert('Información actualizada exitosamente')</script>");
                    limpiar();
                }
                else
                {
                    Response.Write("<script language=javascript>alert('No se encontraron elementos con el código especificado')</script>");
                }
            }
            else
            {
                // Manejo del caso cuando el archivo no existe
                Response.Write("<script language=javascript>alert('El archivo de datos no existe')</script>");
            }
        }

        protected void btnELIMINAR_Click(object sender, EventArgs e)
        {
            string filePath = Server.MapPath(rutaArchivo);

            if (File.Exists(filePath))
            {
                // Leer todas las líneas del archivo
                string[] lineas = File.ReadAllLines(filePath);
                List<string> nuevasLineas = new List<string>();
                bool prodEncontrado = false;

                foreach (string linea in lineas)
                {
                    string[] campos = linea.Split(',');

                    if (campos[0] == txtCodigo)
                    {
                        prodEncontrado = true;
                        // No agregar esta línea a las nuevas líneas, es decir, se elimina
                    }
                    else
                    {
                        nuevasLineas.Add(linea);

                    }
                }

                if (prodEncontrado)
                {
                    // Escribir las nuevas líneas (sin la línea eliminada) de nuevo en el archivo
                    File.WriteAllLines(filePath, nuevasLineas.ToArray());
                    Response.Write("<script language=javascript>alert('Dato eliminado exitosamente')</script>");
                    limpiar();
                }
                else
                {
                    Response.Write("<script language=javascript>alert('No se encontraron datos con el código especificado')</script>");
                }
            }
            else
            {
                // Manejo del caso cuando el archivo no existe
                Response.Write("<script language=javascript>alert('El archivo de datos no existe')</script>");
            }
        }

        protected void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            TextBoxCodigo.Text = "";
            TextBoxProducto.Text = "";

            btnOff();
        }

        protected void ButtonINGnuevo0_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            // Redirigir al login o página principal
            Response.Redirect("Login.aspx");
        }

        public void txtAstr()
        {
            txtCodigo = TextBoxCodigo.Text;
            txtProducto = TextBoxProducto.Text;

        }
        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            CargarSede();
            bool encontrado = false;
            string filePath = Server.MapPath(rutaArchivo);
            if (File.Exists(filePath))
            {
                // Leer todas las líneas del archivo
                string[] lineas = File.ReadAllLines(filePath);

                foreach (string linea in lineas)
                {
                    string[] campos = linea.Split(',');

                    if (campos[0] == TextBoxBuscar.Text)
                    {
                        txtCodigo = campos[0];
                        txtProducto = campos[1];
                        

                        encontrado = true;
                        break;
                    }
                }

                // Habilitar editar y eliminar
                if (encontrado)
                {
                    btnEDITAR.Enabled = true;
                    btnELIMINAR.Enabled = true;

                    // muestra los datos correspondientes
                    TextBoxCodigo.Text = txtCodigo;
                    TextBoxProducto.Text = txtProducto;
                    

                }
                else
                {
                    Response.Write("<script language=javascript>alert('No existen datos con el CODIGO especificado')</script>");
                    btnOff();
                }

                TextBoxBuscar.Text = "";
            }
            else
            {
                // Manejo del caso cuando el archivo no existe
                Response.Write("<script language=javascript>alert('El archivo de datos no existe')</script>");
            }
        }


    }
}