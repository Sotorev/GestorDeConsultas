using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_final
{
    public class Medicamento
    {
        public string Id { get; set; }
        public string IngredienteGenerico { get; set; }
        public string Laboratorio { get; set; }
        public string Enfermedades { get; set; }
        public int VecesRecetado { get; set; }
    }
}