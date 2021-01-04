using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newweb.componentes.requisito1
{
    public partial class evaluaciones : System.Web.UI.Page
    {
        public List<List<string>> myList = new List<List<string>>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (control.Control.estadoConexion == 0)
            {
                Response.Redirect("/componentes/requisito1/login.aspx");
            }
            cargarTabla();
        }
        public void cargarTabla()
        {
            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            string llamado = con.crearConexion();

            myList = con.evaluacionesPendientes();
            con.cerrarConexion();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}