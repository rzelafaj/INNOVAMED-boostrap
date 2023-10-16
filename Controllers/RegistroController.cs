using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//asemos referencia al modelo de la solucion
using INNOVAMED.Models;
using System.Data;
using System.Data.SqlClient;

namespace INNOVAMED.Controllers
{
    public class RegistroController : Controller
    {
        
        // GET: Registro
        public ActionResult RegistrarPaciente()
        {
            return View();
        }
    }
}