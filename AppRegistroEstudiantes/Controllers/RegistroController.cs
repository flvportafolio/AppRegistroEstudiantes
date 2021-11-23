using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppRegistroEstudiantes.Models;
using PracticaWeb1.Context;

namespace AppRegistroEstudiantes.Controllers
{
    public class RegistroController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Registro
        public ActionResult Index()
        {
            var registro = db.Registro.Include(r => r.Alumno).Include(r => r.Curso);
            return View(registro.ToList());
        }

        // GET: Registro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.Registro.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // GET: Registro/Create
        public ActionResult Create()
        {
            ViewBag.AlumnoID = new SelectList(db.Alumno, "Id", "NombreCompleto");
            ViewBag.CursoID = new SelectList(db.Curso, "Id", "Nombre");
            return View();
        }

        // POST: Registro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FechaInscripcion,Observacion1,Observacion2,EsTraspaso,EsBecado,EsRepitente,Matricula,Estado,AlumnoID,CursoID")] Registro registro)
        {
            string inputBeca = Request.Form["Beca"];            
            registro.Beca = Convert.ToDecimal(inputBeca.Replace('.', ','));
            if (ModelState.IsValid)
            {
                db.Registro.Add(registro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlumnoID = new SelectList(db.Alumno, "Id", "Nombre", registro.AlumnoID);
            ViewBag.CursoID = new SelectList(db.Curso, "Id", "Nombre", registro.CursoID);
            return View(registro);
        }

        // GET: Registro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.Registro.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlumnoID = new SelectList(db.Alumno, "Id", "NombreCompleto", registro.AlumnoID);
            ViewBag.CursoID = new SelectList(db.Curso, "Id", "Nombre", registro.CursoID);
            return View(registro);
        }

        // POST: Registro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FechaInscripcion,Observacion1,Observacion2,EsTraspaso,EsBecado,EsRepitente,Matricula,Estado,AlumnoID,CursoID")] Registro registro)
        {
            string inputBeca = Request.Form["Beca"];
            registro.Beca = Convert.ToDecimal(inputBeca.Replace('.', ','));
            if (ModelState.IsValid)
            {
                db.Entry(registro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlumnoID = new SelectList(db.Alumno, "Id", "Nombre", registro.AlumnoID);
            ViewBag.CursoID = new SelectList(db.Curso, "Id", "Nombre", registro.CursoID);
            return View(registro);
        }

        // GET: Registro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.Registro.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // POST: Registro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registro registro = db.Registro.Find(id);
            db.Registro.Remove(registro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
