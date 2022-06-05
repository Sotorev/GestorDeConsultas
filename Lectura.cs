using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Proyecto_final
{
    public class Lectura : Page
    {
        public static List<Usuario> Usuarios { get; set; }
        public static List<Agenda> Agenda { get; set; }
        public static List<Paciente> Pacientes { get; set; }
        public static List<Historial> Historial { get; set; }
        public static List<Sintoma> Sintomas { get; set; }
        public static List<Medicamento> Medicamentos { get; set; }
        public void LeerUsuarios()
        {
            string archivoUsuarios = Server.MapPath("Usuarios.json");
            StreamReader sr = File.OpenText(archivoUsuarios);
            string usuarios = sr.ReadToEnd();
            sr.Close();
            if (usuarios.Length > 0)
                Lectura.Usuarios = JsonConvert.DeserializeObject<List<Usuario>>(usuarios);
            else
                Lectura.Usuarios = new List<Usuario>();
        }
        public void LeerAgenda()
        {
            string archivoAgenda = Server.MapPath("Agenda.json");
            StreamReader sr = File.OpenText(archivoAgenda);
            string agenda = sr.ReadToEnd();
            sr.Close();
            if(agenda.Length > 0)
                Lectura.Agenda = JsonConvert.DeserializeObject<List<Agenda>>(agenda);
            else
                Lectura.Agenda = new List<Agenda>();
        }
        public void LeerPacientes()
        {
            string archivoPacientes = Server.MapPath("Pacientes.json");
            StreamReader sr = File.OpenText(archivoPacientes);
            string pacientes = sr.ReadToEnd();
            sr.Close();
            if (pacientes.Length > 0)
                Lectura.Pacientes = JsonConvert.DeserializeObject<List<Paciente>>(pacientes);
            else
                Lectura.Pacientes = new List<Paciente>();
        }
        public void LeerHistorial()
        {
            string archivoHistorial = Server.MapPath("Historial.json");
            StreamReader sr = File.OpenText(archivoHistorial);
            string historial = sr.ReadToEnd();
            sr.Close();
            if (historial.Length > 0)
                Lectura.Historial = JsonConvert.DeserializeObject<List<Historial>>(historial);
            else
                Lectura.Historial = new List<Historial>();
            
        }
        public void LeerSintomas()
        {
            string archivoSintomas = Server.MapPath("Sintomas.json");
            StreamReader sr = File.OpenText(archivoSintomas);
            string sintomas = sr.ReadToEnd();
            sr.Close();
            if (sintomas.Length > 0)
                Lectura.Sintomas = JsonConvert.DeserializeObject<List<Sintoma>>(sintomas);
            else
                Lectura.Sintomas = new List<Sintoma>();
        }
        public void LeerMedicamentos()
        {
            string archivoMedicamentos = Server.MapPath("Medicamentos.json");
            StreamReader sr = File.OpenText(archivoMedicamentos);
            string medicamentos = sr.ReadToEnd();
            sr.Close();
            if (medicamentos.Length > 0)
                Lectura.Medicamentos = JsonConvert.DeserializeObject<List<Medicamento>>(medicamentos);
            else
                Lectura.Medicamentos = new List<Medicamento>();
        }
    }
}