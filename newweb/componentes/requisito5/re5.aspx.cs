using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newweb.componentes.requisito5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BulletedList1_Click(object sender, BulletedListEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonAprobado_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void ButtonRechazado_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        public class conexion
        {
            string servidor;
            string puerto;
            string usuario;
            string password;
            string db;
            MySqlConnection conBD;
            bool estado;

            public conexion(string servidor, string puerto, string usuario, string password, string db)
            {
                this.servidor = servidor;
                this.puerto = puerto;
                this.usuario = usuario;
                this.password = password;
                this.db = db;
            }
            public string cadenaConexion()
            {
                string cadena = "server=" + servidor + "; port=" + puerto + "; user id=" + usuario + "; password=" + password + "; database=" + db + ";";
                return cadena;
            }
            public MySqlConnection crearConexion()
            {
                conBD = new MySqlConnection(cadenaConexion());

                try
                {
                    conBD.Open();
                    estado = true;
                    return conBD;
                }
                catch (Exception ex)
                {
                    return conBD;
                }
            }

            public void cerrarConexion()
            {
                conBD.Close();
            }


            public void Llenar_Lista()
            {

                conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
                MySqlCommand comm = con.crearConexion().CreateCommand();
                comm.CommandText = "SELECT * FROM Archivos";

                con.cerrarConexion();

            }

        }
    }
}
