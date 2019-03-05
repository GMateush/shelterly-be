namespace Shelterly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedRace : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT [dbo].[Races] ON
                INSERT INTO [dbo].[Races] ([Id], [RaceName]) VALUES (1, N'Dog')
                INSERT INTO [dbo].[Races] ([Id], [RaceName]) VALUES (2, N'Cat')
                INSERT INTO [dbo].[Races] ([Id], [RaceName]) VALUES (3, N'Rabbit')
                INSERT INTO [dbo].[Races] ([Id], [RaceName]) VALUES (4, N'Hamster')
                SET IDENTITY_INSERT [dbo].[Races] OFF
                ");
        }
        
        public override void Down()
        {
        }
    }
}
