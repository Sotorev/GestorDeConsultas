using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_final
{
    public partial class Agenda1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Lectura lector = new Lectura();
            lector.LeerAgenda();
            lector.LeerPacientes();
            CitasGridView.DataSource = Lectura.Agenda.OrderBy(f => f.Fecha).ToList();
            CitasGridView.DataBind();
            if (!IsPostBack)
            {
                foreach(var p in Lectura.Pacientes)
                {
                    PacienteDropDownList.Items.Add(p.Nombre + " " + p.Apellido);
                }
                CargarNitEnDropDownList();
                CargarFechasEnDropDownList();
            }
            
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            int index = PacienteDropDownList.Text.IndexOf('\u0020');
            string nombreSeleccionado = PacienteDropDownList.Text.Substring(0, index);
            var nitCita = Lectura.Pacientes.Find(p => p.Nombre == nombreSeleccionado).NIT;
            if (EsFechaValida() && Calendar1.SelectedDate != null)
            {
                
                Agenda cita = new Agenda()
                {
                    Fecha = Calendar1.SelectedDate,
                    HoraInicio = Convert.ToDateTime(HoraInicioTextBox.Text),
                    HoraFin = Convert.ToDateTime(HoraFinTextBox.Text),
                    NIT = nitCita
                };
                Calendar1.SelectedDates.Clear();
                Lectura.Agenda.Add(cita);
                new Guardar().GuardarAgenda();
                CitasGridView.DataSource = Lectura.Agenda.OrderBy(f => f.Fecha).ToList();
                CitasGridView.DataBind();
                CargarNitEnDropDownList();
                CargarFechasEnDropDownList();
            }
            else
            {
                if(Calendar1.SelectedDate == null)
                    Response.Write("<script> alert('Seleccione una fecha!') </script>");
                else
                    Response.Write("<script> alert('La hora no esta disponible!') </script>");

            }
        }

        protected void HoraInicioTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void HoraFinTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private Boolean EsFechaValida()
        {
            List<Agenda> horasOcupadasEnFechaElegida = new List<Agenda>();
            var HoraInicio = Convert.ToDateTime(HoraInicioTextBox.Text);
            var HoraFin = Convert.ToDateTime(HoraFinTextBox.Text);
            var fechaElegida = Calendar1.SelectedDate;
            Boolean esHoraDisponible = false;

            foreach(var f in Lectura.Agenda)
            {
                if(f.Fecha.Day == Calendar1.SelectedDate.Day && f.Fecha.Month == Calendar1.SelectedDate.Month &&
                    f.Fecha.Year == Calendar1.SelectedDate.Year)
                {
                    horasOcupadasEnFechaElegida.Add(f);
                }
            }
            if(horasOcupadasEnFechaElegida.Count < 1)
            {
                return true;
            }
            foreach(var f in horasOcupadasEnFechaElegida)
            {
                
                //Este if compara si la hora seleccionada esta disponible o ya esta ocupada
                if (((f.HoraInicio.Hour*3600 + f.HoraInicio.Minute*60) < 
                    (HoraInicio.Hour*3600 + HoraInicio.Minute*60) ||
                    (f.HoraInicio.Hour * 3600 + f.HoraInicio.Minute * 60) >
                    (HoraFin.Hour * 3600 + HoraFin.Minute * 60)) &&
                    ((f.HoraFin.Hour * 3600 + f.HoraFin.Minute * 60) <
                    (HoraInicio.Hour * 3600 + HoraInicio.Minute * 60) ||
                    (f.HoraFin.Hour * 3600 + f.HoraFin.Minute * 60) >
                    (HoraFin.Hour * 3600 + HoraFin.Minute * 60)))
                {
                    esHoraDisponible = true;
                }
                else
                {
                    esHoraDisponible = false;
                }

            }
            return esHoraDisponible;
        }
        private void CargarNitEnDropDownList()
        {
            NitDropDownList.Items.Clear();   
            foreach(var a in Lectura.Agenda)
            {
                Boolean esNitValido = true;
                foreach (var i in NitDropDownList.Items)
                {
                    if(a.NIT == i.ToString())
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
        private void CargarFechasEnDropDownList()
        {
            FechaDropDownList.Items.Clear();
            foreach (var a in Lectura.Agenda)
            {
                if (a.NIT == NitDropDownList.Text)
                {
                    FechaDropDownList.Items.Add(a.Fecha.ToString("dd/MM/yyyy"));
                }
            }
        }
        protected void NitDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarFechasEnDropDownList();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Agenda item = null;
            foreach(var a in Lectura.Agenda)
            {
                if(a.NIT == NitDropDownList.Text && a.Fecha.ToString("dd/MM/yyyy") == FechaDropDownList.Text)
                {
                    item = a;
                }
            }
            if (item != null)
                Lectura.Agenda.Remove(item);
            new Guardar().GuardarAgenda();
            CitasGridView.DataSource = Lectura.Agenda.OrderBy(f => f.Fecha).ToList(); ;
            CitasGridView.DataBind();
            CargarNitEnDropDownList();
            CargarFechasEnDropDownList();

        }
    }
}