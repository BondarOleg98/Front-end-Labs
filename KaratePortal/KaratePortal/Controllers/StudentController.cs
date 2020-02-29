using KaratePortal.Models.KarateTeam;
using KaratePortal.Models.PersonKarate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaratePortal.Controllers
{
    public class StudentController : Controller
    {
        private KaratePersonContext db = new KaratePersonContext();


        [HttpGet]
        public ActionResult ShowStudents()
        {
            KaratePerson karatePerson = new KaratePerson();
            ViewBag.CountStudents = karatePerson.CountPeople(db.KarateStudents.ToList());
            return View(db.KarateStudents.ToList());
        }

        [HttpGet]
     
        public ActionResult Create()
        {
            SelectList teams = new SelectList(db.Teams, "Id", "Name");
            ViewBag.Teams = teams;
            ViewBag.Coaches = db.Coaches.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(KarateStudent karateStudent, int[] selectedCoaches)
        {
           
            if (selectedCoaches != null)
            {
                foreach (var c in db.Coaches.Where(co => selectedCoaches.Contains(co.Id)))
                {
                    karateStudent.Coaches.Add(c);
                }
            }
            karateStudent.CountCoach =  karateStudent.CountPeople(selectedCoaches);
            
            db.KarateStudents.Add(karateStudent);
            db.SaveChanges();
            return RedirectToAction("ShowStudents","Student");
        }

        [HttpGet]
     
        public ActionResult Edit(int id = 0)
        {
            KarateStudent karateStudent = db.KarateStudents.Find(id);
            if (karateStudent == null)
            {
                return HttpNotFound();
            }
            SelectList teams = new SelectList(db.Teams, "Id", "Name", karateStudent.TeamId);
            ViewBag.Teams = teams;
            ViewBag.Coaches = db.Coaches.ToList();
            return View(karateStudent);
        }

        [HttpGet]
        public ActionResult Details(int id = 0)
        {
            KarateStudent karateStudent = db.KarateStudents.Find(id);
            if (karateStudent == null)
            {
                return HttpNotFound();
            }
            return View(karateStudent);
        }
        [HttpGet]
      
        public ActionResult Delete(int id =0)
        {
            KarateStudent karateStudent = db.KarateStudents.Find(id);
            if (karateStudent == null)
            {
                return HttpNotFound();
            }
            return View(karateStudent);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            KarateStudent karateStudent = db.KarateStudents.Find(id);
           
            if (karateStudent == null)
            {
                return HttpNotFound();
            }
            
            db.KarateStudents.Remove(karateStudent);
            
            
            db.SaveChanges();
            return RedirectToAction("ShowStudents", "Student");
        }

        [HttpPost]
        public ActionResult Edit(KarateStudent karateStudent, int[] selectedCoaches)
        {
            KarateStudent newStudent = db.KarateStudents.Find(karateStudent.Id);
            newStudent.Name = karateStudent.Name;
            newStudent.LastName = karateStudent.LastName;
            newStudent.Age = karateStudent.Age;
            newStudent.Country = karateStudent.Country;
            newStudent.City = karateStudent.City;
            newStudent.Belt = karateStudent.Belt;
            newStudent.CountCoach = karateStudent.CountPeople(selectedCoaches);
            newStudent.YearsTraining = karateStudent.YearsTraining;
            newStudent.SportsmanStatus = karateStudent.SportsmanStatus;
            newStudent.LikeCompetition = karateStudent.LikeCompetition;
            newStudent.TeamId = karateStudent.TeamId;
            newStudent.Coaches.Clear();
            if (selectedCoaches != null)
            {
                foreach (var c in db.Coaches.Where(co => selectedCoaches.Contains(co.Id)))
                {
                    newStudent.Coaches.Add(c);
                }
            }
            db.Entry(newStudent).State=EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ShowStudents", "Student");
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}