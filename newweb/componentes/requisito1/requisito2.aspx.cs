using System;
using System.Collections.Generic;
using System.Linq;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            var errorMessage = "";
            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            con.crearConexion();

            string pass = con.passwordUsuario(TextBox1.Text);
            con.cerrarConexion();

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
                body: "Tu contraseña es la siguiente: " + pass
                );
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
    }
}