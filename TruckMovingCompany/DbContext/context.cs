
using System.Data.Entity;
using TruckMovingCompany.Models;

namespace TruckMovingCompany.DataModel
{
    public class TruckCompanyContext : DbContext
    {
        public DbSet<Movers> Movers { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Move> Moves { get; set; }


        public static TruckCompanyContext Create()
        {
            return new TruckCompanyContext();
        }
    }
}