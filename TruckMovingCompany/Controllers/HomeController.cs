using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TruckMovingCompany.DataModel;
using TruckMovingCompany.Models;
using TruckMovingCompany.ViewModels;
using System.Data.Entity;
namespace TruckMovingCompany.Controllers
{

    public class HomeController : Controller
    {

        private TruckCompanyContext db;

        public HomeController()
        {
            // Worry about Dependency Injection and repository pattern later
            db = new TruckCompanyContext();
        }

        public ActionResult Index()
        {
            // Get all movers to display to client
            IList<MoverViewModel> movers = new List<MoverViewModel>();

            var AllMovers = db.Movers.Include(x => x.Crews).OrderBy(x => x.LastName).ToList();

            foreach (var mover in AllMovers)
            {
                movers.Add(
                    new MoverViewModel
                    {
                        FirstName = mover.FirstName,
                        LastName = mover.LastName,
                        Crews = mover.Crews
                    }
                );
            }

            HomeViewModel vm = new HomeViewModel {
                CrewNames = db.Crews.Select(x => x.CrewName).Distinct().ToList<string>(),
                Movers = movers
            };


           

            return View(vm);
        }


        // Controller to render last three trucks that went out and Crew Members who went alond with trucks
        public ActionResult DisplayLatestInformation()
        {
            var lastThreeTrucks = GetLastThreeTrucks();
            List<TruckDetailsViewModel> lastThreeTrucksViewModels = new List<TruckDetailsViewModel>();

            // add found trucks into a presentation model list
            foreach (var i in lastThreeTrucks)
            {
                lastThreeTrucksViewModels.Add(new TruckDetailsViewModel
                {
                   TruckName = i.TruckName,
                   LastMoveDateTime = i.LastMoveDateTime
                });
            }

            // View Model that contains a list of the trucks and members will be passed to the view
            LatestViewModel vm = new LatestViewModel
            {
                LastThreeTrucks = lastThreeTrucksViewModels,
                Movers = GetMovers(lastThreeTrucks)
            };
            return View(vm);
        }

        // AJAX POST
        [HttpPost]
        public ActionResult PostMover(AddMoverViewModel mover)
        {
            var _domainCrew = (from x in db.Crews
                               where x.CrewName == mover.CrewName
                               select x).ToList().Take(1);
            Crew domaincrew = _domainCrew.First();
            if (Request.IsAjaxRequest())
            {
                Movers domainMover = new Movers
                {
                    FirstName = mover.FirstName,
                    LastName = mover.LastName,
                    Crews = new List<Crew>()
                };

                domainMover.Crews.Add(domaincrew);

                db.Movers.Add(domainMover);

                db.SaveChanges();

                return Json(new AddMoverViewModel { FirstName = domainMover.FirstName, LastName = domainMover.LastName, CrewName = domaincrew.CrewName });
            }
            else
            {
                return RedirectToAction("Index");
            }
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