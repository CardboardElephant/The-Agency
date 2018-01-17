using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TheAgency.Models;
using TheAgency.Functions;
using static TheAgency.Models.SearchModels;
using System.Collections.Generic;
using System.Data.Linq;

namespace TheAgency.Controllers
{
    public class ProfileController : Controller
    {
        private static DbConnection db = new DbConnection();
        private DataClasses1DataContext linq = db.Linqcon();

        // GET: Profile
        [Route("Profile")]
        public ActionResult Index()
        {
            var Entertainments =
                linq.Entertainments.Join(
                    linq.Profiles,
                    ent => ent.UserId,
                    profile => profile.User_Id,
                    (ent, profile) => new { Entertainment = ent, Profile = profile }
                ).Join(
                    linq.Files,
                    profile2 => profile2.Profile.User_Id,
                    file => file.UserId,
                    (profile2, file) => new { Profile = profile2, File = file }).ToList();
            List<ProfileViewModels> pvmList = new List<ProfileViewModels>();
            foreach (var ents in Entertainments)
            {
                ProfileViewModels pvm = new ProfileViewModels();
                pvm.UserId = ents.Profile.Entertainment.UserId;
                pvm.CompanyName = ents.Profile.Entertainment.CompanyName;
                pvm.TownCity = ents.Profile.Entertainment.TownCity;
                pvm.County = ents.Profile.Entertainment.County;
                pvm.Headline = ents.Profile.Profile.Headline;
                pvm.FileType = ents.File.FileType;
                pvm.Image = (ents.File.Content != null) ? "data:image/png;base64," + Convert.ToBase64String(ents.File.Content.ToArray(), 0, ents.File.Content.Length) : "";
                pvmList.Add(pvm);
            }
            return View(pvmList);
        }

        // GET: Profile/ShowProfile/id
        [Route("Profile/ShowProfile/$l")]
        public ActionResult ShowProfile(string id)
        {
            var Entertainments = linq.Entertainments.Where(x => x.UserId.Equals(id));
            var Profile = linq.Profiles.Where(x => x.User_Id.Equals(id));
            var Files = linq.Files.Where(x => x.UserId.Equals(id));
            var Reviews = linq.Reviews.Where(x => x.UserId.Equals(id));
            ShowProfileModel spm = new ShowProfileModel();
            foreach (var ents in Entertainments)
            {
                spm.ent.CompanyName = ents.CompanyName;
                spm.ent.Address_Line_01 = ents.Address_Line_01;
                spm.ent.Address_Line_02 = ents.Address_Line_02;
                spm.ent.TownCity = ents.TownCity;
                spm.ent.County = ents.County;
                spm.ent.Postcode = ents.Postcode;
            }
            foreach (var profile in Profile)
            {
                spm.pvmList.Headline = profile.Headline;
                spm.pvmList.Content = profile.Content;
            }
            foreach (var file in Files)
            {
                File f = new File
                {
                    ContentType = file.ContentType,
                    Entertainment = file.Entertainment,
                    Entertainments_Id = file.Entertainments_Id,
                    FileId = file.FileId,
                    FileName = (file.Content != null) ? "data:image/png;base64," + Convert.ToBase64String(file.Content.ToArray(), 0, file.Content.Length) : "",
                    FileType = file.FileType,
                    UserId = file.UserId,
                    Venue = file.Venue,
                    Venue_Id = file.Venue_Id
                };
                spm.ImageFiles.Add(f);
            }
            foreach (var review in Reviews)
            {
                Review r = new Review
                {
                    AspNetUser = review.AspNetUser,
                    Attire = review.Attire,
                    Comments = review.Comments.Trim(),
                    Enjoyment = review.Enjoyment,
                    Professionalism = review.Professionalism,
                    UserId = review.UserId,
                    ValueForMoney = review.ValueForMoney,
                    Venue = review.Venue
            };
                spm.VenueReviews.Add(r);
            }
            return View(spm);
        }
    }
}