using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeeBitsHRService.Models
{
	public class Branch
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string AddressLine1 { get; set; }

		public string? AddressLine2 { get; set; }

		[Required]
		public string Town { get; set; }

		[Required]
		public string PostCode { get; set; }

		[Required]
		public string Country { get; set; }

		[Required]
		public string PhoneNumber { get; set; }
		[NotMapped]
		public string Region { get => Name + ", " + Country; }
	}
}
