using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using TheAgency.Interfaces;

namespace TheAgency.Models
{
    public class SearchModels
    {
        public class SearchViewModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "I Am")]
            public string I_Am { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Looking For")]
            public string Looking_For { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Location")]
            public string Location { get; set; }

            public IEnumerable<SelectListItem> I_Am_List { get; set; }
            public IEnumerable<SelectListItem> Looking_For_List { get; set; }
        }
    }
}