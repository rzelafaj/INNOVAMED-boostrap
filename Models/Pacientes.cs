using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace INNOVAMED.Models
{
    public class Pacientes
    {
       public int IdPaciente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DUI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Responsable { get; set; }
        public  bool Estado { get; set; }
    }
}