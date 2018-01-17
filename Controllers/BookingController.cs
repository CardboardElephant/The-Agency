using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TheAgency.Models;
using Microsoft.AspNet.Identity;

namespace TheAgency.Controllers
{
    public class BookingController : Controller
    {
        private static DbConnection db = new DbConnection();
        private DataClasses1DataContext linq = db.Linqcon();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string EntertainmentId)
        {
            var Entertainment = linq.Entertainments.Where(x => x.UserId.Equals(EntertainmentId)).FirstOrDefault();
            BookingViewModel bvm = new BookingViewModel();
            bvm.EntertainmentId = Entertainment.Id;
            bvm.Entertainment = Entertainment.CompanyName;
            bvm.VenueId = HttpContext.User.Identity.GetUserId();
            return View(bvm);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Book(Booking BookingModel)
        {
            if (!ModelState.IsValid)
            {
                return View(BookingModel);
            }
            Booking booking = new Booking
            {
                EventDate = BookingModel.EventDate,
                EventStart = BookingModel.EventStart,
                EventFinish = BookingModel.EventFinish,
                Location = BookingModel.Location,
                Requirements = BookingModel.Requirements,
                SpecialRequests = BookingModel.SpecialRequests,
                EntertainmentId = BookingModel.EntertainmentId,
                VenueId = BookingModel.VenueId
            };
            linq.Bookings.InsertOnSubmit(booking);
            linq.SubmitChanges();
            return View();
        }
    }
}