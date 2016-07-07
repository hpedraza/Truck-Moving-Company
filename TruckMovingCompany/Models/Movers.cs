using System.Collections.Generic;

namespace TruckMovingCompany.Models
{
    public class Movers
    {
        // Would use unsigned byte (tinyint in SQL SERVER), but EF was giving errors: 
        // was not auto incrementing id. (assuming we will always have less than 255 movers in database
        public int MoversId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<Crew> Crews { get; set; }
    }






}