using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeeBitsHRService.Models
{
	public class Absence
	{
		public int Id { get; set; }

		[Required]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
		[Display(Name = "Date of Absence")]
		public DateTime DateofAbsence { get; set; }

		[Required]
		[Display(Name = "Number of Hours")]
		[Column(TypeName = "decimal(4,2)")]
		[DataType(DataType.Date)]
		[Range(0, 24, ErrorMessage = "Please enter valid number between 0 and 24")]
		public double NumberOfHours { get; set; }
	}
}
