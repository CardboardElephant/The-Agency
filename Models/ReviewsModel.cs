using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheAgency.Models
{
    public class ReviewsModel
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        [Required]
        [Display(Name = "How easy was it to deal with this company?", Prompt = "Professionalism")]
        [DataType(DataType.Text)]
        [StringLength(1)]
        public int Professionalism { get; set; }

        [Required]
        [Display(Name = "Do you consider the service suppled as value for money?", Prompt = "Value For Money")]
        [DataType(DataType.Text)]
        [StringLength(1)]
        public int ValueForMoney { get; set; }

        [Required]
        [Display(Name = "How much did everyone enjoy themselves?", Prompt = "Enjoyment")]
        [DataType(DataType.Text)]
        [StringLength(1)]
        public int Enjoyment { get; set; }

        [Required]
        [Display(Name = "Were the croupiers dressed in a manner befitting the event?", Prompt = "Attire")]
        [DataType(DataType.Text)]
        [StringLength(1)]
        public int Attire { get; set; }

        [Required]
        [Display(Name = "Comments", Prompt = "Comments")]
        [DataType(DataType.Text)]
        [StringLength(1024)]
        public string Comments { get; set; }

        public IEnumerable<SelectListItem> GetProfessionalismRatings { get; set; }
        public IEnumerable<SelectListItem> GetValueForMoneyRatings { get; set; }
        public IEnumerable<SelectListItem> GetEnjoymentRatings { get; set; }
        public IEnumerable<SelectListItem> GetAttireRatings { get; set; }
    }
}