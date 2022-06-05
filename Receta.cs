using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_final
{
    public class Receta
    {
        public List<Medicamento> Medicamentos { get; set; }
        public string Dosis { get; set; }
        public string Horario { get; set; }
    }
}