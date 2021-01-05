using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newweb.componentes.requisito1
{
    public partial class requisito2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private static string claveAleatoria(int length)
        {
            Random random = new Random();
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }
            return builder.ToString();
        }
        public static string codificar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted =
            System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            con.crearConexion();
            int ID = con.obtenerID(TextBox1.Text);
            con.cerrarConexion();

            con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            con.crearConexion();

            string nuevaClave = claveAleatoria(12);
            string nuevaClaveCodificada = codificar(nuevaClave);
            con.actualizarClave(ID, nuevaClaveCodificada);

            try
            {
                WebMail.SmtpServer = "mail.camifel.cl";
                WebMail.SmtpPort = 26;
                WebMail.UserName = "scap@camifel.cl";
                WebMail.Password = "Scap123am.";
                WebMail.From = "scap@camifel.cl";

                // Send email
                WebMail.Send(to: TextBox1.Text,
                subject: "Recuperación de contraseña",
                body: "Tu contraseña es la siguiente: " + nuevaClave
                );
                Response.Redirect("/componentes/requisito1/login.aspx");
            }
            catch (Exception)
            {
            }
        }
    }
}