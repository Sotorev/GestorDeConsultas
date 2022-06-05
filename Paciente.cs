using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_final
{
    public class Paciente
    {
        public string NIT { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Telefono { get; set; }

    }
}