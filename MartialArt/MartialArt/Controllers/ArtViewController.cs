using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MartialArt.Controllers
{
    public class ArtViewController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}