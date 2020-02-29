using KaratePortal.Models.PersonKarate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaratePortal.Controllers
{
    public class CoachController : Controller
    {
        private KaratePersonContext db = new KaratePersonContext();
        
        public ActionResult ShowCoaches()
        {
         
            return View();
        }

        [HttpGet]
        public ActionResult GetCoaches()
        {
            KaratePerson karatePerson = new KaratePerson();
            db.Configuration.ProxyCreationEnabled = false;
            List<Coach> data = db.Coaches.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Coach coach)
        {
          
            db.Coaches.Add(coach);

            db.SaveChanges();
            return RedirectToAction("ShowCoaches", "Coach");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.KarateStudents = db.KarateStudents.ToList();
            Coach coach = db.Coaches.Find(id);
           
            return View(coach);
        }

        [HttpGet]
        public ActionResult Details(int id = 0)
        {
            Coach coach = db.Coaches.Find(id);
            if (coach == null)
            {
                return HttpNotFound();
            }
            return View(coach);
        }
        
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            
            Coach coach = db.Coaches.Find(id);
            if (coach == null)
            {
                return HttpNotFound();
            }
           
            db.Coaches.Remove(coach);
            db.SaveChanges();
            return Json(coach);
        }

        [HttpPost]
        public ActionResult Edit(Coach coach)
        {
            Coach newCoach = db.Coaches.Find(coach.Id);
            newCoach.Name = coach.Name;
            newCoach.LastName = coach.LastName;
            newCoach.Age = coach.Age;
            newCoach.KarateStudents.Clear();
       
            db.Entry(newCoach).State = EntityState.Modified;
            db.SaveChanges();


            db.SaveChanges();
            return RedirectToAction("ShowCoaches", "Coach");
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
