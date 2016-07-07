using System.Collections.Generic;

namespace TruckMovingCompany.ViewModels
{
    // The model that will contain last three trucks and movers to be presented to client
    public class LatestViewModel
    {
        public IList<TruckDetailsViewModel> LastThreeTrucks{ get; set; }
        public IList<MoversNameViewModel> Movers { get; set;}
    }


}

