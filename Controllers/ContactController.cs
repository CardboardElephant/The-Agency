using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheAgency.Controllers
{
    [RequireHttps]
    [Authorize]
    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}