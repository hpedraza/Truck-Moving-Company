using System.Collections.Generic;

namespace TruckMovingCompany.ViewModels
{
    public class HomeViewModel
    {
        public IList<string> CrewNames { get; set; }

        public IList<MoverViewModel> Movers { get; set; }

        public HomeViewModel() { }

        public HomeViewModel(List<string> crewNames)
        {
            CrewNames = crewNames;
            Movers = new List<MoverViewModel>();
        }

        public void AddMoverViewModel(MoverViewModel mover)
        {
            Movers.Add(mover);
        }
    }
}