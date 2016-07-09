using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TruckMovingCompany.Models
{
    public class Movers
    {
        // Would use unsigned byte (tinyint in SQL SERVER), but EF was giving errors: 
        // was not auto incrementing id. (assuming we will always have less than 255 movers in database
        public int MoversId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "The {0] must be minumin {2} characters long.")]
        [MaxLength(20, ErrorMessage = "The {0} must be maximum {2} characters long.")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "The {0] must be minumin {2} characters long.")]
        [MaxLength(20, ErrorMessage = "The {0} must be maximum {2} characters long.")]
        public string LastName { get; set; }

        public IList<Crew> Crews { get; set; }
    }






}