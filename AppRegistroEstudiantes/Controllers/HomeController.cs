using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticaWeb1.Context;

namespace AppRegistroEstudiantes.Controllers
{
    public class HomeController : Controller
    {
        private SchoolContext db = new SchoolContext();

        public ActionResult Index()
        {
            dynamic Response = new ExpandoObject();

            int[] Registros = {
                db.Curso.ToList().Count(),
                db.Tutor.ToList().Count(),
                db.Registro.ToList().Count(),
                db.Alumno.ToList().Count(),
            };
            var ultimasInscripciones= db.Registro.OrderByDescending(s => s.Id).Take(5).ToList();
            Response.Registros = Registros;
            Response.Inscripciones = ultimasInscripciones;

            return View(Response);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return RedirectToAction("Create", "Contacto");
        }
    }
}