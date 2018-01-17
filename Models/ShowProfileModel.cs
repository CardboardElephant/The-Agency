using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAgency.Models;

namespace TheAgency.Models
{
    public class ShowProfileModel
    {
        public Entertainment ent = new Entertainment();
        public ProfileViewModels pvmList = new ProfileViewModels();
        public List<TheAgency.File> ImageFiles = new List<TheAgency.File>();
        public List<Review> VenueReviews = new List<Review>();
    }
}