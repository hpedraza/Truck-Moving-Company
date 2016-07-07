using System;
using System.Collections.Generic;

namespace TruckMovingCompany.Models
{
    public class Move
    {
        //public Move()
       // {
           // this.Truck = new HashSet<Truck>();
       // }



        public int MoveId { get; set; }

        public string NameOfMove { get; set; }

        public DateTime TimeOfMove { get; set; }


        // Would Typically have sepetate fields for address, but for the sake of simplicity we will just use address for coding challange
        public string Address { get; set; }

        public virtual ICollection<Truck> Trucks { get; set; }
    }
}