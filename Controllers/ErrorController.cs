using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheAgency.Controllers
{
    public class ErrorController : Controller
    {
        // GET: 404
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
        // GET: 500
        public ActionResult ServerError()
        {
            Response.StatusCode = 500;
            return View();
        }
        // GET: 400
        public ActionResult BadRequest()
        {
            Response.StatusCode = 400;
            return View();
        }
    }
}