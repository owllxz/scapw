using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using newweb.componentes.requisito1;

namespace newweb.componentes.Requisito13
{
    public partial class Notas : System.Web.UI.Page
    {
        MySqlConnection conBD;
        protected void Page_Load(object sender, EventArgs e)
        {
            string asignatura = "Lenguaje";
            Text1.Text = asignatura;
            Alumno.Text = "Javier Alonso Soto Letelier";
            Asignatura.Text = "Lenguaje";
            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            int cantidad = 5;
            for (int i = 0 ; i < cantidad; i++)
            {
                DropDownList1.Items.Add("hola");
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Holaa")
            {
                Text1.Text = "prueba42423";
                Alumno.Text = "Pruebaaa3242";
                Asignatura.Text = "Lenguaje111111";
            }
            if (DropDownList1.SelectedValue == "Hola31231a")
            {
                Text1.Text = "prueba123";
                Alumno.Text = "Pruebaaa123123";
                Asignatura.Text = "Lenguaje22222";
            }
            if (DropDownList1.SelectedValue == "Hola22a")
            {
                Text1.Text = "prueba123123";
                Alumno.Text = "Pruebaaa3243242";
                Asignatura.Text = "Lenguaje333333";
            }

        }
    }
}