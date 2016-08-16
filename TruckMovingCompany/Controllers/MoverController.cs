using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TruckMovingCompany.Models;
using TruckMovingCompany.DataModel;
using System.Data.Entity;
using TruckMovingCompany.DTO;
using TruckMovingCompany.ViewModels;
using TruckMovingCompany.Repository;

namespace TruckMovingCompany.Controllers
{
    public class MoverController : Controller
    {
        private TruckCompanyContext _context;
        private readonly MoverRepository _moverRepository;
        public MoverController()
        {
            _context = new TruckCompanyContext();
            _moverRepository = new MoverRepository(_context);
        }

        [HttpPost]
        public ActionResult Index(string id)
        {
            int moverId = Convert.ToInt32(id);
            Movers mover = _moverRepository.GetMover(Convert.ToInt32(id)); 
            return View(new EditMoverViewModel(mover , _context));
        }


        [HttpPost]
        public ActionResult EditMover(EditMoverViewModel moverViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.SaveChanges();
                return View("Home" , "Index");
            }
            else
            {
                return View("Index" , moverViewModel);
            }

        }


    }
}