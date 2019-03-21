namespace Shelterly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removedstringlengthfromdescription : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animals", "Description", c => c.String());
            AlterColumn("dbo.Shelters", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shelters", "Description", c => c.String(maxLength: 255));
            AlterColumn("dbo.Animals", "Description", c => c.String(maxLength: 255));
        }
    }
}
