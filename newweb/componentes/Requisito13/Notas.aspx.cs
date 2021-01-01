using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newweb.componentes.Requisito13
{
    public partial class Notas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string asignatura = "Lenguaje";
            Text1.Text = asignatura;
            Alumno.Text = "Javier Alonso Soto Letelier";
            Asignatura.Text = "Lenguaje";
            
        }
    }
}