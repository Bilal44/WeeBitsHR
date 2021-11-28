using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeeBitsHRService.Models
{
    public class Employee : User
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "Payroll Number")]
        public string PayrollNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Position { get; set; }

        [Required]
        [Range(0, 99999999.99)]
        [Column(TypeName = "decimal(10,2)")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        [EnumDataType(typeof(Gender))]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Join Date")]
        public DateTime JoinDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Leave Date")]
        public DateTime? LeaveDate { get; set; }

        [Required]
        [ForeignKey("JobCategory")]
        public int JobCategoryId { get; set; }
        [Display(Name = "Job Category")]
        public JobCategory JobCategory { get; set; }

        [Required]
        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        public Branch Branch { get; set; }
        
        public ICollection<Absence> Absences { get; set; }
    }

    public enum Gender { Female, Male, Other }
}
