using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckMovingCompany.Models;
using System.Collections;
using TruckMovingCompany.DataModel;
using System.ComponentModel;

namespace TruckMovingCompany.ViewModels
{
  
    public class EditMoverViewModel
    {
        public EditMoverViewModel()
        {

        }
        public EditMoverViewModel(Movers mover , TruckCompanyContext db)
        {
            MoversCrews = new List<string>();
            foreach(var Crew in mover.Crews)
            {
                MoversCrews.Add(Crew.CrewName);
            }

            FirstName = mover.FirstName;
            LastName = mover.LastName;
            MoverId = mover.MoversId;

            var CrewNameList = db.Crews.Select(c => c.CrewName).Distinct().ToList();
            CrewNameList = CrewNameList.Except(MoversCrews).ToList();

            CrewListToAdd = CrewNameList;
        }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public int MoverId { get; set; }

        public IList<string> MoversCrews { get; set; }

        public IList<string> CrewListToAdd { get; set; }       
    }
}