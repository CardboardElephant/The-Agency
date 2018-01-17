using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TheAgency.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Your Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        //[EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Name", Prompt = "Name (Required)")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Client Type", Prompt = "Client Type (Required)")]
        [DataType(DataType.Text)]
        public string Client_Type { get; set; }

        [Required]
        [Display(Name = "Contact Number", Prompt = "Contact Number (Required)")]
        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address", Prompt = "Email Address (Required)")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Confirm Email Address", Prompt = "Confirm Email Address (Required)")]
        [DataType(DataType.EmailAddress)]
        [System.ComponentModel.DataAnnotations.Compare("Email", ErrorMessage = "The email and confirmation email do not match.")]
        public string ConfirmEmail { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Password", Prompt = "Password (Required)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password", Prompt = "Confirm Password (Required)")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

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

    public class RegisterViewModelBusinessDetails
    {
        public string CompanyName;
        public string Address_Line_01;
        public string Address_Line_02;
        public string TownCity;
        public string County;
        public string Postcode;
        public string CompanyLogo;
    }

    public class RegisterViewModelIndividualDetails
    {
        public string Address_Line_01;
        public string Address_Line_02;
        public string TownCity;
        public string County;
        public string Postcode;
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ContactViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telephone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.Text)]
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}