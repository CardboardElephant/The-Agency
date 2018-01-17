using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TheAgency.Models
{
    public class Individual
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        [Required]
        [Display(Name = "Address Line 01", Prompt = "Address Line 01 (Required)")]
        [DataType(DataType.Text)]
        public string Address_Line_01 { get; set; }

        [Display(Name = "Address Line 02", Prompt = "Address Line 02 (Optional)")]
        [DataType(DataType.Text)]
        public string Address_Line_02 { get; set; }

        [Required]
        [Display(Name = "Town / City", Prompt = "Town / City (Required)")]
        [DataType(DataType.Text)]
        public string TownCity { get; set; }

        [Required]
        [Display(Name = "County", Prompt = "County (Required)")]
        [DataType(DataType.Text)]
        public string County { get; set; }

        [Required]
        [Display(Name = "Postcode", Prompt = "Postcode (Required)")]
        [DataType(DataType.PostalCode)]
        public string Postcode { get; set; }
    }
}