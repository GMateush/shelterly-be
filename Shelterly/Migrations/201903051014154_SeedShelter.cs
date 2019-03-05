namespace Shelterly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedShelter : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            SET IDENTITY_INSERT [dbo].[Shelters] ON
            INSERT INTO [dbo].[Shelters] ([Id], [ShelterName], [Address], [Capacity]) VALUES (1, N'Schronisko Wroc�aw', N'Wroc�aw', 30)
            SET IDENTITY_INSERT [dbo].[Shelters] OFF
            ");
        }
        
        public override void Down()
        {
        }
    }
}
