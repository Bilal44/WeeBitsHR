using System.ComponentModel.DataAnnotations;
using WeeBitsHRService.Models;

namespace WeeBitsHRService.ViewModels
{
    public class AveragePayByJobVM
    {
        public JobCategory JobCategory { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.00}")]
        public decimal AveragePay { get; set; }

        public int TotalEmployees { get; set; }
    }
}
