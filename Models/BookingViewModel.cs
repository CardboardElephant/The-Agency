using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheAgency.Models
{
    public class BookingViewModel
    {
        public string VenueId { get; set; }
        public int EntertainmentId { get; set; }
        public string Entertainment { get; set; }
        public string Venue { get; set; }

        [Display(Name = "Event Date (Required)", Prompt = "Event Date")]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime EventDate { get; set; }

        [Display(Name = "Event Start (Required)", Prompt = "Event Start")]
        [DataType(DataType.Time)]
        [Required]
        public DateTime EventStart { get; set; }

        [Display(Name = "Event Finish (Required)", Prompt = "Event Finish")]
        [DataType(DataType.Time)]
        [Required]
        public DateTime EventFinish { get; set; }

        [Display(Name = "Event Location (Required)", Prompt = "Event Location")]
        [DataType(DataType.Text)]
        [StringLength(128)]
        [Required]
        public string Location { get; set; }

        [Display(Name = "Requirements (Required)", Prompt = "Requirements")]
        [DataType(DataType.Text)]
        [StringLength(1024)]
        [Required]
        public string Requirements { get; set; }

        [Display(Name = "Special Requests", Prompt = "Special Requests")]
        [DataType(DataType.Text)]
        [StringLength(1024)]
        public string SpecialRequests { get; set; }
    }
}