namespace Shelterly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageUrlToAnimal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "ImageUrl");
        }
    }
}
