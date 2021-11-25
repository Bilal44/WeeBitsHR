using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeeBitsHRService.Model
{
    public class Employee : User
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
        [StringLength(20)]
        public string Position { get; set; }

        [Required]
        [Range(0, 99999999.99)]
        [Column(TypeName = "decimal(10,2)")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Join Date")]
        public DateTime JoinDate { get; set; }

        [Display(Name = "Leave Date")]
        public DateTime? LeaveDate { get; set; }

        [Required]
        [ForeignKey("JobCategory")]
        [Display(Name = "JobCategory")]
        public int JobCategoryId { get; set; }
        public JobCategory JobCategory { get; set; }

        [Required]
        [ForeignKey("Branch")]
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public ICollection<TimeOff> TimeOff { get; set; }

    }

    public enum Gender { Female, Male, Other }
}
