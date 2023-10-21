using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INNOVAMED.Models
{
    public class Citas
    {
      public int IdCita { get; set; }
      public int IdPaciente { get; set; }
      public int IdMedico { get; set; }
      public DateTime Fecha { get; set; }
      public string Hora { get; set; }
      public bool Estado { get; set; }
      public int IdEspecialidad { get; set; }
    }
}