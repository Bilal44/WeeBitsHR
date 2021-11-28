using System.ComponentModel.DataAnnotations;
using WeeBitsHRService.Models;

namespace WeeBitsHRService.ViewModels
{
    public class AveragePayByJobViewModel
    {
        public JobCategory JobCategory { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal AveragePay { get; set; }

        public int TotalEmployees { get; set; }
    }
}
