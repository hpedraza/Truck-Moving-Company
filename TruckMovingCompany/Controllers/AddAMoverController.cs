using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TruckMovingCompany.DTO;
using TruckMovingCompany.DataModel;
using TruckMovingCompany.Models;
namespace TruckMovingCompany.Controllers
{
    public class AddAMoverController : ApiController
    {
        private TruckCompanyContext _Context;
        
        public AddAMoverController()
        {
            _Context = new TruckCompanyContext();
        }


        // Ajax POST
        [HttpPost]
        public IHttpActionResult AddMover(MoverDTO dto)
        {
            if(dto.CrewName == "" ||   dto.FirstName == "" || dto.LastName == "")
            {
                return BadRequest("Invalid Model.");
            }
            else
            {
                Crew crew = _Context.Crews.Where(x => x.CrewName == dto.CrewName).First<Crew>();

                if( crew == null){
                    return BadRequest("No such crew exist.");
                }

                Movers mover = new Movers {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Crews = new List<Crew>()
                };
                mover.Crews.Add(crew);
                _Context.Movers.Add(mover);
                _Context.SaveChanges();
            }

            
            return Ok();
        }
    }
}
