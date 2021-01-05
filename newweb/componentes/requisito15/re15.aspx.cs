using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Text;


namespace newweb.componentes.requisito15
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
        public string crearUsuario(string Nombres, string Apellidos, string Rut, string Direccion, string Correo, string Password)
        {
            if (estado)
            {
                try
                {
                    MySqlCommand comm = conBD.CreateCommand();
                    comm.CommandText = "Insert INTO Persona(Nombres,Apellidos,Rut,Direccion,Correo,Password) VALUES(@Nombres, @Apellidos, @Rut, @Direccion, @Correo, @Password)";
                    comm.Parameters.AddWithValue("@Nombres", Nombres);
                    comm.Parameters.AddWithValue("@Apellidos", Apellidos);
                    comm.Parameters.AddWithValue("@Rut", Rut);
                    comm.Parameters.AddWithValue("@Direccion", Direccion);
                    comm.Parameters.AddWithValue("@Correo", Correo);
                    comm.Parameters.AddWithValue("@Password", Password);
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
        public List<int> estudiantes(int ID)
        {
            List<int> est = new List<int>();
            if (estado)
            {
                MySqlCommand comm = conBD.CreateCommand();
                comm.CommandText = "Select * from Asignaturas_Alumnos where Asignatura_FK = @ID";
                comm.Parameters.AddWithValue("@ID", ID);

                MySqlDataReader myReader;
                myReader = comm.ExecuteReader();

                while (myReader.Read())
                {
                   est.Add(myReader.GetInt32(2));
                }
            }
            return est;
        }
        public List<int> personas(List<int> est)
        {
            List<int> personasIDs = new List<int>();

            if (estado)
            {
                foreach(int ID in est)
                {
                    MySqlCommand comm = conBD.CreateCommand();
                    comm.CommandText = "Select * from Alumnos where ID = @ID";
                    comm.Parameters.AddWithValue("@ID", ID);

                    MySqlDataReader myReader;
                    myReader = comm.ExecuteReader();

                    while (myReader.Read())
                    {
                        personasIDs.Add(myReader.GetInt32(1));
                        break;
                    }
                    myReader.Close();
                }
            }

            return personasIDs;
        }
        public string Persona(int ID)
        {
            string persona = "";
            if (estado)
            {
                try
                {
                    MySqlCommand comm = conBD.CreateCommand();
                    comm.CommandText = "Select * from Persona where ID = @ID";
                    comm.Parameters.AddWithValue("@ID", ID);

                    MySqlDataReader myReader;
                    myReader = comm.ExecuteReader();

                    while (myReader.Read())
                    {
                        persona = myReader.GetString(1) + " " + myReader.GetString(2) + " - " + myReader.GetString(3);
                        break;
                    }
                }
                catch(Exception ex)
                {
                    return ex.ToString();
                }
            }
            return persona;
        }
        public int crearAsistencia(int asignatura)
        {
            int idAsistencia = -1;
            if (estado)
            {
                try
                {
                    DateTime theDate = DateTime.Now;
                    string date = theDate.ToString("yyyy-MM-dd H:mm:ss");

                    DateTime fecha = Convert.ToDateTime(date);

                    MySqlCommand comm = conBD.CreateCommand();
                    comm.CommandText = "Insert INTO Asistencia(Fecha, Asignaturas_FK) VALUES(@fecha, @asignatura)";
                    comm.Parameters.AddWithValue("@fecha", fecha);
                    comm.Parameters.AddWithValue("@asignatura", asignatura);
                    comm.ExecuteNonQuery();

                    comm = conBD.CreateCommand();
                    comm.CommandText = "Select * from Asistencia WHERE Fecha = @fecha";
                    comm.Parameters.AddWithValue("@fecha", fecha);

                    MySqlDataReader myReader;
                    myReader = comm.ExecuteReader();

                    while (myReader.Read())
                    {
                        idAsistencia = myReader.GetInt32(0);
                        break;
                    }
                    return idAsistencia;
                }
                catch (Exception)
                {
                    return idAsistencia;
                }
            }
            return idAsistencia;
        }
        public string crearAsistencia_Alumnos(int asistencia, int alumnos, int estadoa)
        {
            string a = "";
            if (estado)
            {
                try
                {
                    MySqlCommand comm = conBD.CreateCommand();
                    comm.CommandText = "Insert INTO Asistencia_Alumnos(Asistencia_FK, Alumnos_FK, estado) VALUES(@asistencia, @alumnos, @estadoa)";
                    comm.Parameters.AddWithValue("@asistencia", asistencia);
                    comm.Parameters.AddWithValue("alumnos", alumnos);
                    comm.Parameters.AddWithValue("@estadoa", estadoa);
                    comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            return a;
        }
    }
    public partial class re15 : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (control.Control.estadoConexion == 0)
            {
                Response.Redirect("/componentes/requisito1/login.aspx");
            }
            if (!IsPostBack)
            {
                Llenar_Lista();
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Lista_Materias.SelectedItem != null)
            {
                int indice = Lista_Materias.SelectedIndex;
                string nombre_asignatura = Lista_Materias.SelectedItem.Text;

                conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
                con.crearConexion();
                int ID = con.obtenerIDAsignatura(nombre_asignatura);
                con.crearConexion();

                con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
                con.crearConexion();

                List<int> estID = con.estudiantes(ID);

                con.cerrarConexion();

                con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
                con.crearConexion();
                List<int> perID = con.personas(estID);
                con.cerrarConexion();
                int contador = 0;
                CheckBoxList1.Items.Clear();
                foreach(int id in perID)
                {
                    con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
                    con.crearConexion();

                    string persona = con.Persona(id);

                    ListItem li1 = new ListItem(persona+ "(" + estID[contador].ToString() + ")", "", true);
                    li1.Selected = false;
                    CheckBoxList1.Items.Add(li1);
                    con.cerrarConexion();
                    contador ++;
                }
            }
        }
        public void Llenar_Lista()
        {
            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            MySqlCommand comm = con.crearConexion().CreateCommand();
            comm.CommandText = "SELECT * FROM Asignaturas";
            Lista_Materias.DataSource = comm.ExecuteReader();
            Lista_Materias.DataTextField = "Nombre";
            Lista_Materias.DataValueField = "ID";
            string id_asignatura = Lista_Materias.DataValueField;
            Lista_Materias.DataBind();
            con.cerrarConexion();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            con.crearConexion();
            if (Lista_Materias.SelectedItem != null)
            {
                int indice = Lista_Materias.SelectedIndex;
                string nombre_asignatura = Lista_Materias.SelectedItem.Text;
                int asignatura = con.obtenerIDAsignatura(nombre_asignatura);

                con.cerrarConexion();
                con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
                con.crearConexion();
                int idAsistencia = con.crearAsistencia(asignatura);
                con.cerrarConexion();

                Label4.Text = idAsistencia.ToString();

                if(idAsistencia != -1)
                {
                    foreach(ListItem li in CheckBoxList1.Items)
                    {
                        con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
                        con.crearConexion();

                        string[] equationTokens = li.Text.Split(new char[1] { '(' });

                        string idAlumno = "";
                        foreach (string Tok in equationTokens)
                        {
                            idAlumno = Tok;
                        }
                        idAlumno = idAlumno.Substring(0, idAlumno.Length - 1);
                        int ID = Int32.Parse(idAlumno);

                        int estadoa = 0;
                        if (li.Selected)
                        {
                            estadoa = 1;
                        }

                        Label4.Text = con.crearAsistencia_Alumnos(idAsistencia, ID, estadoa);

                        con.cerrarConexion();
                    }
                }
            }
        }
    }
}