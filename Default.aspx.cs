using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_final
{
    public partial class _Default : Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
            Lectura lector = new Lectura();
            lector.LeerHistorial();
            lector.LeerMedicamentos();
            lector.LeerPacientes();
            ObtenerEnfermedadesComunes();
            ObtenerEdadPromedio();
            ObtenerMedicamentosComunes();
        }
        private void ObtenerEnfermedadesComunes()
        {
            List<EstadisticaEnfermedad> enfermedadesComunes = new List<EstadisticaEnfermedad>();
            foreach(var a in Lectura.Historial)
            {
                EstadisticaEnfermedad e = new EstadisticaEnfermedad();
                e.Enfermedad = a.Diagnostico;
                if(enfermedadesComunes.Find(p => p.Enfermedad == a.Diagnostico) != null)
                {
                    continue;
                }
                foreach(var b in Lectura.Historial)
                {
                    
                    if(a.Diagnostico == b.Diagnostico && enfermedadesComunes.Find(p => p.Enfermedad == a.Diagnostico) != null)
                    {
                        continue;
                    }
                    else if(a.Diagnostico == b.Diagnostico)
                    {
                        e.Pacientes++;
                    }
                }
                enfermedadesComunes.Add(e);
            }
            GridView1.DataSource = enfermedadesComunes;
            GridView1.DataBind();
        }
        private void ObtenerEdadPromedio()
        {
            var edad = 0;
            foreach(var p in Lectura.Pacientes)
            {
                edad += (DateTime.Now.Year - p.FechaDeNacimiento.Year);
            }
            Label1.Text = (edad/Lectura.Pacientes.Count).ToString();
        }
        private void ObtenerMedicamentosComunes()
        {
            GridView2.DataSource = Lectura.Medicamentos.OrderByDescending(p => p.VecesRecetado);
            GridView2.DataBind();
        }
        private void ObtenerTotalDeIngresos()
        {
            int totalIngresos = 0;
            var fechaInicio = Convert.ToDateTime(TextBox1.Text);
            var fechaFinal = Convert.ToDateTime(TextBox2.Text);
            foreach(var h in Lectura.Historial)
            {
                if (h.Fecha.CompareTo(fechaInicio) > 0 && h.Fecha.CompareTo(fechaFinal) < 0)
                {
                    totalIngresos += h.CostoDeConsulta;
                }
            }
            Label2.Text = totalIngresos.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ObtenerTotalDeIngresos();

        }
    }
}