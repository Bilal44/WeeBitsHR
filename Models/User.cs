using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeeBitsHRService.Models
{
	public class User : IdentityUser
	{
		public override string Id { get => base.Id; set => base.Id = value; }
		public override string UserName { get => base.UserName; set => base.UserName = value; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

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
		public override string Email { get => base.Email; set => base.Email = value; }

		[Required]
		[StringLength(100)]
		[Display(Name = "Address Line 1")]
		public string AddressLine1 { get; set; }

		[StringLength(100)]
		[Display(Name = "Address Line 2")]
		public string? AddressLine2 { get; set; }

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
		[RegularExpression(@"^\+?[0-9]\d{4,14}$", ErrorMessage = "Please enter a valid phone number.")]
		[Display(Name = "Phone Number")]
		public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }

		[Required]
		[Display(Name = "Active")]
		public bool IsActive { get; set; } = true;

		[NotMapped]
		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[NotMapped]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }
	}
}
