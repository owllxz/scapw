using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newweb.componentes.requisito1
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
        public void cerrarConexion()
        {
            conBD.Close();
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

        }

    }
}