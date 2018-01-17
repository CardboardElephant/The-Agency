using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TheAgency.Models;
using static TheAgency.Models.SearchModels;

namespace TheAgency.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private static DbConnection db = new DbConnection();
        private DataClasses1DataContext linq = db.Linqcon();
        SearchViewModel svm = new SearchViewModel();
        public ActionResult Index()
        {
            svm.I_Am_List = GetSelectListItems(GetAllIAm());
            svm.Looking_For_List = GetSelectListItems(GetAllLookingFor());
            ViewBag.Towns = Towns();
            return View(svm);
        }
        private IEnumerable<string> GetAllIAm()
        {
            return new List<string>
            {
                "Individual",
                "Venue"
            };
        }
        private IEnumerable<string> GetAllLookingFor()
        {
            return new List<string>
            {
                "Fun Casino",
                "Mobile Disco",
                "Photobooth"
            };
        }
        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            var selectList = new List<SelectListItem>();
            foreach (var element in elements){
                selectList.Add(new SelectListItem{
                    Value = element,
                    Text = element
                });
            }
            return selectList;
        }

        public List<Town_List> Towns()
        {
            return linq.Town_Lists.ToList();
        }
    }
}