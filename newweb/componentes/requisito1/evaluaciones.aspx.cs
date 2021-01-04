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
            cargarTabla();
        }
        public void cargarTabla()
        {
            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            string llamado = con.crearConexion();

            myList = con.evaluacionesPendientes();
            con.cerrarConexion();
        }
    }
}