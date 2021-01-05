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
                catch (Exception)
                {
                    return conBD;
                }
            }
            public void cerrarConexion()
            {
                conBD.Close();
            }
            public int idUsuario(string rut)
            {
                if (estado)
                {
                    try
                    {
                        int usuario = -1;
                        MySqlCommand comm = conBD.CreateCommand();
                        comm.CommandText = "Select * from Persona where Rut = @rut";
                        comm.Parameters.AddWithValue("rut", rut);

                        MySqlDataReader myReader = comm.ExecuteReader();

                        while (myReader.Read())
                        {
                            usuario = myReader.GetInt32(0);
                        }
                        return usuario;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            public List<string> horarios(int ID)
            {
                List<string> horario = new List<string>();
                if (estado)
                {
                    try
                    {
                        MySqlCommand comm = conBD.CreateCommand();
                        comm.CommandText = "SELECT Horario.Archivo FROM Persona_Horario JOIN Horario ON Horario.ID = Persona_Horario.Horario_FK WHERE Persona_Horario.Persona_FK = @ID";
                        comm.Parameters.AddWithValue("ID", ID);

                        MySqlDataReader myReader = comm.ExecuteReader();

                        while (myReader.Read())
                        {
                            horario.Add(myReader.GetString(0));
                        }
                        return horario;
                    }
                    catch (Exception)
                    {
                        return horario;
                    }
                }
                return horario;
            }
        }
        public List<string> horario = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (control.Control.estadoConexion == 0)
            {
                Response.Redirect("/componentes/requisito1/login.aspx");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            con.crearConexion();

            int usuario = con.idUsuario(TextBox1.Text);

            con.cerrarConexion();

            con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            con.crearConexion();

            horario = con.horarios(usuario);

            con.cerrarConexion();
            
        }
    }
       
}