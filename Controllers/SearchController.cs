using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheAgency.Models;
using TheAgency.Functions;
using static TheAgency.Models.SearchModels;

namespace TheAgency.Controllers
{
    [RequireHttps]
    public class SearchController : Controller
    {
        private static DbConnection db = new DbConnection();
        private DataClasses1DataContext linq = db.Linqcon();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search()
        {
            if (ModelState.IsValid)
            {
                SearchViewModel svm = new SearchViewModel();
                svm.I_Am = Helper.CleanHTML(Request["I_Am"].ToString());
                svm.Looking_For = Helper.CleanHTML(Request["Looking_For"].ToString());
                svm.Location = Helper.CleanHTML(Request["Location"].ToString());
                ViewBag.Test = "I am " + svm.I_Am + " looking for " + svm.Looking_For + " based in " + svm.Location;
            }
            else
            {
                ViewBag.Test = "Model State is not valid.";
            }
            return View();
        }
    }
}