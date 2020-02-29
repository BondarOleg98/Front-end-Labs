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
    public class TeamController : Controller
    {
        KaratePersonContext db = new KaratePersonContext();
        
        [HttpGet]
        public ActionResult ShowStudentTeam()
        {
            var players = db.KarateStudents.Include(p => p.Team);
            return View(players.ToList());
        }
        [HttpGet]
        public ActionResult ShowTeams()
        {
        
            return View(db.Teams.ToList());
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
         
            ViewBag.KarateStudents = db.KarateStudents.ToList();
            return View(team);
        }
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            Team team = db.Teams.Find(id);

            if (team == null)
            {
                return HttpNotFound();
            }
            var karateStudents = db.KarateStudents.Include(t=>t.Team).ToList();
            foreach(KarateStudent student in karateStudents)
            {
                student.TeamId = null;
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
            }
            
           
           
            db.Teams.Remove(team);

            db.SaveChanges();
            return RedirectToAction("ShowTeams", "Team");
        }
        [HttpPost]
        public ActionResult Edit(Team team, int[] selectedStudents)
        {
            Team newTeam = db.Teams.Find(team.Id);
            newTeam.Name = team.Name;
            newTeam.Coach = team.Coach;
            newTeam.Organization = team.Organization;

            newTeam.KarateStudents.Clear();
            if (selectedStudents != null)
            {
                foreach (var ks in db.KarateStudents.Where(co => selectedStudents.Contains(co.Id)))
                {
                    newTeam.KarateStudents.Add(ks);
                }
            }
            db.Entry(newTeam).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ShowTeams", "Team");
        }
        [HttpGet]
        public ActionResult TeamDetails(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Team team = db.Teams.Include(t => t.KarateStudents).FirstOrDefault(t => t.Id == id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.KarateStudents = db.KarateStudents.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Team team, int[] selectedStudents)
        {

            if (selectedStudents != null)
            {
                foreach (var ks in db.KarateStudents.Where(ks => selectedStudents.Contains(ks.Id)))
                {
                    team.KarateStudents.Add(ks);
                }
            }

            db.Teams.Add(team);
            db.SaveChanges();
            return RedirectToAction("ShowTeams", "Team");
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}