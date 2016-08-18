
using System.Collections.Generic;
using System.Linq;

using TruckMovingCompany.Models;
using TruckMovingCompany.DataModel;
using System.Data.Entity;
using TruckMovingCompany.ViewModels;
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

        public ResultEnum.Result UpdateMoversName(EditMoverViewModel vm)
        {
            try
            {
                var mover = GetMover(vm.MoverId);
                mover.FirstName = vm.FirstName;
                mover.LastName = vm.LastName;

                return ResultEnum.Result.Success;
            }
            catch
            {
                return ResultEnum.Result.Failed;
            }


            
        }

    }


}