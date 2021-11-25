using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WeeBitsHRService.Model
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [StringLength(100)]
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required]
        [StringLength(20)]
        public string Town { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        [Required]
        [StringLength(30)]
        public string Country { get; set; }

        [Required]
        [RegularExpression(@"^\+[1-9]\d{10,14}$", ErrorMessage = "Please enter a valid phone number including your country code (e.g. +44 for UK).")]
        [Display(Name = "Phone Number Including Country Code")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Payroll Number")]
        public string PayrollNumber { get; set; }

        [Required]
        [DefaultValue(true)]
        [Display(Name = "Active User")]
        public bool IsActive { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
