using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_final
{
    public partial class MantenimientoMedicamentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Lectura lector = new Lectura();
            lector.LeerMedicamentos();
            GridView1.DataSource = Lectura.Medicamentos;
            GridView1.DataBind();
        }

        protected void EditarButton_Click(object sender, EventArgs e)
        {

            int index = Lectura.Medicamentos.FindIndex(m => m.Id == CodigoTextBox.Text);
            if (index != -1)
            {
                Medicamento medicamento = new Medicamento()
                {
                    Id = CodigoTextBox.Text,
                    IngredienteGenerico = IngrTextBox.Text,
                    Laboratorio = MarcaTextBox.Text,
                    Enfermedades = EnfermedadesTextBox.Text
                };
                Lectura.Medicamentos[index] = medicamento;
            }
            else
            {
                Response.Write("<script> alert('Este medicamento no esta registrado') </script>");
            }
            GridView1.DataSource = Lectura.Medicamentos;
            GridView1.DataBind();
            LimpiarCamposDeDatos();
        }
        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            if(Lectura.Medicamentos.Find(m => m.Id == CodigoTextBox.Text) == null)
            {
                Medicamento medicamento = new Medicamento()
                {
                    Id = CodigoTextBox.Text,
                    IngredienteGenerico = IngrTextBox.Text,
                    Laboratorio = MarcaTextBox.Text,
                    Enfermedades = EnfermedadesTextBox.Text
                };
                Lectura.Medicamentos.Add(medicamento);
                Guardar guardar = new Guardar();
                guardar.GuardarMedicamento();
            }
            else
            {
                Response.Write("<script> alert('Este medicamento ya esta registrado') </script>");
            }
            GridView1.DataSource = Lectura.Medicamentos;
            GridView1.DataBind();
            LimpiarCamposDeDatos();
        }
        private void LimpiarCamposDeDatos()
        {
            CodigoTextBox.Text = null;
            IngrTextBox.Text = null;
            MarcaTextBox.Text = null;
            EnfermedadesTextBox.Text = null;
        }
    }
}