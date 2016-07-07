using System;
using System.Collections.Generic;
using TruckMovingCompany.Models;

namespace TruckMovingCompany.ViewModels
{
    [Serializable]
    public class MoverViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual IList<Crew> Crews { get; set; }
    }
}