using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Proyecto_final
{
    //
    // Resumen:
    //     Proporciona métodos auxiliares para guardar archivos json.
    public class Guardar : Page
    {
        public void GuardarUsuario()
        {
            string json = JsonConvert.SerializeObject(Lectura.Usuarios);
            string archivoUsuarios = Server.MapPath("Usuarios.json");
            System.IO.File.WriteAllText(archivoUsuarios, json);
        }
        public void GuardarAgenda()
        {
            string json = JsonConvert.SerializeObject(Lectura.Agenda);
            string archivoAgenda = Server.MapPath("Agenda.json");
            System.IO.File.WriteAllText(archivoAgenda, json);
        }
        public void GuardarPaciente()
        {
            string json = JsonConvert.SerializeObject(Lectura.Pacientes);
            string archivoPacientes = Server.MapPath("Pacientes.json");
            System.IO.File.WriteAllText(archivoPacientes, json);
        }
        public void GuardarHistorial()
        {
            string json = JsonConvert.SerializeObject(Lectura.Historial);
            string archivoHistoral = Server.MapPath("Historial.json");
            System.IO.File.WriteAllText(archivoHistoral, json);
        }
        public void GuardarSintoma()
        {
            string json = JsonConvert.SerializeObject(Lectura.Sintomas);
            string archivoSintoma = Server.MapPath("Sintomas.json");
            System.IO.File.WriteAllText(archivoSintoma, json);
        }
        public void GuardarMedicamento()
        {
            string json = JsonConvert.SerializeObject(Lectura.Medicamentos);
            string archivoMedicamentos = Server.MapPath("Medicamentos.json");
            System.IO.File.WriteAllText(archivoMedicamentos, json);
        }
    }
}