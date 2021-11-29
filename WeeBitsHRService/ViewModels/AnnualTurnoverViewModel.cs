using System.ComponentModel.DataAnnotations;

namespace WeeBitsHRService.ViewModels
{
    public class AnnualTurnoverViewModel
    {
        [Display(Name = "Average Number of Employees")]
        public int AverageNumberOfEmployees { get; set; }

        [Display(Name = "New Employees")]
        public int NewEmployees { get; set; }

        [Display(Name = "Employees Left")]
        public int EmployeesLeft { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.##}")]

        [Display(Name = "Annual Staff Turnover Ratio")]
        public double StaffTurnoverRatio { get; set; }

        public int Year { get; set; }
        public String Region { get; set; }

        public AnnualTurnoverViewModel(int averageNumberOfEmployees, int newEmployees, int employeesLeft, double staffTurnoverRatio, int year, string region)
        {
            AverageNumberOfEmployees = averageNumberOfEmployees;
            NewEmployees = newEmployees;
            EmployeesLeft = employeesLeft;
            StaffTurnoverRatio = staffTurnoverRatio;
            Year = year;
            Region = region;
        }

        public AnnualTurnoverViewModel()
        {
        }
    }
}
