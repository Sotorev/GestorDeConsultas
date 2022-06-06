using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_final
{
    public partial class Consulta : System.Web.UI.Page
    {
        private static List<Multimedia> multimediaPaciente = new List<Multimedia>();
        private static List<Sintoma> sintomasPaciente = new List<Sintoma>();
        private static List<Medicamento> medicamentosPaciente = new List<Medicamento>();
        protected void Page_Load(object sender, EventArgs e)
        {
            var identidad = (FormsIdentity)Context.User.Identity;
            if (identidad.Ticket.UserData != "1")
            {
                Response.Redirect("~/Default.aspx", true);
            }
                Lectura lector = new Lectura();
            lector.LeerHistorial();
            lector.LeerAgenda();
            lector.LeerSintomas();
            lector.LeerPacientes();
            lector.LeerMedicamentos();

            if (Lectura.Pacientes.Count > 0 && !IsPostBack && Lectura.Agenda.Count >0)
            {
                CargarDatosPacientes();
                
            }
            CargarSintomasEnDropDownList();
            CargarMedicamentosEnDropDownList();
            CargarHistorial();
            IdTextBox.Text = (Lectura.Historial.Count + 1).ToString();

            if (!IsPostBack)
            {
                AgendarTextBox.Enabled = false;
                HoraFinTextBox.Enabled = false;
                HoraInicioTextBox.Enabled = false;
                AgendarButton.Enabled = false;

            }
        }

        protected void AgregarSintomaButton_Click(object sender, EventArgs e)
        {
            Sintoma sintoma = new Sintoma()
            {
                Id = CodigoTextBox.Text,
                Descripcion = SintomasTextBox.Text
            };

            if (Lectura.Sintomas.Find(s => s.Id == sintoma.Id) == null)
            {
                Consulta.sintomasPaciente.Add(sintoma);
                SintomasGridView.DataSource = sintomasPaciente;
                SintomasGridView.DataBind();
                Lectura.Sintomas.Add(sintoma);
            }
            else
            {
                Response.Write("<script> alert('Este sintoma ya ha sido anteriormente registrado') </script>");
            }
        }

        protected void SintomaComunButton_Click(object sender, EventArgs e)
        {

            if (sintomasPaciente.Find(s => s.Id == SintomasDropDownList.Text) == null)
            {
                sintomasPaciente.Add(Lectura.Sintomas.Find(s => s.Id == SintomasDropDownList.Text));
                SintomasGridView.DataSource = sintomasPaciente;
                SintomasGridView.DataBind();
            }
            else
            {
                Response.Write("<script> alert('Este sintoma ya esta registrado') </script>");
            }

        }

        protected void MultimediaButton_Click(object sender, EventArgs e)
        {
            string archivoOrigen = Path.GetFileName(FileUpload1.FileName);
            try
            {
                FileUpload1.SaveAs(Server.MapPath("~/imagenes/") + archivoOrigen);

            }
            catch (Exception ex)
            {

            }
            string archivo = "~/imagenes/" + FileUpload1.FileName;
            Multimedia m = new Multimedia();
            m.Imagen = archivo;
            m.Descripcion = DescripcionMultimediaTextBox.Text;
            multimediaPaciente.Add(m);
            MultimediaGridView.DataSource = multimediaPaciente;
            MultimediaGridView.DataBind();
        }
        private void CargarDatosPacientes()
        {
            foreach (var p in Lectura.Pacientes)
            {
                foreach (var a in Lectura.Agenda)
                {
                    if (a.NIT == p.NIT)
                    {
                        Boolean nombreRepetido = false;
                        foreach (var i in PacienteDropDownList.Items)
                        {
                            var nombreCompleto = p.Nombre + " " + p.Apellido;
                            if (nombreCompleto == i.ToString())
                                nombreRepetido = true;
                            else
                            {
                                nombreRepetido = false;
                            }
                        }
                        if (!nombreRepetido)
                        {
                            PacienteDropDownList.Items.Add(p.Nombre + " " + p.Apellido);
                        }
                    }
                }
            }
            int index = PacienteDropDownList.Text.IndexOf('\u0020');
            string nombreSeleccionado = PacienteDropDownList.Text.Substring(0, index);
            var paciente = Lectura.Pacientes.Find(p => p.Nombre == nombreSeleccionado);
            NitTextBox.Text = paciente.NIT;
            var fechaConsulta = Lectura.Agenda.OrderBy(a => a.Fecha).ToList().Find(a => a.NIT == paciente.NIT);
            if (fechaConsulta != null)
                FechaConsultaTextBox.Text = fechaConsulta.Fecha.ToString("dd/M/yyyy") + " " + fechaConsulta.HoraInicio.ToString("HH:mm");
            FiltroIDDropDownList.Items.Clear();

            //Carga id en dropdownlist para filtrar el historial medico
            foreach (var h in Lectura.Historial)
            {
                if (paciente.NIT == h.NIT)
                {
                    FiltroIDDropDownList.Items.Add(h.Id.ToString());
                }
            }
        }

        private void CargarSintomasEnDropDownList()
        {
            if (!IsPostBack)
            {
                foreach (var s in Lectura.Sintomas)
                {
                    SintomasDropDownList.Items.Add(s.Id);
                }
            }
        }
        private void CargarMedicamentosEnDropDownList()
        {
            if (!IsPostBack)
            {
                foreach (var s in Lectura.Medicamentos)
                {
                    MedicamentosDropDownList.Items.Add(s.Id);
                }
            }
        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            string nombreSeleccionado;
            Agenda fechaConsulta = null;
            if (PacienteDropDownList.Text.Length > 1)
            {
                int index = PacienteDropDownList.Text.IndexOf('\u0020');
                nombreSeleccionado = PacienteDropDownList.Text.Substring(0, index);
                var paciente = Lectura.Pacientes.Find(p => p.Nombre == nombreSeleccionado);
                NitTextBox.Text = paciente.NIT;
                fechaConsulta = Lectura.Agenda.OrderBy(a => a.Fecha).ToList().Find(a => a.NIT == paciente.NIT);
            }

            if (fechaConsulta != null && sintomasPaciente.Count > 0)
            {
                Receta receta = new Receta()
                {
                    Medicamentos = medicamentosPaciente,
                    Dosis = DosisTextBox.Text,
                    Horario = HorarioTextBox.Text
                };
                Historial historialPaciente = new Historial()
                {
                    Id = Lectura.Historial.Count + 1,
                    NIT = NitTextBox.Text,
                    Fecha = fechaConsulta.Fecha,
                    Temperatura = Convert.ToDouble(TemperaturaTextBox.Text),
                    Presion = Convert.ToDouble(PresionTextBox.Text),
                    Sintomas = sintomasPaciente,
                    Diagnostico = DiagnosticoTextBox.Text,
                    Receta = receta,
                    CostoDeConsulta = Convert.ToInt32(CostoDropDownList.SelectedValue),
                    Multimedia = multimediaPaciente,
                    Tratamiento = TratamientoTextBox.Text

                };
                if (AgendarTextBox.Text != null && AgendarTextBox.Text != "")
                    historialPaciente.ProximaCita = Convert.ToDateTime(AgendarTextBox.Text);
                Guardar guardar = new Guardar();
                Lectura.Historial.Add(historialPaciente);
                guardar.GuardarHistorial();
                CargarHistorial();
            }
            else
            {
                Response.Write("<script> alert('Revise que los campos esten llenados correctamente') </script>");
            }
            LimpiarCamposDeDatos();

            //Eliminar cita ya que ya ha sido llevada a cabo
            Agenda item = null;
            foreach (var a in Lectura.Agenda)
            {
                if (a.Fecha.ToString("dd/MM/yyyy") == fechaConsulta.Fecha.ToString("dd/MM/yyyy"))
                {
                    item = a;
                }
            }
            if (item != null)
                Lectura.Agenda.Remove(item);
            new Guardar().GuardarAgenda();
            
            CargarHistorial();
        }

        protected void MedicamentosButton_Click(object sender, EventArgs e)
        {
            if (medicamentosPaciente.Find(m => m.Id == MedicamentosDropDownList.Text) == null)
            {
                
                var medicamento = Lectura.Medicamentos.Find(m => m.Id == MedicamentosDropDownList.Text);
                Lectura.Medicamentos.Find(m => m.Id == MedicamentosDropDownList.Text).VecesRecetado++;
                new Guardar().GuardarMedicamento();
                medicamentosPaciente.Add(medicamento);
            }
            else
            {
                Response.Write("<script> alert('Este medicamento ya esta en la receta') </script>");

            }
            MedicamentosGridView.DataSource = medicamentosPaciente;
            MedicamentosGridView.DataBind();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Response.Write("<script>window.open(~/Agenda.aspx,'_blank')</script>");
        }

        protected void CheckBox1_CheckedChanged1(object sender, EventArgs e)
        {
            AgendarTextBox.Enabled = true;
            HoraFinTextBox.Enabled = true;
            HoraInicioTextBox.Enabled = true;
            AgendarButton.Enabled = true;
            CheckBox1.Enabled = false;
        }

        protected void AgendarButton_Click(object sender, EventArgs e)
        {
            if (EsFechaValida())
            {
                Agenda cita = new Agenda()
                {
                    Fecha = Convert.ToDateTime(AgendarTextBox.Text),
                    HoraInicio = Convert.ToDateTime(HoraInicioTextBox.Text),
                    HoraFin = Convert.ToDateTime(HoraFinTextBox.Text),
                    NIT = NitTextBox.Text
                };
                Lectura.Agenda.Add(cita);
                new Guardar().GuardarAgenda();
                Response.Write("<script> alert('Cita agendada exitosamente!') </script>");

            }
            else
            {
                Response.Write("<script> alert('La hora no esta disponible!') </script>");
            }
        }
        private Boolean EsFechaValida()
        {
            List<Agenda> horasOcupadasEnFechaElegida = new List<Agenda>();
            var HoraInicio = Convert.ToDateTime(HoraInicioTextBox.Text);
            var HoraFin = Convert.ToDateTime(HoraFinTextBox.Text);
            var fechaElegida = Convert.ToDateTime(AgendarTextBox.Text);
            Boolean esHoraDisponible = false;

            foreach (var f in Lectura.Agenda)
            {
                if (f.Fecha.Day == fechaElegida.Day && f.Fecha.Month == fechaElegida.Month &&
                    f.Fecha.Year == fechaElegida.Year)
                {
                    horasOcupadasEnFechaElegida.Add(f);
                }
            }
            if (horasOcupadasEnFechaElegida.Count < 1)
            {
                return true;
            }
            foreach (var f in horasOcupadasEnFechaElegida)
            {

                //Este if compara si la hora seleccionada esta disponible o ya esta ocupada
                if (((f.HoraInicio.Hour * 3600 + f.HoraInicio.Minute * 60) <
                    (HoraInicio.Hour * 3600 + HoraInicio.Minute * 60) ||
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
        private void CargarHistorial()
        {
            int id = -1;
            Historial historialMedicoPaciente = new Historial();
            List<Multimedia> historialmultimediaPaciente = new List<Multimedia>();
            Receta historialReceta = new Receta();
            if(FiltroIDDropDownList.Text.Length > 0)
                id= Convert.ToInt32(FiltroIDDropDownList.Text);

            historialMedicoPaciente = Lectura.Historial.Find(h => h.Id == id);
            if(historialMedicoPaciente != null)
            {
                historialmultimediaPaciente = historialMedicoPaciente.Multimedia;
                HistorialMedicoGridView.DataSource = new Historial[] { historialMedicoPaciente };
                HistorialMedicoGridView.DataBind();
                MultimediaHGridView.DataSource = historialmultimediaPaciente;
                MultimediaHGridView.DataBind();
                RecetaGridView.DataSource = new Receta[] { historialMedicoPaciente.Receta };
                RecetaGridView.DataBind();
            }
            else
            {
                HistorialMedicoGridView.DataSource = null;
                HistorialMedicoGridView.DataBind();
                MultimediaHGridView.DataSource = null;
                MultimediaHGridView.DataBind();
            }
            
        }

        protected void PacienteDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = PacienteDropDownList.Text.IndexOf('\u0020');
            string nombreSeleccionado = PacienteDropDownList.Text.Substring(0, index);
            var paciente = Lectura.Pacientes.Find(p => p.Nombre == nombreSeleccionado);
            NitTextBox.Text = paciente.NIT;
            var fechaConsulta = Lectura.Agenda.OrderBy(a => a.Fecha).ToList().Find(a => a.NIT == paciente.NIT);
            if (fechaConsulta != null)
                FechaConsultaTextBox.Text = fechaConsulta.Fecha.ToString("dd/M/yyyy") + " " + fechaConsulta.HoraInicio.ToString("HH:mm");
            //Carga id en dropdownlist para filtrar el historial medico
            FiltroIDDropDownList.Items.Clear();
            foreach (var h in Lectura.Historial)
            {
                if (paciente.NIT == h.NIT)
                {
                    FiltroIDDropDownList.Items.Add(h.Id.ToString());
                }
            }
            CargarHistorial();

        }

        protected void SintomasDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = SintomasDropDownList.Text;
            foreach (var s in Lectura.Sintomas)
            {
                if (s.Id == id)
                {
                    DescripcionSintomaTextBox.Text = s.Descripcion;
                }
            }
        }

        protected void DescripcionSintomaTextBox_Load(object sender, EventArgs e)
        {
            var id = SintomasDropDownList.Text;
            foreach (var s in Lectura.Sintomas)
            {
                if (s.Id == id)
                {
                    DescripcionSintomaTextBox.Text = s.Descripcion;
                }
            }
        }
        private void LimpiarCamposDeDatos()
        {
            TemperaturaTextBox.Text = null;
            PresionTextBox.Text = null;
            CodigoTextBox.Text = null;
            SintomasTextBox.Text = null;
            DiagnosticoTextBox.Text = null;
            TratamientoTextBox.Text = null;
            DosisTextBox.Text = null;
            HorarioTextBox.Text = null;
            DescripcionMultimediaTextBox.Text = null;
            FileUpload1 = new FileUpload();
            SintomasGridView.DataSource = null;
            multimediaPaciente.Clear();
            sintomasPaciente.Clear();
            medicamentosPaciente.Clear();
            SintomasGridView.DataBind();
            MedicamentosGridView.DataBind();
            MultimediaGridView.DataBind();
        }
        protected void FiltroIDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHistorial();
        }
    }
}
