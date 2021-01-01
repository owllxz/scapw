using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newweb.componentes.Req_4
{
    public partial class Req_4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            String Nombre_profesor = "";
            String Semestre = "";
            String Password_profesor = "";
            String Materia = "";
            String Curso = "";
            String Nombre_Syllabus = "";

            if (Nombre_profesor != null && Semestre != null && Password_profesor != null && Materia != null && Curso != null && Nombre_Syllabus != null)
            {
                Nombre_profesor = Text_NombreProfe.ToString();
                Semestre = Text_Semestre.ToString();
                Password_profesor = Password_profe.ToString();
                Materia = Text_Materia.ToString();
                Curso = Text_Curso.ToString();
                Nombre_Syllabus = Text_NombreSyllabus.ToString();
            }
            else { 
                
            
            }

            //Enviar variables a la base de datos
        }
    }
}