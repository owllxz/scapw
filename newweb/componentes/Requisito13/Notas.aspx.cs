using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            string asignatura = "Lenguaje";
            Alumno.Text = "Javier Alonso Soto Letelier";
            Asignatura.Text = asignatura;
            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            Console.WriteLine("fsdfdsfsfs");


        }
    }
}