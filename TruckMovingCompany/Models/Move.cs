using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TruckMovingCompany.ViewModels;

namespace TruckMovingCompany.Models
{
    public class Move
    {

        public int MoveId { get; set; }

        [MinLength(5, ErrorMessage = "The {0] must be minumin {2} characters long.")]
        [MaxLength(50, ErrorMessage = "The {0} must be maximum {2} characters long.")]
        public string NameOfMove { get; set; }


        [Required]
        [DateTimeVerify]
        public DateTime TimeOfMove { get; set; }


        // Would Typically have sepetate fields for address, but for the sake of simplicity we will just use address for coding challange
        [Required]
        public string Address { get; set; }

        public virtual ICollection<Truck> Trucks { get; set; }
    }
}