using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_final
{
    public partial class MantenimientoUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new Lectura().LeerUsuarios();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario()
            {
                UserName = TextBox1.Text,
                Level = Convert.ToInt32(RadioButtonList1.SelectedValue)
            };
            string myPassword = TextBox2.Text;
            string mySalt = BCrypt.Net.BCrypt.GenerateSalt();
            string myHash = BCrypt.Net.BCrypt.HashPassword(myPassword, mySalt);
            user.Password = myHash;
            Lectura.Usuarios.Add(user);
            new Guardar().GuardarUsuario();
            Response.Write("<script> alert('Usuario registrado!') </script>");
            LimpiarCamposDeDatos();
        }
        private void LimpiarCamposDeDatos()
        {
            TextBox1.Text = null;
            TextBox2.Text = null;
            RadioButtonList1.SelectedIndex = 0;
        }
    }
}