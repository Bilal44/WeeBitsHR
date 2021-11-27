﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeeBitsHRService.Models
{
    public class TimeOff
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date of Absence")]
        public DateTime DateofAbsence { get; set; }

        [Required]
        [Display(Name = "Number of Hours")]
        [Column(TypeName = "decimal(4,2)")]
        [DataType(DataType.Currency)]
        public double NumberOfHours { get; set; }
    }
}
