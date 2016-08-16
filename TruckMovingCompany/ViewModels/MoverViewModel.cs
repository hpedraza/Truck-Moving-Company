using System;
using System.Collections.Generic;
using TruckMovingCompany.Models;
using System.Linq;


namespace TruckMovingCompany.ViewModels
{
    [Serializable]
    public class MoverViewModel
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual IList<string> Crews { get; set; }

        public MoverViewModel() { }

        public MoverViewModel( Movers mover)
        {
            id = mover.MoversId;
            FirstName = mover.FirstName;
            LastName = mover.LastName;
            Crews = mover.Crews.Select(c => c.CrewName).ToList<string>();
        }
    }
}