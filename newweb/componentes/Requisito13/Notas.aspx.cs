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
            public List<string> conocerRol(int idPersona)
            {
                List<string> datos = new List<string> { };
                if (estado)
                {
                    string rol = "";
                    int idRol = -1;

                    MySqlCommand comm = conBD.CreateCommand();
                    comm.CommandText = "Select * from Administrador where Persona_FK = @persona";
                    comm.Parameters.AddWithValue("@persona", idPersona);

                    MySqlDataReader myReader;
                    myReader = comm.ExecuteReader();

                    while (myReader.Read())
                    {
                        rol = "Administrador";
                        idRol = myReader.GetInt32(0);
                        break;
                    }
                    myReader.Close();
                    if (idRol != -1)
                    {
                        datos.Add(rol);
                        datos.Add(idRol.ToString());
                        return datos;
                    }
                    else
                    {
                        comm = conBD.CreateCommand();
                        comm.CommandText = "Select * from Alumnos where Persona_FK = @persona";
                        comm.Parameters.AddWithValue("@persona", idPersona);
                        myReader = comm.ExecuteReader();

                        while (myReader.Read())
                        {
                            rol = "Alumnos";
                            idRol = myReader.GetInt32(0);
                            break;
                        }
                        myReader.Close();
                        if (idRol != -1)
                        {
                            datos.Add(rol);
                            datos.Add(idRol.ToString());
                            return datos;
                        }
                        else
                        {
                            comm = conBD.CreateCommand();
                            comm.CommandText = "Select * from Apoderado where Persona_FK = @persona";
                            comm.Parameters.AddWithValue("@persona", idPersona);
                            myReader = comm.ExecuteReader();

                            while (myReader.Read())
                            {
                                rol = "Apoderado";
                                idRol = myReader.GetInt32(0);
                                break;
                            }
                            myReader.Close();
                            if (idRol != -1)
                            {
                                datos.Add(rol);
                                datos.Add(idRol.ToString());
                                return datos;
                            }
                            else
                            {
                                comm = conBD.CreateCommand();
                                comm.CommandText = "Select * from Director where Persona_FK = @persona";
                                comm.Parameters.AddWithValue("@persona", idPersona);
                                myReader = comm.ExecuteReader();

                                while (myReader.Read())
                                {
                                    rol = "Director";
                                    idRol = myReader.GetInt32(0);
                                    break;
                                }
                                myReader.Close();
                                if (idRol != -1)
                                {
                                    datos.Add(rol);
                                    datos.Add(idRol.ToString());
                                    return datos;
                                }
                                else
                                {
                                    comm = conBD.CreateCommand();
                                    comm.CommandText = "Select * from Profesor where Persona_FK = @persona";
                                    comm.Parameters.AddWithValue("@persona", idPersona);
                                    myReader = comm.ExecuteReader();

                                    while (myReader.Read())
                                    {
                                        rol = "Profesor";
                                        idRol = myReader.GetInt32(0);
                                        break;
                                    }
                                    myReader.Close();
                                    if (idRol != -1)
                                    {
                                        datos.Add(rol);
                                        datos.Add(idRol.ToString());
                                        return datos;
                                    }
                                    else
                                    {
                                        comm = conBD.CreateCommand();
                                        comm.CommandText = "Select * from Secretario where Persona_FK = @persona";
                                        comm.Parameters.AddWithValue("@persona", idPersona);
                                        myReader = comm.ExecuteReader();

                                        while (myReader.Read())
                                        {
                                            rol = "Secretario";
                                            idRol = myReader.GetInt32(0);
                                            break;
                                        }
                                        myReader.Close();
                                        if (idRol != -1)
                                        {
                                            datos.Add(rol);
                                            datos.Add(idRol.ToString());
                                            return datos;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return datos;
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
                        comm.Parameters.AddWithValue("@rut", rut);

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
        }
        public List<List<string>> myList = new List<List<string>>();
        public List<List<string>> myList2 = new List<List<string>>();
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
        public Dictionary<string, int> idAsignatura2(int rolID)
        {
            Dictionary<string, int> asignaturas = new Dictionary<string, int>();

            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            MySqlCommand comm = con.crearConexion().CreateCommand();
            comm.CommandText = "SELECT Asignaturas.Nombre, Asignaturas.ID FROM Asignaturas_Alumnos INNER JOIN Asignaturas ON Asignaturas.ID = Asignaturas_Alumnos.Asignatura_FK WHERE Asignaturas_Alumnos.Alumnos_FK = @idAlumno";
            comm.Parameters.AddWithValue("idAlumno", rolID);
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
        public int idAsignaturas_Alumnos2(int idAsignatura, int rolID)
        {
            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            MySqlCommand comm = con.crearConexion().CreateCommand();
            comm.CommandText = "SELECT * FROM Asignaturas_Alumnos WHERE Asignatura_FK = @idAsignatura  AND Alumnos_FK = @idAlumno";
            comm.Parameters.AddWithValue("idAlumno", rolID);
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
        public List<List<string>> notas2(Dictionary<string, int> asignaturas, int rolID)
        {
            List<List<string>> myList2 = new List<List<string>>();
            foreach (var a in asignaturas)
            {
                int idAsignaturaAlumnos = idAsignaturas_Alumnos2(a.Value, rolID);
                if (idAsignaturaAlumnos != -1)
                {
                    conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
                    MySqlCommand comm = con.crearConexion().CreateCommand();
                    comm.CommandText = "SELECT Nombre, Ponderacion, Nota FROM Notas WHERE Asignaturas_Alumnos_FK = @ID";
                    comm.Parameters.AddWithValue("@ID", idAsignaturaAlumnos);
                    MySqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        myList2.Add(new List<string> { a.Key, reader.GetString(0), reader.GetFloat(1).ToString(), reader.GetFloat(2).ToString() });
                    }
                    reader.Close();
                    con.cerrarConexion();
                }
            }
            return myList2;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            con.crearConexion();
            int ID = con.idUsuario(TextBox1.Text);

            con.cerrarConexion();
            con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            con.crearConexion();

            List<string> persona = con.conocerRol(ID);
            
            if(persona.Count > 0)
            {
                Dictionary<string, int> asignaturas = idAsignatura2(Int32.Parse(persona[1]));
                myList2 = notas2(asignaturas, Int32.Parse(persona[1]));
            }
            con.cerrarConexion();
        }
    }
}