using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using newweb.componentes.requisito1;
using System.Data.SqlClient;

namespace newweb.componentes.Requisito13
{
    public partial class Notas : System.Web.UI.Page
    {
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
            public int obtenerIDAsignatura(string asignatura)
            {
                if (estado)
                {
                    MySqlCommand comm = conBD.CreateCommand();
                    comm.CommandText = "Select * from Asignaturas where Nombre = @asignatura";
                    comm.Parameters.AddWithValue("@asignatura", asignatura);

                    MySqlDataReader myReader;
                    myReader = comm.ExecuteReader();

                    while (myReader.Read())
                    {
                        int a = myReader.GetInt32(0);
                        myReader.Close();
                        return a;
                        break;
                    }
                    return -1;
                }
                else
                {
                    return -1;
                }
            }
            public string crearArchivo(string url, int a_fk, int p_fk)
            {
                if (estado)
                {
                    try
                    {
                        MySqlCommand comm = conBD.CreateCommand();
                        comm.CommandText = "Insert INTO Archivos(Archivo, Asignatura_FK,Profesor_FK) VALUES(@Url, @a_fk, @p_fk)";
                        comm.Parameters.AddWithValue("@Url", url);
                        comm.Parameters.AddWithValue("@a_fk", a_fk);
                        comm.Parameters.AddWithValue("@p_fk", p_fk);
                        comm.ExecuteNonQuery();
                        return "Usuario creado correctamente";
                    }
                    catch (Exception ex)
                    {
                        return ex.ToString();
                    }
                }
                else
                {
                    return "La conexion no esta abierta";
                }
            }
            public void cerrarConexion()
            {
                conBD.Close();
            }
        }
        MySqlConnection conBD;
        protected void Page_Load(object sender, EventArgs e)
        {
            string asignatura = "Lenguaje";
            Text1.Text = asignatura;
            Alumno.Text = "Javier Alonso Soto Letelier";
            Asignatura.Text = "Lenguaje";
            MySqlDataReader datos ;
            datos = Consulta();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Holaa")
            {
                

            }

        }
        public MySqlDataReader Consulta()
        {
            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            MySqlCommand comm = con.crearConexion().CreateCommand();
            comm.CommandText = "SELECT Nombres FROM Persona";
            MySqlDataReader reader = comm.ExecuteReader();
            DropDownList1.DataSource =  reader;
            int e = 0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if(DropDownList1.Items.Count == 5 )
                    {
                        DropDownList1.Items.RemoveAt(e);
                    }
                    DropDownList1.Items.Insert(e,reader.GetString(0));

                }
            }
            reader.Close();


            return reader;

        }
    }
}