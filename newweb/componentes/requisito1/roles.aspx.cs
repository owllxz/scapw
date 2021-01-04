using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newweb.componentes.requisito1
{
    public partial class roles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarTabla();
        }
        public void cargarTabla()
        {
            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            string llamado = con.crearConexion();

            con.ConsultaPersonasSinRol();

            GridView1.DataSource = conexion.ds;
            GridView1.DataBind();
            con.cerrarConexion();
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            string rol = rolgrupo.SelectedItem.Text;
            conexion con = new conexion("camifel.cl", "3306", "camifel_admin", "Scap123am.", "camifel_scap");
            string llamado = con.crearConexion();
            if (!String.IsNullOrEmpty(TextBox2.Text))
            {
                if (!String.IsNullOrEmpty(TextBox3.Text))
                {
                    Label4.Text = con.insertarRol(rol, Int32.Parse(TextBox1.Text), Int32.Parse(TextBox3.Text), Int32.Parse(TextBox2.Text));
                }
                else
                {
                    Label4.Text = con.insertarRol(rol, Int32.Parse(TextBox1.Text), 0, Int32.Parse(TextBox2.Text));
                }
            }
            else
            {
                Label4.Text = con.insertarRol(rol, Int32.Parse(TextBox1.Text), 0, 0);
            }
            con.cerrarConexion();

            cargarTabla();
        }
    }
}