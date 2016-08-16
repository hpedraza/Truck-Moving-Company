using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TruckMovingCompany.DataModel;
using TruckMovingCompany.Models;
using TruckMovingCompany.ViewModels;
using System.Data.Entity;
using TruckMovingCompany.Repository;

namespace TruckMovingCompany.Controllers
{

    public class HomeController : Controller
    {

        private TruckCompanyContext db;
        private readonly MoverRepository _moverRepository;
        public HomeController()
        {
            // Worry about Dependency Injection and repository pattern later
            db = new TruckCompanyContext();
            _moverRepository = new MoverRepository(db);
        }

        public ActionResult Index()
        {

            IList<MoverViewModel> movers = new List<MoverViewModel>();

            var AllMovers = _moverRepository.GetAllMovers(); 

            HomeViewModel vm = new HomeViewModel(db.Crews.Select(x => x.CrewName).Distinct().ToList<string>());

            foreach (var mover in AllMovers)
                vm.AddMoverViewModel(new MoverViewModel(mover));


            return View(vm);
        }



        // Controller to render last three trucks that went out and Crew Members who went along with trucks
        public ActionResult DisplayLatestInformation()
        {
            var lastThreeTrucks = GetLastThreeTrucks();
            List<TruckDetailsViewModel> lastThreeTrucksViewModels = new List<TruckDetailsViewModel>();

            // add found trucks into a presentation model list
            foreach (var truck in lastThreeTrucks)
            {
                lastThreeTrucksViewModels.Add(
                        new TruckDetailsViewModel
                        {
                           TruckName = truck.TruckName,
                           LastMoveDateTime = truck.LastMoveDateTime
                        }
                );
            }

            // View Model that contains a list of the last three trucks that went out and Movers who were part of the crew.
            LatestViewModel vm = new LatestViewModel
            {
                LastThreeTrucks = lastThreeTrucksViewModels,
                Movers = GetMovers(lastThreeTrucks)
            };

            return View(vm);
        }



        //-- Helper Methods ----------------------------------------------------------------------------------------////////
        //
        //
        //
        private List<Truck> GetLastThreeTrucks()
        {
            var LastThreeTrucks = db.Trucks
                                  .OrderByDescending(x => x.LastMoveDateTime)
                                  .Take(3)
                                  .ToList();
            return LastThreeTrucks;
        }

        private List<MoversNameViewModel> GetMovers(List<Truck> lastThreeTrucks)
        {
            List<MoversNameViewModel> Movers = new List<MoversNameViewModel>();

            // 1. Loop through last three trucks used.
            // 2. Find Crew associated with trucks.
            // 3. Extract all Movers from every found crew avoding duplicates. 

            var count = 0;
            foreach(var truck in lastThreeTrucks)
            {
                var tempList = db.Movers.Include(x => x.Crews).Where(x => x.Crews.Any(y => y.CrewId == truck.CrewId)).Select(x => x).ToList();
                
                foreach (var mover in tempList)
                {
                    if (mover.Crews == null) { count = 0; }
                    else { count = mover.Crews.Count; }

                    // check to see if mover is already in the list. If not add to Mover list
                    if ( !Movers.Any(x => x.FirstName == mover.FirstName && x.LastName == x.LastName))
                    {
                        Movers.Add(new MoversNameViewModel
                        {
                            FirstName = mover.FirstName,
                            LastName = mover.LastName,
                            CrewCount = count
                        });
                    }
                }
            }

            return Movers;
        }

        private List<Crew> GetCrewList()
        {
            var CrewList = db.Crews.ToList();

            return CrewList;
        }
    }
}