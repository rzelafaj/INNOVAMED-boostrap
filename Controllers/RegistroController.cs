using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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