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
                catch (Exception)
                {
                    return conBD;
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
        public List<List<string>> myList = new List<List<string>>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (control.Control.estadoConexion == 0)
            {
                Response.Redirect("/componentes/requisito1/login.aspx");
            }
            Alumno.Text = "Correo:" + control.Control.email;
            Dictionary<string, int> asignaturas = idAsignatura();

            Consulta(asignaturas.Count());
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void Consulta(int cantidadAsignaturas)
        {
            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            MySqlCommand comm = con.crearConexion().CreateCommand();
            comm.CommandText = "SELECT Asignaturas.Nombre FROM Asignaturas_Alumnos INNER JOIN Asignaturas ON Asignaturas.ID = Asignaturas_Alumnos.Asignatura_FK WHERE Asignaturas_Alumnos.Alumnos_FK = @idAlumno";
            comm.Parameters.AddWithValue("idAlumno", control.Control.rolID);
            MySqlDataReader reader = comm.ExecuteReader();
            DropDownList1.DataSource =  reader;
            int e = 0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if(DropDownList1.Items.Count == cantidadAsignaturas )
                    {
                        DropDownList1.Items.RemoveAt(e);
                    }
                    DropDownList1.Items.Insert(e,reader.GetString(0));

                }
            }
            reader.Close();
            con.cerrarConexion();
        }
        public Dictionary<string, int> idAsignatura()
        {
            Dictionary<string, int> asignaturas = new Dictionary<string, int>();

            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            MySqlCommand comm = con.crearConexion().CreateCommand();
            comm.CommandText = "SELECT Asignaturas.Nombre, Asignaturas.ID FROM Asignaturas_Alumnos INNER JOIN Asignaturas ON Asignaturas.ID = Asignaturas_Alumnos.Asignatura_FK WHERE Asignaturas_Alumnos.Alumnos_FK = @idAlumno";
            comm.Parameters.AddWithValue("idAlumno", control.Control.rolID);
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                asignaturas.Add(reader.GetString(0), reader.GetInt32(1));
            }
            reader.Close();
            con.cerrarConexion();
            return asignaturas;
        }
        //SELECT * FROM Asignaturas_Alumnos WHERE Asignatura_FK = 2 AND Alumnos_FK = 2
        public int idAsignaturas_Alumnos(int idAsignatura)
        {
            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            MySqlCommand comm = con.crearConexion().CreateCommand();
            comm.CommandText = "SELECT * FROM Asignaturas_Alumnos WHERE Asignatura_FK = @idAsignatura  AND Alumnos_FK = @idAlumno";
            comm.Parameters.AddWithValue("idAlumno", control.Control.rolID);
            comm.Parameters.AddWithValue("idAsignatura", idAsignatura);
            MySqlDataReader reader = comm.ExecuteReader();
            int idAsignaturaA = -1;
            while (reader.Read())
            {
                idAsignaturaA = reader.GetInt32(0);
                break;
            }
            reader.Close();
            con.cerrarConexion();
            return idAsignaturaA;
        }
        public List<List<string>> notas(int ID)
        {
            List<List<string>> myList = new List<List<string>>();

            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            MySqlCommand comm = con.crearConexion().CreateCommand();
            comm.CommandText = "SELECT Nombre, Ponderacion, Nota FROM Notas WHERE Asignaturas_Alumnos_FK = @ID";
            comm.Parameters.AddWithValue("@ID", ID);
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                myList.Add(new List<string> { reader.GetString(0), reader.GetFloat(1).ToString(), reader.GetFloat(2).ToString() });
            }
            reader.Close();
            con.cerrarConexion();
            return myList;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Asignatura.Text = DropDownList1.SelectedItem.Text;
            Dictionary<string, int> asignaturas = idAsignatura();
            int idAsignaturaAlumnos = 0;
            foreach (var a in asignaturas)
            {
                if (a.Key == DropDownList1.SelectedItem.Text)
                {
                    idAsignaturaAlumnos = idAsignaturas_Alumnos(a.Value);
                    break;
                }
            }
            if (idAsignaturaAlumnos != -1)
            {
                int IDaA = idAsignaturaAlumnos;
                myList = notas(IDaA);
            }
        }
    }
}