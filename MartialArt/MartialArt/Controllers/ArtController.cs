using MartialArt.Models;
using MartialArt.Models.App_Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;

namespace MartialArt.Controllers
{
    public class ArtsController : ApiController
    {
        ArtContext db = new ArtContext();


        public IEnumerable<Art> GetArts()
        {
            return db.Arts;
        }

        public Art GetArt(int id)
        {
            Art art = db.Arts.Find(id);
            return art;
        }

        [HttpPost]
        public void CreateArt([FromBody]Art art)
        {
            db.Arts.Add(art);
            db.SaveChanges();
        }

        [HttpPut]
        public void EditArt(int id, [FromBody]Art art)
        {
            if (id == art.Id)
            {
                db.Entry(art).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        public void DeleteArt(int id)
        {
            Art art = db.Arts.Find(id);
            if (art != null)
            {
                db.Arts.Remove(art);
                db.SaveChanges();
            }
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
