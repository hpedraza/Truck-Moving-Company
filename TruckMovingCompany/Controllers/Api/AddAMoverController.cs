using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TruckMovingCompany.DTO;
using TruckMovingCompany.DataModel;
using TruckMovingCompany.Models;
using System.Data.Entity;

namespace TruckMovingCompany.Controllers
{
    public class AddAMoverController : ApiController
    {
        private TruckCompanyContext _Context;
        
        public AddAMoverController()
        {
            _Context = new TruckCompanyContext();
        }


        [HttpPost]
        public int AddMover(MoverDTO dto)
        {
            bool status = (_Context.Movers.Any(m => m.FirstName == dto.FirstName && m.LastName == dto.LastName));
            if (dto.CrewName == "" || dto.FirstName == "" || dto.LastName == "" || status)
            {
                if (status)
                    return -1;

                return -2;
            } 

            else
            {
                Crew crew = _Context.Crews.Where(x => x.CrewName == dto.CrewName).Single();

                Movers mover = new Movers(dto.FirstName, dto.LastName, crew);

                _Context.Movers.Add(mover);
                _Context.SaveChanges();

                return _Context.Movers
                    .Where(m => m.FirstName == dto.FirstName && m.LastName == dto.LastName)
                    .Select(m => m.MoversId)
                    .First(); 
            }
        }
    }
}
