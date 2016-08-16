using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckMovingCompany.DataModel;
using TruckMovingCompany.Models;
using System.Data.Entity;

namespace TruckMovingCompany.Repository
{

    public class CrewRepository
    {
        private TruckCompanyContext _context;
        public CrewRepository(TruckCompanyContext db)
        {
            _context = db;
        }

        public Crew GetCrewByName(string CrewName)
        {
            return _context.Crews
                .Where(c => c.CrewName == CrewName)
                .Include(c => c.Movers)
                .First();
        }
    }
}