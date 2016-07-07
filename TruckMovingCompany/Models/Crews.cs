using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TruckMovingCompany.Models
{
    public class Crew
    {
        //public Crew()
        //{
           // this.Movers = new HashSet<Movers>();
      //  }

        // Would use unsigned byte but EF was giving errors: 
        // was not auto incrementing id
        public int CrewId { get; set; }

        [Required]
        public string CrewName { get; set; }


        public ICollection<Movers> Movers { get; set; }

    }
}