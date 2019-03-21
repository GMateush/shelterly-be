namespace Shelterly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDescriptionToRaceAndShelter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "Description", c => c.String(maxLength: 255));
            AddColumn("dbo.Shelters", "Description", c => c.String(maxLength: 255));
            AlterColumn("dbo.Shelters", "ShelterName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Shelters", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shelters", "Address", c => c.String());
            AlterColumn("dbo.Shelters", "ShelterName", c => c.String());
            DropColumn("dbo.Shelters", "Description");
            DropColumn("dbo.Animals", "Description");
        }
    }
}
