using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TruckMovingCompany.DataModel;
using System.Linq;
using TruckMovingCompany.ViewModels;
namespace TruckMovingCompany.Models
{
    public class Movers
    {
        // Would use unsigned byte (tinyint in SQL SERVER), but EF was giving errors: 
        // was not auto incrementing id. (assuming we will always have less than 255 movers in database
        public int MoversId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public IList<Crew> Crews { get; set; }

        public Movers()
        {
            Crews = new List<Crew>();
        }

        public Movers(string firstName , string lastName , Crew crew)
        {
            FirstName = firstName;
            LastName = lastName;
            Crews = new List<Crew>{ crew };
        }

        public void UpdateName(EditMoverViewModel vm)
        {
            FirstName = vm.FirstName;
            LastName = vm.LastName;
        }

        public ResultEnum.Result AddToCrew(Crew Crew)
        {
            if(!Crews.Any(c => c == Crew))
            {
                Crews.Add(Crew);
                return ResultEnum.Result.Success;
            }

            return ResultEnum.Result.Failed;

        }

        public ResultEnum.Result RemoveFromCrew(Crew Crew)
        {
            if (Crews.Any(c => c == Crew))
            {
                Crews.Remove(Crew);
                return ResultEnum.Result.Success;
            }

            return ResultEnum.Result.Failed;

        }

    }






}