using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckMovingCompany.Models;
using TruckMovingCompany.DataModel;
using System.Data.Entity;

namespace TruckMovingCompany.Repository
{
    public class MoverRepository
    {
        private readonly TruckCompanyContext _context;
        public MoverRepository(TruckCompanyContext db)
        {
            _context = db;
        }

        public List<Movers> GetAllMovers()
        {
            return _context.Movers
                .Include(m => m.Crews)
                .OrderBy(x => x.FirstName)
                .ToList();
        }

        public Movers GetMover(int id)
        {
            return _context.Movers.Where(m => m.MoversId == id).Include(m => m.Crews).First();
        }

    }


}