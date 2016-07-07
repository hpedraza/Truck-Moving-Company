using System;
using System.ComponentModel.DataAnnotations;

namespace TruckMovingCompany.Models
{
    public class Truck
    {
        // Would use unsigned byte but EF was giving errors: 
        // was not auto incrementing id
        public int TruckId { get; set; }

        [Required]
        public string TruckName { get; set; }


        public DateTime LastMoveDateTime { get; set; }


        //public Crew CrewMember { get; set; }

        public int CrewId { get; set; }

        public int MoveId { get; set; }


    }
}