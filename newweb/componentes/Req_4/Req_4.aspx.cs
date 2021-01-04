using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

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
            Byte[] Archivo = null;
            string nombreArchivo = string.Empty;
            string extensionArchivo = string.Empty;
            if (Archivo_Syllabus.HasFile == true)
            {
                using (BinaryReader reader = new BinaryReader(Archivo_Syllabus.PostedFile.InputStream))
                {
                    Archivo = reader.ReadBytes(Archivo_Syllabus.PostedFile.ContentLength);
                }
                _ = Path.GetFileNameWithoutExtension(Archivo_Syllabus.FileName);
                extensionArchivo = Path.GetExtension(Archivo_Syllabus.FileName);
            }
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
    }
}
