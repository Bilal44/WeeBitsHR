using System.ComponentModel.DataAnnotations;

namespace WeeBitsHRService.Models
{
    public class JobCategory
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
