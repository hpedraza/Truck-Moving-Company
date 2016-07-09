using System;
using System.ComponentModel.DataAnnotations;
using TruckMovingCompany.ViewModels;

namespace TruckMovingCompany.Models
{
    public class Truck
    {
        // Would use unsigned byte but EF was giving errors: 
        // was not auto incrementing id
        public int TruckId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "The {0] must be minumin {2} characters long.")]
        [MaxLength(26, ErrorMessage = "The {0} must be maximum {2} characters long.")]
        public string TruckName { get; set; }

        [DateTimeVerify]
        public DateTime LastMoveDateTime { get; set; }

        public int CrewId { get; set; }

        public int MoveId { get; set; }


    }
}