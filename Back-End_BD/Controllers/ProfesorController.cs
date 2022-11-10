using Back_End_BD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Back_End_BD.Controllers
{
    public class ProfesorController : Controller
    {
        // GET: Profesor

        //Index
        public ActionResult Index()
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                return View(dbAlumnos.Profe.ToList());
            }
        }
        //Detalles
        public ActionResult Details(int? id)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                ProfesoresModel prof = dbAlumnos.Profe.Find(id);
                if (prof == null)
                {
                    return HttpNotFound();
                }
                return View(prof);
            }
        }
        //Agregar uno nuevo
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProfesoresModel prof)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                dbAlumnos.Profe.Add(prof);
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //Editar
        public ActionResult Edit(int? id)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                return View(dbAlumnos.Profe.Where(x => x.Id == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Edit(ProfesoresModel prof)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                dbAlumnos.Entry(prof).State = EntityState.Modified;
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //Borrar
        public ActionResult Delete(int? id)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                return View(dbAlumnos.Profe.Where(x => x.Id == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Delete(ProfesoresModel prof, int? id)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                ProfesoresModel pro = dbAlumnos.Profe.Where(x => x.Id == id).FirstOrDefault();
                dbAlumnos.Profe.Remove(pro);
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}