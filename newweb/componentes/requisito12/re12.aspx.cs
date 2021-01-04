using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace newweb.componentes.requisito12
{
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        public class conexion
    {
        public static DataSet ds;
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
    }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Image1.Visible = true;
        }

        protected void rolgrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            MySqlCommand comm = con.crearConexion().CreateCommand();


            if (rolgrupo.SelectedItem.Text == "curso 1")
            {
                string imagenHorario = "https://www.camifel.cl/scap/CLASE1.jpg";
                Image1.ImageUrl = imagenHorario;
                con.cerrarConexion();
            }
            else
            {
                string imagenHorario = "https://www.camifel.cl/scap/CLASE2.jpg";
                Image1.ImageUrl = imagenHorario;
                con.cerrarConexion();
            }
            

        }
    }
       
}