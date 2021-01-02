using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newweb.componentes.requisito1
{
    public partial class roles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            string llamado = con.crearConexion();

            llamado = con.ConsultaPersonasSinRol();

            Label1.Text = "";

            string[] equationTokens = llamado.Split(new char[1] { '/' });

            foreach (string Tok in equationTokens)
                Label1.Text += Tok + "--";
        }
    }
}