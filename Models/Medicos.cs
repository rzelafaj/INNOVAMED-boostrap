using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INNOVAMED.Models
{
    public class Medicos
    {
        public int IdMedico { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdEspecialidad { get; set; }
    }
}