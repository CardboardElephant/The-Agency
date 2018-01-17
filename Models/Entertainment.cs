using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;

namespace TheAgency.Models
{
    public class Entertainment
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Company Name", Prompt = "Company Name (Optional)")]
        [DataType(DataType.EmailAddress)]
        public string CompanyName { get; set; }

        [Display(Name = "Click to Upload Company Logo", Prompt = "Company Logo (Optional)")]
        [DataType(DataType.ImageUrl)]
        public string CompanyLogo { get; set; }

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