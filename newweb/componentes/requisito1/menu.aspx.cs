using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newweb.componentes.requisito1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<string> myList = new List<string> { };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (control.Control.estadoConexion == 0)
            {
                Response.Redirect("/componentes/requisito1/login.aspx");
            }
            myList.Add(control.Control.email);
            myList.Add(control.Control.ID.ToString());
            myList.Add(control.Control.rol);
            myList.Add(control.Control.rolID.ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/componentes/requisito1/requisito2.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/componentes/Req_4/Req_4.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("/componentes/requisito5/re5.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("/componentes/requisito1/evaluaciones.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("/componentes/requisito12/re12.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("/componentes/requisito13/Notas.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {

        }
    }
}