using System.Collections.Generic;

namespace TruckMovingCompany.ViewModels
{
    public class HomeViewModel
    {
        public IList<string> CrewNames { get; set; }
        public IEnumerable<MoverViewModel> Movers{get;set;}
    }
}