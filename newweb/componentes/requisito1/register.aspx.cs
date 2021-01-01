using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newweb.componentes.requisito1
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            Label1.Text = con.crearConexion();

            string Nombres = TextBox1.Text + " " + TextBox2.Text;
            string Apellidos = TextBox3.Text + " " + TextBox4.Text;
            string Rut = TextBox5.Text;
            string Direccion = TextBox6.Text;
            string Correo = TextBox7.Text + "@" + TextBox8.Text; ;
            string Password = codificar(TextBox9.Text);

            Label1.Text = con.crearUsuario(Nombres, Apellidos, Rut, Direccion, Correo, Password);

            con.cerrarConexion();
        }
    }
}