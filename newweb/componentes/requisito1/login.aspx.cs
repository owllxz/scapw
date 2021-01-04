using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newweb.componentes.requisito1
{
    public class conexion
    {
        public static DataSet ds;
        public static DataSet dsS;
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
        public string crearConexion()
        {
            conBD = new MySqlConnection(cadenaConexion());

            try
            {
                conBD.Open();
                estado = true;
                return "Conexion exitosa";
            }
            catch (Exception ex)
            {
                return ex.ToString();
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
        public string decodificar(string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted =
            Convert.FromBase64String(_cadenaAdesencriptar);
            System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
        public string insertarRol(string rol, int personaID, int apoderadoID, int aingreso)
        {
            if (estado)
            {
                MySqlCommand comm = conBD.CreateCommand();
                comm.CommandText = "Select * from Persona where rol = 0 and ID = @id";
                comm.Parameters.AddWithValue("@id", personaID);

                MySqlDataReader myReader;
                myReader = comm.ExecuteReader();

                int contador = 0;

                while (myReader.Read())
                {
                    contador++;
                }

                cerrarConexion();

                crearConexion();


                if(contador == 0)
                {
                    return "No";
                }
                else
                {
                    comm = conBD.CreateCommand();
                    if (rol == "Secretario")
                    {
                        comm.CommandText = "Insert INTO Secretario(Persona_FK, A_ingreso) VALUES(@persona, @Aingreso)";
                        comm.Parameters.AddWithValue("@persona", personaID);
                        comm.Parameters.AddWithValue("@Aingreso", aingreso);
                    }
                    else if(rol == "Director")
                    {
                        comm.CommandText = "Insert INTO Director(A_ingreso, Persona_FK) VALUES(@Aingreso, @persona)";
                        comm.Parameters.AddWithValue("@persona", personaID);
                        comm.Parameters.AddWithValue("@Aingreso", aingreso);
                    }
                    else if(rol == "Profesor")
                    {
                        comm.CommandText = "Insert INTO Profesor(Persona_FK, A_ingreso) VALUES(@persona, @Aingreso)";
                        comm.Parameters.AddWithValue("@persona", personaID);
                        comm.Parameters.AddWithValue("@Aingreso", aingreso);
                    }
                    else if(rol == "Administrador")
                    {
                        comm.CommandText = "Insert INTO Administrador(Persona_FK) VALUES(@persona)";
                        comm.Parameters.AddWithValue("@persona", personaID);
                    }
                    else if(rol == "Apoderado")
                    {
                        comm.CommandText = "Insert INTO Apoderado(Persona_FK) VALUES(@persona)";
                        comm.Parameters.AddWithValue("@persona", personaID);
                    }
                    else if(rol == "Alumnos")
                    {
                        comm.CommandText = "Insert INTO Alumnos(Persona_FK, A_ingreso, Apoderado_FK) VALUES(@persona, @Aingreso, @apoderado)";
                        comm.Parameters.AddWithValue("@persona", personaID);
                        comm.Parameters.AddWithValue("@Aingreso", aingreso);
                        comm.Parameters.AddWithValue("@apoderado", apoderadoID);
                    }
                    else
                    {
                        return "Rol no existe";
                    }
                    comm.ExecuteNonQuery();

                    comm = conBD.CreateCommand();
                    comm.CommandText = "Update Persona Set rol = 1 where ID = @persona";

                    comm.Parameters.AddWithValue("@persona", personaID);
                    comm.ExecuteNonQuery();
                }

                return "Rol asignado";
            }
            else
            {
                return "La conexion no esta abierta";
            }
        }
        public void ConsultaPersonasSinRol()
        {
            //string resultado = "";
            if (estado)
            {
                try
                {
                    MySqlCommand comm = conBD.CreateCommand();
                    comm.CommandText = "Select ID, Nombres from Persona where rol = 0";
                    //MySqlDataReader myReader;
                    //myReader = comm.ExecuteReader();

                    MySqlDataAdapter mda = new MySqlDataAdapter(comm);
                    ds = new DataSet();
                    mda.Fill(ds);
                    comm.ExecuteNonQuery();

                    /*
                    while (myReader.Read())
                    {
                        resultado += myReader.GetInt32(0).ToString();
                        resultado += myReader.GetString(1) + "/";
                    }
                    resultado = resultado.Substring(0, resultado.Length - 1);
                    */
                }
                catch (Exception ex)
                {
                    
                }
            }
            else
            {
                
            }
        }
        public void SylabusSinAprobar()
        {
            //string resultado = "";
            if (estado)
            {
                try
                {
                    MySqlCommand comm = conBD.CreateCommand();
                    comm.CommandText = "Select * from Archivos where estado = 0";
                    //MySqlDataReader myReader;
                    //myReader = comm.ExecuteReader();

                    MySqlDataAdapter mda = new MySqlDataAdapter(comm);
                    dsS = new DataSet();
                    mda.Fill(dsS);
                    comm.ExecuteNonQuery();

                    /*
                    while (myReader.Read())
                    {
                        resultado += myReader.GetInt32(0).ToString();
                        resultado += myReader.GetString(1) + "/";
                    }
                    resultado = resultado.Substring(0, resultado.Length - 1);
                    */
                }
                catch (Exception)
                {

                }
            }
            else
            {

            }
        }
        public int verificarRol(string correo)
        {
            if (estado)
            {
                MySqlCommand comm = conBD.CreateCommand();
                comm.CommandText = "Select * from Persona where Correo = @correo";
                comm.Parameters.AddWithValue("@correo", correo);

                MySqlDataReader myReader;
                myReader = comm.ExecuteReader();

                int contador = 0;
                int estado = 0;

                while (myReader.Read())
                {
                    estado = myReader.GetInt32(7);
                    contador++;
                }
                if (contador == 0)
                {
                    return 0;
                }
                else
                {
                    return estado;
                }
            }
            return 0;
        }
        public int obtenerID(string correo)
        {
            if (estado)
            {
                MySqlCommand comm = conBD.CreateCommand();
                comm.CommandText = "Select * from Persona where Correo = @correo";
                comm.Parameters.AddWithValue("@correo", correo);

                MySqlDataReader myReader;
                myReader = comm.ExecuteReader();

                int idUsuario = 0;

                while (myReader.Read())
                {
                    idUsuario = myReader.GetInt32(0);
                    break;
                }
                return idUsuario;
            }
            return 0;
        }
        public string passwordUsuario(string correo)
        {
            if (estado)
            {
                MySqlCommand comm = conBD.CreateCommand();
                comm.CommandText = "Select * from Persona where Correo = @correo";
                comm.Parameters.AddWithValue("@correo", correo);

                MySqlDataReader myReader;
                myReader = comm.ExecuteReader();

                int contador = 0;
                string pass = "";

                while (myReader.Read())
                {
                    pass = myReader.GetString(6);
                    contador++;
                }
                if (contador == 0)
                {
                    return "Error";
                }
                else
                {
                    pass = decodificar(pass);
                    return pass;
                }
            }
            return "Error";
        }
        public void cerrarConexion()
        {
            conBD.Close();
        }
        public List<List<string>> evaluacionesPendientes()
        {
            List<int> IDtabla = new List<int> { };
            List<string> ASIGNATURAtabla = new List<string> { };
            List<int> idASIGNATURAtabla = new List<int> { };
            List<string> ARCHIVOtabla = new List<string> { };
            List<string> NOMBREtabla = new List<string> { };
            List<List<string>> myList = new List<List<string>>();
            //string resultado = "";
            if (estado)
            {
                MySqlCommand comm = conBD.CreateCommand();
                comm.CommandText = "Select * from Evaluacion where estado = 0";
                MySqlDataReader myReader;
                myReader = comm.ExecuteReader();

                while (myReader.Read())
                {
                    IDtabla.Add(myReader.GetInt32(0));
                    ARCHIVOtabla.Add(myReader.GetString(1));
                    NOMBREtabla.Add(myReader.GetString(2));
                    idASIGNATURAtabla.Add(myReader.GetInt32(3));
                }
                myReader.Close();
                foreach (int ida in idASIGNATURAtabla)
                {
                    comm = conBD.CreateCommand();
                    comm.CommandText = "Select * from Asignaturas where ID = @ida";
                    comm.Parameters.AddWithValue("@ida", ida);
                    myReader = comm.ExecuteReader();

                    while (myReader.Read())
                    {
                        ASIGNATURAtabla.Add(myReader.GetString(1));
                        break;
                    }
                    myReader.Close();
                }
                int i = 0;
                while (i < IDtabla.Count)
                {
                    myList.Add(new List<string> { IDtabla[i].ToString(), NOMBREtabla[i].ToString(), ASIGNATURAtabla[i].ToString(), ARCHIVOtabla[i].ToString(), });
                    i++;
                }
            }
            return myList;
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
                if(idRol != -1)
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
    }
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public static string decodificar(string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted =
            Convert.FromBase64String(_cadenaAdesencriptar);
            System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            string llamado = con.crearConexion();

            string password = con.passwordUsuario(TextBox1.Text);
            if (!String.IsNullOrEmpty(TextBox2.Text) && !String.IsNullOrEmpty(TextBox1.Text))
            {
                if (TextBox2.Text == password)
                {
                    con.cerrarConexion();

                    //Verificar si el usuario tiene rol

                    con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
                    llamado = con.crearConexion();
                    int estado = con.verificarRol(TextBox1.Text);

                    if(estado == 1) {
                        Label1.Text = "Se ha iniciado sesion!";
                        Label1.CssClass = "mt-2 mb-2 alert alert-success form-control";
                        Label1.Visible = true;
                        con.cerrarConexion();

                        //Redirije a pagina de requisitos
                        control.Control.estadoConexion = 1;
                        control.Control.email = TextBox1.Text;

                        con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
                        con.crearConexion();
                        int idUsuario = con.obtenerID(TextBox1.Text);
                        con.cerrarConexion();

                        control.Control.ID = idUsuario;

                        con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
                        con.crearConexion();

                        List<String> datos = con.conocerRol(idUsuario);
                        con.cerrarConexion();

                        if (datos.Count > 0)
                        {
                            control.Control.rol = datos[0];
                            control.Control.rolID = Int32.Parse(datos[1]);
                        }

                        Response.Redirect("menu.aspx");
                    }
                    else
                    {
                        Label1.Text = "Cuenta no habilitada!";
                        Label1.CssClass = "mt-2 mb-2 alert alert-danger form-control";
                        Label1.Visible = true;
                        con.cerrarConexion();
                    }

                }
                else
                {
                    Label1.Text = "Datos Incorrectos!";
                    Label1.CssClass = "mt-2 mb-2 alert alert-danger form-control";
                    Label1.Visible = true;
                    con.cerrarConexion();
                }
            }
            else
            {
                Label1.Text = "Faltan datos!";
                Label1.CssClass = "mt-2 mb-2 alert alert-warning form-control";
                Label1.Visible = true;
                con.cerrarConexion();
            }

        }

    }
}