using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INNOVAMED.Controllers
{
    public class EspecialidadesController : Controller
    {
        // GET: Especialidades
        public ActionResult Cardiologia()
        {
            return View();
        }


        // GET: Especialidades
        public ActionResult Pediatria()
        {
            return View();
        }
    }
}
