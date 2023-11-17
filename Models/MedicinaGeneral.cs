using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INNOVAMED.Models
{
    public class MedicinaGeneral
    {
        public int IdCita { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public bool Estado { get; set; }
        public int IdEspecialidad { get; set; }

      
        public static List<Medicos> LstMedicos { get; set; } = new List<Medicos>();
        public static int IdMedicoSeleccionado { get; set; }
        public static int IdEspecialidadSeleccionada { get; set; }
    }
}