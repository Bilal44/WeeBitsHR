using System.ComponentModel.DataAnnotations;
using WeeBitsHRService.Models;

namespace WeeBitsHRService.ViewModels
{
    public class AveragePayByGenderViewModel
    {
        public Gender Gender { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal AveragePay { get; set; }

        public int TotalEmployees { get; set; }
    }
}
