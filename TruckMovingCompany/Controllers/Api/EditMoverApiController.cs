using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TruckMovingCompany.DataModel;
using TruckMovingCompany.DTO;
using TruckMovingCompany.Models;
using TruckMovingCompany.Repository;


namespace TruckMovingCompany.Controllers.Api
{
    public class EditMoverApiController : ApiController
    {
        private TruckCompanyContext _context;
        private MoverRepository _moverRepository;
        private CrewRepository _crewRepository;
        public EditMoverApiController()
        {
            _context = new TruckCompanyContext();
            _moverRepository = new MoverRepository(_context);
            _crewRepository = new CrewRepository(_context);
        }

        [HttpPost]
        public IHttpActionResult AddMoverToCrew(CrewNameDTO dto)
        {
            Movers mover = _moverRepository.GetMover(dto.MoverId);
            var result = mover.AddToCrew(_crewRepository.GetCrewByName(dto.CrewName));

            if(result == ResultEnum.Result.Success)
            {
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest("Something failed");
            }

        }

        [HttpDelete]
        public IHttpActionResult RemoveMoverFromCrew(CrewNameDTO dto)
        {
            Movers mover = _moverRepository.GetMover(dto.MoverId);
            var result = mover.RemoveFromCrew(_crewRepository.GetCrewByName(dto.CrewName));

            if (result == ResultEnum.Result.Success)
            {
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest("Something failed");
            }

        }


    }
}
