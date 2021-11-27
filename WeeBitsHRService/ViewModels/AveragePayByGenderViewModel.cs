using WeeBitsHRService.Models;

namespace WeeBitsHRService.ViewModels
{
    public class AveragePayByGenderViewModel
    {
        public Gender Gender { get; set; }
        public decimal AveragePay { get; set; }
    }
}
