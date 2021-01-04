using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newweb.componentes.requisito11
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (control.Control.estadoConexion == 0)
            {
                Response.Redirect("/componentes/requisito1/login.aspx");
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}