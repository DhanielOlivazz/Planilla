using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanillaAppMovil.Models
{
    public class Empleado
    {
        public string nombreCompleto { get; set; }
        public DateTime FechaInicio { get; set; }
        public double salario { get; set; }
        public Cargo cargo { get; set; }
        public string UrlFoto { get; set; }
    }
}
