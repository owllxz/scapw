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

namespace newweb.componentes.Req_4
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
    }
    public partial class Req_4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Llenar_Lista();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string url = FTPUpload();
            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            con.crearConexion();
            //con.crearArchivo(url, );
            int idAsignatura = con.obtenerIDAsignatura(Lista_Materias.SelectedItem.Text);

            label_vacio.Visible = true;
            label_vacio.Text =  con.crearArchivo(url, idAsignatura, 2);
            con.cerrarConexion();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Lista_Materias.SelectedItem != null)
            {
                int indice = Lista_Materias.SelectedIndex;
                string nombre_asignatura = Lista_Materias.SelectedItem.Text;
                texto_prueba.Text = "Se ha seleccionado " + nombre_asignatura;
                texto_prueba.Visible = true;
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
        protected string FTPUpload()
        {
            //FTP Server URL.
            string ftp = "ftp://camifel.cl/";

            //FTP Folder name. Leave blank if you want to upload to root folder.
            string ftpFolder = "";

            byte[] fileBytes = null;

            //Read the FileName and convert it to Byte array.
            string fileName = Path.GetFileName(Archivo_Syllabus.FileName);
            using (StreamReader fileStream = new StreamReader(Archivo_Syllabus.PostedFile.InputStream))
            {
                fileBytes = Encoding.UTF8.GetBytes(fileStream.ReadToEnd());
                fileStream.Close();
            }

            try
            {
                //Create FTP Request.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + fileName);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                //Enter FTP Server credentials.
                request.Credentials = new NetworkCredential("scap@camifel.cl", "Scap123am.");
                request.ContentLength = fileBytes.Length;
                request.UsePassive = true;
                request.UseBinary = true;
                request.ServicePoint.ConnectionLimit = fileBytes.Length;
                request.EnableSsl = false;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileBytes, 0, fileBytes.Length);
                    requestStream.Close();
                }

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                //label_vacio.Visible = true;
                response.Close();
                return "http://camifel.cl/scap/" + fileName;
                //label_vacio.Text += urlBD+ " uploaded.<br />";
            }
            catch (WebException ex)
            {
                throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
            }
        }
    }
}
