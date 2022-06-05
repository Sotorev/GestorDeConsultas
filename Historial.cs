using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_final
{
    public class Historial
    {
        public int Id { get; set; }
        public string NIT { get; set; }
        public DateTime Fecha { get; set; }
        public double Temperatura { get; set; }
        public double Presion { get; set; }
        public List<Sintoma> Sintomas { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
        public Receta Receta { get; set; }
        public DateTime ProximaCita { get; set; }
        public int CostoDeConsulta { get; set; }
        public List<Multimedia> Multimedia { get; set; }
        //
        // Constructor:
        //     Provee un id diferente a cada objeto que se crea a la hora de hacer una consulta.
        
    }
}