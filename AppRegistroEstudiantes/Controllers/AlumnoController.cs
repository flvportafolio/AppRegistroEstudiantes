using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppRegistroEstudiantes.Models;
using PracticaWeb1.Context;

namespace AppRegistroEstudiantes.Controllers
{
    public class AlumnoController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Alumno
        public ActionResult Index()
        {
            var alumnos = db.Alumno.Include(a => a.Madre).Include(a => a.Padre);
            return View(alumnos.ToList());
        }

        // GET: Alumno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumno.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // GET: Alumno/Create
        public ActionResult Create()
        {
            ViewBag.MadreID = new SelectList(db.Tutor.Where(s => s.Genero == Persona.TipoGenero.Mujer), "Id", "NombreCompleto");
            ViewBag.PadreID = new SelectList(db.Tutor.Where(s => s.Genero == Persona.TipoGenero.Hombre), "Id", "NombreCompleto");
            return View();
        }

        // POST: Alumno/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,ApellidoPaterno,ApellidoMaterno,Genero,CI,FechaNacimiento,LugarNacimiento,Direccion,Zona,Telefono,Foto,Procedencia,PadreID,MadreID")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase Imagen = Request.Files["Foto"];
                if (Imagen != null)
                {
                    string fileType = Path.GetExtension(Imagen.FileName);
                    string fileName = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + fileType;
                    string path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                    alumno.Foto = fileName;
                    Imagen.SaveAs(path);
                    db.Alumno.Add(alumno);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.MadreID = new SelectList(db.Tutor.Where(s => s.Genero == Persona.TipoGenero.Mujer), "Id", "NombreCompleto");
            ViewBag.PadreID = new SelectList(db.Tutor.Where(s => s.Genero == Persona.TipoGenero.Hombre), "Id", "NombreCompleto");
            return View(alumno);
        }

        // GET: Alumno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumno.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            ViewBag.MadreID = new SelectList(db.Tutor.Where(s => s.Genero == Persona.TipoGenero.Mujer), "Id", "NombreCompleto", alumno.MadreID);
            ViewBag.PadreID = new SelectList(db.Tutor.Where(s => s.Genero == Persona.TipoGenero.Hombre), "Id", "NombreCompleto", alumno.PadreID);
            return View(alumno);
        }

        // POST: Alumno/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,ApellidoPaterno,ApellidoMaterno,Genero,CI,FechaNacimiento,LugarNacimiento,Direccion,Zona,Telefono,Foto,Procedencia,PadreID,MadreID")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase Imagen = Request.Files["FotoUpdated"];
                if (Imagen != null && Imagen.FileName != "")
                {
                    string fileType = Path.GetExtension(Imagen.FileName);
                    string fileName = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + fileType;
                    string oldImage = Path.Combine(Server.MapPath("~/Content/Images"), alumno.Foto);
                    string newImage = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                    alumno.Foto = fileName;
                    Imagen.SaveAs(newImage);
                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }
                    
                }
                db.Entry(alumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MadreID = new SelectList(db.Tutor.Where(s => s.Genero == Persona.TipoGenero.Mujer), "Id", "NombreCompleto", alumno.MadreID);
            ViewBag.PadreID = new SelectList(db.Tutor.Where(s => s.Genero == Persona.TipoGenero.Hombre), "Id", "NombreCompleto", alumno.PadreID);
            return View(alumno);
        }

        // GET: Alumno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumno.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // POST: Alumno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alumno alumno = db.Alumno.Find(id);
            string rutaImagen = Path.Combine(Server.MapPath("~/Content/Images"), alumno.Foto);
            db.Alumno.Remove(alumno);
            if (System.IO.File.Exists(rutaImagen))
            {
                System.IO.File.Delete(rutaImagen);
            }
            //
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
