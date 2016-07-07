namespace TruckMovingCompany.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<TruckMovingCompany.DataModel.TruckCompanyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TruckMovingCompany.DataModel.TruckCompanyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var Truck1 = new Truck { LastMoveDateTime = new DateTime(2008, 11, 21), TruckName = "The Truck" };
            var Truck2 = new Truck { LastMoveDateTime = new DateTime(2010, 08, 20), TruckName = "Monster" };
            var Truck3 = new Truck { LastMoveDateTime = new DateTime(2011, 05, 2), TruckName = "Zipper" };
            var Truck4 = new Truck { LastMoveDateTime = new DateTime(2012, 02, 23), TruckName = "The Machine" };
            var Truck5 = new Truck { LastMoveDateTime = new DateTime(2013, 06, 05), TruckName = "Trash Picker" };
            var Truck6 = new Truck { LastMoveDateTime = new DateTime(2014, 12, 25), TruckName = "House Helper" };


            var Crew1 = new Crew { CrewName = "The Crew" , Movers = new HashSet<Movers>()};
            var Crew2 = new Crew { CrewName = "Weekend Warriors", Movers = new HashSet<Movers>() };
            var Crew3 = new Crew { CrewName = "The Greatest", Movers = new HashSet<Movers>() };
            var Crew4 = new Crew { CrewName = "The Crew II", Movers = new HashSet<Movers>() };
            var Crew5 = new Crew { CrewName = "We Do It Best Crew", Movers = new HashSet<Movers>() };
            var Crew6 = new Crew { CrewName = "The Great", Movers = new HashSet<Movers>() };
            var Crew7 = new Crew { CrewName = "Warriors", Movers = new HashSet<Movers>() };
            var Crew8 = new Crew { CrewName = "The Cowboys", Movers = new HashSet<Movers>() };
            var Crew9 = new Crew { CrewName = "Party Boys", Movers = new HashSet<Movers>() };
            var Crew10 = new Crew { CrewName = "The Gamer Dudes", Movers = new HashSet<Movers>() };
            var Crew11 = new Crew { CrewName = "We Like To Code", Movers = new HashSet<Movers>() };
            var Crew12 = new Crew { CrewName = "The Junior Crew", Movers = new HashSet<Movers>() };
            var Crew13 = new Crew { CrewName = "The Senior Crew", Movers = new HashSet<Movers>() };
            var Crew14 = new Crew { CrewName = "We Do Like To Work", Movers = new HashSet<Movers>() };
            var Crew15 = new Crew { CrewName = "The Greatest II", Movers = new HashSet<Movers>() };

            var Mover1 = new Movers { FirstName = "George", LastName = "Lopez", Crews = new List<Crew>() };
            var Mover2 = new Movers { FirstName = "Francis", LastName = "Ramirez", Crews = new List<Crew>() };
            var Mover3 = new Movers { FirstName = "Angela", LastName = "Maritenez", Crews = new List<Crew>() };
            var Mover4 = new Movers { FirstName = "Joe", LastName = "Smith", Crews = new List<Crew>() };
            var Mover5 = new Movers { FirstName = "Allen", LastName = "West", Crews = new List<Crew>() };
            var Mover6 = new Movers { FirstName = "Justin", LastName = "Wong", Crews = new List<Crew>() };
            var Mover7= new Movers { FirstName = "Ray", LastName = "Jones", Crews = new List<Crew>() };
            var Mover8= new Movers { FirstName = "Aaron", LastName = "Collins", Crews = new List<Crew>() };
            var Mover9 = new Movers { FirstName = "Emily", LastName = "Chan", Crews = new List<Crew>() };

            Mover1.Crews.Add(Crew1);
            Mover1.Crews.Add(Crew2);
            Mover1.Crews.Add(Crew9);
            Crew1.Movers.Add(Mover1);
            Crew2.Movers.Add(Mover1);
            Crew9.Movers.Add(Mover1);

            
            Mover2.Crews.Add(Crew2);
            Mover2.Crews.Add(Crew3);
            Mover2.Crews.Add(Crew15);
            Crew2.Movers.Add(Mover2);
            Crew3.Movers.Add(Mover2);
            Crew15.Movers.Add(Mover2);

            Mover3.Crews.Add(Crew1);
            Mover3.Crews.Add(Crew3);
            Crew1.Movers.Add(Mover3);
            Crew3.Movers.Add(Mover3);



            Mover4.Crews.Add(Crew1);
            Mover4.Crews.Add(Crew2);
            Mover4.Crews.Add(Crew3);
            Crew1.Movers.Add(Mover4);
            Crew3.Movers.Add(Mover4);
            Crew2.Movers.Add(Mover4);

            Mover5.Crews.Add(Crew1);
            Mover6.Crews.Add(Crew2);
            Mover6.Crews.Add(Crew7);
            Crew1.Movers.Add(Mover5);
            Crew2.Movers.Add(Mover6);
            Crew7.Movers.Add(Mover6);


            Mover7.Crews.Add(Crew4);
            Crew4.Movers.Add(Mover7);
            Mover7.Crews.Add(Crew9);
            Crew9.Movers.Add(Mover7);
            Mover7.Crews.Add(Crew1);
            Crew1.Movers.Add(Mover7);
            Mover7.Crews.Add(Crew2);
            Crew2.Movers.Add(Mover7);




            Mover8.Crews.Add(Crew9);
            Crew9.Movers.Add(Mover8);
            Mover8.Crews.Add(Crew5);
            Crew5.Movers.Add(Mover8);

            Mover9.Crews.Add(Crew13);
            Crew13.Movers.Add(Mover9);

            context.Movers.AddOrUpdate<Movers>(x => x.MoversId, Mover1);
            context.Movers.AddOrUpdate<Movers>(x => x.MoversId, Mover2);
            context.Movers.AddOrUpdate<Movers>(x => x.MoversId, Mover3);
            context.Movers.AddOrUpdate<Movers>(x => x.MoversId, Mover4);
            context.Movers.AddOrUpdate<Movers>(x => x.MoversId, Mover5);
            context.Movers.AddOrUpdate<Movers>(x => x.MoversId, Mover6);
            context.Movers.AddOrUpdate<Movers>(x => x.MoversId, Mover7);
            context.Movers.AddOrUpdate<Movers>(x => x.MoversId, Mover8);
            context.Movers.AddOrUpdate<Movers>(x => x.MoversId, Mover9);
            context.SaveChanges();

            context.Crews.AddOrUpdate<Crew>(x => x.CrewName, Crew1);
            context.Crews.AddOrUpdate<Crew>(x => x.CrewName, Crew2);
            context.Crews.AddOrUpdate<Crew>(x => x.CrewName, Crew3);
            context.Crews.AddOrUpdate<Crew>(x => x.CrewName, Crew4);
            context.Crews.AddOrUpdate<Crew>(x => x.CrewName, Crew5);
            context.Crews.AddOrUpdate<Crew>(x => x.CrewName, Crew6);
            context.Crews.AddOrUpdate<Crew>(x => x.CrewName, Crew7);
            context.Crews.AddOrUpdate<Crew>(x => x.CrewName, Crew8);
            context.Crews.AddOrUpdate<Crew>(x => x.CrewName, Crew9);
            context.Crews.AddOrUpdate<Crew>(x => x.CrewName, Crew10);
            context.Crews.AddOrUpdate<Crew>(x => x.CrewName, Crew11);
            context.Crews.AddOrUpdate<Crew>(x => x.CrewName, Crew12);
            context.Crews.AddOrUpdate<Crew>(x => x.CrewName, Crew13);
            context.Crews.AddOrUpdate<Crew>(x => x.CrewName, Crew14);
            context.Crews.AddOrUpdate<Crew>(x => x.CrewName, Crew15);
            context.SaveChanges();

            Truck1.CrewId = Crew1.CrewId;
           // Crew1.TruckId = Truck1.TruckId;

            Truck2.CrewId = Crew3.CrewId;
            //Crew3.TruckId = Truck2.TruckId;

            Truck3.CrewId = Crew2.CrewId;
            //Crew2.TruckId = Truck3.TruckId;

            Truck4.CrewId = Crew4.CrewId;
           // Crew4.TruckId = Truck4.TruckId;

            Truck5.CrewId = Crew9.CrewId;
           // Crew9.TruckId = Truck5.TruckId;

            Truck6.CrewId = Crew13.CrewId;
            //Crew13.TruckId = Truck6.TruckId;


            var Move1 = new Move { Address = "1111 E. 10th St.", NameOfMove = "House Movement at New Mexico", TimeOfMove = new DateTime(2010, 08, 20) , Trucks = new HashSet<Truck>()};
            var Move2 = new Move { Address = "5648 E. 12th St.", NameOfMove = "Warehouse Movement at Texas", TimeOfMove = new DateTime(2012, 05, 20), Trucks = new HashSet<Truck>() };
            var Move3 = new Move { Address = "313 E. 15th St.", NameOfMove = "Apartment Movement at New Mexico", TimeOfMove = new DateTime(2014, 08, 20), Trucks = new HashSet<Truck>() };
            var Move4 = new Move { Address = "511 E. 8th St.", NameOfMove = "Dell Movement at Texas", TimeOfMove = new DateTime(2010, 08, 20), Trucks = new HashSet<Truck>() };
            var Move5 = new Move { Address = "100 E. 6th St.", NameOfMove = "Home Depot Shipment", TimeOfMove = new DateTime(2012, 08, 20), Trucks = new HashSet<Truck>() };
            var Move6 = new Move { Address = "912 E. 10th Rd.", NameOfMove = "La Costa Mesa Movement", TimeOfMove = new DateTime(2013, 08, 20), Trucks = new HashSet<Truck>() };

            Move1.Trucks.Add(Truck1);
            Move1.Trucks.Add(Truck2);

            Move2.Trucks.Add(Truck3);
            Move2.Trucks.Add(Truck4);

            Move3.Trucks.Add(Truck5);
            Move3.Trucks.Add(Truck6);

            Move4.Trucks.Add(Truck1);
            Move5.Trucks.Add(Truck2);

            Move6.Trucks.Add(Truck1);



            context.Trucks.AddOrUpdate<Truck>(x=>x.TruckName , Truck1);
            context.Trucks.AddOrUpdate<Truck>(x => x.TruckName, Truck2);
            context.Trucks.AddOrUpdate<Truck>(x => x.TruckName, Truck3);
            context.Trucks.AddOrUpdate<Truck>(x => x.TruckName, Truck4);
            context.Trucks.AddOrUpdate<Truck>(x => x.TruckName, Truck5);
            context.Trucks.AddOrUpdate<Truck>(x => x.TruckName, Truck6);

            context.Moves.AddOrUpdate<Move>(x=> x.NameOfMove , Move1);
            context.Moves.AddOrUpdate<Move>(x => x.NameOfMove, Move2);
            context.Moves.AddOrUpdate<Move>(x => x.NameOfMove, Move3);
            context.Moves.AddOrUpdate<Move>(x => x.NameOfMove, Move4);
            context.Moves.AddOrUpdate<Move>(x => x.NameOfMove, Move5);
            context.Moves.AddOrUpdate<Move>(x => x.NameOfMove, Move6);
            context.SaveChanges();

        }
    }
}
