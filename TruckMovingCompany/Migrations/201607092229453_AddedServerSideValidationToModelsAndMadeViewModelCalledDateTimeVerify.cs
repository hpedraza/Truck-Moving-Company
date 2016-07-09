namespace TruckMovingCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedServerSideValidationToModelsAndMadeViewModelCalledDateTimeVerify : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movers", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Movers", "LastName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Moves", "NameOfMove", c => c.String(maxLength: 50));
            AlterColumn("dbo.Moves", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Trucks", "TruckName", c => c.String(nullable: false, maxLength: 26));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trucks", "TruckName", c => c.String(nullable: false));
            AlterColumn("dbo.Moves", "Address", c => c.String());
            AlterColumn("dbo.Moves", "NameOfMove", c => c.String());
            AlterColumn("dbo.Movers", "LastName", c => c.String());
            AlterColumn("dbo.Movers", "FirstName", c => c.String());
        }
    }
}
