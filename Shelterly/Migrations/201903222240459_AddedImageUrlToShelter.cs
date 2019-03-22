namespace Shelterly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageUrlToShelter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shelters", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shelters", "ImageUrl");
        }
    }
}
