using System.ComponentModel.DataAnnotations;
using WeeBitsHRService.Models;

namespace WeeBitsHRService.ViewModels
{
    public class AbsenteeProfileViewModel
    {
        [Display(Name = "Job Category")]
        public JobCategory JobCategory { get; set; }

        [Display(Name = "Average Hours of Absence")]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public double AverageHoursOfAbsence { get; set; }

        [Display(Name = "Total Employees")]
        public int TotalEmployees { get; set; }
    }
}
