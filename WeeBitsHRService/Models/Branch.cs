using System.ComponentModel.DataAnnotations.Schema;

namespace WeeBitsHRService.Models
{
	public class Branch
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string AddressLine1 { get; set; }
		public string? AddressLine2 { get; set; }
		public string Town { get; set; }
		public string PostCode { get; set; }
		public string Country { get; set; }
		public string PhoneNumber { get; set; }
		[NotMapped]
		public string Region { get => Name + ", " + Country; }
	}
}
