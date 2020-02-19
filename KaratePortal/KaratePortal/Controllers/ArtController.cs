using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaratePortal.Controllers
{
    public class ArtController : Controller
    {
    
        public ActionResult ShowArts()
        {
            return View();
        }
    }
}