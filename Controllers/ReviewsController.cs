using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheAgency.Models;
using TheAgency.Functions;
using Microsoft.AspNet.Identity;

namespace TheAgency.Controllers
{
    [RequireHttps]
    public class ReviewsController : Controller
    {
        private static DbConnection db = new DbConnection();
        private DataClasses1DataContext linq = db.Linqcon();

        //public ActionResult Index(string id)
        //{
        //    return View();
        //}

        [Authorize]
        [Route("Reviews/AddReview/$l")]
        public ActionResult AddReview(string id)
        {
            ReviewsModel reviews = new ReviewsModel();
            var ents = linq.Entertainments.Where(x => x.UserId.Equals(id)).FirstOrDefault();
            ViewBag.Id = id;
            ViewBag.Company = ents.CompanyName;
            reviews.GetProfessionalismRatings = GetProfessionalismRatings(Ratings());
            reviews.GetValueForMoneyRatings = GetValueForMoneyRatings(Ratings());
            reviews.GetEnjoymentRatings = GetEnjoymentRatings(Ratings());
            reviews.GetAttireRatings = GetAttireRatings(Ratings());
            return View(reviews);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveReview(Review review)
        {
            var user = User.Identity.GetUserId();
            Review rm = new Review();
            Venue v = linq.Venues.Where(x => x.UserId.Equals(user)).FirstOrDefault();
            rm.Professionalism = review.Professionalism;
            rm.ValueForMoney = review.ValueForMoney;
            rm.Enjoyment = review.Enjoyment;
            rm.Attire = review.Attire;
            rm.Comments = Helper.CleanHTML(review.Comments);
            rm.UserId = Helper.CleanHTML(review.UserId);
            rm.Venue = v.CompanyName;
            linq.Reviews.InsertOnSubmit(rm);
            linq.SubmitChanges();
            return View(AddReview(review.UserId));
        }

        private IEnumerable<int> Ratings()
        {
            return new List<int>
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };
        }

        private IEnumerable<SelectListItem> GetProfessionalismRatings(IEnumerable<int> ratings)
        {
            var selectList = new List<SelectListItem>();
            foreach (var rating in ratings)
            {
                selectList.Add(new SelectListItem
                {
                    Value = rating.ToString(),
                    Text = rating.ToString()
                });
            }
            return selectList;
        }

        private IEnumerable<SelectListItem> GetValueForMoneyRatings(IEnumerable<int> ratings)
        {
            var selectList = new List<SelectListItem>();
            foreach (var rating in ratings)
            {
                selectList.Add(new SelectListItem
                {
                    Value = rating.ToString(),
                    Text = rating.ToString()
                });
            }
            return selectList;
        }

        private IEnumerable<SelectListItem> GetEnjoymentRatings(IEnumerable<int> ratings)
        {
            var selectList = new List<SelectListItem>();
            foreach (var rating in ratings)
            {
                selectList.Add(new SelectListItem
                {
                    Value = rating.ToString(),
                    Text = rating.ToString()
                });
            }
            return selectList;
        }

        private IEnumerable<SelectListItem> GetAttireRatings(IEnumerable<int> ratings)
        {
            var selectList = new List<SelectListItem>();
            foreach (var rating in ratings)
            {
                selectList.Add(new SelectListItem
                {
                    Value = rating.ToString(),
                    Text = rating.ToString()
                });
            }
            return selectList;
        }
    }
}