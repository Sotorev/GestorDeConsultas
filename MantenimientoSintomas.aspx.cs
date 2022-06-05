using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_final
{
    public partial class MantenimientoSintomas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Lectura lector = new Lectura();
            lector.LeerSintomas();
            GridView1.DataSource = Lectura.Sintomas;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            if(Lectura.Sintomas.Find(s => s.Id == TextBox1.Text) == null)
            {
                Sintoma sintoma = new Sintoma()
                {
                    Id = TextBox1.Text,
                    Descripcion = TextBox2.Text
                };
                Lectura.Sintomas.Add(sintoma);
                Guardar guardar = new Guardar();
                guardar.GuardarSintoma();
            }
            else
            {
                Response.Write("<script> alert('Este sintoma ya esta registrado') </script>");
            }
            GridView1.DataSource = Lectura.Sintomas;
            GridView1.DataBind();
        }

        protected void EditarButton_Click(object sender, EventArgs e)
        {
            int index = Lectura.Sintomas.FindIndex(s => s.Id == TextBox1.Text);
            if (index != -1)
            {
                Lectura.Sintomas[index].Id = TextBox1.Text;
                Lectura.Sintomas[index].Descripcion = TextBox2.Text;
                Guardar guardar = new Guardar();
                guardar.GuardarSintoma();
            }
            else
            {
                Response.Write("<script> alert('Este sintoma no esta registrado') </script>");
            }
            GridView1.DataSource = Lectura.Sintomas;
            GridView1.DataBind();
        }
    }
}