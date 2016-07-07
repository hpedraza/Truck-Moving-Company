namespace TruckMovingCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedCrewModelRemovedTruckId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Crews", "TruckId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Crews", "TruckId", c => c.Int(nullable: false));
        }
    }
}
