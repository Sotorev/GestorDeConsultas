using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_final
{
    public partial class MantenimientoPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Lectura lector = new Lectura();
            lector.LeerPacientes();
            GridView1.DataSource = Lectura.Pacientes;
            GridView1.DataBind();
            CargarNitEnDropDownList();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if(Lectura.Pacientes.Find(p => p.NIT == NitTextBox.Text) == null)
            {
                Paciente paciente = new Paciente()
                {
                    Apellido = ApellidoTextBox.Text,
                    Direccion = DireccionTextBox.Text,
                    FechaDeNacimiento = Convert.ToDateTime(FechaNacimientoTextBox.Text),
                    NIT = NitTextBox.Text,
                    Nombre = NombreTextBox.Text,
                    Telefono = TelefonoTextBox.Text
                };
                Lectura.Pacientes.Add(paciente);
                new Guardar().GuardarPaciente();
            }
            else
            {
                Response.Write("<script> alert('Este paciente ya ha sido anteriormente registrado') </script>");

            }
            GridView1.DataSource = Lectura.Pacientes;
            GridView1.DataBind();
            CargarNitEnDropDownList();
            LimpiarCamposDeDatos();

        }

        protected void EditarButton_Click(object sender, EventArgs e)
        {
            int index = Lectura.Pacientes.FindIndex(p => p.NIT == NitDropDownList.Text);
            if(index != -1)
            {
                Paciente paciente = new Paciente()
                {
                    Apellido = ApellidoTextBox0.Text,
                    Direccion = DireccionTextBox0.Text,
                    FechaDeNacimiento = Convert.ToDateTime(FechaNacimientoTextBox0.Text),
                    Nombre = NombreTextBox0.Text,
                    Telefono = TelefonoTextBox0.Text
                };
                paciente.NIT = NitDropDownList.Text;
                Lectura.Pacientes[index] = paciente;
                new Guardar().GuardarPaciente();
            }
            else
            {
                Response.Write("<script> alert('Este paciente no ha sido anteriormente registrado') </script>");

            }
            GridView1.DataSource = Lectura.Pacientes;
            GridView1.DataBind();
            LimpiarCamposDeDatos();
        }
        private void CargarNitEnDropDownList()
        {

            foreach (var a in Lectura.Pacientes)
            {
                Boolean esNitValido = true;
                foreach (var i in NitDropDownList.Items)
                {
                    if (a.NIT == i.ToString())
                    {
                        esNitValido = false;
                    }
                }
                if (esNitValido)
                {
                    NitDropDownList.Items.Add(a.NIT);
                }
            }
        }
        private void LimpiarCamposDeDatos()
        {
            //Apellido = ApellidoTextBox0.Text,
            //        Direccion = DireccionTextBox0.Text,
            //        FechaDeNacimiento = Convert.ToDateTime(FechaNacimientoTextBox0.Text),
            //        NIT = NitTextBox0.Text,
            //        Nombre = NombreTextBox0.Text,
            //        Telefono = TelefonoTextBox0.Text
            ApellidoTextBox.Text = null;
            ApellidoTextBox0.Text = null;
            FechaNacimientoTextBox.Text = null;
            FechaNacimientoTextBox0.Text = null;
            NitTextBox.Text = null;
            NombreTextBox.Text = null;
            NombreTextBox0.Text = null;
            TelefonoTextBox.Text = null;
            TelefonoTextBox0.Text = null;
        }
    }
}