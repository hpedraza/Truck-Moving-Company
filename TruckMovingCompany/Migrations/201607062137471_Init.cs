namespace TruckMovingCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Crews",
                c => new
                    {
                        CrewId = c.Int(nullable: false, identity: true),
                        CrewName = c.String(nullable: false),
                        TruckId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CrewId);
            
            CreateTable(
                "dbo.Movers",
                c => new
                    {
                        MoversId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.MoversId);
            
            CreateTable(
                "dbo.Moves",
                c => new
                    {
                        MoveId = c.Int(nullable: false, identity: true),
                        NameOfMove = c.String(),
                        TimeOfMove = c.DateTime(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.MoveId);
            
            CreateTable(
                "dbo.Trucks",
                c => new
                    {
                        TruckId = c.Int(nullable: false, identity: true),
                        TruckName = c.String(nullable: false),
                        LastMoveDateTime = c.DateTime(nullable: false),
                        CrewId = c.Int(nullable: false),
                        MoveId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TruckId)
                .ForeignKey("dbo.Moves", t => t.MoveId, cascadeDelete: true)
                .Index(t => t.MoveId);
            
            CreateTable(
                "dbo.MoversCrews",
                c => new
                    {
                        Movers_MoversId = c.Int(nullable: false),
                        Crew_CrewId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movers_MoversId, t.Crew_CrewId })
                .ForeignKey("dbo.Movers", t => t.Movers_MoversId, cascadeDelete: true)
                .ForeignKey("dbo.Crews", t => t.Crew_CrewId, cascadeDelete: true)
                .Index(t => t.Movers_MoversId)
                .Index(t => t.Crew_CrewId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trucks", "MoveId", "dbo.Moves");
            DropForeignKey("dbo.MoversCrews", "Crew_CrewId", "dbo.Crews");
            DropForeignKey("dbo.MoversCrews", "Movers_MoversId", "dbo.Movers");
            DropIndex("dbo.MoversCrews", new[] { "Crew_CrewId" });
            DropIndex("dbo.MoversCrews", new[] { "Movers_MoversId" });
            DropIndex("dbo.Trucks", new[] { "MoveId" });
            DropTable("dbo.MoversCrews");
            DropTable("dbo.Trucks");
            DropTable("dbo.Moves");
            DropTable("dbo.Movers");
            DropTable("dbo.Crews");
        }
    }
}
